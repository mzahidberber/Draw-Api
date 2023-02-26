using Draw.Entities.Concrete.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.DataAccess.Abstract.Elements
{
    internal interface IElementDal : IEntityRepository<Element>
    {
    }
}
