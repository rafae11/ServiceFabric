// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Threading.Tasks;

using MyApplication.Interface;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.ServiceFabric.Services.Remoting.Client;
#else
using Microsoft.ServiceFabric.Services.Remoting.Client;
#endif

namespace MyApplication.Client
{
   public class Client
   {
      static async Task Test_StatelessService()
      {
         try
         {
            Uri serviceUri = new Uri("fabric:/MyApplication.StatelessService/MyStatelessService");
            IMyStatelessService service1 = ServiceProxy.Create<IMyStatelessService>(serviceUri,listenerName:typeof(IMyStatelessService).Name);

            MyDataContract myDataContract = new MyDataContract
                                            {
                                               MyValue = "My value"
                                            };

            string message = await service1.MyMethodAsync(myDataContract);
            Console.WriteLine(message);
            message = await service1.MyMethodAsync(myDataContract);
            Console.WriteLine(message);
            message = await service1.MyMethodAsync(myDataContract);
            Console.WriteLine(message);

            IOtherStatelessService service2 = ServiceProxy.Create<IOtherStatelessService>(serviceUri,listenerName:typeof(IOtherStatelessService).Name);

            message = await service2.MyOtherMethodAsync(myDataContract);
            Console.WriteLine(message);
            message = await service2.MyOtherMethodAsync(myDataContract);
            Console.WriteLine(message);
            message = await service2.MyOtherMethodAsync(myDataContract);
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
