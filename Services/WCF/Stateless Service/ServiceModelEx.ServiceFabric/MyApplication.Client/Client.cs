// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Threading.Tasks;

using ServiceModelEx.ServiceFabric.Services.Communication.Wcf.Client;

using MyApplication.Interface;

namespace MyApplication.Client
{
   public class Client
   {
      class StatelessServiceProxy : ServiceFabricClientBase<IMyStatelessWcfContract>,IMyStatelessWcfContract
      {
         public StatelessServiceProxy(Uri address) : base(address)
         {}

         public Task<string> MyMethodAsync(MyDataContract request)
         {
            return InvokeWithRetry(client=>client.Channel.MyMethodAsync(request));
         }
      }
      class OtherStatelessServiceProxy : ServiceFabricClientBase<IOtherMyStatelessWcfContract>,IOtherMyStatelessWcfContract
      {
         public OtherStatelessServiceProxy(Uri address) : base(address)
         {}

         public Task<string> MyOtherMethodAsync(MyDataContract request)
         {
            return InvokeWithRetry(client=>client.Channel.MyOtherMethodAsync(request));
         }
      }

      static async Task Test_StatelessService()
      {
         try
         {
            Uri serviceUri = new Uri("fabric:/MyApplication.StatelessService.Wcf/MyStatelessWcfService");

            MyDataContract myDataContract = new MyDataContract
                                            {
                                               MyValue = "My value"
                                            };

            string message = string.Empty;
            StatelessServiceProxy proxy = new StatelessServiceProxy(serviceUri);
            message = await proxy.MyMethodAsync(myDataContract);
            Console.WriteLine(message);
            message = await proxy.MyMethodAsync(myDataContract);
            Console.WriteLine(message);
            message = await proxy.MyMethodAsync(myDataContract);
            Console.WriteLine(message);

            OtherStatelessServiceProxy otherProxy = new OtherStatelessServiceProxy(serviceUri);
            message = await otherProxy.MyOtherMethodAsync(myDataContract);
            Console.WriteLine(message);
            message = await otherProxy.MyOtherMethodAsync(myDataContract);
            Console.WriteLine(message);
            message = await otherProxy.MyOtherMethodAsync(myDataContract);
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
         Console.WriteLine("Close with Enter");
         Console.ReadLine();
      }
   }
}
