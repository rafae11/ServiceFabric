// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

namespace Company.Microservice.Content
{
   public static class Hosting
   {
      public static void Register()
      {
         //TODO: Replace with HostHelper.
         Company.Access.User.Service.Hosting.Register();
         Company.Access.Module.Service.Hosting.Register();
         Company.Engine.Transform.Service.Hosting.Register();
         Company.Engine.Validation.Service.Hosting.Register();
         Company.Manager.Content.Service.Hosting.Register();
      }
   }
}
