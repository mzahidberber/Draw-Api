using Draw.Entities.Concrete.Commands;
using Draw.Entities.Concrete.Draw;
using Draw.Entities.Concrete.Elements;
using Draw.Entities.Concrete.Helpers;
using Draw.Entities.Concrete.Users;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Draw.DataAccess.Concrete.EntityFramework.Context
{
    public class DrawContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<DrawBox> Draws { get; set; }
        public DbSet<DrawCommand> Commands { get; set; }
        public DbSet<Layer> Layers { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<PenStyle> PenStyles { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<PointType> PointTypes { get; set; }
        public DbSet<ElementType> ElementTypes { get; set; }
        public DbSet<SSAngle> SSAngles { get; set; }
        public DbSet<Radius> Radiuses { get; set; }
        public DbSet<Pen> Pens { get; set; }

        

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
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "d:\\DrawDB.db" };
            var connectionString = connectionStringBuilder.ToString();
            var sqliteConnection = new SqliteConnection(connectionString);

            var mysqlConnection = "server=localhost;port=3306;database=DrawDB;user=root;password=mysql123.";

            

            optionsBuilder
                //.UseSqlite(sqliteConnection)
                .UseMySql(mysqlConnection, ServerVersion.AutoDetect(mysqlConnection));
        }
    }

}
