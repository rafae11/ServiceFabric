// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.ServiceFabric;
using ServiceModelEx.ServiceFabric.Actors;
using ServiceModelEx.ServiceFabric.Actors.Runtime;
#else
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
#endif

using VoicemailBox.Interface;

namespace VoicemailBox.Actors
{
#if ServiceModelEx_ServiceFabric
   [Serializable]
   [ApplicationManifest("VoicemailBox.StatefulActor","VoicemailBoxActorService")]
#endif
   //TODO: Change to StatePersistence.Persisted to ensure Service Fabric persists your state to disk.
   [StatePersistence(StatePersistence.Volatile)]
   public class VoicemailBoxActor : Actor,IVoicemailBoxActor
   {
      string stateName = typeof(Interface.VoicemailBox).FullName;

      public VoicemailBoxActor(ActorService actorService,ActorId actorId) : base(actorService,actorId)
      {}
      protected override Task OnActivateAsync()
      {
         if(StateManager.ContainsStateAsync(stateName).Result == false)
         {
            StateManager.SetStateAsync<Interface.VoicemailBox>(stateName,new Interface.VoicemailBox()).Wait();
         }
         return base.OnActivateAsync();
      }

      public async Task<List<Voicemail>> GetMessagesAsync()
      {
         Interface.VoicemailBox voicemailBox = await StateManager.GetStateAsync<Interface.VoicemailBox>(stateName);
         return voicemailBox.MessageList;
      }
      public async Task<string> GetGreetingAsync()
      {
         Interface.VoicemailBox voicemailBox = await StateManager.GetStateAsync<Interface.VoicemailBox>(stateName);
         if (string.IsNullOrEmpty(voicemailBox.Greeting))
         {
            voicemailBox.Greeting = "No one is available, please leave a message after the beep.";
            StateManager.SetStateAsync<Interface.VoicemailBox>(stateName,voicemailBox).Wait();
         }

         return voicemailBox.Greeting;
      }
      public async Task LeaveMessageAsync(string message)
      {
         try
         {
            Interface.VoicemailBox voicemailBox = await StateManager.GetStateAsync<Interface.VoicemailBox>(stateName);
            voicemailBox.MessageList.Add(new Voicemail
                                         {
                                            Id = Guid.NewGuid(),
                                            Message = message,
                                            ReceivedAt = DateTime.Now
                                         });
            await StateManager.SetStateAsync<Interface.VoicemailBox>(stateName,voicemailBox);
         }
         catch(Exception ex)
         {
            throw ex;
         }
      }
      public async Task SetGreetingAsync(string greeting)
      {
         Interface.VoicemailBox voicemailBox = await StateManager.GetStateAsync<Interface.VoicemailBox>(stateName);
         voicemailBox.Greeting = greeting;
         await StateManager.SetStateAsync<Interface.VoicemailBox>(stateName,voicemailBox);
      }
      public async Task DeleteMessageAsync(Guid messageId)
      {
         Interface.VoicemailBox voicemailBox = await StateManager.GetStateAsync<Interface.VoicemailBox>(stateName);
         for (int i = 0; i < voicemailBox.MessageList.Count; i++)
         {
            if (voicemailBox.MessageList[i].Id.Equals(messageId))
            {
               voicemailBox.MessageList.RemoveAt(i);
               break;
            }
         }
         await StateManager.SetStateAsync<Interface.VoicemailBox>(stateName,voicemailBox);
      }
      public async Task DeleteAllMessagesAsync()
      {
         Interface.VoicemailBox voicemailBox = await StateManager.GetStateAsync<Interface.VoicemailBox>(stateName);
         voicemailBox.MessageList.Clear();
         await StateManager.SetStateAsync<Interface.VoicemailBox>(stateName,voicemailBox);
      }
   }
}
