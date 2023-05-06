using Draw.DrawLayer.Concrete.DrawCommands;
using Draw.DrawLayer.Concrete.EditCommands;

namespace Draw.DrawLayer.Concrete.BaseCommand
{
    internal class CommandsMultiton
    {
        private static Dictionary<CommandEnums,Type> _commands = new Dictionary<CommandEnums,Type>
        {
            { CommandEnums.line,typeof(LineCommand) },
            { CommandEnums.circleTwoPoint,typeof(CircleTwoPointsCommand) },
            { CommandEnums.circleCenterPoint,typeof(CircleCenterPointCommand) },
            { CommandEnums.circleCenterRadius,typeof(CircleCenterRadiusCommand) },
            { CommandEnums.circleTreePoint,typeof(CircleTreePointCommand) },
            { CommandEnums.rectangle,typeof(RectangleCommand) },
            { CommandEnums.spline,typeof(SPLineCommand) },
            { CommandEnums.move,typeof(MoveCommands) },
            { CommandEnums.copy,typeof(CopyCommand) },
            { CommandEnums.ellipse,typeof(EllipsCommand) },
            { CommandEnums.arcThreePoint,typeof(ArcTreePoint) },
            { CommandEnums.arcCenterTwoPoint,typeof(ArcCenterTwoPoint) },
        };
        private CommandsMultiton() { }

        public static Type GetCommand(CommandEnums commandEnum)
        {
            return _commands[commandEnum];
        }

    }
}
