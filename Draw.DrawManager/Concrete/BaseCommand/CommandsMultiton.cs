using Draw.DataAccess.Abstract.Commands;
using Draw.DrawManager.Concrete.DrawCommands;
using Draw.DrawManager.Concrete.EditCommands;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Draw.DrawManager.Concrete.BaseCommand
{
    internal class CommandsMultiton
    {
        private static Dictionary<CommandEnums, IBaseCommand> _commands = new Dictionary<CommandEnums, IBaseCommand>
        {
            { CommandEnums.line,new LineCommand() },
            { CommandEnums.circleTwoPoint,new CircleTwoPointsCommand() },
            { CommandEnums.circleCenterPoint,new CircleCenterPointCommand() },
            { CommandEnums.circleCenterRadius,new CircleCenterRadiusCommand() },
            { CommandEnums.circleTreePoint,new CircleTreePointCommand() },
            { CommandEnums.rectangle,new RectangleCommand() },
            { CommandEnums.spline,new SPLineCommand() },
            { CommandEnums.move,new MoveCommands() },
            { CommandEnums.copy,new CopyCommand() }
        };
        private CommandsMultiton() { }

        public static IBaseCommand GetCommand(CommandEnums commandEnum)
        {
            return _commands[commandEnum];
        }

    }
}
