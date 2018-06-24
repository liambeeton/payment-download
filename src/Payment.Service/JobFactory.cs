﻿using FluentScheduler;
using Ninject;

namespace Payment.Service
{
    public class JobFactory : IJobFactory
    {
        private IKernel Kernel { get; }

        public JobFactory(IKernel kernel)
        {
            Kernel = kernel;
        }

        public IJob GetJobInstance<T>() where T : IJob
        {
            return Kernel.Get<T>();
        }
    }
}
