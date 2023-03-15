using Draw.DataAccess.Abstract;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.DrawLayer.Abstract.Commands;
using Draw.DrawLayer.Concrete.BaseCommand;
using Draw.DrawLayer.Concrete.DrawElements;

namespace Draw.DrawLayer.Concrete
{
    public class DrawM
    {
        private string _userName { get; set; }
        private CommandContext _commandContext;
        private CommandMemory _commandMemory;

        private IElementDal _efElementDal = DataInstanceFactory.GetInstance<IElementDal>();
        private IDrawBoxDal _efDrawBoxDal = DataInstanceFactory.GetInstance<IDrawBoxDal>();
        private ILayerDal _efLayerDal = DataInstanceFactory.GetInstance<ILayerDal>();
        private IColorDal _efColorDal = DataInstanceFactory.GetInstance<IColorDal>();
        private IPenStyleDal _efPenStylesDal = DataInstanceFactory.GetInstance<IPenStyleDal>();
        private IPenDal _efPenDal = DataInstanceFactory.GetInstance<IPenDal>();
        public DrawM(string userName)
        {
            _userName = userName;
            _commandMemory = new CommandMemory(DrawMemoryMultiton.GetDrawMemory(_userName), _userName);
            _commandContext = new CommandContext(_commandMemory);
        }
        public object StartCommand(CommandEnums commandEnum, int userDrawBoxId, int userLayerId, int userPenId)
        {
            if (!_commandMemory.IsWorkingCommand)
            {
                SetCommandMemoryValues(userDrawBoxId, userLayerId, userPenId);
                var command = GetCommandEnumsToCommand(commandEnum);
                SetContext(command);
                _commandMemory.SetIsWorkingCommand(true);
                //Console.WriteLine($"komut başladı DrawBaseManager {_userDrawBoxId} id li box {_userLayerId} id li layer");
                return $"komut başladı DrawBaseManager {userDrawBoxId} id li box {userLayerId} id li layer";
            }
            else
            {
                return "Working Command,Should Stop Command or Finish Command";
            }

        }

        public bool GetIsWorkingCommand() { return _commandMemory.IsWorkingCommand; }

        public void SetSnapPoints(HelperEnums snapPoint, bool openOrClose) => _commandMemory.SetSnapPoint(snapPoint, openOrClose);



        public void AddRadius(double radius) => _commandMemory.SetRadius(radius);

        public void AddEditElementsId(List<int> editElementsId) => _commandMemory.SetEditElementsId(editElementsId);

        private void SetCommandMemoryValues(int userDrawBoxId, int userLayerId, int userPenId)
        {
            _commandMemory.SetLayerId(userLayerId);
            _commandMemory.SetPen(userPenId);
            _commandMemory.SetDrawBoxId(userDrawBoxId);
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
            if (_commandMemory.IsWorkingCommand)
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

        //public object GetLayers(int userDrawBoxId)
        //{
        //    return _commandMemory.DrawMemory.GetLayers(userDrawBoxId);
        //}

        //public async object AddLayer(int userDrawBoxId, Layer layer)
        //{
        //    await _efLayerDal.AddAsync(layer);
        //    return true;
        //}

        //public object DeleteLayer(int userDrawBoxId, int layerId)
        //{
        //    _efLayerDal.DeleteFromId(layerId);
        //    return true;
        //}

        //public object UpdateLayer(int userDrawBoxId, Layer layer)
        //{
        //    _efLayerDal.Update(layer);
        //    return true;
        //}

        //public object GetElements(int userDrawBoxId)
        //{
        //    return _commandMemory.DrawMemory.GetElements(userDrawBoxId);
        //}

        //public object GetColors()
        //{
        //    return _commandMemory.DrawMemory.GetColors();
        //}
        //public object GetDrawBoxes()
        //{
        //    return _commandMemory.DrawMemory.GetDrawBoxes();
        //}

        //public object GetPenStyles()
        //{
        //    return _commandMemory.DrawMemory.GetPenStyles();
        //}
        //public object GetPens()
        //{
        //    return _commandMemory.DrawMemory.GetPens();
        //}

        private IBaseCommand GetCommandEnumsToCommand(CommandEnums commandEnum)
        {
            var commandType = CommandsMultiton.GetCommand(commandEnum);
            var command = (BaseCommanAbstract?)Activator.CreateInstance(commandType, _commandMemory);
            //command.SetCommandMemory(this._commandMemory);
            return command != null ? command : throw new NullReferenceException();
        }


        private void StopCommandControl()
        {
            if (!_commandMemory.IsWorkingCommand)
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
