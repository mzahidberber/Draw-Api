using Draw.Entities.Concrete.Draw;
using Draw.Entities.Concrete.Web;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ninject.Activation;
using System.Configuration;

namespace Draw.DataAccess.Concrete.EntityFramework
{

    public class DrawContext : IdentityDbContext<User, UserRole, string>
    {

        public DrawContext()
        {
        }
        //public DrawContext(DbContextOptions<DrawContext> opt) : base(opt)
        //{
        //}



        public DbSet<DrawBox>? Draws { get; set; }
        public DbSet<Layer>? Layers { get; set; }
        public DbSet<Element>? Elements { get; set; }
        public DbSet<Point>? Points { get; set; }
        public DbSet<PenStyle>? PenStyles { get; set; }
        public DbSet<PointType>? PointTypes { get; set; }
        public DbSet<ElementType>? ElementTypes { get; set; }
        public DbSet<SSAngle>? SSAngles { get; set; }
        public DbSet<Radius>? Radiuses { get; set; }
        public DbSet<Pen>? Pens { get; set; }
        public DbSet<UserRefreshToken>? UserRefreshTokens { get; set; }
        public DbSet<MainTitle> MainTitles { get; set; }
        public DbSet<BaseTitle> Titles { get; set; }
        public DbSet<SubTitle> SubTitles { get; set; }
        public DbSet<Numbers> Numbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRefreshTokenConfiguration());
            modelBuilder.ApplyConfiguration(new DrawMapping());
            modelBuilder.ApplyConfiguration(new LayerMapping());
            modelBuilder.ApplyConfiguration(new ElementMapping());
            modelBuilder.ApplyConfiguration(new PointMapping());
            modelBuilder.ApplyConfiguration(new PenStyleMapping());
            modelBuilder.ApplyConfiguration(new PointTypeMapping());
            modelBuilder.ApplyConfiguration(new ElementTypeMapping());
            modelBuilder.ApplyConfiguration(new PenMapping());
            modelBuilder.ApplyConfiguration(new RadiusMapping());
            modelBuilder.ApplyConfiguration(new SSAngleMapping());
            modelBuilder.ApplyConfiguration(new MainTitleMapping());
            modelBuilder.ApplyConfiguration(new BaseTitleMapping());
            modelBuilder.ApplyConfiguration(new SubTitleMapping());
            modelBuilder.ApplyConfiguration(new NumbersMapping());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            var dbHost = Environment.GetEnvironmentVariable("dbHost");
            var dbName = Environment.GetEnvironmentVariable("dbName");
            var dbPassword = Environment.GetEnvironmentVariable("dbPassword");
            var dbPort = Environment.GetEnvironmentVariable("dbPort");
            //var cnstr = $"server={dbHost};port={dbPort};database={dbName};User Id=root;password={dbPassword};";
            var cnstr = $"server=localhost;port=3306;database=drawdb5;User Id=root;password=mysql123.;";
            optionsBuilder.UseMySql(cnstr, ServerVersion.AutoDetect(cnstr));


        }

        public override int SaveChanges()
        {
            var now = DateTime.Now;

            foreach (var changedEntity in ChangeTracker.Entries())
            {
                
                if (changedEntity.Entity is Layer layer)
                {
                    layer.CalculateElements();
                }
                if (changedEntity.Entity is DrawBox drawBox)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Modified:
                            Entry(drawBox).Property(x => x.EditTime).IsModified = false;
                            Entry(drawBox).Property(x => x.CreateTime).IsModified = false;
                            drawBox.EditTime = now;
                            break;
                        case EntityState.Added:
                            drawBox.EditTime = now;
                            drawBox.CreateTime = now;
                            break;
                    }
                    drawBox.CalculateElements();

                }
                
            }
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var now = DateTime.Now;

            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is Layer layer)
                {
                    layer.CalculateElements();
                }

                if (changedEntity.Entity is DrawBox drawBox)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Modified:
                            Entry(drawBox).Property(x => x.EditTime).IsModified = false;
                            Entry(drawBox).Property(x => x.CreateTime).IsModified = false;
                            drawBox.EditTime = now;
                            break;
                        case EntityState.Added:
                            drawBox.EditTime = now;
                            drawBox.CreateTime = now;
                            break;
                    }
                    drawBox.CalculateElements();
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
