using Application.Interfaces.IAnimalRaza;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalRazaController : ControllerBase
    {
        private readonly IAnimalRazaService _animalRazaService;
        public AnimalRazaController(IAnimalRazaService animalRazaService)
        {
            _animalRazaService = animalRazaService;
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(CreateAnimalRazaResponse),201)]
        public async Task<IActionResult>CreateAnimalRaza(CreateAnimalRazaRequest request)
        {
            try
            {
                var result = _animalRazaService.CreateAnimalRaza(request);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult>UpdateAnimalRaza(UpdateAnimalRazaRequest request)
        {
            try
            {
                var result = _animalRazaService.UpdateAnimalRaza(request);
                return new JsonResult(result) {StatusCode = 201};
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult>DeleteAnimalRaza(DeleteAnimalRazaRequest request)
        {
            try
            {
                var result = _animalRazaService.DeleteAnimalRaza(request);
                return new JsonResult(result){StatusCode = 201};
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult>GetAnimalRazaById(int id)
        {
            try
            {
                var animalRaza = _animalRazaService.GetAnimalRazaById(id);
                return new JsonResult(animalRaza){StatusCode = 201};
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult>GetListAnimalRaza()
        {
            try
            {
                var result = await _animalRazaService.GetListAnimalRaza();
                return new JsonResult(result){StatusCode = 201};
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
