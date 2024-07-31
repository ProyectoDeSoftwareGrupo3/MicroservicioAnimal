using AnimalRepository;
using Application;
using Application.Interfaces.ICurrentUser;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AnimalTesting.Animal.Command;

public class CreateAnimalTests
{
    private readonly Mock<IAnimalServices> _mockAnimalServices;
    private readonly Mock<ICurrentUserService> _mockCurrentUserService;
    private readonly AnimalController _controller;

    public CreateAnimalTests()
    {
        _mockAnimalServices = new Mock<IAnimalServices>();
        _mockCurrentUserService = new Mock<ICurrentUserService>();
        _controller = new AnimalController(_mockAnimalServices.Object);
    }

    [Fact]
    public async Task CreateAnimal_Returns201StatusCode_WhenAnimalIsCreated()
    {
        // Arrange
        var createAnimalRequest = new CreateAnimalRequest
        {
            RazaId = 1,
            Nombre = "Max",
            Genero = true,
            Edad = 3,
            Peso = 20.5m,
            Historia = "Max fue rescatado de la calle y es muy amigable.",
            Foto = new FormFile(null, 0, 0, null, "max.jpg")
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
        _mockAnimalServices.Setup(service => service.CreateAnimal(It.IsAny<CreateAnimalRequest>(), It.IsAny<string>(), It.IsAny<string>()))
                           .ReturnsAsync(getAnimalResponse);

        // Act
        var result = await _controller.CreateAnimal(createAnimalRequest, _mockCurrentUserService.Object);

        // Assert
        var jsonResult = Assert.IsType<JsonResult>(result);
        Assert.Equal(201, jsonResult.StatusCode);
        Assert.Equal(getAnimalResponse, jsonResult.Value);
    }

}
