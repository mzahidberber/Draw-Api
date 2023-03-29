﻿using Draw.DrawLayer.Abstract;
using Draw.DrawLayer.Concrete.BaseCommand;
using Draw.DrawLayer.Concrete.Model;

namespace Draw.DrawLayer.Concrete
{
    public class CommandData
    {
        private CommandContext _commandContext { get; set; }
        public CommandData(string userName)
        {
            _commandContext = new CommandContext(this);
            UserId = userName;
            EditElementsId = new List<int>();
            PointsList = new List<PointD>();
            SetUseTimeNow();
        }
        internal bool IsFinish { get; private set; }=false;
        internal IBaseCommand? SelectedCommand { get; private set; }
        internal DateTime IsUseTime { get; private set; }
        internal List<PointD> PointsList { get; private set; }
        internal List<int> EditElementsId { get; private set; }
        internal double SelectedRadius { get; private set; } = 0;
        internal int SelectedPenId { get; private set; }
        internal int SelectedLayerId { get; private set; }
        internal string UserId { get; private set; }
        internal int SelectedUserDrawBoxId { get; private set; }
        internal int SelectedElementTypeId { get; private set; } = 0;
        internal bool IsWorkingCommand { get; private set; } = false;
        internal void SetIsFinish(bool finish) => IsFinish = finish;
        internal void SetDefaultCommand() => _commandContext.SetContextDefaultCommand();
        internal void SetSelectedCommand(IBaseCommand command) =>  _commandContext.SetCommand(command);
        internal IBaseCommand GetSelectedCommand() => _commandContext.GetCommand();
        internal void SetData(int layerId, int drawId, int penId)
        {
                SetDrawBoxId(drawId);
                SetPen(penId);
                SetLayerId(layerId);
        }
        internal void SetIsWorkingCommand(bool workingCommandValue) => IsWorkingCommand = workingCommandValue;
        internal void SetUseTimeNow() => IsUseTime = DateTime.Now;
        internal void SetElementTypeId(int elementTypeId) =>  SelectedElementTypeId = elementTypeId; 
        internal void SetRadius(double radius) => SelectedRadius = radius;
        internal void SetDrawBoxId(int drawBoxId) =>  SelectedUserDrawBoxId = drawBoxId; 
        internal void SetPen(int penId) =>  SelectedPenId = penId; 
        internal void SetEditElementsId(List<int> editElementsId) =>  EditElementsId = editElementsId; 
        internal void SetLayerId(int layerId) => SelectedLayerId = layerId;
        internal void SetUserId(string userId) =>  UserId = userId; 
        internal void ClearPointList() => PointsList.Clear(); 
        internal void ClearEditList() =>  EditElementsId.Clear(); 
    }
}
