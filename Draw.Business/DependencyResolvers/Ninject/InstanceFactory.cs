﻿using Ninject;

namespace Draw.Business.DependencyResolvers.Ninject
{
    public class BusinessInstanceFactory
    {
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new BusinessModule());
            return kernel.Get<T>();
        }
    }
}
