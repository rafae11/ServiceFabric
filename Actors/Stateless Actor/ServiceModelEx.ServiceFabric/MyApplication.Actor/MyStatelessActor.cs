// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System.Threading.Tasks;

using MyApplication.Interface;

#if ServiceModelEx_ServiceFabric
using System;
using ServiceModelEx.ServiceFabric;
using ServiceModelEx.ServiceFabric.Actors;
using ServiceModelEx.ServiceFabric.Actors.Runtime;
#else
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
#endif

namespace MyApplication.Actors
{
   #if ServiceModelEx_ServiceFabric
   [Serializable]
   [ApplicationManifest("MyApplication.StatelessActor","MyStatelessActorService")]
   #endif
   [StatePersistence(StatePersistence.None)]
   public class MyStatelessActor : Actor,IMyStatelessActor
   {
      public MyStatelessActor(ActorService actorService,ActorId actorId) : base(actorService,actorId)
      {}
      public Task<string> MyMethodAsync(string message)
      {
         //TODO: In Azure Service Fabric, uncomment this and client code to observe stateful behavior 
         //      across runs regardless of StatePersistence setting.
         //string response = StateManager.AddOrUpdateStateAsync("test",message,(name,value)=>value+message).Result;

         string response = message + " Id1: " + Id;
         return Task.FromResult(response);
      }
   }
}
