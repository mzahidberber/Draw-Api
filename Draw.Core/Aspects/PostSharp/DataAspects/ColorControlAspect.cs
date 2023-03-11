using Draw.Core.CrosCuttingConcers.Caching;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Draw.Core.Aspects.PostSharp.DataAspects
{
    [Serializable]
    public class ColorControlAspect: MethodInterceptionAspect
    {
        public override void RuntimeInitialize(MethodBase method)
        {
            
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
           
            base.OnInvoke(args);

        }
    }
}
