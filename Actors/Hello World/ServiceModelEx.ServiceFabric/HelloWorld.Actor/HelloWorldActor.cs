// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System.Threading.Tasks;

#if ServiceModelEx_ServiceFabric
using System;
using ServiceModelEx;
using ServiceModelEx.ServiceFabric;
using ServiceModelEx.ServiceFabric.Actors;
using ServiceModelEx.ServiceFabric.Actors.Runtime;
#else
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
#endif

using HelloWorld.Interface;

namespace HelloWorld.Actors
{
   #if ServiceModelEx_ServiceFabric
   [Serializable]
   [ApplicationManifest("HelloWorld.StatelessActor","HelloWorldActorService")]
   #endif
   [StatePersistence(StatePersistence.None)]
   public class HelloWorldActor : Actor,IHelloWorldActor
   {
      public HelloWorldActor(ActorService actorService,ActorId actorId) : base(actorService,actorId)
      {}
      public Task<string> SayHelloAsync(string message)
      {
         return Task.FromResult("You said '" + message + "'. I say hello world! ");
      }
   }
}
