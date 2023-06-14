using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoCalendario.Controllers;
using System.Web.Mvc;
using Assert = Xunit.Assert;


namespace UnitTestHomeControllerCalendario
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void ValidarIndex()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);

            var viewResult = result as ViewResult;
            var viewData = viewResult.ViewData;

            Assert.NotNull(viewData);
            Assert.True(viewData.ContainsKey("nombreUsuario"));
            Assert.Equal("Isaac", viewData["nombreUsuario"]);
        
        }
    }
}
