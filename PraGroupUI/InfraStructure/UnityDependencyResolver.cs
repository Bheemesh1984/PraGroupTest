using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace PraGroupUI.InfraStructure
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer unitycontainer;
        public UnityDependencyResolver(IUnityContainer container)
        {
            unitycontainer = container;
        }
        public object GetService(Type serviceType)
        {
            try
            {
                return unitycontainer.Resolve(serviceType);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return unitycontainer.ResolveAll(serviceType);
            }
            catch { return null; };
        }
    }
}