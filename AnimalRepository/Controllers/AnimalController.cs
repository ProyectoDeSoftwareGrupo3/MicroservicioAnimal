﻿using System.Reflection;
using Application;
using Application.Exceptions;
using Application.Interfaces.ICurrentUser;
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

    private readonly IWebHostEnvironment _hostingEnvironment;

    public AnimalController(IAnimalServices animalServices, IWebHostEnvironment hostingEnvironment)
    {
        _animalServices = animalServices;
        _hostingEnvironment = hostingEnvironment;
    }

    [HttpPost]
    [ProducesResponseType(typeof(GetAnimalResponse), 201)]
    [ProducesResponseType(typeof(ExceptionMessage), 409)]
    [Authorize]
    public async Task<IActionResult> CreateAnimal(CreateAnimalRequest request, [FromServices] ICurrentUserService currentUser)
    {
        try
        {
            var imageUrl = await UploadImage(request.Foto);
            var result = await _animalServices.CreateAnimal(request, currentUser.User.Id, imageUrl);
            return new JsonResult(result) { StatusCode = 201 };
        }
        catch (Conflict ex)
        {

            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 409 };
        }
    }
    [HttpPut]
    [ProducesResponseType(typeof(GetAnimalResponse), 200)]
    [ProducesResponseType(typeof(ExceptionMessage), 401)]
    [ProducesResponseType(typeof(ExceptionMessage), 404)]
    [Authorize]
    public async Task<IActionResult> UpdateAnimal(UpdateAnimalRequest request, [FromServices] ICurrentUserService currentUser)
    {
        try
        {
            var result = await _animalServices.UpdateAnimal(request, currentUser.User.Id);
            return new JsonResult(result) { StatusCode = 201 };
        }
        catch (ExceptionNotFound ex)
        {

            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
        }
        catch (NotAuthorizedException ex)
        {
            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 401 };
        }
    }
    [HttpDelete]
    [ProducesResponseType(typeof(DeleteAnimalResponse), 200)]
    [ProducesResponseType(typeof(ExceptionMessage), 401)]
    [ProducesResponseType(typeof(ExceptionMessage), 404)]
    [Authorize]
    public async Task<IActionResult> DeleteAnimal(int id, [FromServices] ICurrentUserService currentUser)
    {
        try
        {
            var result = await _animalServices.DeleteAnimal(id, currentUser.User.Id);
            return new JsonResult(result) { StatusCode = 200 };
        }
        catch (ExceptionNotFound ex)
        {

            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
        }
        catch (NotAuthorizedException ex)
        {
            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 401 };
        }
    }
    [HttpGet]
    [ProducesResponseType(typeof(List<GetAnimalResponse>), 200)]
    public async Task<IActionResult> GetListAnimal(string? nombre, decimal? peso, int? edad, bool? genero, int? tipoId, int? razaId, string? localidad)
    {
        var result = await _animalServices.GetListAnimal(nombre,peso,edad, genero, tipoId, razaId, localidad);
        return new JsonResult(result) { StatusCode = 200 };

    }
    [HttpGet]   
    [Route("GetAnimalList")] 
    public async Task<IActionResult> GetAnimalListByUserId(string userId)
    {
        try
        {
            var result = await _animalServices.GetListAnimalByUserId(userId);
            return new JsonResult(result) { StatusCode = 200 };
        }
        catch (Conflict ex)
        {

            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 409 };
        }  
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
    [ProducesResponseType(typeof(ExceptionMessage), 401)]
    [ProducesResponseType(typeof(ExceptionMessage), 404)]
    [Authorize]
    public async Task<IActionResult> AddMedia(CreateMediaRequest request, [FromServices] ICurrentUserService currentUser)
    {
        try
        {
            var result = await _animalServices.AddMedia(request, currentUser.User.Id);
            return new JsonResult(result) { StatusCode = 201 };
        }
        catch (ExceptionNotFound ex)
        {
            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
        }
        catch (NotAuthorizedException ex)
        {
            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 401 };
        }
    }
    [HttpDelete]
    [Route("DeleteMedia")]
    [ProducesResponseType(typeof(GetAnimalResponse), 200)]
    [ProducesResponseType(typeof(ExceptionMessage), 401)]
    [ProducesResponseType(typeof(ExceptionMessage), 409)]
    [Authorize]
    public async Task<IActionResult> DeleteMedia(DeleteMediaRequest request, [FromServices] ICurrentUserService currentUser)
    {
        try
        {
            var result = await _animalServices.DeleteMedia(request, currentUser.User.Id);
            return new JsonResult(result) { StatusCode = 200 };
        }
        catch (Conflict ex)
        {
            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 409 };
        }
        catch (NotAuthorizedException ex)
        {
            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 401 };
        }
    }

    [HttpPost("ImageUpload")]
        public async Task<string> UploadImage(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                return "No se ha seleccionado una imagen";
            }            
            // string path = Environment.CurrentDirectory;     
            string path = "../../FrontEnd/app/public";       
            var uploadsFolder = Path.Combine(path, "pets");
            Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }                
            string fileName = Path.GetFileName(filePath);     
            var filePathForDb = Path.Combine("/pets", fileName);            

            return filePathForDb;
        }
}
