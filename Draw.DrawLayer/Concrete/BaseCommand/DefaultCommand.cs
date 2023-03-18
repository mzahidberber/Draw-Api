using Draw.DrawLayer.Abstract;

namespace Draw.DrawLayer.Concrete.BaseCommand
{
    internal class DefaultCommand : BaseCommanAbstract
    {
        public DefaultCommand(CommandMemory commandMemory) : base(commandMemory)
        {
        }

        protected override Task<ElementInformation> ControlCommand()
        {
            FinishCommand();
            return Task.FromResult(new ElementInformation { isTrue=false,message="Last Start Command!"});
        }
    }
}
