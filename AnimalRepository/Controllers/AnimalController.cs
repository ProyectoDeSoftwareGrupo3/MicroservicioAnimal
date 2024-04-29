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
    [ProducesResponseType(typeof(GetAnimalResponse), 201)]
    [ProducesResponseType(typeof(ExceptionMessage), 409)]
    public async Task<IActionResult> CreateAnimal(CreateAnimalRequest request)
    {
        try
        {
            var result =await _animalServices.CreateAnimal(request);
            return new JsonResult(result) { StatusCode = 201 };
        }
        catch (Conflict ex)
        {

            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 409 };
        }
    }
    [HttpPut]
    [Authorize]
    [ProducesResponseType(typeof(GetAnimalResponse), 200)]
    [ProducesResponseType(typeof(ExceptionMessage), 404)]
    public async Task<IActionResult> UpdateAnimal(UpdateAnimalRequest request)
    {
        try
        {
            var result =await _animalServices.UpdateAnimal(request);
            return new JsonResult(result) { StatusCode = 201 };
        }
        catch (ExceptionNotFound ex)
        {

            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
        }
    }
    [HttpDelete]
    [ProducesResponseType(typeof(DeleteAnimalResponse), 200)]
    [ProducesResponseType(typeof(ExceptionMessage), 404)]
    [Authorize]
    public async Task<IActionResult> DeleteAnimal(int id)
    {
        try
        {
            var result = await _animalServices.DeleteAnimal(id);
            return new JsonResult(result) { StatusCode = 200 };
        }
        catch (ExceptionNotFound ex)
        {

            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
        }
    }
    [HttpGet]
    [Authorize]
    [ProducesResponseType(typeof(GetAnimalResponse), 200)]
    public async Task<IActionResult> GetListAnimal()
    {
        var result = await _animalServices.GetListAnimal();
        return new JsonResult(result) { StatusCode = 200 };


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

    //[HttpGet("PorGenero/{genero}")]
    //[Authorize]
    //public async Task<IActionResult> GetByGender(String genero)
    //{
    //    try
    //    {
    //        var result = await _animalServices.GetByGender(genero);
    //        return new JsonResult(result) { StatusCode = 201 };
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //}
    //[HttpGet("PorPeso/{peso}")]
    //[Authorize]
    //public async Task<IActionResult> GetByWeight(decimal peso)
    //{
    //    try
    //    {
    //        var result = await _animalServices.GetByWeight(peso);
    //        return new JsonResult(result) { StatusCode = 201 };
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //}
    //[HttpGet("PorEdad/{edad}")]
    //[Authorize]
    //public async Task<IActionResult> GetByAge(int edad)
    //{
    //    try
    //    {
    //        var result = await _animalServices.GetByAge(edad);
    //        return new JsonResult(result) { StatusCode = 201 };
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //}
}
