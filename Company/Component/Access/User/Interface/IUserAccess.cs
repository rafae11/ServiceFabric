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

namespace Company.Access.User.Interface
{
   [ServiceContract]
   public interface IUserAccess : IService
   {
      [OperationContract]
      Task<string> AssembleProfileAsync(string request);
   }
}
