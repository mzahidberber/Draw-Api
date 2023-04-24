using Draw.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Draw.DataAccess.Concrete.EntityFramework
{
    internal class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.Code).IsRequired().HasMaxLength(300);
        }
    }

    internal class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(
                new UserRole { Id = Guid.NewGuid().ToString(), Name = "admin", NormalizedName = "ADMIN" },
                new UserRole { Id = Guid.NewGuid().ToString(), Name = "manager", NormalizedName = "MANAGER" },
                new UserRole { Id = Guid.NewGuid().ToString(), Name = "user", NormalizedName = "USER" }

                );
        }
    }
    internal class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasData(
                new User { Id = "b21972e1-742f-4fa7-be46-1189d9cab7ca", UserName = "zahid",Email="zahid11@gmail.com", EmailConfirmed = false, PhoneNumber = "513", PhoneNumberConfirmed = true, TwoFactorEnabled = false, LockoutEnabled = false, AccessFailedCount = 1 },
                new User { Id = "b21972e1-742f-4fa7-be46-1189d9cab7cb", UserName = "ali", Email = "ali@gmail.com", EmailConfirmed = false, PhoneNumber = "513", PhoneNumberConfirmed = true, TwoFactorEnabled = false, LockoutEnabled = false, AccessFailedCount = 1 },
                new User { Id = "b21972e1-742f-4fa7-be46-1189d9cab7cc", UserName = "zeynep", Email = "zeynep@gmail.com", EmailConfirmed = false, PhoneNumber = "513", PhoneNumberConfirmed = true, TwoFactorEnabled = false, LockoutEnabled = false, AccessFailedCount = 1 }

                );

        }
    }

    internal class DrawMapping : IEntityTypeConfiguration<DrawBox>
    {
        public void Configure(EntityTypeBuilder<DrawBox> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id);

            builder.Property(u => u.Name).IsRequired().HasMaxLength(200);

            builder.HasData(
                new DrawBox { Id = 1, Name = "c1", UserId = "b21972e1-742f-4fa7-be46-1189d9cab7ca" },
                new DrawBox { Id = 2, Name = "c2", UserId = "b21972e1-742f-4fa7-be46-1189d9cab7ca" },
                new DrawBox { Id = 3, Name = "c1", UserId = "b21972e1-742f-4fa7-be46-1189d9cab7cb" }
            );

            builder.HasOne(d => d.User)
                .WithMany(u => u.DrawBoxs)
                .HasForeignKey(d => d.UserId);

        }
    }

    internal class DrawCommandMapping : IEntityTypeConfiguration<DrawCommand>
    {
        public void Configure(EntityTypeBuilder<DrawCommand> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name);

            builder.HasData(
                new DrawCommand { Id = 1, Name = "dc1", DrawBoxId = 1 },
                new DrawCommand { Id = 2, Name = "dc2", DrawBoxId = 1 },
                new DrawCommand { Id = 3, Name = "dc3", DrawBoxId = 1 }
            );

            builder.HasOne(d => d.DrawBox)
                .WithMany(u => u.DrawCommands)
                .HasForeignKey(d => d.DrawBoxId);

        }
    }

    internal class LayerMapping : IEntityTypeConfiguration<Layer>
    {
        public void Configure(EntityTypeBuilder<Layer> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name).IsRequired().HasMaxLength(200);
            builder.HasIndex(u => u.Name).IsUnique();

            builder.Property(u => u.Lock).IsRequired();

            builder.Property(u => u.Visibility).IsRequired();

            builder.Property(l => l.Thickness).IsRequired().HasPrecision(3, 1);

            builder.HasData(
                new Layer { Id = 1, Name = "0", Lock = false, Visibility = false, Thickness = 1, DrawBoxId = 1, PenId = 1 },
                new Layer { Id = 2, Name = "a", Lock = false, Visibility = false, Thickness = 1, DrawBoxId = 1, PenId = 2 },
                new Layer { Id = 3, Name = "b", Lock = false, Visibility = false, Thickness = 1, DrawBoxId = 1, PenId = 1 }

            );
            builder.HasOne(l => l.Pen)
                .WithMany(p => p.Layers)
                .HasForeignKey(l => l.PenId);

            builder.HasOne(d => d.DrawBox)
                .WithMany(u => u.Layers)
                .HasForeignKey(d => d.DrawBoxId);

        }
    }

    internal class ElementMapping : IEntityTypeConfiguration<Element>
    {
        public void Configure(EntityTypeBuilder<Element> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.TypeId).IsRequired();

            builder.HasData(
                new Element { Id = 1, TypeId = 1, PenId = 1, LayerId = 1 },
                new Element { Id = 2, TypeId = 1, PenId = 1, LayerId = 1 },
                new Element { Id = 3, TypeId = 1, PenId = 1, LayerId = 1 },
                new Element { Id = 4, TypeId = 5, PenId = 1, LayerId = 1 },
                new Element { Id = 5, TypeId = 4, PenId = 1, LayerId = 1 }


            );

            builder.HasOne(d => d.Layer)
                .WithMany(u => u.Elements)
                .HasForeignKey(d => d.LayerId);

            builder.HasOne(e => e.Pen)
                .WithMany(p => p.Elements)
                .HasForeignKey(e => e.PenId);

            builder.HasOne(e => e.Type)
                .WithMany(p => p.Elements)
                .HasForeignKey(e => e.TypeId);

        }
    }

    internal class PointMapping : IEntityTypeConfiguration<Point>
    {
        public void Configure(EntityTypeBuilder<Point> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.PointTypeId).IsRequired();

            builder.Property(u => u.X).IsRequired().HasPrecision(10,5);

            builder.Property(u => u.Y).IsRequired().HasPrecision(10, 5);

            builder.HasData(
                new Point { Id = 1, PointTypeId = 1, X = 10, Y = 8, ElementId = 1 },
                new Point { Id = 2, PointTypeId = 1, X = 15, Y = 20, ElementId = 1 },
                new Point { Id = 3, PointTypeId = 1, X = 5, Y = 10, ElementId = 2 },
                new Point { Id = 4, PointTypeId = 1, X = 9, Y = 20, ElementId = 2 },
                new Point { Id = 5, PointTypeId = 1, X = 7, Y = 3, ElementId = 3 },
                new Point { Id = 6, PointTypeId = 1, X = 2, Y = 1, ElementId = 3 },
                new Point { Id = 7, PointTypeId = 2, X = 0, Y = 0, ElementId = 4 }


            );

            builder.HasOne(p => p.PointType)
                .WithMany(pt => pt.Points)
                .HasForeignKey(p => p.PointTypeId);

            builder.HasOne(d => d.Element)
                .WithMany(u => u.Points)
                .HasForeignKey(d => d.ElementId);

        }
    }

    internal class PenStyleMapping : IEntityTypeConfiguration<PenStyle>
    {
        public void Configure(EntityTypeBuilder<PenStyle> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name).IsRequired();

            builder.HasData(
                new PenStyle { Id = 1, Name = "solid" },
                new PenStyle { Id = 2, Name = "dot" }


            );


        }
    }

    internal class ColorMapping : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Red).IsRequired();
            builder.Property(u => u.Blue).IsRequired();
            builder.Property(u => u.Green).IsRequired();

            builder.HasData(
                new Color { Id = 1, Name = "white", Red = 255, Blue = 255, Green = 255 },
                new Color { Id = 2, Name = "red", Red = 211, Blue = 0, Green = 0 },
                new Color { Id = 3, Name = "orange", Red = 255, Blue = 127, Green = 0 },
                new Color { Id = 4, Name = "blue", Red = 99, Blue = 184, Green = 255 },
                new Color { Id = 5, Name = "black", Red = 0, Blue = 0, Green = 0 },
                new Color { Id = 6, Name = "gray", Red = 153, Blue = 153, Green = 153 },
                new Color { Id = 7, Name = "green", Red = 74, Blue = 128, Green = 77 }



            );


        }
    }

    internal class PointTypeMapping : IEntityTypeConfiguration<PointType>
    {
        public void Configure(EntityTypeBuilder<PointType> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name).IsRequired();

            builder.HasData(
                new PointType { Id = 1, Name = "end" },
                new PointType { Id = 2, Name = "center" },
                new PointType { Id = 3, Name = "middle" }
                );


        }
    }

    internal class ElementTypeMapping : IEntityTypeConfiguration<ElementType>
    {
        public void Configure(EntityTypeBuilder<ElementType> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name).IsRequired();

            builder.HasData(
                new ElementType { Id = 1, Name = "line" },
                new ElementType { Id = 2, Name = "circle" },
                new ElementType { Id = 3, Name = "rectangle" },
                new ElementType { Id = 4, Name = "arc" },
                new ElementType { Id = 5, Name = "ellips" },
                new ElementType { Id = 6, Name = "spline" }
                );


        }
    }
    internal class PenMapping : IEntityTypeConfiguration<Pen>
    {
        public void Configure(EntityTypeBuilder<Pen> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Blue).IsRequired();
            builder.Property(u => u.Red).IsRequired();
            builder.Property(u => u.Green).IsRequired();

            builder.HasData(
                new Pen { Id = 1, Name = "pen1", PenStyleId = 1 ,Red=10,Green=10,Blue=10,UserId= "b21972e1-742f-4fa7-be46-1189d9cab7ca" },
                new Pen { Id = 2, Name = "pen2", PenStyleId = 2, Red = 10, Green = 10, Blue = 10, UserId = "b21972e1-742f-4fa7-be46-1189d9cab7ca" }
                );

            //builder.HasOne(c => c.PenColor).WithMany(p => p.Pens).HasForeignKey(c => c.PenColorId);

            builder.HasOne(c => c.PenStyle).WithMany(p => p.Pens).HasForeignKey(c => c.PenStyleId);

            builder.HasOne(d => d.User)
                .WithMany(u => u.Pens)
                .HasForeignKey(d => d.UserId);

        }
    }

    internal class RadiusMapping : IEntityTypeConfiguration<Radius>
    {
        public void Configure(EntityTypeBuilder<Radius> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Value).IsRequired().HasPrecision(8, 4);

            builder.HasData(
                new Radius { Id = 1, Value = 10, ElementId = 4 },
                new Radius { Id = 2, Value = 15, ElementId = 4 }
                );

            builder.HasOne(d => d.Element)
                .WithMany(u => u.Radiuses)
                .HasForeignKey(d => d.ElementId);
        }
    }

    internal class SSAngleMapping : IEntityTypeConfiguration<SSAngle>
    {
        public void Configure(EntityTypeBuilder<SSAngle> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Type).IsRequired();
            builder.Property(u => u.Value).IsRequired().HasPrecision(8, 4);

            builder.HasData(
                new SSAngle { Id = 1, Type = "start", Value = 0, ElementId = 1 },
                new SSAngle { Id = 2, Type = "stop", Value = 30, ElementId = 1 }
                );

            builder.HasOne(d => d.Element)
                .WithMany(u => u.SSAngles)
                .HasForeignKey(d => d.ElementId);
        }
    }
}