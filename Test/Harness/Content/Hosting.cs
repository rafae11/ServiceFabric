// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;

namespace Test.Harness.Content
{
   static class Hosting
   {
      static void Main()
      {
         try
         {
#if ServiceModelEx_ServiceFabric
            Company.Microservice.Content.Hosting.Register();
            Console.WriteLine("Hosted...\r\n");
#endif

            Client.Test();
            Console.WriteLine("Enter to close");
            Console.ReadLine();
         }
         catch(Exception exception)
         {
            throw exception;
         }
      }
   }
}
