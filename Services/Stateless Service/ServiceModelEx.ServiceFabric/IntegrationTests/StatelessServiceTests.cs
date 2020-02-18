// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MyApplication.Interface;
using MyApplication.Service;

namespace IntegrationTests
{
   [TestClass]
   public class StatelessServiceTests
   {
      IntegrationTestHarness harness = null;

      [TestInitialize]
      public void Setup()
      {
         harness = new IntegrationTestHarness();
         harness.Setup(typeof(MyStatelessService));
      }
      [TestCleanup]
      public void Cleanup()
      {
         harness.Cleanup();
      }

      #region MyStatelessService.IMyStatelessService
      [TestMethod]
      [TestCategory("MyStatelessService.IMyStatelessService")]
      public void Test_IMyStatelessService_MyMethodAsync_AsPoco()
      {
         MyDataContract testDataContract = new MyDataContract
                                           {
                                              MyValue = "test"
                                           };

         Action<IMyStatelessService> callerMock = (poco)=>
                                                  {
                                                     string result = poco.MyMethodAsync(testDataContract).Result;
                                                     Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                     Assert.IsTrue(result.Contains(testDataContract.MyValue) == true);
                                                  };
         harness.TestServicePoco<IMyStatelessService>(callerMock);
      }
      [TestMethod]
      [TestCategory("MyStatelessService.IMyStatelessService")]
      public void Test_IMyStatelessService_MyMethodAsync_AsService()
      {
         MyDataContract testDataContract = new MyDataContract
                                           {
                                              MyValue = "test"
                                           };

         Action<IMyStatelessService> callerMock = (proxy)=>
                                                  {
                                                     string result = proxy.MyMethodAsync(testDataContract).Result;
                                                     Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                     Assert.IsTrue(result.Contains(testDataContract.MyValue) == true);
                                                  };
         harness.TestService<IMyStatelessService>(callerMock);
      }
      #endregion

      #region MyStatelessService.IOtherStatelessService
      [TestMethod]
      [TestCategory("MyStatelessService.IOtherStatelessService")]
      public void Test_IOtherStatelessService_SayHelloAgainAsync_AsPoco()
      {
         MyDataContract testDataContract = new MyDataContract
                                           {
                                              MyValue = "test"
                                           };

         Action<IOtherStatelessService> callerMock = (poco)=>
                                                     {
                                                        string result = poco.MyOtherMethodAsync(testDataContract).Result;
                                                        Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                        Assert.IsTrue(result.Contains(testDataContract.MyValue) == true);
                                                     };
         harness.TestServicePoco<IOtherStatelessService>(callerMock);
      }
      [TestMethod]
      [TestCategory("MyStatelessService.IOtherStatelessService")]
      public void Test_IOtherStatelessService_SayHelloAgainAsync_AsService()
      {
         MyDataContract testDataContract = new MyDataContract
                                           {
                                              MyValue = "test"
                                           };

         Action<IOtherStatelessService> callerMock = (proxy)=>
                                                     {
                                                        string result = proxy.MyOtherMethodAsync(testDataContract).Result;
                                                        Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                        Assert.IsTrue(result.Contains(testDataContract.MyValue) == true);
                                                     };
         harness.TestService<IOtherStatelessService>(callerMock);
      }
      #endregion
   }
}
