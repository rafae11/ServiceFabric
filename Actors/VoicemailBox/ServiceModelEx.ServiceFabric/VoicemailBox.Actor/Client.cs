// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.ServiceFabric.Actors;
using ServiceModelEx.ServiceFabric.Actors.Client;
#else
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
#endif

using VoicemailBox.Interface;

namespace VoicemailBox.Client
{
   public class Client
   {
      static async Task Test_StatefulActor()
      {
         string namedActor1 = "Actor1";
         string namedActor2 = "Actor2";

         try
         {
            Uri serviceUri = new Uri("fabric:/VoicemailBox.StatefulActor/VoicemailBoxActorService");

            ActorId actorId1 = new ActorId(namedActor1);
            ActorId actorId2 = new ActorId(namedActor2);

            IVoicemailBoxActor actor1 = ActorProxy.Create<IVoicemailBoxActor>(actorId1,serviceUri);
            IVoicemailBoxActor actor2 = ActorProxy.Create<IVoicemailBoxActor>(actorId2,serviceUri);

            await actor1.LeaveMessageAsync("A voicemail message.!!!");
            await actor1.LeaveMessageAsync("A voicemail message.!!!");
            await actor1.LeaveMessageAsync("A voicemail message.!!!");

            await actor2.LeaveMessageAsync("A voicemail message.!!!");
            await actor2.LeaveMessageAsync("A voicemail message.!!!");
            await actor2.LeaveMessageAsync("A voicemail message.!!!");
            await actor2.LeaveMessageAsync("A voicemail message.!!!");
            await actor2.LeaveMessageAsync("A voicemail message.!!!");

            IVoicemailBoxActor actor3 = ActorProxy.Create<IVoicemailBoxActor>(actorId1,serviceUri);
            IVoicemailBoxActor actor4 = ActorProxy.Create<IVoicemailBoxActor>(actorId2,serviceUri);

            await actor3.LeaveMessageAsync("A voicemail message.!!!");
            await actor3.LeaveMessageAsync("A voicemail message.!!!");
            await actor3.LeaveMessageAsync("A voicemail message.!!!");

            await actor4.LeaveMessageAsync("A voicemail message.!!!");
            await actor4.LeaveMessageAsync("A voicemail message.!!!");
            await actor4.LeaveMessageAsync("A voicemail message.!!!");
            await actor4.LeaveMessageAsync("A voicemail message.!!!");
            await actor4.LeaveMessageAsync("A voicemail message.!!!");

            List<Voicemail> voicemails1 = await actor3.GetMessagesAsync();
            Console.WriteLine("VoicemailBox 1: " + voicemails1.Count);

            List<Voicemail> voicemails2 = await actor4.GetMessagesAsync();
            Console.WriteLine("VoicemailBox 2: " + voicemails2.Count);

            //TODO: Uncomment to observe actor completion and unloading of state. See IVoicemailBoxActor.
            //await actor3.DeleteAllMessagesAsync();
            //await actor4.DeleteAllMessagesAsync();

            //voicemails1 = await actor3.GetMessagesAsync();
            //Console.WriteLine("VoicemailBox 1: " + voicemails1.Count);

            //voicemails2 = await actor4.GetMessagesAsync();
            //Console.WriteLine("VoicemailBox 2: " + voicemails2.Count);

            Console.WriteLine("Finished...");
         }
         catch (Exception ex)
         {
            Console.WriteLine("Exception :" + ex.Message);
         }
      }

      public static void Test()
      {      
         Client.Test_StatefulActor().Wait();
      }
      #if ServiceModelEx_ServiceFabric == false
      static void Main()
      {
         Test();
         Console.WriteLine("Close with Enter");
         Console.ReadLine();
      }
      #endif
   }
}
