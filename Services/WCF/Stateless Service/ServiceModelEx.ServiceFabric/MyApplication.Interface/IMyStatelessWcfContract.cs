// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System.ServiceModel;
using System.Threading.Tasks;

namespace MyApplication.Interface
{
   [ServiceContract]
   public interface IMyStatelessWcfContract
   {
      [OperationContract]
      Task<string> MyMethodAsync(MyDataContract request);
   }
}
