using System;
using System.Collections.Generic;
using System.Linq;
using Autofac.Builder;
using Autofac.Core;

namespace Business.DependencyInjection
{
    public class CmsRegistrationSource : IRegistrationSource
    {
        public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
        {
            if (registrationAccessor(service).Any())
            {
                return Enumerable.Empty<IComponentRegistration>();
            }

            if (!(service is IServiceWithType swt))
            {
                return Enumerable.Empty<IComponentRegistration>();
            }

            object instance = null;
            if (CMS.Core.Service.IsRegistered(swt.ServiceType))
            {
                instance = CMS.Core.Service.Resolve(swt.ServiceType);
            }

            if (instance == null)
            {
                return Enumerable.Empty<IComponentRegistration>();
            }

            return new[]
            {
                RegistrationBuilder.ForDelegate(swt.ServiceType, (c, p) => instance).CreateRegistration()
            };
        }

        public bool IsAdapterForIndividualComponents => false;
    }
}
