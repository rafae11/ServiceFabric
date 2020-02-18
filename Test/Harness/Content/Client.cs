// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Threading.Tasks;

using Company.Framework.Proxy;
using Company.Manager.Content.Interface;

namespace Test.Harness.Content
{
   public class Client
   {
      static async Task Test_IContentManager_RequestContent()
      {
         try
         {
            IContentManager proxy = Proxy.ForMicroservice<IContentManager>();

            string response = await proxy.RequestContentAsync("Call chain:\r\nClient->");
            Console.WriteLine(response);
            Console.WriteLine("\r\nFinished...");
         }
         catch (Exception ex)
         {
            Console.WriteLine("Test Exception: " + ex.Message);
         }
      }
      public static void Test()
      {      
         Client.Test_IContentManager_RequestContent().Wait();
      }
   }
}
