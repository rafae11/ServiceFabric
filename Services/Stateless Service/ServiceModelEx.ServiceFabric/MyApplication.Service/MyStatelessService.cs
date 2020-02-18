// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System.Collections.Generic;
using System.Threading.Tasks;

using MyApplication.Interface;

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

namespace MyApplication.Service
{
   #if ServiceModelEx_ServiceFabric
   [ApplicationManifest("MyApplication.StatelessService","MyStatelessService")]
   #endif
   public class MyStatelessService : StatelessService,IMyStatelessService,IOtherStatelessService
   {
      public MyStatelessService(StatelessServiceContext context) : base(context)
      {}
      protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
      {
         return new[] 
                {
                   new ServiceInstanceListener((context) => new FabricTransportServiceRemotingListener(context,this,new FabricTransportListenerSettings {EndpointResourceName = typeof(IMyStatelessService).Name}),typeof(IMyStatelessService).Name),
                   new ServiceInstanceListener((context) => new FabricTransportServiceRemotingListener(context,this,new FabricTransportListenerSettings {EndpointResourceName = typeof(IOtherStatelessService).Name}),typeof(IOtherStatelessService).Name)
                };
      }
      public Task<string> MyMethodAsync(MyDataContract request)
      {
         return Task.FromResult("You said '" + request.MyValue + "'. I say hello!");
      }
      public Task<string> MyOtherMethodAsync(MyDataContract request)
      {
         return Task.FromResult("You said '" + request.MyValue + "'. I say hello again!");
      }
   }
}
