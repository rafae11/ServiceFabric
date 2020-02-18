// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System.ServiceModel;
using System.Threading.Tasks;

namespace HelloWorld.Interface
{
   [ServiceContract]
   public interface IHelloWorldService
   {
      [OperationContract]
      Task<string> SayHelloAsync(string message);
   }
}
