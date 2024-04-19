using Application.Interfaces.IAnimalTipo;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace AnimalRepository.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalTipoController : ControllerBase
{
    private readonly IAnimalTipoService _animalTipoService;

    public AnimalTipoController(IAnimalTipoService animalTipoService)
    {
        _animalTipoService = animalTipoService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateAnimalTipoResponse),201)]
    public async Task<IActionResult>CreateAnimalTipo(CreateAnimalTipoRequest request)
    {
        try
        {
            var result = _animalTipoService.CreateAnimalTipo(request);
            return new JsonResult(result) { StatusCode = 201 };
        }
        catch (Exception)
        {
            throw;
        }
        }
}
