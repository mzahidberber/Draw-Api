using Draw.DataAccess.Concrete.EntityFramework.Draws;
using Draw.DataAccess.Concrete.EntityFramework.Elements;
using Draw.DataAccess.Concrete.EntityFramework.Helpers;
using Draw.Entities.Concrete.Draw;
using Draw.Entities.Concrete.Elements;
using Draw.Entities.Concrete.Helpers;

namespace Draw.DrawManager.Concrete
{
    public class DrawMemory
    {
        private List<DrawBox> _drawBoxes;
        private List<Layer> _layers;
        private List<Element> _elements;
        
        private EfElementsDal _efElementDal = new EfElementsDal();
        private EfDrawBoxDal _efDrawBoxDal = new EfDrawBoxDal();
        private EfLayerDal _efLayerDal = new EfLayerDal();
        private EfColorDal _efColorDal = new EfColorDal();
        private EfPenStyleDal _efPenStylesDal = new EfPenStyleDal();
        private EfPenDal _efPenDal = new EfPenDal();

        public DrawMemory(string userName)
        {
            this._elements = new List<Element>();
            this._layers = new List<Layer>();
            this._drawBoxes = GetUserDrawBoxes(userName);
            foreach (var drawBox in _drawBoxes)
            {
                _layers.AddRange(GetUserLayers(drawBox.DrawBoxId));
            }
        }
        public void AddElement(Element element)
        {
            _efElementDal.AddElementAll(element);
            GetElement(element);
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
            return _efElementDal.GetElementBesidePoints(elementsIdList);
        }

        public object GetLayers(int userDrawBoxId)
        {
            return _efLayerDal.GetLayersAndPen(userDrawBoxId);
        }
        public object GetElements(int userDrawBoxId)
        {
            return _efElementDal.GetElementsInDrawBox(userDrawBoxId) ?? throw new NullReferenceException();
        }


        public object GetDrawBoxes()
        {
            return _efDrawBoxDal.GetAll();
        }
        public object GetColors()
        {
            return _efColorDal.GetAll();
        }

        public object GetPenStyles()
        {
            return _efPenStylesDal.GetAll();
        }

        public object GetPens()
        {
            return _efPenDal.GetPensColorAndPenStyle();
        }
        public object GetElement(Element element)
        {
            return _efElementDal.GetElementBesidePointsAndLayer(element) ?? throw new NullReferenceException();
        }



        public void AddDrawBox(DrawBox drawBox)=> this._drawBoxes.Add(drawBox);
        public void AddLayer(Layer layer) => this._layers.Add(layer);

        public List<DrawBox> GetUserDrawBoxes(string userName)
        {
            return _efDrawBoxDal.GetAll(d => d.User.UserName == userName).ToList();
        }
        public List<Layer> GetUserLayers(int drawBoxId)
        {
            return _efLayerDal.GetAll(d => d.DrawBoxId == drawBoxId).ToList();
        }
    }
}
