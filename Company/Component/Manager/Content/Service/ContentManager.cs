// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System.Collections.Generic;
using System.Threading.Tasks;

using Company.Framework.Proxy;
using Company.Engine.Transform.Interface;
using Company.Engine.Validation.Interface;
using Company.Manager.Content.Interface;

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

namespace Company.Manager.Content.Service
{
   #if ServiceModelEx_ServiceFabric
   [ApplicationManifest("Company.Microservice.Content","ContentManager")]
   #endif
   public class ContentManager : StatelessService,IContentManager
   {
      public ContentManager(StatelessServiceContext context) : base(context)
      {}

      protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
      {
         return new[] 
                {
                   new ServiceInstanceListener((context) => new FabricTransportServiceRemotingListener(context,this,new FabricTransportListenerSettings {EndpointResourceName = typeof(IContentManager).Name}),typeof(IContentManager).Name),
                };
      }

      public async Task<string> RequestContentAsync(string request)
      {
         string response = request + "\r\n  ContentManager.RequestContent->";

         IValidationEngine validationEngine = Proxy.ForComponent<IValidationEngine>(this);
         string validationResponse = await validationEngine.ConfirmRequestAsync(response);

         ITransformEngine transformEngine = Proxy.ForComponent<ITransformEngine>(this);
         string transformResponse = await transformEngine.ToResponseAsync(validationResponse);

         return transformResponse;
      }
   }
}
