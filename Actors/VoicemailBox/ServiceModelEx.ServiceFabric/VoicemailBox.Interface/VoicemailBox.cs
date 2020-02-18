// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VoicemailBox.Interface
{
   [Serializable]
   [DataContract]
   public class VoicemailBox
   {
      public VoicemailBox()
      {
         this.MessageList = new List<Voicemail>();
      }

      [DataMember]
      public List<Voicemail> MessageList 
      {get; set;}

      [DataMember]
      public string Greeting
      {get; set;}
   }
}
