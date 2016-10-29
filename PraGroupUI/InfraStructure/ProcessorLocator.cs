using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

namespace PraGroupUI
{
    public class ProcessorLocator : IProcessorLocator
    {
        public T GetProcessor<T>()
        {
             return MvcApplication.container.Resolve<T>();
        }


        public T GetProcessor<T>(string Name)
        {
            return MvcApplication.container.Resolve<T>(Name);
        }
    }
}