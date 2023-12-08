using Animals.Dtos;
using BusnisLogicLayer.Helpers;
using BusnisLogicLayer.Interfaces;
using BussinessLogicLayer.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AnimalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAnimalsItems()
        {
            var animals = await _animalService.GetAnimalAsync();
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var animal = await _animalService.GetAnimalByIdAsync(id);
            if (animal == null)
            {
                return NotFound(); 
            }
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            LoggingService.LogInfo($"User with IP {ip} requested animal with id {id}");
            return Ok(animal);
        }

        [HttpPost("AddAnimal")]
        public async Task<IActionResult> AddAnimalAysnc([FromBody] AddAnimaldto newAnimal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _animalService.AddAnimalAsync(newAnimal);
            return Ok("Animal added successfully");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAnimalAsync([FromBody] AnimalDto animalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _animalService.UpdateAnimalAsync(animalDto);
            return Ok("Animal updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimalAsync(int id)
        {
            await _animalService.DeleteAnimalAsync(id);
            return Ok("Animal deleted successfully");
        }
    }
}
