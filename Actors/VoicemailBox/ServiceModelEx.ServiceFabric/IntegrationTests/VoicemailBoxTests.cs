// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using VoicemailBox.Actors;
using VoicemailBox.Interface;

namespace IntegrationTests
{
   [TestClass]
   public class VoicemailBoxTests
   {
      IntegrationTestHarness harness = null;

      [TestInitialize]
      public void Setup()
      {
         harness = new IntegrationTestHarness();
         harness.Setup(typeof(VoicemailBoxActor));
      }
      [TestCleanup]
      public void Cleanup()
      {
         harness.Cleanup();
      }

      #region VoicemailBoxActor.IVoicemailBoxActor
      [TestMethod]
      [TestCategory("VoicemailBoxActor.IVoicemailBoxActor")]
      public void Test_IVoicemailBoxActor_LeaveMessageAsync_AsPoco()
      {
         Action<IVoicemailBoxActor> callerMock = (poco)=>
                                                 {
                                                    poco.LeaveMessageAsync("test").Wait();
                                                 };
         harness.TestActorPoco<IVoicemailBoxActor>(callerMock);
      }
      [TestMethod]
      [TestCategory("VoicemailBoxActor.IVoicemailBoxActor")]
      public void Test_IVoicemailBoxActor_LeaveMessageAsync_AsService()
      {
         Action<IVoicemailBoxActor> callerMock = (proxy)=>
                                                 {
                                                    proxy.LeaveMessageAsync("test").Wait();
                                                 };
         harness.TestActor<IVoicemailBoxActor>(callerMock);
      }
      #endregion
   }
}
