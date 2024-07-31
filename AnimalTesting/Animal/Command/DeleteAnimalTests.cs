using AnimalRepository;
using Application.Interfaces.ICurrentUser;
using Application;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace AnimalTesting.Animal.Command
{
    public class DeleteAnimalTests
    {
        private readonly Mock<IAnimalServices> _mockAnimalServices;
        private readonly Mock<ICurrentUserService> _mockCurrentUserService;
        private readonly AnimalController _controller;

        public DeleteAnimalTests()
        {
            _mockAnimalServices = new Mock<IAnimalServices>();
            _mockCurrentUserService = new Mock<ICurrentUserService>();
            _controller = new AnimalController(_mockAnimalServices.Object);
        }

        [Fact]
        public async Task DeleteAnimal_Returns200StatusCode_WhenAnimalIsDeleted()
        {
            // Arrange
            int id = 1;
            var currentUser = new CurrentUser("b69b0c7e-ef99-4147-9232-85dcbfadc368", "Fabian Carlos");
            var deleteAnimalResponse = new DeleteAnimalResponse
            {
                Id = 0,
                Nombre = "Max",
                Adoptado = false,
                Raza = new CreateAnimalRazaResponse { Id = 1, Descripcion = "Pastor Alemán", Tipo = new GetAnimalTipoResponse { Descripcion = "Perro" } }
            };
            _mockCurrentUserService.Setup(service => service.User).Returns(currentUser);
            _mockAnimalServices.Setup(service => service.DeleteAnimal(It.IsAny<int>(), It.IsAny<string>()))
                               .ReturnsAsync(deleteAnimalResponse);

            // Act
            var result = await _controller.DeleteAnimal(id, _mockCurrentUserService.Object);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            Assert.Equal(200, jsonResult.StatusCode);
            Assert.Equal(deleteAnimalResponse, jsonResult.Value);
        }

        [Fact]
        public async Task DeleteAnimal_Returns404StatusCode_WhenAnimalNotFound()
        {
            // Arrange
            int id = 0;
            var currentUser = new CurrentUser("b69b0c7e-ef99-4147-9232-85dcbfadc368", "Fabian Carlos");
            _mockCurrentUserService.Setup(service => service.User).Returns(currentUser);
            _mockAnimalServices.Setup(service => service.DeleteAnimal(It.IsAny<int>(), It.IsAny<string>()))
                               .ThrowsAsync(new ExceptionNotFound("not found"));

            // Act
            var result = await _controller.DeleteAnimal(id, _mockCurrentUserService.Object);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            Assert.Equal(404, jsonResult.StatusCode);
        }

    }
}
