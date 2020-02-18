// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.ServiceFabric.Services.Runtime;
#else
using System.Fabric;
using System.Threading;
using Microsoft.ServiceFabric.Services.Runtime;
#endif

namespace MyApplication.Service
{
   internal static class Host
   {
      private static void Main()
      {
         try
         {
            ServiceRuntime.RegisterServiceAsync("MyStatelessServiceType",(context)=>new MyStatelessService(context));

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
