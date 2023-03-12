using Draw.DataAccess.Abstract;
using Draw.DataAccess.Concrete.EntityFramework;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Concrete;

namespace Draw.DrawManager.Concrete
{
    public class DrawMemory
    {
        private List<DrawBox> _drawBoxes;
        private List<Layer> _layers;
        private List<Element> _elements;

        private IElementDal _efElementDal = DataInstanceFactory.GetInstance<IElementDal>();
        private IDrawBoxDal _efDrawBoxDal = DataInstanceFactory.GetInstance<IDrawBoxDal>();
        private ILayerDal _efLayerDal = DataInstanceFactory.GetInstance<ILayerDal>();
        private IColorDal _efColorDal = DataInstanceFactory.GetInstance<IColorDal>();
        private IPenStyleDal _efPenStylesDal = DataInstanceFactory.GetInstance<IPenStyleDal>();
        private IPenDal _efPenDal = DataInstanceFactory.GetInstance<IPenDal>();

        public DrawMemory(string userName)
        {
            this._elements = new List<Element>();
            this._layers = new List<Layer>();
            //this._drawBoxes = GetUserDrawBoxes(userName);
            //foreach (var drawBox in _drawBoxes)
            //{
            //    _layers.AddRange(GetUserLayers(drawBox.DrawBoxId));
            //}
        }
        public void AddElement(Element element)
        {
            //_efElementDal.AddElementAll(element);
            //GetElement(element);
            this._elements.Add(element);
        }

        internal void SetElements(List<Element> elements)
        {
            //Burayı yaz movedan geldi
        }

        internal void AddElements(List<Element> elements)
        {
            //Burayı yaz copy geldi
        }

        internal List<Element> GetElementsId(List<int> elementsIdList)
        {
            //return _efElementDal.GetElementBesidePoints(elementsIdList);
            throw new NotImplementedException();
        }

        //public object GetLayers(int userDrawBoxId)
        //{
        //    return _efLayerDal.GetLayersAndPen(userDrawBoxId);
        //}
        //public object GetElements(int userDrawBoxId)
        //{
        //    return _efElementDal.GetElementsInDrawBox(userDrawBoxId) ?? throw new NullReferenceException();
        //}


        //public object GetDrawBoxes()
        //{
        //    return _efDrawBoxDal.GetAll();
        //}
        //public object GetColors()
        //{
        //    return _efColorDal.GetAll();
        //}

        //public object GetPenStyles()
        //{
        //    return _efPenStylesDal.GetAll();
        //}

        //public object GetPens()
        //{
        //    return _efPenDal.GetPensColorAndPenStyle();
        //}
        //public object GetElement(Element element)
        //{
        //    return _efElementDal.GetElementBesidePointsAndLayer(element) ?? throw new NullReferenceException();
        //}



        public void AddDrawBox(DrawBox drawBox)=> this._drawBoxes.Add(drawBox);
        //public void AddLayer(Layer layer)
        //{
        //    this._efLayerDal.Add(layer);
        //    this._layers.Add(layer);
        //}

        

        //public List<DrawBox> GetUserDrawBoxes(string userName)
        //{
        //    return _efDrawBoxDal.GetAll(d => d.User.UserName == userName).ToList();
        //}
        //public List<Layer> GetUserLayers(int drawBoxId)
        //{
        //    return _efLayerDal.GetAll(d => d.DrawBoxId == drawBoxId).ToList();
        //}
    }
}
