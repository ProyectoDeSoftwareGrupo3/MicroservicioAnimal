﻿using Application;
using Application.Interfaces.IFoto;
using Application.Request;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateFoto(UpdateFotoRequest request)
    {
        try
        {
            var result = _fotoServices.UpdateFoto(request);
            return new JsonResult(result){StatusCode = 201};
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> DeleteFoto(DeleteFotoRequest request)
    {
        try
        {
            var result = _fotoServices.DeleteFoto(request);
            return new JsonResult(result){StatusCode = 201};
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpGet("{id}")]
    [Authorize]
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
    [Authorize]
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
