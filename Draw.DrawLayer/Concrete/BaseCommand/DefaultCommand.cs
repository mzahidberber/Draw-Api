using Draw.DrawLayer.Abstract;
using Draw.DrawLayer.Concrete.Model;

namespace Draw.DrawLayer.Concrete.BaseCommand
{
    internal class DefaultCommand : BaseCommanAbstract
    {
        public DefaultCommand(CommandData commandMemory) : base(commandMemory)
        {
        }

        protected override Task<ElementInformation> ControlCommand()
        {
            FinishCommand();
            return Task.FromResult(new ElementInformation { isTrue=false,message="Last Start Command!"});
        }
    }
}
