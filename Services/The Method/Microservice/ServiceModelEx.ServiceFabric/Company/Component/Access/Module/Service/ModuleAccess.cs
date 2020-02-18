// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System.Collections.Generic;
using System.Threading.Tasks;

using Company.Access.Module.Interface;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.Fabric;
using ServiceModelEx.ServiceFabric;
using ServiceModelEx.ServiceFabric.Services.Communication.Runtime;
using ServiceModelEx.ServiceFabric.Services.Runtime;
using ServiceModelEx.ServiceFabric.Services.Remoting.FabricTransport.Runtime;
using ServiceModelEx.ServiceFabric.Services.Communication.FabricTransport.Runtime;
#else
using System.Fabric;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.FabricTransport.Runtime;
using Microsoft.ServiceFabric.Services.Communication.FabricTransport.Runtime;
#endif

namespace Company.Access.Module.Service
{
   #if ServiceModelEx_ServiceFabric
   [ApplicationManifest("Company.Microservice.Content","ModuleAccess")]
   #endif
   public class ModuleAccess : StatelessService,IModuleAccess
   {
      public ModuleAccess(StatelessServiceContext context) : base(context)
      {}

      protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
      {
         return new[] 
                {
                   new ServiceInstanceListener((context) => new FabricTransportServiceRemotingListener(context,this,new FabricTransportListenerSettings {EndpointResourceName = typeof(IModuleAccess).Name}),typeof(IModuleAccess).Name),
                };
      }

      public Task<string> BuildModuleAsync(string request)
      {
         return Task.FromResult(request + "\r\n      ModuleAccess.BuildModuleAsync");
      }
   }
}
