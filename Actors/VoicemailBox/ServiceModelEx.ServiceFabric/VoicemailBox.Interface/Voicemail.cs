// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Runtime.Serialization;

namespace VoicemailBox.Interface
{
   [Serializable]
   [DataContract]
   public class Voicemail
   {
      [DataMember]
      public Guid Id 
      {get; set;}

      [DataMember]
      public string Message 
      {get; set;}

      [DataMember]
      public DateTime ReceivedAt 
      {get; set;}
   }
}
