﻿using Draw.DrawLayer.Abstract;
using Draw.DrawLayer.Concrete.Helpers;
using Draw.Entities.Concrete;

namespace Draw.DrawLayer.Concrete.EditCommands
{
    public class MoveCommands 
    {
        private Point _point1 = null!;
        private Point _point2 = null!;

        //public MoveCommands(CommandMemory commandMemory) : base(commandMemory)
        //{
            
        //}

        //protected override object ControlCommand()
        //{
            
        //    Console.WriteLine("Move Command");
        //    CommandMemory.SetElementTypeId(1);
        //    if (CommandMemory.EditElementsId.Count == 0 ) { return "Last Add Edit Elements"; };
        //    return CommandMemory.PointsList.Count == 2 ? MoveElements() : ReturnErrorMessageAsync(2);
        //}

        //private object MoveElements()
        //{
        //    this._point1 = CreatePoint(CommandMemory.PointsList[0].X, CommandMemory.PointsList[0].Y, 1);
        //    this._point2 = CreatePoint(CommandMemory.PointsList[1].X, CommandMemory.PointsList[1].Y, 1);

        //    var editElements=CommandMemory.DrawData.GetElementsIdAsync(CommandMemory.EditElementsId);
        //    var x= DrawMath.DifferancePointsX(this._point1, this._point2);
        //    var y= DrawMath.DifferancePointsY(this._point1, this._point2);
        //    foreach (var element in editElements)
        //    {
        //        foreach (var point in element.Points)
        //        {
        //            point.PointX += x;
        //            point.PointY += y;
        //        }
        //    }
        //    CommandMemory.DrawData.SetElements(editElements);
        //    FinishCommand();
        //    return editElements;
        //}
    }

}
