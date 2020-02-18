// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System.Threading.Tasks;

#if ServiceModelEx_ServiceFabric
using System;
using ServiceModelEx.ServiceFabric;
using ServiceModelEx.ServiceFabric.Actors;
using ServiceModelEx.ServiceFabric.Actors.Runtime;
#else
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
#endif

using MyApplication.Interface;

namespace MyApplication.Actors
{
   #if ServiceModelEx_ServiceFabric
   [Serializable]
   [ApplicationManifest("MyApplication.StatefulActor","MyStatefulActorService")]
   #endif
   //TODO: Change to StatePersistence.Persisted to ensure Service Fabric persists your state to disk.
   [StatePersistence(StatePersistence.Volatile)]
   public class MyStatefulActor : Actor,IMyStatefulActor
   {
      string stateName = typeof(MyState).FullName;

      public MyStatefulActor(ActorService actorService,ActorId actorId) : base(actorService,actorId)
      {}
      protected override Task OnActivateAsync()
      {
         if(StateManager.ContainsStateAsync(stateName).Result == false)
         {
            StateManager.SetStateAsync<MyState>(stateName,new MyState());
         }
         return base.OnActivateAsync();
      }

      public async Task<string> MyMethodAsync(MyDataContract request)
      {
         MyState state = await StateManager.GetStateAsync<MyState>(stateName);
         state.MyValue += " " + request.MyValue;
         await StateManager.SetStateAsync<MyState>(stateName,state);
         return "MyState = " + state.MyValue;
      }
   }
}
