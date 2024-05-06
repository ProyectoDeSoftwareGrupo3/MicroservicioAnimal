using Application.Exceptions;
using Application.Interfaces.IAnimalRaza;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnimalRazaController : ControllerBase
    {
        private readonly IAnimalRazaService _animalRazaService;
        public AnimalRazaController(IAnimalRazaService animalRazaService)
        {
            _animalRazaService = animalRazaService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateAnimalRazaResponse),201)]
        public async Task<IActionResult>CreateAnimalRaza(CreateAnimalRazaRequest request)
        {
            try
            {
                var result = await _animalRazaService.CreateAnimalRaza(request);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut]
        [ProducesResponseType(typeof(GetAnimalRazaResponse), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 404)]
        public async Task<IActionResult>UpdateAnimalRaza(UpdateAnimalRazaRequest request)
        {
            try
            {
                var result = await _animalRazaService.UpdateAnimalRaza(request);
                return new JsonResult(result) {StatusCode = 201};
            }
            catch (Conflict ex)
            {

                return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
            }
        }
        [HttpDelete]
        [ProducesResponseType(typeof(CreateAnimalRazaResponse), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 404)]
        public async Task<IActionResult>DeleteAnimalRaza(DeleteAnimalRazaRequest request)
        {
            try
            {
                var result =await _animalRazaService.DeleteAnimalRaza(request);
                return new JsonResult(result){StatusCode = 201};
            }
            catch (Conflict ex)
            {

                return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetAnimalRazaResponse), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 404)]
        public async Task<IActionResult>GetAnimalRazaById(int id)
        {
            try
            {
                var animalRaza = await _animalRazaService.GetAnimalRazaById(id);
                return new JsonResult(animalRaza){StatusCode = 201};
            }
            catch (Conflict ex)
            {

                return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<GetAnimalRazaResponse>), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 404)]
        public async Task<IActionResult>GetListAnimalRaza()
        {
            try
            {
                var result = await _animalRazaService.GetListAnimalRaza();
                return new JsonResult(result){StatusCode = 201};
            }
            catch (Conflict ex)
            {

                return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
            }
        }
    }
}
