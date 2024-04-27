using System.Text.Json;
using Application.Interfaces.IAnimalTipo;
using Application.Request;
using Application.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
    [HttpPut]
    [Authorize]
    public async Task<IActionResult>UpdateAnimalTipo(UpdateAnimalTipoRequest request)
    {
        try
        {
            var result = _animalTipoService.UpdateAnimalTipo(request);
            return new JsonResult(result) {StatusCode = 201};
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpDelete]
    [Authorize]
    public async Task<IActionResult>DeleteAnimalTipo(DeleteAnimalTipoRequest request)
    {
        try
        {
            var result = _animalTipoService.DeleteAnimalTipo(request);
            return new JsonResult(result){StatusCode = 201};
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult>GetAnimalTipoById(int id)
    {
        try
        {
            var animalTipo = _animalTipoService.GetAnimalTipoById(id);
            return new JsonResult(animalTipo){StatusCode = 201};
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpGet]
    [Authorize]
    public async Task<IActionResult>GetListAnimalTipo()
    {
        try
        {
            var result = await _animalTipoService.GetListAnimalTipo();
            return new JsonResult(result){StatusCode = 201};
        }
        catch (Exception)
        {
            throw;
        }
    }
}
