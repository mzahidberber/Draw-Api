using Draw.Core.CrosCuttingConcers.Handling;
using Draw.DrawLayer.Abstract;
using Draw.DrawLayer.Concrete.BaseCommand;
using Draw.DrawLayer.Concrete.Elements;
using Draw.Entities.Concrete;

namespace Draw.DrawLayer.Concrete
{
    public class DrawAdminastor : IDrawAdminastor
    {
        private CommandMemory _commandMemory { get; set; }
        public DrawAdminastor(string userId)
        {
            _commandMemory = new CommandMemory(userId);
        }
        public DateTime GetUseTime() => _commandMemory.IsUseTime;
        public void SetRadius(double radius) => _commandMemory.SetRadius(radius);
        public void SetEditElementsId(List<int> editElementsId) => _commandMemory.SetEditElementsId(editElementsId);
        public Task StartCommandAsync(CommandEnums commandEnum, int DrawBoxId, int LayerId, int PenId)
        {
            if (!_commandMemory.IsWorkingCommand)
            {
                _commandMemory.SetData(LayerId,DrawBoxId, PenId);
                _commandMemory.SetSelectedCommand(GetCommandEnums(commandEnum));
                _commandMemory.SetIsWorkingCommand(true);
                return Task.CompletedTask;
            }
            throw new CustomException("Last Command Stop Or Finish!");
        }

        public async Task<Element> AddCoordinateAdminastorAsync(PointD point)
        {
            if (_commandMemory.IsWorkingCommand)
            {
                var command = _commandMemory.GetSelectedCommand();
                var element = await command.AddPointAsync(point);
                StopCommandControl();
                return element;
            }
            throw new CustomException("Last Start Command!");

        }
        public Task StopCommandAsync()
        {
            _commandMemory.SetDefaultCommand();
            _commandMemory.GetSelectedCommand().FinishCommand();
            _commandMemory.SetIsWorkingCommand(false);
            Console.WriteLine("Komut Durduruldu Stop");
            return Task.CompletedTask;
        }
        private void StopCommandControl()
        {
            if (!_commandMemory.IsWorkingCommand)
            {
                Console.WriteLine("Komut Durduruldu Control");
                _commandMemory.SetDefaultCommand();
                _commandMemory.SetIsWorkingCommand(false);
            }

        }

        private IBaseCommand GetCommandEnums(CommandEnums commandEnum)
        {
            var commandType = CommandsMultiton.GetCommand(commandEnum);
            var command = (BaseCommanAbstract?)Activator.CreateInstance(commandType, _commandMemory);
            return command != null ? command : throw new CustomException("Command Not Found!");
        }

    }

}
