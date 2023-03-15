using Draw.Core.CrosCuttingConcers.Handling;
using Draw.DrawLayer.Abstract;
using Draw.Entities.Concrete;

namespace Draw.DrawLayer.Concrete.BaseCommand
{
    internal class DefaultCommand : BaseCommanAbstract
    {
        public DefaultCommand(CommandMemory commandMemory) : base(commandMemory)
        {
        }

        protected override Task<Element> ControlCommand()
        {
            FinishCommand();
            throw new CustomException("Last Start Command");
        }
    }
}
