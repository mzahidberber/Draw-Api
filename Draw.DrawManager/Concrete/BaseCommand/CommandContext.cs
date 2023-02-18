using Draw.DataAccess.Abstract.Commands;

namespace Draw.DrawManager.Concrete.BaseCommand
{
    internal class CommandContext
    {
        private IBaseCommand _command;

        private DefaultCommand _defaultcommand;

        public CommandContext(CommandMemory commandMemory)
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
