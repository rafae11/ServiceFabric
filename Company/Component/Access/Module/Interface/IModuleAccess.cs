// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System.ServiceModel;
using System.Threading.Tasks;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.ServiceFabric.Services.Remoting;
#else
using Microsoft.ServiceFabric.Services.Remoting;
#endif

namespace Company.Access.Module.Interface
{
   [ServiceContract]
   public interface IModuleAccess : IService
   {
      [OperationContract]
      Task<string> BuildModuleAsync(string request);
   }
}
