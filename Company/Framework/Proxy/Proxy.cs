// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Diagnostics;

using Company.Framework.Common;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.ServiceFabric.Actors;
using ServiceModelEx.ServiceFabric.Actors.Client;
using ServiceModelEx.ServiceFabric.Actors.Runtime;
using ServiceModelEx.ServiceFabric.Services.Remoting;
using ServiceModelEx.ServiceFabric.Services.Remoting.Client;
using ServiceModelEx.ServiceFabric.Services.Runtime;
#else
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.ServiceFabric.Actors.Runtime;
using Microsoft.ServiceFabric.Services.Remoting;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Microsoft.ServiceFabric.Services.Runtime;
#endif

namespace Company.Framework.Proxy
{
   public class Proxy
   {
      static I Create<I>(Uri serviceAddress) where I : class,IService
      {
         Debug.Assert(typeof(I).IsInterface);
         return ServiceProxy.Create<I>(serviceAddress,listenerName:Naming.Listener<I>());
      }
      public static I ForMicroservice<I>() where I : class,IService
      {
         Debug.Assert(typeof(I).Namespace.Contains("Manager"), "Invalid microservice call. Use only the Manager interface to access a microservice.");
         return Create<I>(Addressing.Microservice<I>());
      }
      public static I ForComponent<I>(StatelessService caller) where I : class,IService
      {
         Debug.Assert(caller != null,"Invalid component call. Must supply stateless service caller.");
         return Create<I>(Addressing.Component<I>(caller));
      }

      static I ForActor<I>(string instanceName,Actor caller) where I : class,IActor
      {
         Debug.Assert(typeof(I).IsInterface);

         Uri actorAddress = Addressing.ActorAddress<I>(caller);
         return ActorProxy.Create<I>(new ActorId(instanceName),actorAddress);
      }
      public static I ForAccessor<I>(string instanceName) where I : class,IActor
      {
         Debug.Assert(typeof(I).Namespace.Contains("Accessor"), "Invalid resource call. Use only the Accesor interface to access a resource.");
         return ForActor<I>(instanceName,null);
      }
      public static I ForNode<I>(string instanceName,Actor caller) where I : class,IActor
      {
         Debug.Assert(caller != null,"Invalid node call. Must supply stateful actor caller.");
         return ForActor<I>(instanceName,caller);
      }
   }
}
