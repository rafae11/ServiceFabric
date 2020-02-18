// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using Company.Framework.Common;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.ServiceFabric.Services.Runtime;
#else
using System;
using System.Fabric;
using System.Threading;
using Microsoft.ServiceFabric.Services.Runtime;
#endif

namespace Company.Access.User.Service
{
   public static class Hosting
   {
      public static void Register()
      {
         ServiceRuntime.RegisterServiceAsync(Naming.ServiceType<UserAccess>(),(context) => new UserAccess(context));
      }

#if ServiceModelEx_ServiceFabric == false
      static void Main()
      {
         try
         {
            Register();
            Thread.Sleep(Timeout.Infinite);
         }
         catch(Exception exception)
         {
            throw exception;
         }
      }
#endif
   }
}
