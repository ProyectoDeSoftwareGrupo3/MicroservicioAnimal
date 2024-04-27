using Application;
using Application.Exceptions;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public async Task<IActionResult> CreateAnimal(CreateAnimalRequest request)
    {
        try
        {
            var result = _animalServices.CreateAnimal(request);
            return new JsonResult(result) { StatusCode = 201 };
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateAnimal(UpdateAnimalRequest request)
    {
        try
        {
            var result = _animalServices.UpdateAnimal(request);
            return new JsonResult(result) { StatusCode = 201 };
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> DeleteAnimal(DeleteAnimalRequest request)
    {
        try
        {
            var result = _animalServices.DeleteAnimal(request);
            return new JsonResult(result) { StatusCode = 201 };
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetListAnimal()
    {
        try
        {
            var result = await _animalServices.GetListAnimal();
            return new JsonResult(result) { StatusCode = 201 };
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(typeof(GetAnimalResponse), 200)]
    [ProducesResponseType(typeof(ExceptionMessage), 404)]
    public async Task<IActionResult> GetAnimalById(int id)
    {
        try
        {
            var result = await _animalServices.GetAnimalById(id);
            return new JsonResult(result) { StatusCode = 200 };
        }
        catch (ExceptionNotFound ex)
        {

            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
        }
    }

    [HttpGet("PorGenero/{genero}")]
    [Authorize]
    public async Task<IActionResult> GetByGender(String genero)
    {
        try
        {
            var result = await _animalServices.GetByGender(genero);
            return new JsonResult(result) { StatusCode = 201 };
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpGet("PorPeso/{peso}")]
    [Authorize]
    public async Task<IActionResult> GetByWeight(decimal peso)
    {
        try
        {
            var result = await _animalServices.GetByWeight(peso);
            return new JsonResult(result) { StatusCode = 201 };
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpGet("PorEdad/{edad}")]
    [Authorize]
    public async Task<IActionResult> GetByAge(int edad)
    {
        try
        {
            var result = await _animalServices.GetByAge(edad);
            return new JsonResult(result) { StatusCode = 201 };
        }
        catch (Exception)
        {
            throw;
        }
    }
}
