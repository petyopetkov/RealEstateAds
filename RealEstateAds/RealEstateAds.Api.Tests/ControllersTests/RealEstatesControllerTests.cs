namespace RealEstateAds.Api.Tests.ControllersTests
{
    using System.Web.Http;
    using System.Web.Http.Results;

    using Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class RealEstatesControllerTests
    {
        [TestMethod]
        public void PostShouldValidateInvalidModel()
        {
            var controller = new RealEstatesController(TestObjectFactory.GetRealEstatesServices());
            controller.Configuration = new HttpConfiguration();

            var model = TestObjectFactory.GetInvalidModel();

            controller.Validate(model);
            Assert.IsFalse(controller.ModelState.IsValid);
        }

        [TestMethod]
        public void PostShouldValidateValidModel()
        {
            var controller = new RealEstatesController(TestObjectFactory.GetRealEstatesServices());
            controller.Configuration = new HttpConfiguration();

            var model = TestObjectFactory.GetValidModel();

            controller.Validate(model);
            Assert.IsTrue(controller.ModelState.IsValid);
        }

        [TestMethod]
        public void PostShouldReturnBadRequestWithInvalidModel()
        {
            var controller = new RealEstatesController(TestObjectFactory.GetRealEstatesServices());
            controller.Configuration = new HttpConfiguration();

            var model = TestObjectFactory.GetInvalidModel();

            controller.Validate(model);
            var result = controller.Post(model);

            Assert.AreEqual(typeof(InvalidModelStateResult), result.GetType());
        }

        [TestMethod]
        public void PostShouldReturnBadRequestWithInvalidModelByPrice()
        {
            var controller = new RealEstatesController(TestObjectFactory.GetRealEstatesServices());
            controller.Configuration = new HttpConfiguration();

            var model = TestObjectFactory.GetInvalidModelByPrice();

            controller.Validate(model);
            var result = controller.Post(model);

            Assert.AreEqual(typeof(InvalidModelStateResult), result.GetType());
        }

        
    }
}
