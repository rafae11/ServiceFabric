// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System.Collections.Generic;
using System.Threading.Tasks;

using Company.Access.Module.Interface;
using Company.Access.User.Interface;
using Company.Engine.Transform.Interface;
using Company.Framework.Proxy;

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

namespace Company.Engine.Transform.Service
{
   #if ServiceModelEx_ServiceFabric
   [ApplicationManifest("Company.Microservice.Content","TransformEngine")]
   #endif
   public class TransformEngine : StatelessService,ITransformEngine
   {
      public TransformEngine(StatelessServiceContext context) : base(context)
      {}

      protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
      {
         return new[] 
                {
                   new ServiceInstanceListener((context) => new FabricTransportServiceRemotingListener(context,this,new FabricTransportListenerSettings {EndpointResourceName = typeof(ITransformEngine).Name}),typeof(ITransformEngine).Name),
                };
      }

      public async Task<string> ToResponseAsync(string request)
      {
         string response = request + "\r\n    TransformEngine.ToResponseAsync->";

         IUserAccess userAccess = Proxy.ForComponent<IUserAccess>(this);
         string profileResponse = await userAccess.AssembleProfileAsync(response);

         IModuleAccess moduleAccess = Proxy.ForComponent<IModuleAccess>(this);
         string buildResponse = await moduleAccess.BuildModuleAsync(profileResponse);

         return buildResponse;
      }
   }
}
