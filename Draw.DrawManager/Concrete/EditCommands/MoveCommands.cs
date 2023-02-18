﻿using Draw.DataAccess.Abstract.Commands;
using Draw.DrawManager.Concrete.BaseCommand;
using Draw.DrawManager.Concrete.Helpers;
using Draw.Entities.Concrete.Elements;
using System.Xml.Linq;

namespace Draw.DrawManager.Concrete.EditCommands
{
    public class MoveCommands : BaseCommanAbstract
    {
        private Point _point1;
        private Point _point2;

        public MoveCommands(CommandMemory commandMemory) : base(commandMemory)
        {
            this._point1 = CreatePoint(CommandMemory.PointsList[0].X, CommandMemory.PointsList[0].Y, 1);
            this._point2 = CreatePoint(CommandMemory.PointsList[1].X, CommandMemory.PointsList[1].Y, 1);
        }

        protected override object ControlCommand()
        {
            Console.WriteLine("Move Command");
            CommandMemory.SetElementTypeId(1);
            if (CommandMemory.EditElementsId.Count == 0 ) { return "Last Add Edit Elements"; };
            return CommandMemory.PointsList.Count == 2 ? MoveElements() : ReturnErrorMessage(2);
        }

        private object MoveElements()
        {
            
            
            var editElements=CommandMemory.DrawMemory.GetElementsId(CommandMemory.EditElementsId);
            var x= DrawMath.DifferancePointsX(this._point1, this._point2);
            var y= DrawMath.DifferancePointsY(this._point1, this._point2);
            foreach (var element in editElements)
            {
                foreach (var point in element.Points)
                {
                    point.PointX += x;
                    point.PointY += y;
                }
            }
            CommandMemory.DrawMemory.SetElements(editElements);
            FinishCommand();
            return editElements;
        }
    }

}
