using Application;
using Application.Interfaces.IAnimalGaleria;
using Application.Request;
using Microsoft.AspNetCore.Mvc;

namespace AnimalRepository.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalGaleriaController : ControllerBase
{
    private readonly IAnimalGaleriaServices _animalGaleriaServices;

    public AnimalGaleriaController(IAnimalGaleriaServices animalGaleriaServices)
    {
        _animalGaleriaServices = animalGaleriaServices;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAnimalGaleria(CreateAnimalGaleriaRequest request)
    {
        try
        {
            var result = _animalGaleriaServices.CreateAnimalGaleria(request);
            return new JsonResult(result){StatusCode = 201};
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpPatch]
    public async Task<IActionResult> UpdateAnimalGaleria(UpdateAnimalGaleriaRequest request)
    {
        try
        {
            var result = _animalGaleriaServices.UpdateAnimalGaleria(request);
            return new JsonResult(result){StatusCode = 201};
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteAnimalGaleria(DeleteAnimalGaleriaRequest request)
    {
        try
        {
            var result = _animalGaleriaServices.DeleteAnimalGaleria(request);
            return new JsonResult(result){StatusCode = 201};
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAnimalGaleriaById(int id)
    {
        try
        {
            var animalGaleria = _animalGaleriaServices.GetAnimalGaleriaById(id);
            return new JsonResult(animalGaleria){StatusCode = 201};
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpGet]
    public async Task<IActionResult> GetListAnimalGaleria()
    {
        try
        {
            var result = await _animalGaleriaServices.GetListAnimalGaleria();
            return new JsonResult(result){StatusCode = 201};
        }
        catch (Exception)
        {
            throw;
        }
    }


}
