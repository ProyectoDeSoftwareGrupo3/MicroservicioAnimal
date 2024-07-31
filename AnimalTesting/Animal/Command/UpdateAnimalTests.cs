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
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace AnimalTesting.Animal.Command
{
    public class UpdateAnimalTests
    {
        private readonly Mock<IAnimalServices> _mockAnimalServices;
        private readonly Mock<ICurrentUserService> _mockCurrentUserService;
        private readonly AnimalController _controller;

        public UpdateAnimalTests()
        {
            _mockAnimalServices = new Mock<IAnimalServices>();
            _mockCurrentUserService = new Mock<ICurrentUserService>();
            _controller = new AnimalController(_mockAnimalServices.Object);
        }

        [Fact]
        public async Task UpdateAnimal_Returns200StatusCode_WhenAnimalIsUpdated()
        {
            // Arrange
            var updateAnimalRequest = new UpdateAnimalRequest
            {
                Id = 1,
                AnimalRazaId = 1,
                Nombre = "Max",
                Genero = true,
                Edad = 3,
                Peso = 20.5m,
                Historia = "Max fue rescatado de la calle y es muy amigable.",
                Adoptado = false
            };

            var getAnimalResponse = new GetAnimalResponse
            {
                Id = 1,
                Nombre = "Max",
                Genero = true, // true para macho, false para hembra
                Edad = 3,
                Peso = 20.5m,
                Historia = "Max fue rescatado de la calle y es muy amigable.",
                Adoptado = false,
                Media =
                    [
                        new() { url = "https://example.com/max1.jpg" },
                    new() { url = "https://example.com/max2.jpg" }
                    ],
                Raza = new GetAnimalRazaResponse { Tipo = new GetAnimalTipoResponse { Descripcion = "Perro" }, Descripcion = "Pastor Alemán" }
            };
            var currentUser = new CurrentUser("b69b0c7e-ef99-4147-9232-85dcbfadc368", "Fabian Carlos");


            _mockCurrentUserService.Setup(service => service.User).Returns(currentUser);
            _mockAnimalServices.Setup(service => service.UpdateAnimal(It.IsAny<UpdateAnimalRequest>(), It.IsAny<string>()))
                               .ReturnsAsync(getAnimalResponse);

            // Act
            var result = await _controller.UpdateAnimal(updateAnimalRequest, _mockCurrentUserService.Object);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            Assert.Equal(200, jsonResult.StatusCode);
            Assert.Equal(getAnimalResponse, jsonResult.Value);
        }

        [Fact]
        public async Task UpdateAnimal_Returns404StatusCode_WhenAnimalNotExist()
        {
            // Arrange
            var updateAnimalRequest = new UpdateAnimalRequest
            {
                Id = 0,
                AnimalRazaId = 1,
                Nombre = "Max",
                Genero = true,
                Edad = 3,
                Peso = 20.5m,
                Historia = "Max fue rescatado de la calle y es muy amigable.",
                Adoptado = false
            };

            var currentUser = new CurrentUser("b69b0c7e-ef99-4147-9232-85dcbfadc368", "Fabian Carlos");


            _mockCurrentUserService.Setup(service => service.User).Returns(currentUser);
            _mockAnimalServices.Setup(service => service.UpdateAnimal(It.IsAny<UpdateAnimalRequest>(), It.IsAny<string>()))
                               .ThrowsAsync(new ExceptionNotFound("not found"));

            // Act
            var result = await _controller.UpdateAnimal(updateAnimalRequest, _mockCurrentUserService.Object);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            Assert.Equal(404, jsonResult.StatusCode);
        }

    }
}
