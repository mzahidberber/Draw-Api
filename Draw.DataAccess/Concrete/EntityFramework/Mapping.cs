using Draw.Entities.Concrete.Draw;
using Draw.Entities.Concrete.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostSharp;
using System.Reflection.Emit;

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
            builder.Property(u=>u.DrawLimit).HasDefaultValue(3);
            builder.Property(u=>u.NumberDraw).HasDefaultValue(0);
            builder.Property(u=>u.DrawRemainder).HasDefaultValue(3);
            builder.Property(u=>u.DrawElements).HasDefaultValue(0);

        }
    }
    internal class NumbersMapping : IEntityTypeConfiguration<Numbers>
    {
        public void Configure(EntityTypeBuilder<Numbers> builder)
        {

            builder.HasData(new Numbers { Id=1, DownloadNumber=0,ClickNumber=0});
        }
    }
    internal class MainTitleMapping : IEntityTypeConfiguration<MainTitle>
    {
        public void Configure(EntityTypeBuilder<MainTitle> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Title).IsRequired().HasMaxLength(200);


            builder.Property(u => u.GifUrl).HasMaxLength(200);
            builder.Property(u => u.LogoUrl).HasMaxLength(200);
            builder.Property(u => u.Header).HasMaxLength(2000);
            builder.Property(u => u.IndexId).IsRequired();

            builder.HasData(
                new MainTitle { Id = 1, IndexId = 0, Title = "DrawCAD" ,TextUrl1= "DrawCAD.html" },
                new MainTitle { Id = 2, IndexId = 0, Title = "File", TextUrl1 = "File.html" },
                new MainTitle { Id = 3, IndexId = 0, Title = "Commands", TextUrl1 = "Commands.html" },
                new MainTitle { Id = 4, IndexId = 0, Title = "Layer", TextUrl1 = "Layer.html", LogoUrl="Layer.png"},
                new MainTitle { Id = 5, IndexId = 0, Title = "Snaps", TextUrl1 = "Snaps.html" },
                new MainTitle { Id = 6, IndexId = 0, Title = "Handles", TextUrl1 = "Handles.html" },
                new MainTitle { Id = 7, IndexId = 0, Title = "Element Information", TextUrl1 = "Element Information.html", LogoUrl="elementInfo.png" },
                new MainTitle { Id = 8, IndexId = 0, Title = "Other", TextUrl1 = "Other.html" },
                new MainTitle { Id = 9, IndexId = 2, Title = "DrawApi", TextUrl1 = "DrawApi.html" },
                new MainTitle { Id = 10, IndexId = 2, Title = "Draw" },
                new MainTitle { Id = 11, IndexId = 2, Title = "DrawBox"},
                new MainTitle { Id = 12, IndexId = 2, Title = "Element  " },
                new MainTitle { Id = 13, IndexId = 2, Title = "ElementType  " },
                new MainTitle { Id = 14, IndexId = 2, Title = "Layer  " },
                new MainTitle { Id = 15, IndexId = 2, Title = "Pen  " },
                new MainTitle { Id = 16, IndexId = 2, Title = "PenStyles  "},
                new MainTitle { Id = 17, IndexId = 2, Title = "Point  " },
                new MainTitle { Id = 18, IndexId = 2, Title = "PointType  "},
                new MainTitle { Id = 19, IndexId = 2, Title = "Radius  " },
                new MainTitle { Id = 20, IndexId = 2, Title = "SSAngle  "},
                new MainTitle { Id = 21, IndexId = 3, TextUrl1 = "DrawGeo.html", Title = "DrawGeo"},
                new MainTitle { Id = 22, IndexId = 3, Title = "Geo"},
                new MainTitle { Id = 23, IndexId = 4, TextUrl1 = "DrawAuth.html", Title = "DrawAuth" },
                new MainTitle { Id = 24, IndexId = 4, Title = "User" },
                new MainTitle { Id = 25, IndexId = 4, Title = "Auth" },
                new MainTitle { Id = 26, IndexId = 1, TextUrl1 = "DrawCAD.html", Title = "DrawCAD" },
                new MainTitle { Id = 27, IndexId = 1, TextUrl1 = "api.html", Title = "Api" },
                new MainTitle { Id = 28, IndexId = 1, TextUrl1 = "client.html", Title = "Client" },
                new MainTitle { Id = 29, IndexId = 1, TextUrl1 = "geo.html", Title = "Geo" },
                new MainTitle { Id = 30, IndexId = 1, TextUrl1 = "auth.html", Title = "Auth" },
                new MainTitle { Id = 31, IndexId = 1, TextUrl1 = "data.html", Title = "Data" }
            );

        }
    }

    internal class BaseTitleMapping : IEntityTypeConfiguration<BaseTitle>
    {
        public void Configure(EntityTypeBuilder<BaseTitle> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Title).IsRequired().HasMaxLength(200);


            builder.Property(u => u.GifUrl).HasMaxLength(200);
            builder.Property(u => u.LogoUrl).HasMaxLength(200);
            builder.Property(u => u.Header).HasMaxLength(2000);
            builder.Property(u => u.IndexId).IsRequired();

            builder.HasOne(bt => bt.MainTitle).WithMany(mt => mt.BaseTitles).HasForeignKey(bt => bt.MainTitleId);


            builder.HasData(
                new BaseTitle { Id = 1,IndexId=0, Title = "Draw Commands", MainTitleId = 3 },
                new BaseTitle { Id = 2,IndexId=0, Title = "Edit Commands", MainTitleId = 3 },
                new BaseTitle { Id = 3,IndexId=0, TextUrl1 = "End Snap.html", LogoUrl= "closeendpoint.png", Title = "End Snap",ShortcutUrl1="f6",GifUrl="endsnap.gif", MainTitleId = 5 },
                new BaseTitle { Id = 4,IndexId=0, TextUrl1 = "Middle Snap.html", LogoUrl = "CloseMidPoint.png", Title = "Middle Snap", ShortcutUrl1 = "f7", GifUrl = "middlesnap.gif", MainTitleId = 5 },
                new BaseTitle { Id = 5,IndexId=0, TextUrl1 = "Center Snap.html", LogoUrl = "CloseCenter.png", Title = "Center Snap", ShortcutUrl1 = "f8", GifUrl = "centersnap.gif", MainTitleId = 5 },
                new BaseTitle { Id = 6,IndexId=0, TextUrl1 = "Nearest Snap.html", LogoUrl = "CloseNearest.png", Title = "Nearest Snap", ShortcutUrl1 = "f9", GifUrl = "nearestsnap.gif", MainTitleId = 5 },
                new BaseTitle { Id = 7,IndexId=0, TextUrl1 = "Intersection Snap.html", LogoUrl = "CloseIntersection.png", Title = "Intersection Snap", ShortcutUrl1 = "f10", GifUrl = "intersectionsnap.gif", MainTitleId = 5 },
                new BaseTitle { Id = 8,IndexId=0, TextUrl1 = "Polar Mode.html", LogoUrl = "ClosePain.png", Title = "Polar Mode", ShortcutUrl1 = "f4", GifUrl = "polarmod.gif", MainTitleId = 5 },
                new BaseTitle { Id = 9,  IndexId = 0, TextUrl1 = "Ortho Mode.html", LogoUrl = "CloseOrtho.png", Title = "Ortho Mode", ShortcutUrl1 = "f3", GifUrl = "orthomod.gif", MainTitleId = 5 },
                new BaseTitle { Id = 10, IndexId = 0, TextUrl1 = "Grid Snap.html", LogoUrl = "CloseGrid.png", Title = "Grid Snap", ShortcutUrl1 = "f5", GifUrl = "gridsnap.gif", MainTitleId = 5 },
                new BaseTitle { Id = 11, IndexId = 0, TextUrl1 = "Line Width.html", LogoUrl = "linewidthBtnClose.png", Title = "Line Width", MainTitleId = 8 },
                new BaseTitle { Id = 12, IndexId = 0, TextUrl1 = "Add.html", LogoUrl = "addBtn.png", Title = "Add", GifUrl = "add.gif", MainTitleId = 2 },
                new BaseTitle { Id = 13, IndexId = 0, TextUrl1 = "Open.html", LogoUrl = "openfile.png", Title = "Open", GifUrl = "open.gif", MainTitleId = 2 },
                new BaseTitle { Id = 14, IndexId = 0, TextUrl1 = "Push.html", LogoUrl = "saveCloud.png", Title = "Push", GifUrl = "push.gif", MainTitleId = 2 },
                new BaseTitle { Id = 15, IndexId = 0, TextUrl1 = "Pull.html", LogoUrl = "getCloud.png", Title = "Pull", GifUrl = "pull.gif", MainTitleId = 2 },
                new BaseTitle { Id = 16, IndexId = 0, TextUrl1 = "Save.html", Title = "Save", MainTitleId = 2 },
                new BaseTitle { Id = 17, IndexId = 0, TextUrl1 = "Save Cloud.html", Title = "Save Cloud", MainTitleId = 2 },
                new BaseTitle { Id = 18, IndexId = 2, TextUrl1 = "StartCommand.html", Title = "Start Command", ResponeseType = "POST", Header = "/Draw/startCommand", Body = "StartCommand.json", MainTitleId = 10 },
                new BaseTitle { Id = 19, IndexId = 2, TextUrl1 = "AddCoordinate.html", Title = "Add Coordinate", ResponeseType = "POST", Header = "/Draw/addCoordinate", Body = "AddCoordinate.json", MainTitleId = 10 },
                new BaseTitle { Id = 20, IndexId = 2, TextUrl1 = "StopCommand.html", Title = "Stop Command", ResponeseType = "PUT", Header = "/Draw/stopCommand", MainTitleId = 10 },
                new BaseTitle { Id = 21, IndexId = 2, TextUrl1 = "SetRadius.html", Title = "Set Radius", ResponeseType = "PUT", Header = "/Draw/setRadius", Body = "SetRadius.json", MainTitleId = 10 },
                new BaseTitle { Id = 23, IndexId = 2, TextUrl1 = "SetIsFinish.html", Title = "Set Is Finish", ResponeseType = "PUT", Header = "/Draw/setIsFinish?finish=true", MainTitleId = 10 },
                new BaseTitle { Id = 24, IndexId = 2, TextUrl1 = "SaveDraw.html", Title = "Save Draw", ResponeseType = "POST", Header = "/Draw/saveDraw", Body = "SaveDraw.json", MainTitleId = 10 },
                new BaseTitle { Id = 25, IndexId = 2, TextUrl1 = "ReadDraw.html", Title = "Read Draw", ResponeseType = "POST", Header = "/Draw/readDraw", Body = "ReadDraw.json", MainTitleId = 10 },
                new BaseTitle { Id = 26, IndexId = 2, TextUrl1 = "DrawBoxest.html", Title = "Draw Boxes", ResponeseType = "GET", Header = "/DrawBox/drawBoxes", MainTitleId = 11 },
                new BaseTitle { Id = 27, IndexId = 2, TextUrl1 = "DrawBoxesAdd.html", Title = "Draw Boxes Add", ResponeseType = "GET", Header = "/DrawBox/drawBoxes/add", Body = "DrawBoxesAdd.json", MainTitleId = 11 },
                new BaseTitle { Id = 28, IndexId = 2, TextUrl1 = "DrawBoxesDelete.html", Title = "Draw Boxes Delete", ResponeseType = "DELETE", Header = "/DrawBox/drawBoxes/delete", Body = "DrawBoxesDelete.json", MainTitleId = 11 },
                new BaseTitle { Id = 29, IndexId = 2, TextUrl1 = "DrawBoxesUpdate.html", Title = "Draw Boxes Update", ResponeseType = "PUT", Header = "/DrawBox/drawBoxes/update", Body = "DrawBoxesUpdate.json", MainTitleId = 11 },
                new BaseTitle { Id = 30, IndexId = 2, TextUrl1 = "DrawBoxId.html", Title = "Draw Box", ResponeseType = "GET", Header = "/DrawBox/drawBoxes/{id}", MainTitleId = 11 },
                new BaseTitle { Id = 31, IndexId = 2, TextUrl1 = "DrawBoxIdLayers.html", Title = "Draw Box With Layers", ResponeseType = "GET", Header = "/DrawBox/drawBoxes/{id}/layers", MainTitleId = 11 },
                new BaseTitle { Id = 32, IndexId = 2, TextUrl1 = "Elementst.html", Title = "Elements", ResponeseType = "GET", Header = "/Element/elements", MainTitleId = 12 },
                new BaseTitle { Id = 33, IndexId = 2, TextUrl1 = "ElementsWithAtt.html", Title = "Elements With Attributes", ResponeseType = "GET", Header = "/Element/elementswithatt", MainTitleId = 12 },
                new BaseTitle { Id = 34, IndexId = 2, TextUrl1 = "ElementsByDraw.html", Title = "Elements By Draw", ResponeseType = "GET", Header = "/Element/elementsbydraw?drawId=0", MainTitleId = 12 },
                new BaseTitle { Id = 35, IndexId = 2, TextUrl1 = "ElementsByDrawWithAtt.html", Title = "Elements By Draw With Attributes", ResponeseType = "GET", Header = "/Element/elementsbydrawwithatt?drawId=0", MainTitleId = 12 },
                new BaseTitle { Id = 36, IndexId = 2, TextUrl1 = "ElementsByLayer.html", Title = "Elements By Layer", ResponeseType = "GET", Header = "/Element/elementsbylayer?layerId=0", MainTitleId = 12 },
                new BaseTitle { Id = 37, IndexId = 2, TextUrl1 = "ElementsByLayerWithAtt.html", Title = "Elements By Layer With Attributes", ResponeseType = "GET", Header = "/Element/elementsbylayerwithatt?layerId=0", MainTitleId = 12 },
                new BaseTitle { Id = 38, IndexId = 2, TextUrl1 = "ElementsAdd.html", Title = "Elements Add", ResponeseType = "POST", Header = "/Element/elements/add",Body= "ElementsAdd.json", MainTitleId = 12 },
                new BaseTitle { Id = 39, IndexId = 2, TextUrl1 = "ElementsDelete.html", Title = "Elements Delete", ResponeseType = "DELETE", Header = "/Element/elements/delete",Body= "ElementsDelete.json", MainTitleId = 12 },
                new BaseTitle { Id = 40, IndexId = 2, TextUrl1 = "ElementsUpdate.html", Title = "Elements Update", ResponeseType = "PUT", Header = "/Element/elements/update",Body= "ElementsUpdate.json", MainTitleId = 12 },
                new BaseTitle { Id = 41, IndexId = 2, TextUrl1 = "ElementId.html", Title = "Element", ResponeseType = "GET", Header = "/Element/elements/{id}", MainTitleId = 12 },
                new BaseTitle { Id = 42, IndexId = 2, TextUrl1 = "ElementIdElementType.html", Title = "Element Element Type", ResponeseType = "GET", Header = "/Element/elements/{id}/elementType", MainTitleId = 12 },
                new BaseTitle { Id = 43, IndexId = 2, TextUrl1 = "ElementIdPen.html", Title = "Element Pen", ResponeseType = "GET", Header = "/Element/elements/{id}/pen", MainTitleId = 12 },
                new BaseTitle { Id = 44, IndexId = 2, TextUrl1 = "ElementIdLayer.html", Title = "Element Layer", ResponeseType = "GET", Header = "/Element/elements/{id}/layer", MainTitleId = 12 },
                new BaseTitle { Id = 45, IndexId = 2, TextUrl1 = "ElementIdRadiuses.html", Title = "Element Radiuses", ResponeseType = "GET", Header = "/Element/elements/{id}/radiuses", MainTitleId = 12 },
                new BaseTitle { Id = 46, IndexId = 2, TextUrl1 = "ElementIdSSAngles.html", Title = "Element SSAngles", ResponeseType = "GET", Header = "/Element/elements/{id}/ssangles", MainTitleId = 12 },
                new BaseTitle { Id = 47, IndexId = 2, TextUrl1 = "ElementIdPoints.html", Title = "Element Points", ResponeseType = "GET", Header = "/Element/elements/{id}/points", MainTitleId = 12 },
                new BaseTitle { Id = 48, IndexId = 2, TextUrl1 = "ElementTypes.html", Title = "Element Types", ResponeseType = "GET", Header = "/ElementType/elementTypes", MainTitleId = 13 },
                new BaseTitle { Id = 49, IndexId = 2, TextUrl1 = "ElementType.html", Title = "Element Type", ResponeseType = "GET", Header = "/ElementType/elementTypes/{id}", MainTitleId = 13 },
                new BaseTitle { Id = 50, IndexId = 2, TextUrl1 = "ElementTypeAdd.html", Title = "Element Types Add", ResponeseType = "POST", Header = "/ElementType/elementTypes/add",Body= "ElementTypeAdd.json", MainTitleId = 13 },
                new BaseTitle { Id = 51, IndexId = 2, TextUrl1 = "ElementTypeDelete.html", Title = "Element Types Delete", ResponeseType = "DELETE", Header = "/ElementType/elementTypes/delete",Body= "ElementTypeDelete.json", MainTitleId = 13 },
                new BaseTitle { Id = 52, IndexId = 2, TextUrl1 = "ElementTypeUpdate.html", Title = "Element Types Update", ResponeseType = "PUT", Header = "/ElementType/elementTypes/update",Body= "ElementTypeUpdate.json", MainTitleId = 13 },
                new BaseTitle { Id = 53, IndexId = 2, TextUrl1 = "Layers.html", Title = "Layers", ResponeseType = "GET", Header = "/Layer/layers", MainTitleId = 14 },
                new BaseTitle { Id = 54, IndexId = 2, TextUrl1 = "LayersDrawId.html", Title = "Draw Layers", ResponeseType = "POST", Header = "/Layer/layers?drawId=0", MainTitleId = 14 },
                new BaseTitle { Id = 55, IndexId = 2, TextUrl1 = "LayersDrawIdWithPen.html", Title = "Draw Layers With Pen", ResponeseType = "POST", Header = "/Layer/layerswithpen?drawId=0", MainTitleId = 14 },
                new BaseTitle { Id = 56, IndexId = 2, TextUrl1 = "LayersAdd.html", Title = "Layers Add", ResponeseType = "POST", Header = "/Layer/layers/add",Body="LayersAdd.json", MainTitleId = 14 },
                new BaseTitle { Id = 57, IndexId = 2, TextUrl1 = "LayersDelete.html", Title = "Layers Delete", ResponeseType = "DELETE", Header = "/Layer/layers/delete",Body="LayersDelete.json", MainTitleId = 14 },
                new BaseTitle { Id = 58, IndexId = 2, TextUrl1 = "LayersUpdate.html", Title = "Layers Update", ResponeseType = "PUT", Header = "/Layer/layers/update",Body="LayersUpdate.json", MainTitleId = 14 },
                new BaseTitle { Id = 59, IndexId = 2, TextUrl1 = "Layert.html", Title = "Layer", ResponeseType = "GET", Header = "/Layer/layers/{id}", MainTitleId = 14 },
                new BaseTitle { Id = 60, IndexId = 2, TextUrl1 = "Layerelements.html", Title = "Layer Elements", ResponeseType = "GET", Header = "/Layer/layers/{id}/elements", MainTitleId = 14 },
                new BaseTitle { Id = 61, IndexId = 2, TextUrl1 = "Layerpen.html", Title = "Layer Pen", ResponeseType = "GET", Header = "/Layer/layers/{id}/pen", MainTitleId = 14 },
                new BaseTitle { Id = 62, IndexId = 2, TextUrl1 = "Pens.html", Title = "Pens", ResponeseType = "GET", Header = "/Pen/pens", MainTitleId = 15 },
                new BaseTitle { Id = 63, IndexId = 2, TextUrl1 = "Penswithatt.html", Title = "Pens With Attributes", ResponeseType = "GET", Header = "/Pen/penswithatt", MainTitleId = 15 },
                new BaseTitle { Id = 64, IndexId = 2, TextUrl1 = "Pent.html", Title = "Pen", ResponeseType = "GET", Header = "/Pen/pens/{id}", MainTitleId = 15 },
                new BaseTitle { Id = 65, IndexId = 2, TextUrl1 = "Penpenstyle.html", Title = "Pen PenStyle", ResponeseType = "GET", Header = "/Pen/pens/{id}/penstyle", MainTitleId = 15 },
                new BaseTitle { Id = 66, IndexId = 2, TextUrl1 = "Penadd.html", Title = "Pen Add", ResponeseType = "POST", Header = "/Pen/pens/add",Body="Pensadd.json", MainTitleId = 15 },
                new BaseTitle { Id = 67, IndexId = 2, TextUrl1 = "Pendelete.html", Title = "Pen Delete", ResponeseType = "DELETE", Header = "/Pen/pens/delete",Body="Pensdelete.json", MainTitleId = 15 },
                new BaseTitle { Id = 68, IndexId = 2, TextUrl1 = "Penupdate.html", Title = "Pen Update", ResponeseType = "PUT", Header = "/Pen/pens/update",Body="Pensupdate.json", MainTitleId = 15 },
                new BaseTitle { Id = 69, IndexId = 2, TextUrl1 = "PenStyles.html", Title = "PenStyles", ResponeseType = "GET", Header = "/PenStyles/penstyles", MainTitleId = 16 },
                new BaseTitle { Id = 70, IndexId = 2, TextUrl1 = "Penstylet.html", Title = "PenStyle", ResponeseType = "GET", Header = "/PenStyles/penstyles/{id}", MainTitleId = 16 },
                new BaseTitle { Id = 71, IndexId = 2, TextUrl1 = "Penstylesadd.html", Title = "PenStyles Add", ResponeseType = "POST", Header = "/PenStyles/penstyles/add",Body="Penstyleadd.json", MainTitleId = 16 },
                new BaseTitle { Id = 72, IndexId = 2, TextUrl1 = "Penstylesdelete.html", Title = "PenStyles Delete", ResponeseType = "DELETE", Header = "/PenStyles/penstyles/delete",Body="Penstyledelete.json", MainTitleId = 16 },
                new BaseTitle { Id = 73, IndexId = 2, TextUrl1 = "Penstylesupdate.html", Title = "PenStyles Update", ResponeseType = "PUT", Header = "/PenStyles/penstyles/update",Body="Penstyleupdate.json", MainTitleId = 16 },
                new BaseTitle { Id = 74, IndexId = 2, TextUrl1 = "Points.html", Title = "Points", ResponeseType = "GET", Header = "/Point/points", MainTitleId = 17 },
                new BaseTitle { Id = 75, IndexId = 2, TextUrl1 = "Pointsbyelement.html", Title = "Points By Element", ResponeseType = "GET", Header = "/Point/pointsbyelement?elementId=0", MainTitleId = 17 },
                new BaseTitle { Id = 76, IndexId = 2, TextUrl1 = "Pointsbylayer.html", Title = "Points By Layer", ResponeseType = "GET", Header = "/Point/pointsbylayer?layerId=0", MainTitleId = 17 },
                new BaseTitle { Id = 77, IndexId = 2, TextUrl1 = "Pointsbydraw.html", Title = "Points By Draw", ResponeseType = "GET", Header = "/Point/pointsbydraw?drawId=0", MainTitleId = 17 },
                new BaseTitle { Id = 78, IndexId = 2, TextUrl1 = "Pointsadd.html", Title = "Points Add", ResponeseType = "GET", Header = "/Point/points/add",Body="Pointsadd.json", MainTitleId = 17 },
                new BaseTitle { Id = 79, IndexId = 2, TextUrl1 = "Pointsdelete.html", Title = "Points Delete", ResponeseType = "DELETE", Header = "/Point/points/delete",Body="Pointsdelete.json", MainTitleId = 17 },
                new BaseTitle { Id = 80, IndexId = 2, TextUrl1 = "Pointsupdate.html", Title = "Points Update", ResponeseType = "PUT", Header = "/Point/points/update",Body="Pointsupdate.json", MainTitleId = 17 },
                new BaseTitle { Id = 81, IndexId = 2, TextUrl1 = "Pointt.html", Title = "Point", ResponeseType = "GET", Header = "/Point/points/{id}", MainTitleId = 17 },
                new BaseTitle { Id = 82, IndexId = 2, TextUrl1 = "Pointelement.html", Title = "Point Element", ResponeseType = "GET", Header = "/Point/points/{id}/element", MainTitleId = 17 },
                new BaseTitle { Id = 83, IndexId = 2, TextUrl1 = "Pointpointtype.html", Title = "Point PointType", ResponeseType = "GET", Header = "/Point/points/{id}/pointtype", MainTitleId = 17 },
                new BaseTitle { Id = 84, IndexId = 2, TextUrl1 = "PointTypes.html", Title = "PointTypes", ResponeseType = "GET", Header = "/PointType/pointtypes", MainTitleId = 18 },
                new BaseTitle { Id = 85, IndexId = 2, TextUrl1 = "PointType.html", Title = "PointType", ResponeseType = "GET", Header = "/PointType/pointtypes/{id}", MainTitleId = 18 },
                new BaseTitle { Id = 86, IndexId = 2, TextUrl1 = "PointTypeadd.html", Title = "PointType Add", ResponeseType = "POST", Header = "/PointType/pointtypes/add",Body="pointtypeadd.json", MainTitleId = 18 },
                new BaseTitle { Id = 87, IndexId = 2, TextUrl1 = "PointTypedelete.html", Title = "PointType Delete", ResponeseType = "DELETE", Header = "/PointType/pointtypes/delete",Body="pointtypedelete.json", MainTitleId = 18 },
                new BaseTitle { Id = 88, IndexId = 2, TextUrl1 = "PointTypeupdate.html", Title = "PointType Update", ResponeseType = "PUT", Header = "/PointType/pointtypes/update",Body= "pointtypeupdate.json", MainTitleId = 18 },
                new BaseTitle { Id = 89, IndexId = 2, TextUrl1 = "Radiuses.html", Title = "Radiuses", ResponeseType = "GET", Header = "/Radius/radiuses", MainTitleId = 19 },
                new BaseTitle { Id = 90, IndexId = 2, TextUrl1 = "Radiusesadd.html", Title = "Radiuses Add", ResponeseType = "POST", Header = "/Radius/radiuses/add",Body="radiusesadd.json", MainTitleId = 19 },
                new BaseTitle { Id = 91, IndexId = 2, TextUrl1 = "Radiusesdelete.html", Title = "Radiuses Delete", ResponeseType = "DELETE", Header = "/Radius/radiuses/delete",Body= "radiusesdelete.json", MainTitleId = 19 },
                new BaseTitle { Id = 92, IndexId = 2, TextUrl1 = "Radiusesupdate.html", Title = "Radiuses Update", ResponeseType = "PUT", Header = "/Radius/radiuses/update",Body= "radiusesupdate.json", MainTitleId = 19 },
                new BaseTitle { Id = 93, IndexId = 2, TextUrl1 = "Radiuset.html", Title = "Radiuse", ResponeseType = "GET", Header = "/Radius/radiuses/{id}", MainTitleId = 19 },
                new BaseTitle { Id = 94, IndexId = 2, TextUrl1 = "SSAnglet.html", Title = "SSAngle", ResponeseType = "GET", Header = "/SSAngle/ssangles/{id}", MainTitleId = 20 },
                new BaseTitle { Id = 95, IndexId = 2, TextUrl1 = "SSAngles.html", Title = "SSAngles", ResponeseType = "GET", Header = "/SSAngle/ssangles", MainTitleId = 20 },
                new BaseTitle { Id = 96, IndexId = 2, TextUrl1 = "SSAnglesadd.html", Title = "SSAngles Add", ResponeseType = "POST", Header = "/SSAngle/ssangles/add",Body= "SSAnglesadd.json", MainTitleId = 20 },
                new BaseTitle { Id = 97, IndexId = 2, TextUrl1 = "SSAnglesdelete.html", Title = "SSAngles Delete", ResponeseType = "DELETE", Header = "/SSAngle/ssangles/delete",Body= "SSAnglesdelete.json", MainTitleId = 20 },
                new BaseTitle { Id = 98, IndexId = 2, TextUrl1 = "SSAnglesupdate.html", Title = "SSAngles Update", ResponeseType = "PUT", Header = "/SSAngle/ssangles/update",Body= "SSAnglesupdate.json", MainTitleId = 20 },
                new BaseTitle { Id = 99, IndexId = 3, TextUrl1 = "findTwoPointsLength.html", Title = "Find Two Point Length", ResponeseType = "POST", Header = "/findTwoPointsLength/", Body= "findTwoPointsLength.json", MainTitleId = 22 },
                new BaseTitle { Id = 100, IndexId = 3, TextUrl1 = "findCenterAndRadius.html", Title = "Find Center And Radius", ResponeseType = "POST", Header = "/findCenterAndRadius/", Body= "findCenterAndRadius.json", MainTitleId = 22 },
                new BaseTitle { Id = 101, IndexId = 3, TextUrl1 = "findToSlopeLine.html", Title = "Find To Slope Line", ResponeseType = "POST", Header = "/findToSlopeLine/", Body= "findToSlopeLine.json", MainTitleId = 22 },
                new BaseTitle { Id = 102, IndexId = 3, TextUrl1 = "findDegreeLineSlope.html", Title = "Find Degree Line Slope", ResponeseType = "POST", Header = "/findDegreeLineSlope/", Body= "findDegreeLineSlope.json", MainTitleId = 22 },
                new BaseTitle { Id = 103, IndexId = 3, TextUrl1 = "findDegreeLineTwoPoints.html", Title = "Find Degree Line Two Points", ResponeseType = "POST", Header = "/findDegreeLineTwoPoints/", Body= "findDegreeLineTwoPoints.json", MainTitleId = 22 },
                new BaseTitle { Id = 104, IndexId = 3, TextUrl1 = "convertDegreeToSlope.html", Title = "Convert Degree To Slope", ResponeseType = "POST", Header = "/convertDegreeToSlope/", Body= "convertDegreeToSlope.json", MainTitleId = 22 },
                new BaseTitle { Id = 105, IndexId = 3, TextUrl1 = "convertRadianToDegree.html", Title = "Convert Radian To Degree", ResponeseType = "POST", Header = "/convertRadianToDegree/", Body= "convertRadianToDegree.json", MainTitleId = 22 },
                new BaseTitle { Id = 106, IndexId = 3, TextUrl1 = "convertDegreeToRadians.html", Title = "Convert Degree To Radians", ResponeseType = "POST", Header = "/convertDegreeToRadians/", Body= "convertDegreeToRadians.json", MainTitleId = 22 },
                new BaseTitle { Id = 107, IndexId = 3, TextUrl1 = "findCenterPointToLine.html", Title = "Find Center Point To Line", ResponeseType = "POST", Header = "/findCenterPointToLine/", Body= "findCenterPointToLine.json", MainTitleId = 22 },
                new BaseTitle { Id = 108, IndexId = 3, TextUrl1 = "findDegreeToBetweenTwoLines.html", Title = "Find Degree To Between Two Lines", ResponeseType = "POST", Header = "/findDegreeToBetweenTwoLines/", Body= "findDegreeToBetweenTwoLines.json", MainTitleId = 22 },
                new BaseTitle { Id = 109, IndexId = 3, TextUrl1 = "findDotProductToTwoPoints.html", Title = "Find Dot Product To Two Points", ResponeseType = "POST", Header = "/findDotProductToTwoPoints/", Body= "findDotProductToTwoPoints.json", MainTitleId = 22 },
                new BaseTitle { Id = 110, IndexId = 3, TextUrl1 = "findDifferenceTwoPoints.html", Title = "Find Difference Two Points", ResponeseType = "POST", Header = "/findDifferenceTwoPoints/", Body= "findDifferenceTwoPoints.json", MainTitleId = 22 },
                new BaseTitle { Id = 111, IndexId = 3, TextUrl1 = "wherePointOnLine.html", Title = "Where Point On Line", ResponeseType = "POST", Header = "/wherePointOnLine/", Body= "wherePointOnLine.json", MainTitleId = 22 },
                new BaseTitle { Id = 112, IndexId = 3, TextUrl1 = "findInsectionPointToTwoLines.html", Title = "Find Insection Point To Two Lines", ResponeseType = "POST", Header = "/findInsectionPointToTwoLines/", Body= "findInsectionPointToTwoLines.json", MainTitleId = 22 },
                new BaseTitle { Id = 113, IndexId = 3, TextUrl1 = "findPointLength.html", Title = "Find Point Length", ResponeseType = "POST", Header = "/findPointLength/?length=0", Body= "findPointLength.json", MainTitleId = 22 },
                new BaseTitle { Id = 114, IndexId = 3, TextUrl1 = "wherePointZone.html", Title = "Where Point Zone", ResponeseType = "POST", Header = "/wherePointZone/", Body= "wherePointZone.json", MainTitleId = 22 },
                new BaseTitle { Id = 115, IndexId = 3, TextUrl1 = "findNearetPoint.html", Title = "Find Nearest Point", ResponeseType = "POST", Header = "/findNearetPoint/", Body= "findNearetPoint.json", MainTitleId = 22 },
                new BaseTitle { Id = 116, IndexId = 3, TextUrl1 = "findStartAndStopAngle.html", Title = "Find Start And Stop Angle", ResponeseType = "POST", Header = "/findStartAndStopAngle/", Body= "findStartAndStopAngle.json", MainTitleId = 22 },
                new BaseTitle { Id = 117, IndexId = 3, TextUrl1 = "findStartAndStopAngleTwoPoint.html", Title = "Find Start And Stop Angle Two Point", ResponeseType = "POST", Header = "/findStartAndStopAngleTwoPoint/", Body= "findStartAndStopAngleTwoPoint.json", MainTitleId = 22 },
                new BaseTitle { Id = 118, IndexId = 3, TextUrl1 = "findPointOnCircle.html", Title = "Find Point On Circle", ResponeseType = "POST", Header = "/findPointOnCircle/", Body= "findPointOnCircle.json", MainTitleId = 22 },
                new BaseTitle { Id = 119, IndexId = 4, TextUrl1 = "createuser.html", Title = "Create User", ResponeseType = "POST", Header = "/User/createuser", Body= "createuser.json", MainTitleId = 24 },
                new BaseTitle { Id = 120, IndexId = 4, TextUrl1 = "getuser.html", Title = "Get User", ResponeseType = "GET", Header = "/User/getuser", MainTitleId = 24 },
                new BaseTitle { Id = 121, IndexId = 4, TextUrl1 = "createtoken.html", Title = "Create Token", ResponeseType = "POST", Header = "/Auth/createtoken", Body= "createtoken.json", MainTitleId = 25 },
                new BaseTitle { Id = 122, IndexId = 4, TextUrl1 = "createtokenbyrefreshtoken.html", Title = "Create Token By Refresh Token", ResponeseType = "POST", Header = "/Auth/createtokenbyrefreshtoken", Body= "createtokenbyrefreshtoken.json", MainTitleId = 25 },
                new BaseTitle { Id = 123, IndexId = 4, TextUrl1 = "revokerefreshtoken.html", Title = "Revoke Refresh Token", ResponeseType = "POST", Header = "/Auth/revokerefreshtoken", Body= "revokerefreshtoken.json", MainTitleId = 25 },
                new BaseTitle { Id = 124, IndexId = 1, TextUrl1 = "apilayer.html", Title = "Api", MainTitleId = 27},
                new BaseTitle { Id = 125, IndexId = 1, TextUrl1 = "businesslayer.html", Title = "Business", MainTitleId = 27},
                new BaseTitle { Id = 126, IndexId = 1, TextUrl1 = "dataaccesslayer.html", Title = "DataAccess", MainTitleId = 27},
                new BaseTitle { Id = 127, IndexId = 1, TextUrl1 = "drawlayer.html", Title = "DrawLayer", MainTitleId = 27},
                new BaseTitle { Id = 128, IndexId = 1, TextUrl1 = "corelayer.html", Title = "Core", MainTitleId = 27}


            );
        }
    }

    internal class SubTitleMapping : IEntityTypeConfiguration<SubTitle>
    {
        public void Configure(EntityTypeBuilder<SubTitle> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Title).IsRequired().HasMaxLength(200);


            builder.Property(u => u.GifUrl).HasMaxLength(200);
            builder.Property(u => u.LogoUrl).HasMaxLength(200);
            builder.Property(u => u.Header).HasMaxLength(2000);
            builder.Property(u => u.IndexId).IsRequired();

            builder.HasOne(bt => bt.BaseTitle).WithMany(mt => mt.SubTitles).HasForeignKey(bt => bt.BaseTitleId);



            builder.HasData(
                new SubTitle { Id = 1, IndexId = 0, TextUrl1 = "Line.html", Title = "Line", ShortcutUrl1 = "l", ShortcutUrl2 = "enter", GifUrl="line.gif",LogoUrl="Line.png",  BaseTitleId = 1 },
                new SubTitle { Id = 2, IndexId = 0, TextUrl1 = "Polyline.html", Title = "Polyline", ShortcutUrl1 = "p", ShortcutUrl2 = "o", ShortcutUrl3 = "enter", GifUrl = "polyline.gif", LogoUrl = "polyline.png", BaseTitleId = 1 },
                new SubTitle { Id = 3, IndexId = 0, TextUrl1 = "Rectangle.html", Title = "Rectangle", ShortcutUrl1 = "r", ShortcutUrl2 = "enter", GifUrl = "rectangle.gif", LogoUrl = "Rectangle.png", BaseTitleId = 1 },
                new SubTitle { Id = 4, IndexId = 0, TextUrl1 = "Circle Center Point.html", Title = "Circle Center Point", ShortcutUrl1 = "c", ShortcutUrl2 = "enter", GifUrl = "centerpointcircle.gif", LogoUrl = "CenterPointCircle.png", BaseTitleId = 1 },
                new SubTitle { Id = 5, IndexId = 0, TextUrl1 = "Circle Tree Point.html", Title = "Circle Tree Point", GifUrl = "treepointcircle.gif", LogoUrl = "treepointcircle.png", BaseTitleId = 1 },
                new SubTitle { Id = 6, IndexId = 0, TextUrl1 = "Circle Two Point.html", Title = "Circle Two Point", GifUrl = "twopointcircle.gif", LogoUrl = "TwoPointCircle.png", BaseTitleId = 1 },
                new SubTitle { Id = 7, IndexId = 0, TextUrl1 = "Circle Center Radius.html", Title = "Circle Center Radius", GifUrl = "centerradiuscircle.gif", LogoUrl = "Circle.png", BaseTitleId = 1 },
                new SubTitle { Id = 8, IndexId = 0, TextUrl1 = "Arc Tree Point.html", Title = "Arc Tree Point", ShortcutUrl1 = "a", ShortcutUrl2 = "enter", GifUrl = "treepointarc.gif", LogoUrl = "treepointarc.png", BaseTitleId = 1 },
                new SubTitle { Id = 9, IndexId = 0, TextUrl1 = "Arc Two Point.html", Title = "Arc Two Point", GifUrl = "twopointarc.gif", LogoUrl = "TwoPointCenterArc.png", BaseTitleId = 1 },
                new SubTitle {Id = 10, IndexId = 0, TextUrl1 = "Ellipse.html", Title = "Ellipse", ShortcutUrl1 = "e", ShortcutUrl2 = "enter", GifUrl = "ellipse.gif", LogoUrl = "Ellips.png", BaseTitleId = 1 },
                new SubTitle {Id = 11, IndexId = 0, TextUrl1 = "Move.html", Title = "Move", ShortcutUrl1 = "m", ShortcutUrl2 = "enter", GifUrl = "move.gif", LogoUrl = "move.png", BaseTitleId = 2 },
                new SubTitle {Id = 12, IndexId = 0, TextUrl1 = "Copy.html", Title = "Copy", ShortcutUrl1 = "c", ShortcutUrl2 = "o", ShortcutUrl3 = "enter", GifUrl = "copy.gif", LogoUrl = "Copy.png", BaseTitleId = 2 },
                new SubTitle {Id = 13, IndexId = 0, TextUrl1 = "Rotate.html", Title = "Rotate", ShortcutUrl1 = "r", ShortcutUrl2 = "o", ShortcutUrl3 = "enter", GifUrl = "rotate.gif", LogoUrl = "Rotate.png", BaseTitleId = 2 },
                new SubTitle {Id = 14, IndexId = 0, TextUrl1 = "Scale.html", Title = "Scale", ShortcutUrl1 = "s", ShortcutUrl2 = "enter", GifUrl = "scale.gif", LogoUrl = "Scale.png", BaseTitleId = 2 },
                new SubTitle {Id = 15, IndexId = 0, TextUrl1 = "Mirror.html", Title = "Mirror", ShortcutUrl1 = "m", ShortcutUrl2 = "i", ShortcutUrl3 = "enter", GifUrl = "mirror.gif", LogoUrl = "Mirror.png", BaseTitleId = 2 }
                
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

            builder.Property(u => u.CreateTime).IsRequired();
            builder.Property(u => u.EditTime).IsRequired();

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

            builder.Property(u => u.Lock).IsRequired();

            builder.Property(u => u.Visibility).IsRequired();

            builder.Property(l => l.Thickness).IsRequired().HasPrecision(3, 1);

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

            builder.HasOne(d => d.Element)
                .WithMany(u => u.SSAngles)
                .HasForeignKey(d => d.ElementId);
        }
    }
}