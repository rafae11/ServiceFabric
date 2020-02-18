// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ServiceModelEx.Fabric;

using HelloWorld.Interface;
using HelloWorld.Service;

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
         harness.Setup(typeof(HelloWorldService));
      }
      [TestCleanup]
      public void Cleanup()
      {
         harness.Cleanup();
      }

      #region HelloWorldService.IHelloWorldService
      [TestMethod]
      [TestCategory("HelloWorldService.IHelloWorldService")]
      public void Test_IHelloWorldService_SayHelloAsync_AsPoco()
      {
         Action<IHelloWorldService> callerMock = (poco)=>
                                                 {
                                                    string result = poco.SayHelloAsync("test").Result;
                                                    Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                    Assert.IsTrue(result.Contains("test") == true);
                                                 };
         harness.TestServicePoco<IHelloWorldService>(callerMock);
      }
      [TestMethod]
      [TestCategory("HelloWorldService.IHelloWorldService")]
      public void Test_IHelloWorldService_SayHelloAsync_AsService()
      {
         Action<IHelloWorldService> callerMock = (proxy)=>
                                                 {
                                                    string result = proxy.SayHelloAsync("test").Result;
                                                    Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                    Assert.IsTrue(result.Contains("test") == true);
                                                 };
         harness.TestService<IHelloWorldService>(callerMock);
      }
      #endregion
   }
}
