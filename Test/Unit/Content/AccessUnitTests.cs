// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Company.Access.Module.Interface;
using Company.Access.Module.Service;
using Company.Access.User.Interface;
using Company.Access.User.Service;

namespace Test.Unit.Content
{
   [TestClass]
   public class AccessUnitTests
   {
      UnitTestHarness harness = null;

      [TestInitialize]
      public void Setup()
      {
         harness = new UnitTestHarness();
         harness.Setup(typeof(UserAccess),typeof(ModuleAccess));
      }
      [TestCleanup]
      public void Cleanup()
      {
         harness.Cleanup();
      }

      #region UserAccess.IUserAccess
      [TestMethod]
      [TestCategory("Access.UserAccess.IUserAccess")]
      public void Test_AssembleProfileAsync_With_NoMocks_As_Poco()
      {
         string request = "Test";
         Action<IUserAccess> callerMock = (poco)=>
                                          {
                                             string result = poco.AssembleProfileAsync(request).Result;
                                             Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                             Assert.IsTrue(result.Contains(request) == true);
                                             Assert.IsTrue(result.Contains("UserAccess.AssembleProfileAsync") == true);
                                          };
         harness.TestServicePoco<IUserAccess>(callerMock);
      }
      [TestMethod]
      [TestCategory("Access.UserAccess.IUserAccess")]
      public void Test_AssembleProfileAsync_With_NoMocks_As_Service()
      {
         string request = "Test";
         Action<IUserAccess> callerMock = (proxy)=>
                                          {
                                             string result = proxy.AssembleProfileAsync(request).Result;
                                             Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                             Assert.IsTrue(result.Contains(request) == true);
                                             Assert.IsTrue(result.Contains("UserAccess.AssembleProfileAsync") == true);
                                          };
         harness.TestService<IUserAccess>(callerMock);
      }
      #endregion

      #region ModuleAccess.IModuleAccess
      [TestMethod]
      [TestCategory("Access.ModuleAccess.IModuleAccess")]
      public void Test_BuildModuleAsync_With_NoMocks_As_Poco()
      {
         string request = "Test";
         Action<IModuleAccess> callerMock = (poco)=>
                                            {
                                               string result = poco.BuildModuleAsync(request).Result;
                                               Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                               Assert.IsTrue(result.Contains(request) == true);
                                               Assert.IsTrue(result.Contains("ModuleAccess.BuildModuleAsync") == true);
                                            };
         harness.TestServicePoco<IModuleAccess>(callerMock);
      }
      [TestMethod]
      [TestCategory("Access.ModuleAccess.IModuleAccess")]
      public void Test_BuildModuleAsync_With_NoMocks_As_Service()
      {
         string request = "Test";
         Action<IModuleAccess> callerMock = (proxy)=>
                                            {
                                               string result = proxy.BuildModuleAsync(request).Result;
                                               Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                               Assert.IsTrue(result.Contains(request) == true);
                                               Assert.IsTrue(result.Contains("ModuleAccess.BuildModuleAsync") == true);
                                            };
         harness.TestService<IModuleAccess>(callerMock);
      }
      #endregion
   }
}
