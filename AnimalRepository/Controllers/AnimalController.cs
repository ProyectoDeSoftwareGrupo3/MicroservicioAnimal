using Application;
using Application.Request;
using Microsoft.AspNetCore.Mvc;

namespace AnimalRepository;
[Route("api/[controller]")]
[ApiController]
public class AnimalController : ControllerBase
{
    private readonly IAnimalServices _animalServices;

    public AnimalController(IAnimalServices animalServices)
    {
        _animalServices = animalServices;
    }
    [HttpPost]
    public async Task<IActionResult> CreateAnimal(CreateAnimalRequest request)
    {
        try
        {
            var result = _animalServices.CreateAnimal(request);
            return new JsonResult(result){StatusCode = 201};
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpPatch]
    public async Task<IActionResult> UpdateAnimal(UpdateAnimalRequest request)
    {
        try
        {
            var result = _animalServices.UpdateAnimal(request);
            return new JsonResult(result){StatusCode = 201};
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteAnimal(DeleteAnimalRequest request)
    {
        try
        {
            var result = _animalServices.DeleteAnimal(request);
            return new JsonResult(result){StatusCode = 201};
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpGet]
    public async Task<IActionResult> GetListAnimal()
    {
        try
        {
            var result = await _animalServices.GetListAnimal();
            return new JsonResult(result){StatusCode = 201};
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAnimalById(int id)
    {
        try
        {
            var result = _animalServices.GetAnimalById(id);
            return new JsonResult(result){StatusCode = 201};
        }
        catch (Exception)
        {
            throw;
        }
    }
}
