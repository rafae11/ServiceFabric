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
using Company.Manager.Content.Interface;
using Company.Manager.Content.Service;

namespace Test.Unit.Content
{
   [TestClass]
   public class ManagerUnitTests
   {
      UnitTestHarness harness = null;

      [TestInitialize]
      public void Setup()
      {
         harness = new UnitTestHarness();
         harness.Setup(typeof(UserAccess),
                       typeof(ModuleAccess),
                       typeof(TransformEngine),
                       typeof(ValidationEngine),
                       typeof(ContentManager));
      }
      [TestCleanup]
      public void Cleanup()
      {
         harness.Cleanup();
      }

      #region ContentManager.IContentManager
      [TestMethod]
      [TestCategory("Manager.ContentManager.IContentManager")]
      public void Test_RequestContentAsync_With_AllMocks_As_Poco()
      {
         string request = "Test";

         var validationEngineMock = new Mock<IValidationEngine>();
         validationEngineMock.Setup(x=>x.ConfirmRequestAsync(It.IsAny<string>())).Returns<string>(r=>Task.FromResult(r + " ValidationEngineMock.ConfirmRequestAsync"));

         var transformEngineMock = new Mock<ITransformEngine>();
         transformEngineMock.Setup(x=>x.ToResponseAsync(It.IsAny<string>())).Returns<string>(r=>Task.FromResult(r + " TransformEngineMock.ToResponseAsync->" + " UserAccessMock.AssembleProfileAsync" + " ModuleAccessMock.BuildModuleAsync"));

         Action<IContentManager> callerMock = (poco)=>
                                              {
                                                 string result = poco.RequestContentAsync(request).Result;
                                                 Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                 Assert.IsTrue(result.Contains(request) == true);
                                                 Assert.IsTrue(result.Contains("ValidationEngineMock.ConfirmRequestAsync") == true);
                                                 Assert.IsTrue(result.Contains("UserAccessMock.AssembleProfileAsync") == true);
                                                 Assert.IsTrue(result.Contains("ModuleAccessMock.BuildModuleAsync") == true);
                                                 Assert.IsTrue(result.Contains("TransformEngineMock.ToResponseAsync") == true);
                                              };
                                               
         harness.TestServicePoco<IContentManager>(callerMock,validationEngineMock,transformEngineMock);
      }
      [TestMethod]
      [TestCategory("Manager.ContentManager.IContentManager")]
      public void Test_RequestContentAsync_With_AllMocks_As_Service()
      {
         string request = "Test";

         var validationEngineMock = new Mock<IValidationEngine>();
         validationEngineMock.Setup(x=>x.ConfirmRequestAsync(It.IsAny<string>())).Returns<string>(r=>Task.FromResult(r + " ValidationEngineMock.ConfirmRequestAsync"));

         var transformEngineMock = new Mock<ITransformEngine>();
         transformEngineMock.Setup(x=>x.ToResponseAsync(It.IsAny<string>())).Returns<string>(r=>Task.FromResult(r + " TransformEngineMock.ToResponseAsync->" + " UserAccessMock.AssembleProfileAsync" + " ModuleAccessMock.BuildModuleAsync"));

         Action<IContentManager> callerMock = (proxy)=>
                                              {
                                                 string result = proxy.RequestContentAsync(request).Result;
                                                 Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                 Assert.IsTrue(result.Contains(request) == true);
                                                 Assert.IsTrue(result.Contains("ValidationEngineMock.ConfirmRequestAsync") == true);
                                                 Assert.IsTrue(result.Contains("UserAccessMock.AssembleProfileAsync") == true);
                                                 Assert.IsTrue(result.Contains("ModuleAccessMock.BuildModuleAsync") == true);
                                                 Assert.IsTrue(result.Contains("TransformEngineMock.ToResponseAsync") == true);
                                              };

         harness.TestService<IContentManager>(callerMock,validationEngineMock,transformEngineMock);
      }
      [TestMethod]
      [TestCategory("Manager.ContentManager.IContentManager")]
      public void Test_RequestContentAsync_With_ValidationEngine_As_Poco()
      {
         string request = "Test";

         var transformEngineMock = new Mock<ITransformEngine>();
         transformEngineMock.Setup(x=>x.ToResponseAsync(It.IsAny<string>())).Returns<string>(r=>Task.FromResult(r + " TransformEngineMock.ToResponseAsync->" + " UserAccessMock.AssembleProfileAsync" + " ModuleAccessMock.BuildModuleAsync"));

         Action<IContentManager> callerMock = (poco)=>
                                              {
                                                 string result = poco.RequestContentAsync(request).Result;
                                                 Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                 Assert.IsTrue(result.Contains(request) == true);
                                                 Assert.IsTrue(result.Contains("ValidationEngine.ConfirmRequestAsync") == true);
                                                 Assert.IsTrue(result.Contains("UserAccessMock.AssembleProfileAsync") == true);
                                                 Assert.IsTrue(result.Contains("ModuleAccessMock.BuildModuleAsync") == true);
                                                 Assert.IsTrue(result.Contains("TransformEngineMock.ToResponseAsync") == true);
                                              };

         harness.TestServicePoco<IContentManager>(callerMock,transformEngineMock);
      }
      [TestMethod]
      [TestCategory("Manager.ContentManager.IContentManager")]
      public void Test_RequestContentAsync_With_ValidationEngine_As_Service()
      {
         string request = "Test";

         var transformEngineMock = new Mock<ITransformEngine>();
         transformEngineMock.Setup(x=>x.ToResponseAsync(It.IsAny<string>())).Returns<string>(r=>Task.FromResult(r + " TransformEngineMock.ToResponseAsync->" + " UserAccessMock.AssembleProfileAsync" + " ModuleAccessMock.BuildModuleAsync"));

         Action<IContentManager> callerMock = (proxy)=>
                                              {
                                                 string result = proxy.RequestContentAsync(request).Result;
                                                 Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                 Assert.IsTrue(result.Contains(request) == true);
                                                 Assert.IsTrue(result.Contains("ValidationEngine.ConfirmRequestAsync") == true);
                                                 Assert.IsTrue(result.Contains("UserAccessMock.AssembleProfileAsync") == true);
                                                 Assert.IsTrue(result.Contains("ModuleAccessMock.BuildModuleAsync") == true);
                                                 Assert.IsTrue(result.Contains("TransformEngineMock.ToResponseAsync") == true);
                                              };

         harness.TestService<IContentManager>(callerMock,transformEngineMock);
      }
      [TestMethod]
      [TestCategory("Manager.ContentManager.IContentManager")]
      public void Test_RequestContentAsync_With_TransformEngine_And_AccessMocks_As_Poco()
      {
         string request = "Test";

         var validationEngineMock = new Mock<IValidationEngine>();
         validationEngineMock.Setup(x=>x.ConfirmRequestAsync(It.IsAny<string>())).Returns<string>(r=>Task.FromResult(r + " ValidationEngineMock.ConfirmRequestAsync"));

         var userAccessMock = new Mock<IUserAccess>();
         userAccessMock.Setup(x=>x.AssembleProfileAsync(It.IsAny<string>())).Returns<string>(r=>Task.FromResult(r + " UserAccessMock.AssembleProfileAsync"));

         var moduleAccessMock = new Mock<IModuleAccess>();
         moduleAccessMock.Setup(x=>x.BuildModuleAsync(It.IsAny<string>())).Returns<string>(r=>Task.FromResult(r + " ModuleAccessMock.BuildModuleAsync"));

         Action<IContentManager> callerMock = (poco)=>
                                              {
                                                 string result = poco.RequestContentAsync(request).Result;
                                                 Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                 Assert.IsTrue(result.Contains(request) == true);
                                                 Assert.IsTrue(result.Contains("ValidationEngineMock.ConfirmRequestAsync") == true);
                                                 Assert.IsTrue(result.Contains("UserAccessMock.AssembleProfileAsync") == true);
                                                 Assert.IsTrue(result.Contains("ModuleAccessMock.BuildModuleAsync") == true);
                                                 Assert.IsTrue(result.Contains("TransformEngine.ToResponseAsync") == true);
                                              };

         harness.TestServicePoco<IContentManager>(callerMock,validationEngineMock,userAccessMock,moduleAccessMock);
      }
      [TestMethod]
      [TestCategory("Manager.ContentManager.IContentManager")]
      public void Test_RequestContentAsync_With_TransformEngine_And_AccessMocks_As_Service()
      {
         string request = "Test";

         var validationEngineMock = new Mock<IValidationEngine>();
         validationEngineMock.Setup(x=>x.ConfirmRequestAsync(It.IsAny<string>())).Returns<string>(r=>Task.FromResult(r + " ValidationEngineMock.ConfirmRequestAsync"));

         var userAccessMock = new Mock<IUserAccess>();
         userAccessMock.Setup(x=>x.AssembleProfileAsync(It.IsAny<string>())).Returns<string>(r=>Task.FromResult(r + " UserAccessMock.AssembleProfileAsync"));

         var moduleAccessMock = new Mock<IModuleAccess>();
         moduleAccessMock.Setup(x=>x.BuildModuleAsync(It.IsAny<string>())).Returns<string>(r=>Task.FromResult(r + " ModuleAccessMock.BuildModuleAsync"));

         Action<IContentManager> callerMock = (proxy)=>
                                              {
                                                 string result = proxy.RequestContentAsync(request).Result;
                                                 Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                 Assert.IsTrue(result.Contains(request) == true);
                                                 Assert.IsTrue(result.Contains("ValidationEngineMock.ConfirmRequestAsync") == true);
                                                 Assert.IsTrue(result.Contains("UserAccessMock.AssembleProfileAsync") == true);
                                                 Assert.IsTrue(result.Contains("ModuleAccessMock.BuildModuleAsync") == true);
                                                 Assert.IsTrue(result.Contains("TransformEngine.ToResponseAsync") == true);
                                              };

         harness.TestService<IContentManager>(callerMock,validationEngineMock,userAccessMock,moduleAccessMock);
      }
      [TestMethod]
      [TestCategory("Manager.ContentManager.IContentManager")]
      public void Test_RequestContentAsync_With_NoMocks_As_Poco()
      {
         string request = "Test";

         Action<IContentManager> callerMock = (poco)=>
                                              {
                                                 string result = poco.RequestContentAsync(request).Result;
                                                 Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                 Assert.IsTrue(result.Contains(request) == true);
                                                 Assert.IsTrue(result.Contains("ValidationEngine.ConfirmRequestAsync") == true);
                                                 Assert.IsTrue(result.Contains("UserAccess.AssembleProfileAsync") == true);
                                                 Assert.IsTrue(result.Contains("ModuleAccess.BuildModuleAsync") == true);
                                                 Assert.IsTrue(result.Contains("TransformEngine.ToResponseAsync") == true);
                                              };

         harness.TestServicePoco<IContentManager>(callerMock);
      }
      [TestMethod]
      [TestCategory("Manager.ContentManager.IContentManager")]
      public void Test_RequestContentAsync_With_NoMocks_As_Service()
      {
         string request = "Test";

         Action<IContentManager> callerMock = (proxy)=>
                                              {
                                                 string result = proxy.RequestContentAsync(request).Result;
                                                 Assert.IsTrue(string.IsNullOrEmpty(result) == false);
                                                 Assert.IsTrue(result.Contains(request) == true);
                                                 Assert.IsTrue(result.Contains("ValidationEngine.ConfirmRequestAsync") == true);
                                                 Assert.IsTrue(result.Contains("UserAccess.AssembleProfileAsync") == true);
                                                 Assert.IsTrue(result.Contains("ModuleAccess.BuildModuleAsync") == true);
                                                 Assert.IsTrue(result.Contains("TransformEngine.ToResponseAsync") == true);
                                              };

         harness.TestService<IContentManager>(callerMock);
      }
      #endregion
   }
}
