using Application;
using Application.Exceptions;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalRepository;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AnimalController : ControllerBase
{
    private readonly IAnimalServices _animalServices;

    public AnimalController(IAnimalServices animalServices)
    {
        _animalServices = animalServices;
    }

    [HttpPost]
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
    [ProducesResponseType(typeof(List<GetAnimalResponse>), 200)]
    public async Task<IActionResult> GetListAnimal(decimal? peso, int? edad, bool? genero, int? tipoId, int? razaId)
    {
        var result = await _animalServices.GetListAnimal(peso,edad, genero, tipoId, razaId);
        return new JsonResult(result) { StatusCode = 200 };

    }
    [HttpGet("{id}")]
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

    [HttpPost]
    [Route("AddMedia")]
    [ProducesResponseType(typeof(GetAnimalResponse), 201)]
    [ProducesResponseType(typeof(ExceptionMessage), 404)]
    public async Task<IActionResult> AddMedia(CreateFotoRequest request)
    {
        try
        {
            var result = await _animalServices.AddMedia(request);
            return new JsonResult(result) { StatusCode = 201 };
        }
        catch (ExceptionNotFound ex)
        {
            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
        }
    }
    [HttpDelete]
    [Route("DeleteMedia")]
    [ProducesResponseType(typeof(GetAnimalResponse), 200)]
    [ProducesResponseType(typeof(ExceptionMessage), 409)]
    public async Task<IActionResult> DeleteMedia(DeleteFotoRequest request)
    {
        try
        {
            var result = await _animalServices.DeleteMedia(request);
            return new JsonResult(result) { StatusCode = 200 };
        }
        catch (Conflict ex)
        {
            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 409 };
        }
    }

}
