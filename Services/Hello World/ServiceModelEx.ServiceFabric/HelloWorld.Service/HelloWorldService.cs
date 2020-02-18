// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System.Collections.Generic;
using System.Threading.Tasks;

using HelloWorld.Interface;

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

namespace HelloWorld.Service
{
   #if ServiceModelEx_ServiceFabric
   [ApplicationManifest("HelloWorld.StatelessService","HelloWorldService")]
   #endif
   public class HelloWorldService : StatelessService,IHelloWorldService
   {
      public HelloWorldService(StatelessServiceContext context) : base(context)
      {}

      protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
      {
         return new[] 
                {
                   new ServiceInstanceListener((context) => new FabricTransportServiceRemotingListener(context,this,new FabricTransportListenerSettings {EndpointResourceName = typeof(IHelloWorldService).Name}),typeof(IHelloWorldService).Name)
                };
      }
      public Task<string> SayHelloAsync(string message)
      {
         return Task.FromResult("You said " + message + ". I say hello world!");
      }
   }
}
