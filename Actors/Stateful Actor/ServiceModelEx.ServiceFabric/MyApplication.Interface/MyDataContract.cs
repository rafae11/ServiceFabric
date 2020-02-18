// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System.Runtime.Serialization;

namespace MyApplication.Interface
{
   [DataContract]
   public class MyDataContract
   {
      [DataMember]
      public string MyValue
      {get;set;}
   }
}
