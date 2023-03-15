using Draw.DrawLayer.Concrete.Elements;

namespace Draw.DrawLayer.Concrete.BaseCommand
{
    public class CommandMemory
    {
        public CommandMemory(DrawMemory drawMemory,string userName)
        {
            this.DrawMemory = drawMemory;
            this.UserName = userName;
            this.EditElementsId= new List<int>();
            this.PointsList =new List<PointD>();
            this.SnapPoints = new Dictionary<HelperEnums, bool> { 
                {HelperEnums.end,false},
                {HelperEnums.middle,false},
                {HelperEnums.center,false},
                {HelperEnums.intersection,false},
            };
        }
        internal DrawMemory DrawMemory { get; private set; }
        internal List<PointD> PointsList { get; private set; }
        internal List<int> EditElementsId { get; private set; }
        internal double SelectedRadius { get; private set; } = 0;
        internal int SelectedPenId { get; private set; }
        internal int SelectedLayerId { get; private set; }
        internal string UserName { get; private set; }
        internal int SelectedUserDrawBoxId { get; private set; }
        internal int SelectedElementTypeId { get; private set; } = 0;
        internal bool IsWorkingCommand { get; private set; } = false;
        internal Dictionary<HelperEnums,bool> SnapPoints { get; private set; }

        internal void SetSnapPoint(HelperEnums snapPoint,bool openOrClose) => this.SnapPoints[snapPoint] = openOrClose;
        internal void SetIsWorkingCommand(bool workingCommandValue) => this.IsWorkingCommand = workingCommandValue;
        internal void SetDrawMemory(DrawMemory drawMemory) => this.DrawMemory = drawMemory;
        internal void SetElementTypeId(int elementTypeId) => this.SelectedElementTypeId = elementTypeId;
        internal void SetRadius(double radius) => this.SelectedRadius = radius;
        internal void SetDrawBoxId(int drawBoxId) => this.SelectedUserDrawBoxId = drawBoxId;
        internal void SetPen(int penId) => this.SelectedPenId = penId;
        internal void SetEditElementsId(List<int> editElementsId) => this.EditElementsId = editElementsId;
        internal void SetLayerId(int layerId) => this.SelectedLayerId = layerId;
        internal void SetUserName(string userName) => this.UserName = userName;
        internal void ClearPointList() => this.PointsList.Clear();
        internal void ClearEditList() => this.EditElementsId.Clear();
    }
}
