using Draw.Core.Services.Model;
using Draw.Entities.Concrete;

namespace Draw.Core.Services.Abstract
{
    public interface IGeoService
    {
        Task<GeoRequest<double>> FindTwoPointsLength(Point p1, Point p2);
        Task<RadiusAndPCenter> FindCenterAndRadius(Point p1, Point p2, Point p3);
        Task<GeoRequest<double>> FindToSlopeLine(Point p1, Point p2);
        Task<GeoRequest<StartAndStopRequest>> FindStartAndStopAngle(Point centerPoint, Point p1, Point p2, Point p3);
    }
}
