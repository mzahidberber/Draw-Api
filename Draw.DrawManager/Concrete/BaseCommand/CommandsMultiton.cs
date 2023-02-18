using Draw.DataAccess.Abstract.Commands;
using Draw.DrawManager.Concrete.DrawCommands;
using Draw.DrawManager.Concrete.EditCommands;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Draw.DrawManager.Concrete.BaseCommand
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
            { CommandEnums.copy,typeof(CopyCommand) }
        };
        private CommandsMultiton() { }

        public static Type GetCommand(CommandEnums commandEnum)
        {
            return _commands[commandEnum];
        }

    }
}
