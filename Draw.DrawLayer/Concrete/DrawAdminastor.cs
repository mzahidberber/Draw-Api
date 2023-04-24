using Draw.Core.CrosCuttingConcers.Handling;
using Draw.DrawLayer.Abstract;
using Draw.DrawLayer.Concrete.BaseCommand;
using Draw.DrawLayer.Concrete.FileCommands;
using Draw.DrawLayer.Concrete.Model;
using Draw.Entities.Concrete;

namespace Draw.DrawLayer.Concrete
{
    public class DrawAdminastor : IDrawAdminastor
    {
        private CommandData _commandData { get; set; }
        public DrawAdminastor(string userId)
        {
            _commandData = new CommandData(userId);
        }
        public DateTime GetUseTime() => _commandData.IsUseTime;

        public async Task SaveElements(List<Element> elements)
        {
            await SaveCommand.SaveElementsAsync(elements);
        }

        public Task SetIsFinishAsync(bool finish=true)
        {
            _commandData.SetIsFinish(finish);
            return Task.CompletedTask;
        }
        public Task SetRadiusAsync(double radius) 
        {
            _commandData.SetUseTimeNow();
            _commandData.SetRadius(radius);
            return Task.CompletedTask;
        }
        public Task SetEditElementsIdAsync(List<int> editElementsId) 
        {
            _commandData.SetUseTimeNow();
            _commandData.SetEditElementsId(editElementsId);
            return Task.CompletedTask;
        } 
        
        public Task StartCommandAsync(CommandEnums commandEnum, int DrawBoxId, int LayerId, int PenId)
        {
            if (!_commandData.IsWorkingCommand)
            {
                Console.WriteLine($"Start Command {commandEnum}");
                _commandData.SetUseTimeNow();
                _commandData.SetData(LayerId,DrawBoxId, PenId);
                _commandData.SetSelectedCommand(GetCommandEnums(commandEnum));
                _commandData.SetIsWorkingCommand(true);
                return Task.CompletedTask;
            }
            return Task.FromResult(new ElementInformation { isTrue = false, message = "Last Command Stop Or Finish!" });
        }

        public async Task<ElementInformation> AddCoordinateAdminastorAsync(PointD point)
        {
            if (_commandData.IsWorkingCommand)
            {
                _commandData.SetUseTimeNow();
                var command = _commandData.GetSelectedCommand();
                var element = await command.AddPointAsync(point);
                StopCommandControl();
                return element;
            }
            return new ElementInformation { isTrue = false, message = "Last Start Command" };

        }
        public Task StopCommandAsync()
        {
            _commandData.SetUseTimeNow();
            _commandData.SetDefaultCommand();
            _commandData.GetSelectedCommand().FinishCommand();
            _commandData.SetIsWorkingCommand(false);
            Console.WriteLine("Komut Durduruldu Stop");
            return Task.CompletedTask;
        }
        private void StopCommandControl()
        {
            if (!_commandData.IsWorkingCommand)
            {
                _commandData.SetUseTimeNow();
                Console.WriteLine("Komut Durduruldu Control");
                _commandData.SetDefaultCommand();
                _commandData.SetIsWorkingCommand(false);
            }

        }

        private IBaseCommand GetCommandEnums(CommandEnums commandEnum)
        {
            var commandType = CommandsMultiton.GetCommand(commandEnum);
            var command = (BaseCommanAbstract?)Activator.CreateInstance(commandType, _commandData);
            return command != null ? command : throw new CustomException("Command Not Found!");
        }

       
    }

}
