// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MyApplication.Actors;
using MyApplication.Interface;

namespace IntegrationTests
{
   [TestClass]
   public class MyStatefulActorTests
   {
      IntegrationTestHarness harness = null;

      [TestInitialize]
      public void Setup()
      {
         harness = new IntegrationTestHarness();
         harness.Setup(typeof(MyStatefulActor));
      }
      [TestCleanup]
      public void Cleanup()
      {
         harness.Cleanup();
      }

      #region MyStatefulActor.IMyStatefulActor
      [TestMethod]
      [TestCategory("MyStatefulActor.IMyStatefulActor")]
      public void Test_IMyStatefulActor_MyMethodAsync_AsPoco()
      {
         MyDataContract testDataContract = new MyDataContract
                                           {
                                              MyValue = "test"
                                           };

         MyState state = new MyState {MyValue = "chicken" };

         Action<IMyStatefulActor> callerMock = (poco)=>
                                               {
                                                  string result = poco.MyMethodAsync(testDataContract).Result;
                                                  Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                  Assert.IsTrue(result.Contains(testDataContract.MyValue));
                                               };
         harness.TestActorPoco<IMyStatefulActor,MyState>(callerMock,state);
      }
      [TestMethod]
      [TestCategory("MyStatefulActor.IMyStatefulActor")]
      public void Test_IMyStatefulActor_MyMethodAsync_AsService()
      {
         MyDataContract testDataContract = new MyDataContract
                                           {
                                              MyValue = "test"
                                           };

         MyState state = new MyState {MyValue = "chicken" };

         Action<IMyStatefulActor> callerMock = (proxy)=>
                                               {
                                                  string result = proxy.MyMethodAsync(testDataContract).Result;
                                                  Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                  Assert.IsTrue(result.Contains(testDataContract.MyValue));
                                               };
         harness.TestActor<IMyStatefulActor,MyState>(callerMock,state);
      }
      #endregion
   }
}
