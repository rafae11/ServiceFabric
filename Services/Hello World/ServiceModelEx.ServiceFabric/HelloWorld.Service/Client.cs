// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Threading.Tasks;

using HelloWorld.Interface;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.ServiceFabric.Services.Remoting.Client;
#else
using Microsoft.ServiceFabric.Services.Remoting.Client;
#endif

namespace HelloWorld.Client
{
   public class Client
   {
      static async Task Test_StatelessService()
      {
         try
         {
            Uri serviceUri = new Uri("fabric:/HelloWorld.StatelessService/HelloWorldService");
            IHelloWorldService service1 = ServiceProxy.Create<IHelloWorldService>(serviceUri,listenerName:typeof(IHelloWorldService).Name);

            string message = await service1.SayHelloAsync("I'm a stateless Service!");
            Console.WriteLine(message);
            message = await service1.SayHelloAsync("I'm a stateless Service!");
            Console.WriteLine(message);
            message = await service1.SayHelloAsync("I'm a stateless Service!");
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
         Client.Test_StatelessService().Wait();
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
