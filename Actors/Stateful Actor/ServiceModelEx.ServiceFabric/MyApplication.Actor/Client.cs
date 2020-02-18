// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Threading.Tasks;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.ServiceFabric.Actors;
using ServiceModelEx.ServiceFabric.Actors.Client;
#else
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
#endif

using MyApplication.Interface;

namespace MyApplication.Client
{
   public class Client
   {
      static async Task Test_StatefulActor()
      {
         try
         {
            ActorId actorId1 = new ActorId("Test"); 

            Uri serviceUri = new Uri("fabric:/MyApplication.StatefulActor/MyStatefulActorService");
            IMyStatefulActor actor1 = ActorProxy.Create<IMyStatefulActor>(actorId1,serviceUri);

            MyDataContract myDataContract = new MyDataContract
                                            {
                                               MyValue = "My value."
                                            };
            string message = await actor1.MyMethodAsync(myDataContract);
            Console.WriteLine(message);
            message = await actor1.MyMethodAsync(myDataContract);
            Console.WriteLine(message);
            message = await actor1.MyMethodAsync(myDataContract);
            Console.WriteLine(message);

            IMyStatefulActor actor2 = ActorProxy.Create<IMyStatefulActor>(actorId1,serviceUri);

            message = await actor2.MyMethodAsync(myDataContract);
            Console.WriteLine(message);
            message = await actor2.MyMethodAsync(myDataContract);
            Console.WriteLine(message);
            message = await actor2.MyMethodAsync(myDataContract);
            Console.WriteLine(message);

            Console.WriteLine("Finished...");
         }
         catch (Exception ex)
         {
            Console.WriteLine("Test Exception: " + ex.Message);
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
