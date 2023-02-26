using Draw.Entities.Concrete.Commands;
using Draw.Entities.Concrete.Draw;
using Draw.Entities.Concrete.Elements;
using Draw.Entities.Concrete.Helpers;
using Draw.Entities.Concrete.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Draw.DataAccess.Concrete.EntityFramework.Context
{
    internal class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);

            builder.Property(u => u.UserName).IsRequired().HasMaxLength(200);

            builder.Property(u => u.UserPassword).IsRequired().HasMaxLength(200);

            builder.HasData(
                new User { UserId = 1, UserName = "zahid", UserPassword = "123456" },
                new User { UserId = 2, UserName = "ali", UserPassword = "123456" },
                new User { UserId = 3, UserName = "zeynep", UserPassword = "123456" }

                );

        }
    }

    internal class DrawMapping : IEntityTypeConfiguration<DrawBox>
    {
        public void Configure(EntityTypeBuilder<DrawBox> builder)
        {
            builder.HasKey(u => u.DrawBoxId);

            builder.Property(u => u.DrawBoxId);

            builder.Property(u => u.DrawName).IsRequired().HasMaxLength(200);

            builder.HasData(
                new DrawBox { DrawBoxId = 1, DrawName = "c1", UserId = 1 },
                new DrawBox { DrawBoxId = 2, DrawName = "c2", UserId = 1 },
                new DrawBox { DrawBoxId = 3, DrawName = "c1", UserId = 2 }
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
            builder.HasKey(u => u.DrawCommandId);

            builder.Property(u => u.DrawCommandName);

            builder.HasData(
                new DrawCommand { DrawCommandId = 1, DrawCommandName = "dc1", DrawCommandDrawBoxId = 1 },
                new DrawCommand { DrawCommandId = 2, DrawCommandName = "dc2", DrawCommandDrawBoxId = 1 },
                new DrawCommand { DrawCommandId = 3, DrawCommandName = "dc3", DrawCommandDrawBoxId = 1 }
            );

            builder.HasOne(d => d.DrawCommandDrawBox)
                .WithMany(u => u.DrawCommands)
                .HasForeignKey(d => d.DrawCommandDrawBoxId);

        }
    }

    internal class LayerMapping : IEntityTypeConfiguration<Layer>
    {
        public void Configure(EntityTypeBuilder<Layer> builder)
        {
            builder.HasKey(u => u.LayerId);

            builder.Property(u => u.LayerName).IsRequired().HasMaxLength(200);
            builder.HasIndex(u => u.LayerName).IsUnique();

            builder.Property(u => u.LayerLock).IsRequired();

            builder.Property(u => u.LayerVisibility).IsRequired();

            builder.Property(l => l.LayerThickness).IsRequired();

            builder.HasData(
                new Layer { LayerId = 1, LayerName = "0", LayerLock = false, LayerVisibility = false, LayerThickness = 1, DrawBoxId = 1 ,PenId=1},
                new Layer { LayerId = 2, LayerName = "a", LayerLock = false, LayerVisibility = false, LayerThickness = 1, DrawBoxId = 1 ,PenId=2},
                new Layer { LayerId = 3, LayerName = "b", LayerLock = false, LayerVisibility = false, LayerThickness = 1, DrawBoxId = 1 , PenId = 1 }

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
            builder.HasKey(u => u.ElementId);

            builder.Property(u => u.ElementTypeId).IsRequired().HasMaxLength(200);
            //builder.HasIndex(u => u.ElementType).IsUnique();

            builder.HasData(
                new Element { ElementId = 1, ElementTypeId = 1, PenId = 1, LayerId = 1 },
                new Element { ElementId = 2, ElementTypeId = 1, PenId = 1, LayerId = 1 },
                new Element { ElementId = 3, ElementTypeId = 1, PenId = 1, LayerId = 1 },
                new Element { ElementId = 4, ElementTypeId = 5, PenId = 1, LayerId = 1 },
                new Element { ElementId = 5, ElementTypeId = 4, PenId = 1, LayerId = 1 }


            );

            builder.HasOne(d => d.Layer)
                .WithMany(u => u.Elements)
                .HasForeignKey(d => d.LayerId);

            builder.HasOne(e => e.Pen)
                .WithMany(p => p.Elements)
                .HasForeignKey(e => e.PenId);

            builder.HasOne(e => e.ElementType)
                .WithMany(p => p.Elements)
                .HasForeignKey(e => e.ElementTypeId);

        }
    }

    internal class PointMapping : IEntityTypeConfiguration<Point>
    {
        public void Configure(EntityTypeBuilder<Point> builder)
        {
            builder.HasKey(u => u.PointId);

            builder.Property(u => u.PointTypeId).IsRequired();

            builder.Property(u => u.PointX).IsRequired();

            builder.Property(u => u.PointY).IsRequired();

            builder.HasData(
                new Point { PointId = 1, PointTypeId = 1, PointX = 10, PointY = 8, ElementId = 1 },
                new Point { PointId = 2, PointTypeId = 1, PointX = 15, PointY = 20, ElementId = 1 },
                new Point { PointId = 3, PointTypeId = 1, PointX = 5, PointY = 10, ElementId = 2 },
                new Point { PointId = 4, PointTypeId = 1, PointX = 9, PointY = 20, ElementId = 2 },
                new Point { PointId = 5, PointTypeId = 1, PointX = 7, PointY = 3, ElementId = 3 },
                new Point { PointId = 6, PointTypeId = 1, PointX = 2, PointY = 1, ElementId = 3 },
                new Point { PointId = 7, PointTypeId = 2, PointX = 0, PointY = 0, ElementId = 4 }


            );

            builder.HasOne(p => p.PointType)
                .WithMany(pt => pt.PointTypePoints)
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
            builder.HasKey(u => u.PenStyleId);

            builder.Property(u => u.PenStyleName).IsRequired();

            builder.HasData(
                new PenStyle { PenStyleId = 1, PenStyleName = "solid" },
                new PenStyle { PenStyleId = 2, PenStyleName = "dot" }


            );


        }
    }

    internal class ColorMapping : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(u => u.ColorId);

            builder.Property(u => u.ColorName).IsRequired();
            builder.Property(u => u.ColorRed).IsRequired();
            builder.Property(u => u.ColorBlue).IsRequired();
            builder.Property(u => u.ColorGreen).IsRequired();

            builder.HasData(
                new Color { ColorId = 1, ColorName = "white", ColorRed = 255, ColorBlue = 255, ColorGreen = 255 },
                new Color { ColorId = 2, ColorName = "red", ColorRed = 211, ColorBlue = 0, ColorGreen = 0 },
                new Color { ColorId = 3, ColorName = "orange", ColorRed = 255, ColorBlue = 127, ColorGreen = 0 },
                new Color { ColorId = 4, ColorName = "blue", ColorRed = 99, ColorBlue = 184, ColorGreen = 255 },
                new Color { ColorId = 5, ColorName = "black", ColorRed = 0, ColorBlue = 0, ColorGreen = 0 },
                new Color { ColorId = 6, ColorName = "gray", ColorRed = 153, ColorBlue = 153, ColorGreen = 153 },
                new Color { ColorId = 7, ColorName = "green", ColorRed = 74, ColorBlue = 128, ColorGreen = 77 }



            );


        }
    }

    internal class PointTypeMapping : IEntityTypeConfiguration<PointType>
    {
        public void Configure(EntityTypeBuilder<PointType> builder)
        {
            builder.HasKey(u => u.PointTypeId);

            builder.Property(u => u.PointTypeName).IsRequired();

            builder.HasData(
                new PointType { PointTypeId = 1, PointTypeName = "end" },
                new PointType { PointTypeId = 2, PointTypeName = "center" },
                new PointType { PointTypeId = 3, PointTypeName = "middle" }
                );


        }
    }

    internal class ElementTypeMapping : IEntityTypeConfiguration<ElementType>
    {
        public void Configure(EntityTypeBuilder<ElementType> builder)
        {
            builder.HasKey(u => u.ElementTypeId);

            builder.Property(u => u.ElementTypeName).IsRequired();

            builder.HasData(
                new ElementType { ElementTypeId = 1, ElementTypeName = "line" },
                new ElementType { ElementTypeId = 2, ElementTypeName = "circle" },
                new ElementType { ElementTypeId = 3, ElementTypeName = "rectangle" },
                new ElementType { ElementTypeId = 4, ElementTypeName = "arc" },
                new ElementType { ElementTypeId = 5, ElementTypeName = "ellips" },
                new ElementType { ElementTypeId = 6, ElementTypeName = "spline" }
                );


        }
    }
    internal class PenMapping : IEntityTypeConfiguration<Pen>
    {
        public void Configure(EntityTypeBuilder<Pen> builder)
        {
            builder.HasKey(u => u.PenId);

            builder.Property(u => u.PenName).IsRequired();

            builder.HasData(
                new Pen { PenId = 1,PenName = "pen1", PenColorId = 1, PenStyleId = 1 },
                new Pen { PenId = 2, PenName = "pen2", PenColorId = 2, PenStyleId = 2 }
                );

            builder.HasOne(c => c.PenColor).WithMany(p => p.Pens).HasForeignKey(c => c.PenId);
            
            builder.HasOne(c => c.PenStyle).WithMany(p => p.Pens).HasForeignKey(c => c.PenId);


        }
    }

    internal class RadiusMapping : IEntityTypeConfiguration<Radius>
    {
        public void Configure(EntityTypeBuilder<Radius> builder)
        {
            builder.HasKey(u => u.RadiusId);


            builder.HasData(
                new Radius { RadiusId = 1,RadiusValue=10 ,RadiusElementId=4},
                new Radius { RadiusId = 2,RadiusValue=15,RadiusElementId=4}
                );

            builder.HasOne(d => d.RadiusElement)
                .WithMany(u => u.Radiuses)
                .HasForeignKey(d => d.RadiusElementId);
        }
    }

    internal class SSAngleMapping : IEntityTypeConfiguration<SSAngle>
    {
        public void Configure(EntityTypeBuilder<SSAngle> builder)
        {
            builder.HasKey(u => u.SSAngleId);

            builder.Property(u => u.SSAngleType).IsRequired();

            builder.HasData(
                new SSAngle { SSAngleId = 1, SSAngleType = "start", SSAngleValue = 0,SSAngleElementId =1},
                new SSAngle { SSAngleId = 2, SSAngleType = "stop",SSAngleValue=30 ,SSAngleElementId =1}
                );

            builder.HasOne(d => d.SSAngleElement)
                .WithMany(u => u.SSAngles)
                .HasForeignKey(d => d.SSAngleElementId);
        }
    }
}