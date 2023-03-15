using Draw.DrawLayer.Abstract.Commands;
using Draw.DrawLayer.Concrete.DrawElements;

namespace Draw.DrawLayer.Concrete.BaseCommand
{
    internal class DefaultCommand : BaseCommanAbstract
    {
        public DefaultCommand(CommandMemory commandMemory) : base(commandMemory)
        {
        }

        public override object AddPoint(MouseInformation mouseInformations)
        {
            Console.WriteLine("Default Command");
            FinishCommand();
            return "Last Start Command";
        }

        protected override object ControlCommand()
        {
            throw new NotImplementedException();
        }
    }
}
