using Draw.DataAccess.Abstract.Commands;
using Draw.DrawManager.Concrete.BaseCommand;
using Draw.DrawManager.Concrete.HelperCommands;
using Draw.Entities.Concrete.Elements;
using Draw.Manager.Concrete.DrawElements;

namespace Draw.DrawManager.Concrete
{
    public class DrawManager
    {
        private string _userName { get; set; }

        private CommandContext _commandContext;
        
        private CommandMemory _commandMemory;
        
        public DrawManager(string userName)
        {
            this._userName = userName;


            _commandMemory= new CommandMemory(DrawMemoryMultiton.GetDrawMemory(this._userName), this._userName);
            
            _commandContext= new CommandContext(_commandMemory);


            

        }
        public object StartCommand(CommandEnums commandEnum,int userDrawBoxId,int userLayerId,int userPenId)
        {
            if (!_commandMemory.IsWorkingCommand)
            {
                SetCommandMemoryValues(userDrawBoxId,userLayerId,userPenId); 
                var command = GetCommandEnumsToCommand(commandEnum);
                SetContext(command);
                _commandMemory.SetIsWorkingCommand(true);
                //Console.WriteLine($"komut başladı DrawBaseManager {_userDrawBoxId} id li box {_userLayerId} id li layer");
                return $"komut başladı DrawBaseManager {userDrawBoxId} id li box {userLayerId} id li layer";
            }else
            {
                return "Working Command,Should Stop Command or Finish Command";
            }
            
        }

        public bool GetIsWorkingCommand() { return _commandMemory.IsWorkingCommand; }

        public void SetSnapPoints(HelperEnums snapPoint , bool openOrClose) => _commandMemory.SetSnapPoint(snapPoint , openOrClose);
       
        
       
        public void AddRadius(double radius) => _commandMemory.SetRadius(radius);
        
        public void AddEditElementsId(List<int> editElementsId) => _commandMemory.SetEditElementsId(editElementsId);

        private void SetCommandMemoryValues(int userDrawBoxId, int userLayerId, int userPenId)
        {
            this._commandMemory.SetLayerId(userLayerId);
            this._commandMemory.SetPen(userPenId);
            this._commandMemory.SetDrawBoxId(userDrawBoxId);
        }
        public void StopCommand()
        {
            _commandContext.SetContextDefaultCommand();
            _commandContext.GetCommand().FinishCommand();
            _commandMemory.SetIsWorkingCommand(false);
            Console.WriteLine("Komut Durduruldu Stop");
        }
        public object AddCoordinate(MouseInformation mouseInformation)
        {
            if(_commandMemory.IsWorkingCommand)
            {
                var command = _commandContext.GetCommand();
                var element = command.AddPoint(mouseInformation);
                StopCommandControl();
                return element;
            }
            else
            {
                return "Last Start Command!!";
            }
            
        }

        public object GetLayers(int userDrawBoxId)
        {
            return _commandMemory.DrawMemory.GetLayers(userDrawBoxId);
        }

        public object GetElements(int userDrawBoxId)
        {
            return _commandMemory.DrawMemory.GetElements(userDrawBoxId);
        }

        public object GetColors()
        {
            return _commandMemory.DrawMemory.GetColors();
        }
        public object GetDrawBoxes()
        {
            return _commandMemory.DrawMemory.GetDrawBoxes();
        }

        public object GetPenStyles()
        {
            return _commandMemory.DrawMemory.GetPenStyles();
        }
        public object GetPens()
        {
            return _commandMemory.DrawMemory.GetPens();
        }

        private IBaseCommand GetCommandEnumsToCommand(CommandEnums commandEnum) 
        {
            var commandType = CommandsMultiton.GetCommand(commandEnum);
            var command=(BaseCommanAbstract?)Activator.CreateInstance(commandType,this._commandMemory);
            //command.SetCommandMemory(this._commandMemory);
            return command!=null ? command : throw new NullReferenceException();
        }

        
        private void StopCommandControl()
        {
            if(!_commandMemory.IsWorkingCommand) 
            {
                Console.WriteLine("Komut Durduruldu Control");
                _commandContext.SetContextDefaultCommand();
                _commandMemory.SetIsWorkingCommand(false);
            }
        }

        private void SetContext(IBaseCommand command)
        {
            _commandContext.SetCommand(command);
            //_commandsList.Add(command);
        }

        

    }

}
