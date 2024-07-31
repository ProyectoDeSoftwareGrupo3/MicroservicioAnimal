using AnimalRepository;
using Application;
using Application.Exceptions;
using Application.Interfaces.ICurrentUser;
using Application.Request;
using Application.Response;
using Application.UseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace AnimalTesting
{
    public class AnimalTest1
    {
        private readonly AnimalController _controller;
        private readonly Mock<IAnimalServices> _mockAnimalServices;
        private readonly Mock<IWebHostEnvironment> _mockHostingEnvironment;

        public AnimalTest1()
        {
            // Crear mocks para las dependencias
            _mockAnimalServices = new Mock<IAnimalServices>();
            _mockHostingEnvironment = new Mock<IWebHostEnvironment>();

            // Configuración del controlador con los mocks
            _controller = new AnimalController(_mockAnimalServices.Object);
        }

        [Fact]
        //Obtiene una lista de animales
        public async void Test1()
        {
            // Arrange
            int expectedStatusCode = 200;

            // Configuración del mock para devolver un resultado esperado
            _mockAnimalServices.Setup(service => service.GetListAnimal(null, null, null, null, null, null, null))
                               .ReturnsAsync(new List<GetAnimalResponse>());

            // Act
            IActionResult result = await _controller.GetListAnimal(null, null, null, null, null, null, null);
            var jsonResult = result as JsonResult;

            // Assert
            Assert.NotNull(jsonResult);
            Assert.Equal(expectedStatusCode, jsonResult.StatusCode);
        }

        [Fact]
        // Filtro nombre inexistente
        public async Task Test2()
        {
            // Arrange
            int expectedStatusCode = 200;
            string name = "Animal Test 00000000";

            // Configuración del mock para devolver un resultado vacío
            _mockAnimalServices.Setup(service => service.GetListAnimal(name, null, null, null, null, null, null))
                               .ReturnsAsync(new List<GetAnimalResponse>());

            // Act
            IActionResult result = await _controller.GetListAnimal(name, null, null, null, null, null, null);
            var jsonResult = result as JsonResult;

            // Assert
            Assert.NotNull(jsonResult); // Verifica que el resultado no sea nulo
            if (jsonResult != null)
            {
                Assert.Equal(expectedStatusCode, jsonResult.StatusCode); // Verifica que el estado sea 200
                Assert.NotNull(jsonResult.Value); // Asegura que el valor no sea nulo
                Assert.Empty((List<GetAnimalResponse>)jsonResult.Value); // Verifica que la lista esté vacía
            }
        }


        [Fact]
        //Crear animal con raza inexistente
        public async Task Test3()
        {
            // Arrange
            int expectedStatusCode = 201;

            Random random = new Random();

            int razaId = random.Next(300, 500);
            string nombre = "Nombre_" + random.Next(1, 1000);
            bool genero = random.Next(0, 2) == 0;
            int edad = random.Next(1, 20);
            decimal peso = (decimal)(random.NextDouble() * (200 - 30) + 30);
            string historia = "Historia_" + random.Next(1, 1000);
            IFormFile foto = null; // Asigna un archivo si es necesario
            string url = "Url_" + random.Next(1, 1000);
            string guid = "00000000-0000-0000-0000-000000000000";
            ICurrentUserService user = new Mock<ICurrentUserService>().Object;

            var animalRequest = new CreateAnimalRequest
            {
                RazaId = razaId,
                Nombre = nombre,
                Genero = genero,
                Edad = edad,
                Peso = peso,
                Historia = historia,
                Foto = foto
            };

            // Configura el mock para que devuelva un resultado esperado
            _mockAnimalServices
                .Setup(service => service.CreateAnimal(animalRequest, guid, url))
                .ThrowsAsync(new ExceptionNotFound("Simulated conflict exception"));

            // Act
            IActionResult result = await _controller.CreateAnimal(animalRequest, user);
            var jsonResult = result as JsonResult;

            // Assert
            Assert.NotNull(jsonResult); // Verifica que el resultado no sea nulo
            if (jsonResult != null)
            {
                Assert.Equal(expectedStatusCode, jsonResult.StatusCode); // Verifica el código de estado esperado
                Assert.NotNull(jsonResult.Value); // Asegura que el valor no sea nulo
                                                 
            }
        }

        [Fact]
        public async Task Test4()
        {
            // Arrange
            int expectedStatusCode = 200;
            string name = "Animal Test 00000000";

            // Configuración del mock para devolver un resultado vacío
            _mockAnimalServices.Setup(service => service.GetListAnimal(name, null, null, null, null, null, null))
                               .ReturnsAsync(new List<GetAnimalResponse>());

            // Act
            IActionResult result = await _controller.GetListAnimal(name, null, null, null, null, null, null);
            var jsonResult = result as JsonResult;

            // Assert
            Assert.NotNull(jsonResult); // Verifica que el resultado no sea nulo
            if (jsonResult != null)
            {
                Assert.Equal(expectedStatusCode, jsonResult.StatusCode); // Verifica que el estado sea 200
                Assert.NotNull(jsonResult.Value); // Asegura que el valor no sea nulo
                Assert.Empty((List<GetAnimalResponse>)jsonResult.Value); // Verifica que la lista esté vacía
            }
        }
        [Fact]
        public async Task Test5()
        {
            // Arrange
            int expectedStatusCode = 200;
            string name = "Animal Test 00000000";

            // Configuración del mock para devolver un resultado vacío
            _mockAnimalServices.Setup(service => service.GetListAnimal(name, null, null, null, null, null, null))
                               .ReturnsAsync(new List<GetAnimalResponse>());

            // Act
            IActionResult result = await _controller.GetListAnimal(name, null, null, null, null, null, null);
            var jsonResult = result as JsonResult;

            // Assert
            Assert.NotNull(jsonResult); // Verifica que el resultado no sea nulo
            if (jsonResult != null)
            {
                Assert.Equal(expectedStatusCode, jsonResult.StatusCode); // Verifica que el estado sea 200
                Assert.NotNull(jsonResult.Value); // Asegura que el valor no sea nulo
                Assert.Empty((List<GetAnimalResponse>)jsonResult.Value); // Verifica que la lista esté vacía
            }
        }

        [Fact]
        public async Task Test6()
        {
            // Arrange
            int expectedStatusCode = 200;
            string name = "Animal Test 00000000";

            // Configuración del mock para devolver un resultado vacío
            _mockAnimalServices.Setup(service => service.GetListAnimal(name, null, null, null, null, null, null))
                               .ReturnsAsync(new List<GetAnimalResponse>());

            // Act
            IActionResult result = await _controller.GetListAnimal(name, null, null, null, null, null, null);
            var jsonResult = result as JsonResult;

            // Assert
            Assert.NotNull(jsonResult); // Verifica que el resultado no sea nulo
            if (jsonResult != null)
            {
                Assert.Equal(expectedStatusCode, jsonResult.StatusCode); // Verifica que el estado sea 200
                Assert.NotNull(jsonResult.Value); // Asegura que el valor no sea nulo
                Assert.Empty((List<GetAnimalResponse>)jsonResult.Value); // Verifica que la lista esté vacía
            }
        }

        [Fact]
        public async Task Test7()
        {
            // Arrange
            int expectedStatusCode = 200;
            string name = "Animal Test 00000000";

            // Configuración del mock para devolver un resultado vacío
            _mockAnimalServices.Setup(service => service.GetListAnimal(name, null, null, null, null, null, null))
                               .ReturnsAsync(new List<GetAnimalResponse>());

            // Act
            IActionResult result = await _controller.GetListAnimal(name, null, null, null, null, null, null);
            var jsonResult = result as JsonResult;

            // Assert
            Assert.NotNull(jsonResult); // Verifica que el resultado no sea nulo
            if (jsonResult != null)
            {
                Assert.Equal(expectedStatusCode, jsonResult.StatusCode); // Verifica que el estado sea 200
                Assert.NotNull(jsonResult.Value); // Asegura que el valor no sea nulo
                Assert.Empty((List<GetAnimalResponse>)jsonResult.Value); // Verifica que la lista esté vacía
            }
        }

        [Fact]
        public async Task Test8()
        {
            // Arrange
            int expectedStatusCode = 200;
            string name = "Animal Test 00000000";

            // Configuración del mock para devolver un resultado vacío
            _mockAnimalServices.Setup(service => service.GetListAnimal(name, null, null, null, null, null, null))
                               .ReturnsAsync(new List<GetAnimalResponse>());

            // Act
            IActionResult result = await _controller.GetListAnimal(name, null, null, null, null, null, null);
            var jsonResult = result as JsonResult;

            // Assert
            Assert.NotNull(jsonResult); // Verifica que el resultado no sea nulo
            if (jsonResult != null)
            {
                Assert.Equal(expectedStatusCode, jsonResult.StatusCode); // Verifica que el estado sea 200
                Assert.NotNull(jsonResult.Value); // Asegura que el valor no sea nulo
                Assert.Empty((List<GetAnimalResponse>)jsonResult.Value); // Verifica que la lista esté vacía
            }
        }
        [Fact]
        public async Task Test9()
        {
            // Arrange
            int expectedStatusCode = 200;
            string name = "Animal Test 00000000";

            // Configuración del mock para devolver un resultado vacío
            _mockAnimalServices.Setup(service => service.GetListAnimal(name, null, null, null, null, null, null))
                               .ReturnsAsync(new List<GetAnimalResponse>());

            // Act
            IActionResult result = await _controller.GetListAnimal(name, null, null, null, null, null, null);
            var jsonResult = result as JsonResult;

            // Assert
            Assert.NotNull(jsonResult); // Verifica que el resultado no sea nulo
            if (jsonResult != null)
            {
                Assert.Equal(expectedStatusCode, jsonResult.StatusCode); // Verifica que el estado sea 200
                Assert.NotNull(jsonResult.Value); // Asegura que el valor no sea nulo
                Assert.Empty((List<GetAnimalResponse>)jsonResult.Value); // Verifica que la lista esté vacía
            }
        }

        [Fact]
        public async Task Test10()
        {
            // Arrange
            int expectedStatusCode = 200;
            string name = "Animal Test 00000000";

            // Configuración del mock para devolver un resultado vacío
            _mockAnimalServices.Setup(service => service.GetListAnimal(name, null, null, null, null, null, null))
                               .ReturnsAsync(new List<GetAnimalResponse>());

            // Act
            IActionResult result = await _controller.GetListAnimal(name, null, null, null, null, null, null);
            var jsonResult = result as JsonResult;

            // Assert
            Assert.NotNull(jsonResult); // Verifica que el resultado no sea nulo
            if (jsonResult != null)
            {
                Assert.Equal(expectedStatusCode, jsonResult.StatusCode); // Verifica que el estado sea 200
                Assert.NotNull(jsonResult.Value); // Asegura que el valor no sea nulo
                Assert.Empty((List<GetAnimalResponse>)jsonResult.Value); // Verifica que la lista esté vacía
            }
        }
    }
}
