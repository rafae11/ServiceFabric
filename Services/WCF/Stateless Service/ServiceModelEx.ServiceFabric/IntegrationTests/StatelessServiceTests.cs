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
         harness.Setup(typeof(MyStatelessWcfService));
      }
      [TestCleanup]
      public void Cleanup()
      {
         harness.Cleanup();
      }

      #region MyStatelessWcfService.IMyStatelessWcfService
      [TestMethod]
      [TestCategory("MyStatelessWcfService.IMyStatelessWcfService")]
      public void Test_IMyStatelessWcfService_MyMethodAsync_AsPoco()
      {
         MyDataContract testDataContract = new MyDataContract
                                           {
                                              MyValue = "test"
                                           };

         Action<IMyStatelessWcfContract> callerMock = (poco)=>
                                                  {
                                                     string result = poco.MyMethodAsync(testDataContract).Result;
                                                     Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                     Assert.IsTrue(result.Contains(testDataContract.MyValue) == true);
                                                  };
         harness.TestServicePoco<IMyStatelessWcfContract>(callerMock);
      }
      [TestMethod]
      [TestCategory("MyStatelessWcfService.IMyStatelessWcfService")]
      public void Test_IMyStatelessWcfService_MyMethodAsync_AsService()
      {
         MyDataContract testDataContract = new MyDataContract
                                           {
                                              MyValue = "test"
                                           };

         Action<IMyStatelessWcfContract> callerMock = (proxy)=>
                                                  {
                                                     string result = proxy.MyMethodAsync(testDataContract).Result;
                                                     Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                     Assert.IsTrue(result.Contains(testDataContract.MyValue) == true);
                                                  };
         harness.TestService<IMyStatelessWcfContract>(callerMock);
      }
      #endregion

      #region MyStatelessWcfService.IOtherStatelessService
      [TestMethod]
      [TestCategory("MyStatelessWcfService.IOtherStatelessService")]
      public void Test_IOtherStatelessService_SayHelloAgainAsync_AsPoco()
      {
         MyDataContract testDataContract = new MyDataContract
                                           {
                                              MyValue = "test"
                                           };

         Action<IOtherMyStatelessWcfContract> callerMock = (poco)=>
                                                     {
                                                        string result = poco.MyOtherMethodAsync(testDataContract).Result;
                                                        Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                        Assert.IsTrue(result.Contains(testDataContract.MyValue) == true);
                                                     };
         harness.TestServicePoco<IOtherMyStatelessWcfContract>(callerMock);
      }
      [TestMethod]
      [TestCategory("MyStatelessWcfService.IOtherStatelessService")]
      public void Test_IOtherStatelessService_SayHelloAgainAsync_AsService()
      {
         MyDataContract testDataContract = new MyDataContract
                                           {
                                              MyValue = "test"
                                           };

         Action<IOtherMyStatelessWcfContract> callerMock = (proxy)=>
                                                     {
                                                        string result = proxy.MyOtherMethodAsync(testDataContract).Result;
                                                        Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                        Assert.IsTrue(result.Contains(testDataContract.MyValue) == true);
                                                     };
         harness.TestService<IOtherMyStatelessWcfContract>(callerMock);
      }
      #endregion
   }
}
