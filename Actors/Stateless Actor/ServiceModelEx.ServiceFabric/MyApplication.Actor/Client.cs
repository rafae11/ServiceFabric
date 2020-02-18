// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Threading.Tasks;

using MyApplication.Interface;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.ServiceFabric.Actors;
using ServiceModelEx.ServiceFabric.Actors.Client;
#else
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
#endif

namespace MyApplication.Client
{
   public class Client
   {
      static async Task Test_StatelessActor()
      {
         try
         {
            //Using a new Guid for each run produces produces 'stateless' behavior.
            ActorId actorId1 = new ActorId(Guid.NewGuid()); 

            //TODO: Uncomment this and actor code to observe stateful behavior across runs regardless of 
            //      StatePersistence setting in Azure Service Fabric.
            //ActorId actorId1 = new ActorId("Test"); 

            Uri serviceUri = new Uri("fabric:/MyApplication.StatelessActor/MyStatelessActorService");
            IMyStatelessActor actor1 = ActorProxy.Create<IMyStatelessActor>(actorId1,serviceUri);

            string message = await actor1.MyMethodAsync("Calling stateless actor.");
            Console.WriteLine(message);
            message = await actor1.MyMethodAsync("Calling stateless actor.");
            Console.WriteLine(message);
            message = await actor1.MyMethodAsync("Calling stateless actor.");
            Console.WriteLine(message);

            IMyStatelessActor actor2 = ActorProxy.Create<IMyStatelessActor>(actorId1,serviceUri);

            message = await actor2.MyMethodAsync("Calling stateless actor.");
            Console.WriteLine(message);
            message = await actor2.MyMethodAsync("Calling stateless actor.");
            Console.WriteLine(message);
            message = await actor2.MyMethodAsync("Calling stateless actor.");
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
