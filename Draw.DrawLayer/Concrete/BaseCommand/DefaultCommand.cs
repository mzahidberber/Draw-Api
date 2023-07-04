using Draw.Core.DrawLayer.Abstract;
using Draw.Core.DrawLayer.Model;
using Draw.DrawLayer.Abstract;

namespace Draw.DrawLayer.Concrete.BaseCommand
{
    internal class DefaultCommand : BaseCommanAbstract
    {
        public DefaultCommand(ICommandData commandMemory) : base(commandMemory)
        {
        }

        public override Task<ElementInformation> ControlCommandAsync()
        {
            FinishCommand();
            return Task.FromResult(new ElementInformation { isTrue=false,message="Last Start Command!"});
        }
    }
}
