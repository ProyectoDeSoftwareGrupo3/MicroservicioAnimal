using AnimalRepository;
using Application.Interfaces.ICurrentUser;
using Application;
using Application.Response;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions;

namespace AnimalTesting.Animal.Queries
{
    public class GetAnimalTests
    {
        private readonly Mock<IAnimalServices> _mockAnimalServices;
        private readonly AnimalController _controller;

        public GetAnimalTests()
        {
            _mockAnimalServices = new Mock<IAnimalServices>();
            _controller = new AnimalController(_mockAnimalServices.Object);
        }
        [Fact]
        public async void GetAnimal_Returns200StatusCode_WhenAnimalsIsObtained()
        {
            // Arrange
            _mockAnimalServices.Setup(service => service.GetListAnimal(It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                               .ReturnsAsync(new List<GetAnimalResponse>());

            // Act
            IActionResult result = await _controller.GetListAnimal(null, null, null, null, null, null, null);
            var jsonResult = result as JsonResult;

            // Assert
            Assert.NotNull(jsonResult);
            Assert.Equal(200, jsonResult.StatusCode);
        }        
    }  
}
