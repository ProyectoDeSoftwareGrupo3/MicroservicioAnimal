// using Application;
// using Application.Exceptions;
// using Application.Interfaces.IFoto;
// using Application.Request;
// using Application.Response;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;

// namespace AnimalRepository.Controllers;

// [Route("api/[controller]")]
// [ApiController]
// [Authorize]
// public class FotoControllers : ControllerBase
// {
//     private readonly IFotoServices _fotoServices;

//     public FotoControllers(IFotoServices fotoServices)
//     {
//         _fotoServices = fotoServices;
//     }
//     [HttpPost]
//     [ProducesResponseType(typeof(CreateFotoResponse), 201)]
//     [ProducesResponseType(typeof(ExceptionMessage), 404)]
//     public async Task<IActionResult> CreateFoto(CreateFotoRequest request)
//     {
//         try
//         {
//             var result = await _fotoServices.CreateFoto(request);
//             return new JsonResult(result){StatusCode = 201};
//         }
//         catch (ExceptionNotFound ex)
//         {

//             return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
//         }
//     }
//     [HttpPut]
//     [ProducesResponseType(typeof(GetFotoReponse), 200)]
//     [ProducesResponseType(typeof(ExceptionMessage), 404)]
//     public async Task<IActionResult> UpdateFoto(UpdateFotoRequest request)
//     {
//         try
//         {
//             var result =await _fotoServices.UpdateFoto(request);
//             return new JsonResult(result){StatusCode = 200};
//         }
//         catch (ExceptionNotFound ex)
//         {

//             return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
//         }
//     }
//     [HttpDelete]
//     [ProducesResponseType(typeof(CreateFotoResponse), 200)]
//     [ProducesResponseType(typeof(ExceptionMessage), 404)]
//     public async Task<IActionResult> DeleteFoto(DeleteFotoRequest request)
//     {
//         try
//         {
//             var result =await _fotoServices.DeleteFoto(request);
//             return new JsonResult(result){StatusCode = 201};
//         }
//         catch (ExceptionNotFound ex)
//         {

//             return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
//         }
//     }
//     [HttpGet("{id}")]
//     [ProducesResponseType(typeof(GetFotoReponse), 200)]
//     [ProducesResponseType(typeof(ExceptionMessage), 404)]
//     public async Task<IActionResult> GetFotoById(int id)
//     {
//         try
//         {
//             var result =await _fotoServices.GetFotoById(id);
//             return new JsonResult(result){StatusCode = 200};
//         }
//         catch (ExceptionNotFound ex)
//         {

//             return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
//         }
//     }
//     [HttpGet]
//     [ProducesResponseType(typeof(List<GetFotoReponse>), 200)]
//     [ProducesResponseType(typeof(ExceptionMessage), 404)]
//     public async Task<IActionResult> GetListFoto()
//     {
//         try
//         {
//             var result = await _fotoServices.GetListFoto();
//             return new JsonResult(result){StatusCode = 200};
//         }
//         catch (ExceptionNotFound ex)
//         {

//             return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
//         }
//     }
// }
