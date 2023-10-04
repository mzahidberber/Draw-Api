

using Draw.Api.Configuration;
using Draw.Api.Extensions;
using Draw.Api.Validation;
using Draw.DataAccess.Concrete.EntityFramework;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Ninject.Activation;
using NLog.Web;
using PostSharp.Extensibility;
using System;
using System.Text.Json.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Logging.ClearProviders();
        //builder.Logging.AddConsole();
        builder.Host.UseNLog();



        using (DrawContext context = new DrawContext())
        {
            //context.Database.EnsureCreated();
            var pendingMigrations = context.Database.GetPendingMigrations();
            if (pendingMigrations.Any())
                context.Database.Migrate();
        }

        builder.Services.Configure<CustomTokenOption>(builder.Configuration.GetSection("TokenOption"));
        var tokenOptions = builder.Configuration.GetSection("TokenOption").Get<CustomTokenOption>();
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
        {
            opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            {
                ValidIssuer = tokenOptions.Issuer,
                ValidAudience = tokenOptions.Audience[0],
                IssuerSigningKey = SignService.GetSymmetricSecurityKey(tokenOptions.SecurityKey),

                ValidateIssuerSigningKey = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });


        

        builder.Services.AddControllersWithViews()
                .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


        builder.Services.AddControllers();


        builder.Services.AddValidatorsFromAssemblyContaining<LayerRequestValidation>();

        builder.Services.UseCustomValidationResponse();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme{Reference = new OpenApiReference{
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }},
                    new string[]{}}
            });
        });

        var cors = Environment.GetEnvironmentVariable("cors").Split(";");

        builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
        {
            builder.WithOrigins(cors)
            .AllowAnyHeader()
            .AllowAnyMethod();
        }));


        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCustomException();

        app.UseHttpsRedirection();
        app.UseCors("corsapp");
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();

        
    }
}