//using Application.Exceptions;
//using Application.Interfaces.IAnimalTipo;
//using Application.Request;
//using Application.Response;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace AnimalRepository.Controllers;

//[Route("api/[controller]")]
//[ApiController]
//[Authorize]
//public class AnimalTipoController : ControllerBase
//{
//    private readonly IAnimalTipoService _animalTipoService;

//    public AnimalTipoController(IAnimalTipoService animalTipoService)
//    {
//        _animalTipoService = animalTipoService;
//    }

//    [HttpPost]
//    [ProducesResponseType(typeof(CreateAnimalTipoResponse),201)]
//    public async Task<IActionResult>CreateAnimalTipo(CreateAnimalTipoRequest request)
//    {
//        try
//        {
//            var result =await _animalTipoService.CreateAnimalTipo(request);
//            return new JsonResult(result) { StatusCode = 201 };
//        }
//        catch (Exception)
//        {
//            throw;
//        }
//    }
//    [HttpPut]
//    [ProducesResponseType(typeof(GetAnimalTipoResponse), 200)]
//    [ProducesResponseType(typeof(ExceptionMessage), 404)]
//    public async Task<IActionResult>UpdateAnimalTipo(UpdateAnimalTipoRequest request)
//    {
//        try
//        {
//            var result =await _animalTipoService.UpdateAnimalTipo(request);
//            return new JsonResult(result) {StatusCode = 201};
//        }
//        catch (ExceptionNotFound ex)
//        {

//            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
//        }
//    }
//    [HttpDelete]
//    [ProducesResponseType(typeof(CreateAnimalTipoResponse), 200)]
//    [ProducesResponseType(typeof(ExceptionMessage), 404)]
//    public async Task<IActionResult>DeleteAnimalTipo(DeleteAnimalTipoRequest request)
//    {
//        try
//        {
//            var result =await _animalTipoService.DeleteAnimalTipo(request);
//            return new JsonResult(result){StatusCode = 200};
//        }
//        catch (ExceptionNotFound ex)
//        {

//            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
//        }
//    }
//    [HttpGet("{id}")]
//    [ProducesResponseType(typeof(GetAnimalTipoResponse), 200)]
//    [ProducesResponseType(typeof(ExceptionMessage), 404)]
//    public async Task<IActionResult>GetAnimalTipoById(int id)
//    {
//        try
//        {
//            var animalTipo = await _animalTipoService.GetAnimalTipoById(id);
//            return new JsonResult(animalTipo){StatusCode = 201};
//        }
//        catch (ExceptionNotFound ex)
//        {

//            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
//        }
//    }
//    [HttpGet]
//    [ProducesResponseType(typeof(List<GetAnimalTipoResponse>), 200)]
//    [ProducesResponseType(typeof(ExceptionMessage), 404)]
//    public async Task<IActionResult>GetListAnimalTipo()
//    {
//        try
//        {
//            var result = await _animalTipoService.GetListAnimalTipo();
//            return new JsonResult(result){StatusCode = 200};
//        }
//        catch (ExceptionNotFound ex)
//        {

//            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
//        }
//    }
//}
