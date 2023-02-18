using Draw.Entities.Abstract;
using Draw.Entities.Concrete.Elements;
using System.Collections.Generic;

namespace Draw.Entities.Concrete.Helpers
{
    public class ElementType:IEntity
    {
        public ElementType()
        {
            this.Elements=new List<Element>();
        }
        public int ElementTypeId { get; set; }
        public string ElementTypeName { get; set; }= null!;

        public List<Element> Elements { get; set; }
    }
}
