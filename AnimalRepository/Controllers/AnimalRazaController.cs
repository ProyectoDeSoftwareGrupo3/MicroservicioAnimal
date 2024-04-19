using Application.Interfaces.IAnimalRaza;
using Application.Request;
using Application.Response;
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
    }
}
