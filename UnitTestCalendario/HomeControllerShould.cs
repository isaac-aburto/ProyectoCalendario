using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ProyectoCalendario.Controllers;
using Xunit;
using Assert = Xunit.Assert;
using System.Web.Mvc;

namespace UnitTestCalendario
{
    [TestClass]
    public class HomeControllerShould
    {
        [Fact]
        public void ValidateValidIndex()
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
