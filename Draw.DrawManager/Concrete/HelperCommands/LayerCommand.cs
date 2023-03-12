using Draw.DrawManager.Concrete.BaseCommand;
using Draw.Entities.Concrete;

namespace Draw.DrawManager.Concrete.HelperCommands
{
    internal class LayerCommand
    {
        private CommandMemory _commandMemory { get; set; }
        internal void SetCommandMemory(CommandMemory commandMemory) => this._commandMemory = commandMemory;

        internal LayerCommand(CommandMemory commadMemory)
        {
            this._commandMemory=commadMemory;
        }

        internal void AddLayer(Layer layer)
        {

        }
        internal void DeleteLayer(Layer layer)
        {

        }

        internal void SetLayerPen(Pen pen)
        {

        }



    }
}
