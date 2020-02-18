// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.ServiceFabric.Services.Runtime;
#else
using System.Threading;
using Microsoft.ServiceFabric.Services.Runtime;
#endif

namespace HelloWorld.Service
{
   internal static class Host
   {
      private static void Main()
      {
         try
         {
            ServiceRuntime.RegisterServiceAsync("HelloWorldServiceType",(context)=>new HelloWorldService(context));

            #if ServiceModelEx_ServiceFabric
            Console.WriteLine("Hosted...");
            Client.Client.Test();
            Console.WriteLine("Enter to close");
            Console.ReadLine();
            #else
            Thread.Sleep(Timeout.Infinite);
            #endif
         }
         catch (Exception exception)
         {
            throw exception;
         }
      }
   }
}
