// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.ServiceFabric.Actors;
#else
using Microsoft.ServiceFabric.Actors;
#endif

namespace VoicemailBox.Interface
{
   [ServiceContract(SessionMode = SessionMode.Required)]
   public interface IVoicemailBoxActor : IActor
   {
      [OperationContract]
      Task<List<Voicemail>> GetMessagesAsync();

      [OperationContract(IsInitiating = false)]
      Task<string> GetGreetingAsync();

      [OperationContract]
      Task LeaveMessageAsync(string message);

      [OperationContract(IsInitiating = false)]
      Task SetGreetingAsync(string greeting);

      [OperationContract(IsInitiating = false)]
      Task DeleteMessageAsync(Guid messageId);

      [OperationContract(IsInitiating = false)]
#if ServiceModelEx_ServiceFabric
      [CompletesActorInstance]
#endif
      Task DeleteAllMessagesAsync();
   }
}
