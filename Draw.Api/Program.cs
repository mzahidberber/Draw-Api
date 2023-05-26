

using Draw.Api.Configuration;
using Draw.Api.Extensions;
using Draw.Api.Validation;
using Draw.DataAccess.Concrete.EntityFramework;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NLog.Web;
using System.Configuration;
using System.Text.Json.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Logging.ClearProviders();
        //builder.Logging.AddConsole();
        builder.Host.UseNLog();


        

        //var dbHost = Environment.GetEnvironmentVariable("dbHost");
        //var dbName = Environment.GetEnvironmentVariable("dbName");
        //var dbPassword = Environment.GetEnvironmentVariable("dbPassword");
        //var dbPort = Environment.GetEnvironmentVariable("dbPort");

        //builder.Services.AddDbContext<DrawContext>(options =>
        //{
        //    var connectionString = $"server={dbHost};port={dbPort};database={dbName};User Id=root;password={dbPassword};";
        //    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        //    //    , sqlOptions =>
        //    //{
        //    //    sqlOptions.MigrationsAssembly("AuthServer.DataAccess");
        //    //});
        //});


        

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

        // Add services to the container.

        // using(DrawContext context=new DrawContext())
        // {
        //     context.Database.EnsureCreated();
        //     context.Database.Migrate();
        // }

        builder.Services.AddControllersWithViews()
                .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


        builder.Services.AddControllers();

        builder.Services.AddValidatorsFromAssemblyContaining<LayerRequestValidation>();

        builder.Services.UseCustomValidationResponse();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        
        var app = builder.Build();

        

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCustomException();

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();

        
    }
}