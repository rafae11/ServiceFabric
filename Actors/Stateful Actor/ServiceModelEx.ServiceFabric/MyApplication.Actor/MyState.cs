// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Runtime.Serialization;

namespace MyApplication.Actors
{
   [Serializable]
   [DataContract]
   public class MyState
   {
      [DataMember]
      public string MyValue
      {get;set;}
   }
}
