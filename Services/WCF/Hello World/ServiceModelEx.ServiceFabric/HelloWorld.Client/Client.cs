// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Threading.Tasks;

using ServiceModelEx.ServiceFabric.Services.Communication.Wcf.Client;

using HelloWorld.Interface;

namespace HelloWorld.Client
{
   public class Client
   {
      class HelloWorldProxy : ServiceFabricClientBase<IHelloWorldService>,IHelloWorldService
      {
         public HelloWorldProxy(Uri address) : base(address)
         {}

         public Task<string> SayHelloAsync(string message)
         {
            return InvokeWithRetry(client=>client.Channel.SayHelloAsync(message));
         }
      }

      static async Task Test_StatelessService()
      {
         try
         {
            Uri serviceUri = new Uri("fabric:/HelloWorld.StatelessService.Wcf/HelloWorldService");

            string message = string.Empty;
            HelloWorldProxy proxy = new HelloWorldProxy(serviceUri);
            message = await proxy.SayHelloAsync("Calling stateless WCF Service!");
            Console.WriteLine(message);
            message = await proxy.SayHelloAsync("Calling stateless WCF Service!");
            Console.WriteLine(message);
            message = await proxy.SayHelloAsync("Calling stateless WCF Service!");
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
      static void Main()
      {
         Test();
         Console.WriteLine("Enter to close");
         Console.ReadLine();
      }
   }
}
