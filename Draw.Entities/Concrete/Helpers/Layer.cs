using Draw.Entities.Abstract;
using Draw.Entities.Concrete.Draw;
using Draw.Entities.Concrete.Elements;
using System.Collections.Generic;

namespace Draw.Entities.Concrete.Helpers
{
    public class Layer:IEntity
    {
        public Layer()
        {
            this.Elements=new List<Element>();
        }

        public int LayerId { get; set; }
        public string LayerName { get; set; }= null!;
        public bool LayerLock { get; set; }
        public bool LayerVisibility { get; set; }
        public float LayerThickness { get; set; }
        
        public int DrawBoxId { get; set; }
        public DrawBox? DrawBox { get; set; }

        public int PenId { get; set; }
        public Pen? Pen { get; set; }

        public List<Element> Elements { get; set; }
    }
}
