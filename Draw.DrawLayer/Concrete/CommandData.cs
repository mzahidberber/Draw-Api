using Draw.Core.DrawLayer.Abstract;
using Draw.Core.DrawLayer.Model;
using Draw.DrawLayer.Concrete.BaseCommand;

namespace Draw.DrawLayer.Concrete
{
    public class CommandData:ICommandData
    {
        private CommandContext _commandContext { get; set; }
        public CommandData(string userId)
        {
            _commandContext = new CommandContext(this);
            UserId = userId;
            EditElementsId = new List<int>();
            PointsList = new List<PointD>();
            SetUseTimeNow();
        }
        public bool IsFinish { get; set; }=false;
        public IBaseCommand? SelectedCommand { get; set; }
        public DateTime IsUseTime { get; set; }
        public List<PointD> PointsList { get; set; }
        public List<int> EditElementsId { get; set; }
        public double SelectedRadius { get; set; } = 0;
        public int? SelectedPenId { get; set; }
        public int? SelectedLayerId { get; set; }
        public string UserId { get; set; }
        public int? SelectedDrawBoxId { get; set; }
        public int SelectedElementTypeId { get; set; } = 0;
        public bool IsWorkingCommand { get; set; } = false;
        public void SetIsFinish(bool finish) => IsFinish = finish;
        public void SetDefaultCommand() => _commandContext.SetContextDefaultCommand();
        public void SetSelectedCommand(IBaseCommand command) =>  _commandContext.SetCommand(command);
        public IBaseCommand GetSelectedCommand() => _commandContext.GetCommand();
        public void SetData(int? layerId, int? drawId, int? penId)
        {
                SetDrawBoxId(drawId);
                SetPen(penId);
                SetLayerId(layerId);
        }
        public void SetIsWorkingCommand(bool workingCommandValue) => IsWorkingCommand = workingCommandValue;
        public void SetUseTimeNow() => IsUseTime = DateTime.Now;
        public void SetElementTypeId(int elementTypeId) =>  SelectedElementTypeId = elementTypeId;
        public void SetRadius(double radius) => SelectedRadius = radius;
        public void SetDrawBoxId(int? drawBoxId) =>  SelectedDrawBoxId = drawBoxId;
        public void SetPen(int? penId) =>  SelectedPenId = penId;
        public void SetEditElementsId(List<int> editElementsId) =>  EditElementsId = editElementsId;
        public void SetLayerId(int? layerId) => SelectedLayerId = layerId;
        public void SetUserId(string userId) =>  UserId = userId;
        public void ClearPointList() => PointsList.Clear();
        public void ClearEditList() =>  EditElementsId.Clear(); 
    }
}
