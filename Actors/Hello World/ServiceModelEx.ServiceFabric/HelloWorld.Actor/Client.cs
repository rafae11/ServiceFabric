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

using HelloWorld.Interface;

namespace HelloWorld.Client
{
   public class Client
   {
      static async Task Test_StatelessActor()
      {
         try
         {
            ActorId actorId1 = new ActorId(Guid.NewGuid()); 

            Uri serviceUri = new Uri("fabric:/HelloWorld.StatelessActor/HelloWorldActorService");
            IHelloWorldActor actor1 = ActorProxy.Create<IHelloWorldActor>(actorId1,serviceUri);

            string message = await actor1.SayHelloAsync("I'm a stateless Actor!");
            Console.WriteLine(message);
            message = await actor1.SayHelloAsync("I'm a stateless Actor!");
            Console.WriteLine(message);
            message = await actor1.SayHelloAsync("I'm a stateless Actor!");
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
         Client.Test_StatelessActor().Wait();
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
