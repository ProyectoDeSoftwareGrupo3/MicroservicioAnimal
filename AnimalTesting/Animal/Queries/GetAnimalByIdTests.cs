using AnimalRepository;
using Application;
using Application.Exceptions;
using Application.Response;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalTesting.Animal.Queries
{
    public class GetAnimalByIdTests
    {
        private readonly Mock<IAnimalServices> _mockAnimalServices;
        private readonly AnimalController _controller;

        public GetAnimalByIdTests()
        {
            _mockAnimalServices = new Mock<IAnimalServices>();
            _controller = new AnimalController(_mockAnimalServices.Object);
        }
        [Fact]
        public async Task GetAnimalById_Returns200StatusCode_WhenAnimalExist()
        {
            // Arrange
            int id = 1;
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

            _mockAnimalServices.Setup(service => service.GetAnimalById(id))
                               .ReturnsAsync(getAnimalResponse);

            // Act
            IActionResult result = await _controller.GetAnimalById(id);
            var jsonResult = result as JsonResult;

            // Assert
            Assert.NotNull(jsonResult);
            Assert.Equal(200, jsonResult.StatusCode);
            Assert.Equal(getAnimalResponse, jsonResult.Value);
        }

        [Fact]
        public async Task GetAnimalById_Returns404StatusCode_WhenAnimalNotExist()
        {
            // Arrange
            int id = 0;

            _mockAnimalServices.Setup(service => service.GetAnimalById(id))
                               .ThrowsAsync(new ExceptionNotFound("not found"));

            // Act
            IActionResult result = await _controller.GetAnimalById(id);
            var jsonResult = result as JsonResult;

            // Assert
            Assert.NotNull(jsonResult);
            Assert.Equal(404, jsonResult.StatusCode);
        }
    }
}
