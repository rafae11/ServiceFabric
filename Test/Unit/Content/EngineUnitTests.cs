// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using Company.Access.Module.Interface;
using Company.Access.Module.Service;
using Company.Access.User.Interface;
using Company.Access.User.Service;
using Company.Engine.Transform.Interface;
using Company.Engine.Transform.Service;
using Company.Engine.Validation.Interface;
using Company.Engine.Validation.Service;

namespace Test.Unit.Content
{
   [TestClass]
   public class EngineUnitTests
   {
      UnitTestHarness harness = null;

      [TestInitialize]
      public void Setup()
      {
         harness = new UnitTestHarness();
         harness.Setup(typeof(UserAccess),
                       typeof(ModuleAccess),
                       typeof(TransformEngine),
                       typeof(ValidationEngine));
      }
      [TestCleanup]
      public void Cleanup()
      {
         harness.Cleanup();
      }

      #region ValidationEngine.IValidationEngine
      [TestMethod]
      [TestCategory("Engine.ValidationEngine.IValidationEngine")]
      public void Test_ConfirmRequestAsync_With_NoMocks_As_Poco()
      {
         string request = "Test";

         Action<IValidationEngine> callerMock = (poco)=>
                                               {
                                                  string result = poco.ConfirmRequestAsync(request).Result;
                                                  Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                  Assert.IsTrue(result.Contains(request) == true);
                                                  Assert.IsTrue(result.Contains("ValidationEngine.ConfirmRequestAsync") == true);
                                               };

         harness.TestServicePoco<IValidationEngine>(callerMock);
      }
      [TestMethod]
      [TestCategory("Engine.ValidationEngine.IValidationEngine")]
      public void Test_ConfirmRequestAsync_With_NoMocks_As_Service()
      {
         string request = "Test";

         Action<IValidationEngine> callerMock = (proxy)=>
                                               {
                                                  string result = proxy.ConfirmRequestAsync(request).Result;
                                                  Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                  Assert.IsTrue(result.Contains(request) == true);
                                                  Assert.IsTrue(result.Contains("ValidationEngine.ConfirmRequestAsync") == true);
                                               };

         harness.TestService<IValidationEngine>(callerMock);
      }
      #endregion

      #region TransformEngine.ITransformEngine
      [TestMethod]
      [TestCategory("Engine.TransformEngine.ITransformEngine")]
      public void Test_ToResponseAsync_With_AllMocks_As_Poco()
      {
         string request = "Test";

         var userAccessMock = new Mock<IUserAccess>();
         userAccessMock.Setup(x=>x.AssembleProfileAsync(It.IsAny<string>())).Returns<string>(r=>Task.FromResult(r + " UserAccessMock.AssembleProfileAsync"));

         var moduleAccessMock = new Mock<IModuleAccess>();
         moduleAccessMock.Setup(x=>x.BuildModuleAsync(It.IsAny<string>())).Returns<string>(r=>Task.FromResult(r + " ModuleAccessMock.BuildModuleAsync"));

         Action<ITransformEngine> callerMock = (poco)=>
                                               {
                                                  string result = poco.ToResponseAsync(request).Result;
                                                  Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                  Assert.IsTrue(result.Contains(request) == true);
                                                  Assert.IsTrue(result.Contains("UserAccessMock.AssembleProfileAsync") == true);
                                                  Assert.IsTrue(result.Contains("ModuleAccessMock.BuildModuleAsync") == true);
                                                  Assert.IsTrue(result.Contains("TransformEngine.ToResponseAsync") == true);
                                               };

         harness.TestServicePoco<ITransformEngine>(callerMock,userAccessMock,moduleAccessMock);
      }
      [TestMethod]
      [TestCategory("Engine.TransformEngine.ITransformEngine")]
      public void Test_ToResponseAsync_With_AllMocks_As_Service()
      {
         string request = "Test";

         var userAccessMock = new Mock<IUserAccess>();
         userAccessMock.Setup(x=>x.AssembleProfileAsync(It.IsAny<string>())).Returns<string>(r=>Task.FromResult(r + " UserAccessMock.AssembleProfileAsync"));

         var moduleAccessMock = new Mock<IModuleAccess>();
         moduleAccessMock.Setup(x=>x.BuildModuleAsync(It.IsAny<string>())).Returns<string>(r=>Task.FromResult(r + " ModuleAccessMock.BuildModuleAsync"));

         Action<ITransformEngine> callerMock = (proxy)=>
                                               {
                                                  string result = proxy.ToResponseAsync(request).Result;
                                                  Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                  Assert.IsTrue(result.Contains(request) == true);
                                                  Assert.IsTrue(result.Contains("UserAccessMock.AssembleProfileAsync") == true);
                                                  Assert.IsTrue(result.Contains("ModuleAccessMock.BuildModuleAsync") == true);
                                                  Assert.IsTrue(result.Contains("TransformEngine.ToResponseAsync") == true);
                                               };
         harness.TestService<ITransformEngine>(callerMock,userAccessMock,moduleAccessMock);
      }
      [TestMethod]
      [TestCategory("Engine.TransformEngine.ITransformEngine")]
      public void Test_ToResponseAsync_With_UserAccess_As_Poco()
      {
         string request = "Test";

         var moduleAccessMock = new Mock<IModuleAccess>();
         moduleAccessMock.Setup(x=>x.BuildModuleAsync(It.IsAny<string>())).Returns<string>(r=>Task.FromResult(r + " ModuleAccessMock.BuildModuleAsync"));

         Action<ITransformEngine> callerMock = (poco)=>
                                               {
                                                  string result = poco.ToResponseAsync(request).Result;
                                                  Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                  Assert.IsTrue(result.Contains(request) == true);
                                                  Assert.IsTrue(result.Contains("UserAccess.AssembleProfileAsync") == true);
                                                  Assert.IsTrue(result.Contains("ModuleAccessMock.BuildModuleAsync") == true);
                                                  Assert.IsTrue(result.Contains("TransformEngine.ToResponseAsync") == true);
                                               };

         harness.TestServicePoco<ITransformEngine>(callerMock,moduleAccessMock);
      }
      [TestMethod]
      [TestCategory("Engine.TransformEngine.ITransformEngine")]
      public void Test_ToResponseAsync_With_UserAccess_As_Service()
      {
         string request = "Test";

         var moduleAccessMock = new Mock<IModuleAccess>();
         moduleAccessMock.Setup(x=>x.BuildModuleAsync(It.IsAny<string>())).Returns<string>(r=>Task.FromResult(r + " ModuleAccessMock.BuildModuleAsync"));

         Action<ITransformEngine> callerMock = (proxy)=>
                                               {
                                                  string result = proxy.ToResponseAsync(request).Result;
                                                  Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                  Assert.IsTrue(result.Contains(request) == true);
                                                  Assert.IsTrue(result.Contains("UserAccess.AssembleProfileAsync") == true);
                                                  Assert.IsTrue(result.Contains("ModuleAccessMock.BuildModuleAsync") == true);
                                                  Assert.IsTrue(result.Contains("TransformEngine.ToResponseAsync") == true);
                                               };

         harness.TestService<ITransformEngine>(callerMock,moduleAccessMock);
      }
      [TestMethod]
      [TestCategory("Engine.TransformEngine.ITransformEngine")]
      public void Test_ToResponseAsync_With_ModuleAccess_As_Poco()
      {
         string request = "Test";

         var userAccessMock = new Mock<IUserAccess>();
         userAccessMock.Setup(x=>x.AssembleProfileAsync(It.IsAny<string>())).Returns<string>(r=>Task.FromResult(r + " UserAccessMock.AssembleProfileAsync"));

         Action<ITransformEngine> callerMock = (poco)=>
                                               {
                                                  string result = poco.ToResponseAsync(request).Result;
                                                  Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                  Assert.IsTrue(result.Contains(request) == true);
                                                  Assert.IsTrue(result.Contains("UserAccessMock.AssembleProfileAsync") == true);
                                                  Assert.IsTrue(result.Contains("ModuleAccess.BuildModuleAsync") == true);
                                                  Assert.IsTrue(result.Contains("TransformEngine.ToResponseAsync") == true);
                                               };

         harness.TestServicePoco<ITransformEngine>(callerMock,userAccessMock);
      }
      [TestMethod]
      [TestCategory("Engine.TransformEngine.ITransformEngine")]
      public void Test_ToResponseAsync_With_ModuleAccess_As_Service()
      {
         string request = "Test";

         var userAccessMock = new Mock<IUserAccess>();
         userAccessMock.Setup(x=>x.AssembleProfileAsync(It.IsAny<string>())).Returns<string>(r=>Task.FromResult(r + " UserAccessMock.AssembleProfileAsync"));

         Action<ITransformEngine> callerMock = (proxy)=>
                                               {
                                                  string result = proxy.ToResponseAsync(request).Result;
                                                  Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                  Assert.IsTrue(result.Contains(request) == true);
                                                  Assert.IsTrue(result.Contains("UserAccessMock.AssembleProfileAsync") == true);
                                                  Assert.IsTrue(result.Contains("ModuleAccess.BuildModuleAsync") == true);
                                                  Assert.IsTrue(result.Contains("TransformEngine.ToResponseAsync") == true);
                                               };

         harness.TestService<ITransformEngine>(callerMock,userAccessMock);
      }
      [TestMethod]
      [TestCategory("Engine.TransformEngine.ITransformEngine")]
      public void Test_ToResponseAsync_With_NoMocks_As_Poco()
      {
         string request = "Test";

         Action<ITransformEngine> callerMock = (poco)=>
                                               {
                                                  string result = poco.ToResponseAsync(request).Result;
                                                  Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                  Assert.IsTrue(result.Contains(request) == true);
                                                  Assert.IsTrue(result.Contains("UserAccess.AssembleProfileAsync") == true);
                                                  Assert.IsTrue(result.Contains("ModuleAccess.BuildModuleAsync") == true);
                                                  Assert.IsTrue(result.Contains("TransformEngine.ToResponseAsync") == true);
                                               };

         harness.TestServicePoco<ITransformEngine>(callerMock);
      }
      [TestMethod]
      [TestCategory("Engine.TransformEngine.ITransformEngine")]
      public void Test_ToResponseAsync_With_NoMocks_As_Service()
      {
         string request = "Test";

         Action<ITransformEngine> callerMock = (proxy)=>
                                               {
                                                  string result = proxy.ToResponseAsync(request).Result;
                                                  Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                  Assert.IsTrue(result.Contains(request) == true);
                                                  Assert.IsTrue(result.Contains("UserAccess.AssembleProfileAsync") == true);
                                                  Assert.IsTrue(result.Contains("ModuleAccess.BuildModuleAsync") == true);
                                                  Assert.IsTrue(result.Contains("TransformEngine.ToResponseAsync") == true);
                                               };

         harness.TestService<ITransformEngine>(callerMock);
      }
      #endregion
   }
}
