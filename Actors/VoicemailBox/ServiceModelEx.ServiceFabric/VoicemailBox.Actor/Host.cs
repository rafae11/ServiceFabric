// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.ServiceFabric.Actors.Runtime;
#else
using System.Threading;
using Microsoft.ServiceFabric.Actors.Runtime;
#endif

namespace VoicemailBox.Actors
{
   internal static class Host
   {
      static void Main()
      {
         try
         {
            ActorRuntime.RegisterActorAsync<VoicemailBoxActor>();

            #if ServiceModelEx_ServiceFabric
            Console.WriteLine("Hosted...");
            Client.Client.Test();
            Console.Write("Enter to close");
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
