// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System.ServiceModel;
using System.Threading.Tasks;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.ServiceFabric.Actors;
#else
using Microsoft.ServiceFabric.Actors;
#endif

namespace MyApplication.Interface
{
   [ServiceContract(SessionMode = SessionMode.Required)]
   public interface IMyStatefulActor : IActor
   {
      [OperationContract]
      Task<string> MyMethodAsync(MyDataContract request);
   }
}
