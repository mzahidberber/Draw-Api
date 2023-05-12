using Draw.Entities.Abstract;
using Draw.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Draw.DataAccess.Concrete.EntityFramework
{

    public class DrawContext : IdentityDbContext<User, UserRole, string>
    {
        //public DrawContext(DbContextOptions<DrawContext> opt):base(opt)
        //{

        //}

        public DbSet<DrawBox>? Draws { get; set; }
        public DbSet<Layer>? Layers { get; set; }
        public DbSet<Element>? Elements { get; set; }
        public DbSet<Point>? Points { get; set; }
        public DbSet<PenStyle>? PenStyles { get; set; }
        //public DbSet<Color>? Colors { get; set; }
        public DbSet<PointType>? PointTypes { get; set; }
        public DbSet<ElementType>? ElementTypes { get; set; }
        public DbSet<SSAngle>? SSAngles { get; set; }
        public DbSet<Radius>? Radiuses { get; set; }
        public DbSet<Pen>? Pens { get; set; }

        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRefreshTokenConfiguration());
            modelBuilder.ApplyConfiguration(new DrawMapping());
            //modelBuilder.ApplyConfiguration(new DrawCommandMapping());
            modelBuilder.ApplyConfiguration(new LayerMapping());
            modelBuilder.ApplyConfiguration(new ElementMapping());
            modelBuilder.ApplyConfiguration(new PointMapping());
            modelBuilder.ApplyConfiguration(new PenStyleMapping());
            //modelBuilder.ApplyConfiguration(new ColorMapping());
            modelBuilder.ApplyConfiguration(new PointTypeMapping());
            modelBuilder.ApplyConfiguration(new ElementTypeMapping());
            modelBuilder.ApplyConfiguration(new PenMapping());
            modelBuilder.ApplyConfiguration(new RadiusMapping());
            modelBuilder.ApplyConfiguration(new SSAngleMapping());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var cnn2 = $"server=localhost;port=3306;database=drawdb4;user=root;password=mysql123.;";
            optionsBuilder.UseMySql(cnn2, ServerVersion.AutoDetect(cnn2));

            //.LogTo(Console.WriteLine,LogLevel.Information)

            //if (!optionsBuilder.IsConfigured)
            //{
            //    var dbHost=Environment.GetEnvironmentVariable("dbHost");
            //    var dbName=Environment.GetEnvironmentVariable("dbName");
            //    var dbPassword=Environment.GetEnvironmentVariable("dbPassword");
            //    var dbPort=Environment.GetEnvironmentVariable("dbPort");
            //    //var cnn=$"server={dbHost};port={dbPort};database={dbName};user=root;password={dbPassword};";
            //    //optionsBuilder.UseMySql(cnn,ServerVersion.AutoDetect(cnn));
            //    var cnn2= $"server=localhost;port=3306;database=drawdb1;user=root;password=mysql123.;";
            //    optionsBuilder.UseMySql(cnn2,ServerVersion.AutoDetect(cnn2));


            //}
        }

        public override int SaveChanges()
        {
            var now = DateTime.Now;

            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is DrawBox entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Modified:
                            Entry(entity).Property(x => x.EditTime).IsModified = false;
                            Entry(entity).Property(x => x.CreateTime).IsModified = false;
                            entity.EditTime = now;
                            break;
                        case EntityState.Added:
                            entity.EditTime = now;
                            entity.CreateTime = now;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var now = DateTime.Now;

            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is DrawBox entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Modified:
                            Entry(entity).Property(x => x.EditTime).IsModified = false;
                            Entry(entity).Property(x => x.CreateTime).IsModified = false;
                            entity.EditTime = now;
                            break;
                        case EntityState.Added:
                            entity.EditTime = now;
                            entity.CreateTime = now;
                            break;
                    }
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
            
        //    return base.SaveChangesAsync(cancellationToken);
        //}
    }
}
