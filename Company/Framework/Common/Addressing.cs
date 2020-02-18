// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Diagnostics;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.ServiceFabric.Actors;
using ServiceModelEx.ServiceFabric.Actors.Runtime;
using ServiceModelEx.ServiceFabric.Services.Remoting;
using ServiceModelEx.ServiceFabric.Services.Runtime;
#else
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using Microsoft.ServiceFabric.Services.Remoting;
using Microsoft.ServiceFabric.Services.Runtime;
#endif

namespace Company.Framework.Common
{
   public static class Addressing
   {
      public static Uri Microservice<I>() where I : IService
      {
         Debug.Assert(typeof(I).IsInterface);
         Debug.Assert(typeof(I).Namespace.Contains("Manager"), "Invalid microservice interface. Use only the Manager interface to access a microservice.");

         string[] namespaceSegments = typeof(I).Namespace.Split('.');
         Uri serviceUri = new Uri("fabric:/" + Naming.Microservice<I>() + "/" + Naming.Component<I>());
         return serviceUri;
      }
      public static Uri Component<I>(StatelessService caller) where I : IService
      {
         Debug.Assert(typeof(I).IsInterface);
         Debug.Assert(caller != null);
         Debug.Assert(caller.Context != null);
         Debug.Assert(caller.Context.ServiceName != null);

         string[] namespaceSegments = caller.Context.ServiceName.Segments;
         Uri serviceUri = new Uri("fabric:/" + namespaceSegments[1] + Naming.Component<I>());
         return serviceUri;
      }
      public static Uri ActorAddress<I>() where I : IActor
      {
         return ActorAddress<I>(null);
      }
      public static Uri ActorAddress<I>(Actor caller) where I : IActor
      {
         Debug.Assert(typeof(I).IsInterface);

         string[] namespaceSegments = null;
         Uri serviceUri = null;
         if(caller == null)
         {
            namespaceSegments = typeof(I).Namespace.Split('.');
            serviceUri = new Uri("fabric:/" + namespaceSegments[0] + ".Resource." + namespaceSegments[2] + "/" + typeof(I).Name.TrimStart('I'));
         }
         else
         {
            namespaceSegments = caller.ServiceUri.Segments;
            serviceUri = new Uri("fabric:/" + namespaceSegments[1] + typeof(I).Name.TrimStart('I'));
         }
         return serviceUri;
      }
   }
}
