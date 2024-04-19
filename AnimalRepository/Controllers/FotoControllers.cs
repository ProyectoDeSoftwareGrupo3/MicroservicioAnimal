using Application;
using Application.Interfaces.IFoto;
using Microsoft.AspNetCore.Mvc;

namespace AnimalRepository.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FotoControllers : ControllerBase
{
    private readonly IFotoServices _fotoServices;

    public FotoControllers(IFotoServices fotoServices)
    {
        _fotoServices = fotoServices;
    }
    [HttpPost]
    public async Task<IActionResult> CreateFoto(CreateFotoRequest request)
    {
        try
        {
            var result = _fotoServices.CreateFoto(request);
            return new JsonResult(result){StatusCode = 201};
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetFotoById(int id)
    {
        try
        {
            var result = _fotoServices.GetFotoById(id);
            return new JsonResult(result){StatusCode = 201};
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpGet]
    public async Task<IActionResult> GetListFoto()
    {
        try
        {
            var result = await _fotoServices.GetListFoto();
            return new JsonResult(result){StatusCode = 201};
        }
        catch (Exception)
        {
            throw;
        }
    }
}
