﻿using Draw.Entities.Concrete.Commands;
using Draw.Entities.Concrete.Draw;
using Draw.Entities.Concrete.Elements;
using Draw.Entities.Concrete.Helpers;
using Draw.Entities.Concrete.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Draw.DataAccess.Concrete.EntityFramework.Context
{
    
    public class DrawContext : DbContext
    {
        

        public DbSet<User>? Users { get; set; }
        public DbSet<DrawBox>? Draws { get; set; }
        public DbSet<DrawCommand>? Commands { get; set; }
        public DbSet<Layer>? Layers { get; set; }
        public DbSet<Element>? Elements { get; set; }
        public DbSet<Point>? Points { get; set; }
        public DbSet<PenStyle>? PenStyles { get; set; }
        public DbSet<Color>? Colors { get; set; }
        public DbSet<PointType>? PointTypes { get; set; }
        public DbSet<ElementType>? ElementTypes { get; set; }
        public DbSet<SSAngle>? SSAngles { get; set; }
        public DbSet<Radius>? Radiuses { get; set; }
        public DbSet<Pen>? Pens { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new DrawMapping());
            modelBuilder.ApplyConfiguration(new DrawCommandMapping());
            modelBuilder.ApplyConfiguration(new LayerMapping());
            modelBuilder.ApplyConfiguration(new ElementMapping());
            modelBuilder.ApplyConfiguration(new PointMapping());
            modelBuilder.ApplyConfiguration(new PenStyleMapping());
            modelBuilder.ApplyConfiguration(new ColorMapping());
            modelBuilder.ApplyConfiguration(new PointTypeMapping());
            modelBuilder.ApplyConfiguration(new ElementTypeMapping());
            modelBuilder.ApplyConfiguration(new PenMapping());
            modelBuilder.ApplyConfiguration(new RadiusMapping());
            modelBuilder.ApplyConfiguration(new SSAngleMapping());

        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var dbHost=Environment.GetEnvironmentVariable("dbHost");
                var dbName=Environment.GetEnvironmentVariable("dbName");
                var dbPassword=Environment.GetEnvironmentVariable("dbPassword");
                var dbPort=Environment.GetEnvironmentVariable("dbPort");
                //var cnn=$"server={dbHost};port={dbPort};database={dbName};user=root;password={dbPassword};";
                //optionsBuilder.UseMySql(cnn,ServerVersion.AutoDetect(cnn));
                var cnn2= $"server=127.0.0.1;port=3306;database=drawdb;user=root;password=123456;";
                optionsBuilder.UseMySql(cnn2,ServerVersion.AutoDetect(cnn2));
                // var environmentName =Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                // if(environmentName=="Development")
                // {
                //     var cnn=$"server=localhost;port=3306;database=drawdb;user=root;password=mysql123.;";
                //     optionsBuilder.UseMySql(cnn,ServerVersion.AutoDetect(cnn));
                // }
                // else
                // {
                //     var dbHost=Environment.GetEnvironmentVariable("dbHost");
                //     var dbName=Environment.GetEnvironmentVariable("dbName");
                //     var dbPassword=Environment.GetEnvironmentVariable("dbPassword");
                //     var cnn=$"server={dbHost};port=3306;database={dbName};user=root;password={dbPassword};";
                //     optionsBuilder.UseMySql(cnn,ServerVersion.AutoDetect(cnn));
                // }
            
                
            }
        }
    }
}