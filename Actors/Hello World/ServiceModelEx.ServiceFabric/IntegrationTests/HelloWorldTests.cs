// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HelloWorld.Interface;
using HelloWorld.Actors;

namespace IntegrationTests
{
   [TestClass]
   public class HelloWorldTests
   {
      IntegrationTestHarness harness = null;

      [TestInitialize]
      public void Setup()
      {
         harness = new IntegrationTestHarness();
         harness.Setup(typeof(HelloWorldActor));
      }
      [TestCleanup]
      public void Cleanup()
      {
         harness.Cleanup();
      }

      #region HelloWorldActor.IHelloWorldActor
      [TestMethod]
      [TestCategory("HelloWorldActor.IHelloWorldActor")]
      public void Test_IHelloWorldActor_SayHelloAsync_AsPoco()
      {
         Action<IHelloWorldActor> callerMock = (poco)=>
                                               {
                                                  string result = poco.SayHelloAsync("test").Result;
                                                  Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                  Assert.IsTrue(result.Contains("test"));
                                                  Assert.IsTrue(result.Contains("I say hello world!"));
                                               };
         harness.TestActorPoco<IHelloWorldActor>(callerMock);
      }
      [TestMethod]
      [TestCategory("HelloWorldActor.IHelloWorldActor")]
      public void Test_IHelloWorldActor_SayHelloAsync_AsService()
      {
         Action<IHelloWorldActor> callerMock = (proxy)=>
                                               {
                                                  string result = proxy.SayHelloAsync("test").Result;
                                                  Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                  Assert.IsTrue(result.Contains("test"));
                                                  Assert.IsTrue(result.Contains("I say hello world!"));
                                               };
         harness.TestActor<IHelloWorldActor>(callerMock);
      }
      #endregion
   }
}
