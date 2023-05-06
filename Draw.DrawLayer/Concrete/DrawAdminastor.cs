using Draw.Core.Aspects.PostSharp.LoggingAspects;
using Draw.Core.CrosCuttingConcers.Handling;
using Draw.Core.CrosCuttingConcers.Logging.Nlog;
using Draw.DrawLayer.Abstract;
using Draw.DrawLayer.Concrete.BaseCommand;
using Draw.DrawLayer.Concrete.FileCommands;
using Draw.DrawLayer.Concrete.Model;
using Draw.Entities.Concrete;

namespace Draw.DrawLayer.Concrete
{

    public class DrawAdminastor : IDrawAdminastor,ILog
    {
        public CommandData _commandData { get; set; }
        public DrawAdminastor(string userId)
        {
            _commandData = new CommandData(userId);
        }

        public string GetUserId() => _commandData.UserId;
        public string GetUserName() => "";
        public DateTime GetUseTime() => _commandData.IsUseTime;

        public async Task SaveElements(List<Element> elements)
        {
            await SaveCommand.SaveElementsAsync(elements);
        }
        [LogAspect]
        public async Task<ElementInformation> SetIsFinishAsync(bool finish=true)
        {
            _commandData.SetIsFinish(finish);
            var command = _commandData.GetSelectedCommand();
            var data= await command.ControlCommandAsync();
            await this.StopCommandAsync();
            _commandData.SetIsFinish(false);
            return data;
        }
        [LogAspect]
        public Task SetRadiusAsync(double radius) 
        {
            //logger.Info($"User:{_commandData.UserId} Set Radius {radius}");
            _commandData.SetUseTimeNow();
            _commandData.SetRadius(radius);
            return Task.CompletedTask;
        }
        [LogAspect]
        public Task SetEditElementsIdAsync(List<int> editElementsId) 
        {
            _commandData.SetUseTimeNow();
            _commandData.SetEditElementsId(editElementsId);
            return Task.CompletedTask;
        }
        [LogAspect]
        public Task StartCommandAsync(CommandEnums commandEnum, int DrawBoxId, int LayerId, int PenId)
        {
            if (!_commandData.IsWorkingCommand)
            {
                _commandData.SetUseTimeNow();
                _commandData.SetData(LayerId,DrawBoxId, PenId);
                _commandData.SetSelectedCommand(GetCommandEnums(commandEnum));
                _commandData.SetIsWorkingCommand(true);
                return Task.CompletedTask;
            }
            return Task.FromResult(new ElementInformation { isTrue = false, message = "Last Command Stop Or Finish!" });
        }
        [LogAspect]
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
        [LogAspect]
        public Task StopCommandAsync()
        {
            _commandData.SetUseTimeNow();
            _commandData.SetDefaultCommand();
            _commandData.GetSelectedCommand().FinishCommand();
            _commandData.SetIsWorkingCommand(false);
            return Task.CompletedTask;
        }
        [LogAspect]
        private void StopCommandControl()
        {
            if (!_commandData.IsWorkingCommand)
            {
                _commandData.SetUseTimeNow();
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
