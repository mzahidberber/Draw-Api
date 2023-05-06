using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.Core.CrosCuttingConcers.Logging.Nlog
{
    public interface ILog 
    {
        string GetUserId();
        string GetUserName();
    }
}
