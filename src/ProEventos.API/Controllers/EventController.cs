using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contracts;
using ProEventos.Domain.Entities.Events;

namespace ProEventos.API.Controllers
{

    [ApiController]
    [Route("v1/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var events = await _eventService.GetAllEventsAsync(false);
                if (events == null) return NotFound("No Events Found");
                return Ok(events);
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
                var eventId = await _eventService.GetEventById(id, false);
                if (eventId == null) return NotFound("Event Not Found");
                return Ok(eventId);

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Request Error: {ex.Message}");
            }
        }

        [HttpGet("{theme}/theme")]
        public async Task<IActionResult> GetByTheme(string theme)
        {
            try
            {
                var eventsTheme = await _eventService.GetAllEventThemeAsync(theme, false);
                if (eventsTheme == null) return NotFound("Event Not Found");
                return Ok(eventsTheme);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Request Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Event model)
        {
            try
            {
                var eventModel = await _eventService.Add(model);
                if (eventModel == null) return BadRequest("Error Signing Up ");
                return Ok(eventModel);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Request Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Event model)
        {
            try
            {
                var eventPut = await _eventService.Update(model, id);
                if (eventPut == null) return NotFound("Event Not Found");
                return Ok(eventPut);
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
                var eventRemoved = await _eventService.Remove(id);
                return (eventRemoved ? Ok()
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