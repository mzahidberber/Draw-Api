using Draw.Entities.Abstract;
using System.Collections.Generic;

namespace Draw.Entities.Concrete
{
    public class ElementType : IEntity
    {
        public ElementType()
        {
            Elements = new List<Element>();
        }
        public int ElementTypeId { get; set; }
        public string ElementTypeName { get; set; } = null!;

        public List<Element> Elements { get; set; }
    }
}
