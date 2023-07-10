using Draw.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.Entities.Concrete.Web
{
    public class Numbers:IEntity
    {
        public int Id { get; set; }
        public int DownloadNumber { get; set; }
        public int ClickNumber { get; set; }
    }
}
