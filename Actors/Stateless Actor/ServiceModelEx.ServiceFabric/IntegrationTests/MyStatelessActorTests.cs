// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MyApplication.Interface;
using MyApplication.Actors;

namespace IntegrationTests
{
   [TestClass]
   public class MyStatelessActorTests
   {
      IntegrationTestHarness harness = null;

      [TestInitialize]
      public void Setup()
      {
         harness = new IntegrationTestHarness();
         harness.Setup(typeof(MyStatelessActor));
      }
      [TestCleanup]
      public void Cleanup()
      {
         harness.Cleanup();
      }

      #region MyStatelessActor.IMyStatelessActor
      [TestMethod]
      [TestCategory("MyStatelessActor.IMyStatelessActor")]
      public void Test_IMyStatelessActor_MyMethodAsync_AsPoco()
      {
         Action<IMyStatelessActor> callerMock = (poco)=>
                                                {
                                                   string result = poco.MyMethodAsync("test").Result;
                                                   Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                   Assert.IsTrue(result.Contains("test"));
                                                };
         harness.TestActorPoco<IMyStatelessActor>(callerMock);
      }
      [TestMethod]
      [TestCategory("MyStatelessActor.IMyStatelessActor")]
      public void Test_IMyStatelessActor_MyMethodAsync_AsService()
      {
         Action<IMyStatelessActor> callerMock = (proxy)=>
                                                {
                                                   string result = proxy.MyMethodAsync("test").Result;
                                                   Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                   Assert.IsTrue(result.Contains("test"));
                                                };
         harness.TestActor<IMyStatelessActor>(callerMock);
      }
      #endregion
   }
}
