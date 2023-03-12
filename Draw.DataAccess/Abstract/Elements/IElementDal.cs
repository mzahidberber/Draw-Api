using Draw.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.DataAccess.Abstract.Elements
{
    public interface IElementDal : IEntityRepository<Element>
    {
    }
}
