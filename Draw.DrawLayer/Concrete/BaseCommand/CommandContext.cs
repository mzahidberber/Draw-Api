using Draw.Core.DrawLayer.Abstract;
using Draw.DrawLayer.Abstract;

namespace Draw.DrawLayer.Concrete.BaseCommand
{
    internal class CommandContext
    {
        private IBaseCommand _command;

        private DefaultCommand _defaultcommand;

        public CommandContext(ICommandData commandMemory)
        {
            this._defaultcommand= new DefaultCommand(commandMemory);
            _command = this._defaultcommand;
        }
        
        public void SetCommand(IBaseCommand command)
        {
            _command = command;
        }

        public IBaseCommand GetCommand()
        {
            return _command;
        }

        public void SetContextDefaultCommand() => this._command = this._defaultcommand;
    }
}
