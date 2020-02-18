// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System.Collections.Generic;
using System.Threading.Tasks;

using ServiceModelEx.ServiceFabric.Services.Communication.Wcf.Runtime;

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

using MyApplication.Interface;

namespace MyApplication.Service
{
   #if ServiceModelEx_ServiceFabric
   [ApplicationManifest("MyApplication.StatelessService.Wcf","MyStatelessWcfService")]
   #endif
   public class MyStatelessWcfService : StatelessService,IMyStatelessWcfContract,IOtherMyStatelessWcfContract
   {
      public MyStatelessWcfService(StatelessServiceContext context) : base(context)
      {}

      protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
      {
         return WcfHelper.CreateListeners<MyStatelessWcfService>(this);
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
