// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System.Threading.Tasks;
using System.ServiceModel;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.ServiceFabric.Actors;
#else
using Microsoft.ServiceFabric.Actors;
#endif

namespace HelloWorld.Interface
{
   [ServiceContract(SessionMode = SessionMode.Required)]
   public interface IHelloWorldActor : IActor
   {
      [OperationContract]
      Task<string> SayHelloAsync(string message);
   }
}
