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

namespace HelloWorld.Interface
{
   [ServiceContract]
   public interface IHelloWorldService : IService
   {
      [OperationContract]
      Task<string> SayHelloAsync(string message);
   }
}
