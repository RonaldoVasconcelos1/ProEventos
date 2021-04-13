using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contracts;
using ProEventos.Domain.Entities.Peoples;

namespace ProEventos.API.Controllers
{

    [ApiController]
    [Route("v1/People")]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peropleService;
        public PeopleController(IPeopleService peopleService)
        {
            _peropleService = peopleService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var peoples = await _peropleService.GetAllPeoplesAsync();
                if (peoples == null) return NotFound("No People Found");
                return Ok(peoples);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Request Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var people = await _peropleService.GetPeopleById(id);
                if (people == null) return NotFound("People Not Found");
                return Ok(people);

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Request Error: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(People model)
        {
            try
            {
                var peopleModel = await _peropleService.Add(model);
                if (peopleModel == null) return BadRequest("Error Signing Up ");
                return Ok(peopleModel);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Request Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, People model)
        {
            try
            {
                var people = await _peropleService.Update(model, id);
                if (people == null) return NotFound("People Not Found");
                return Ok(people);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Request Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var people = await _peropleService.Remove(id);
                return (people ? Ok()
                    : BadRequest("Error while deleting"));
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Request Error: {ex.Message}");
            }
        }
    }
}