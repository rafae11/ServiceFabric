// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System.Collections.Generic;
using System.Threading.Tasks;

using ServiceModelEx.ServiceFabric.Services.Communication.Wcf.Runtime;
using HelloWorld.Interface;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.Fabric;
using ServiceModelEx.ServiceFabric;
using ServiceModelEx.ServiceFabric.Services.Communication.Runtime;
using ServiceModelEx.ServiceFabric.Services.Runtime;
#else
using System.Fabric;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
#endif

namespace HelloWorld.Service
{
   #if ServiceModelEx_ServiceFabric
   [ApplicationManifest("HelloWorld.StatelessService.Wcf","HelloWorldService")]
   #endif
   public class HelloWorldService : StatelessService,IHelloWorldService
   {
      public HelloWorldService(StatelessServiceContext context) : base(context)
      {}

      protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
      {
         return WcfHelper.CreateListeners<HelloWorldService>(this);
      }
      public Task<string> SayHelloAsync(string message)
      {
         return Task.FromResult("You said " + message + ". I say hello world!");
      }
   }
}
