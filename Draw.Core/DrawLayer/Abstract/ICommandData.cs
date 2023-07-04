using Draw.Core.DrawLayer.Model;

namespace Draw.Core.DrawLayer.Abstract
{
    public interface ICommandData
    {
        bool IsFinish { get; set; }
        IBaseCommand? SelectedCommand { get; set; }
        DateTime IsUseTime { get; set; }
        List<PointD> PointsList { get; set; }
        List<int> EditElementsId { get; set; }
        double SelectedRadius { get; set; }
        int? SelectedPenId { get; set; }
        int? SelectedLayerId { get; set; }
        string UserId { get; set; }
        int? SelectedDrawBoxId { get; set; }
        int SelectedElementTypeId { get; set; }
        bool IsWorkingCommand { get; set; }
        void SetIsFinish(bool finish);
        void SetDefaultCommand();
        void SetSelectedCommand(IBaseCommand command);
        IBaseCommand GetSelectedCommand();
        void SetData(int? layerId, int? drawId, int? penId);
        void SetIsWorkingCommand(bool workingCommandValue);
        void SetUseTimeNow();
        void SetElementTypeId(int elementTypeId);
        void SetRadius(double radius);
        void SetDrawBoxId(int? drawBoxId);
        void SetPen(int? penId);
        void SetEditElementsId(List<int> editElementsId);
        void SetLayerId(int? layerId);
        void SetUserId(string userId);
        void ClearPointList();
        void ClearEditList();
    }
}
