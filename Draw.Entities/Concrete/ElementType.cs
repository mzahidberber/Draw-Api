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
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Element> Elements { get; set; }
    }
}
