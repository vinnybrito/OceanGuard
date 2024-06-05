using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OceanGuard.Entities;
using OceanGuard.Interfaces;

namespace OceanGuard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoNaturalController : ControllerBase
    {
        private readonly IEventoNaturalRepository _eventoNaturalRepository;
        private readonly IMapper _mapper;

        public EventoNaturalController(IEventoNaturalRepository eventoNaturalRepository, IMapper mapper)
        {
            _eventoNaturalRepository = eventoNaturalRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<EventoNatural>))]
        public IActionResult GetEventosNaturais()
        {
            var eventosNaturais = _eventoNaturalRepository.GetEventosNaturais();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(eventosNaturais);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(EventoNatural))]
        [ProducesResponseType(400)]
        public IActionResult GetEventoNatural(int id)
        {
            if (!_eventoNaturalRepository.EventoNaturalExists(id))
            {
                return NotFound();
            }

            var eventoNatural = _eventoNaturalRepository.GetEventoNatural(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(eventoNatural);
        }

        [HttpGet("byDate/{dataEvento}")]
        [ProducesResponseType(200, Type = typeof(EventoNatural))]
        [ProducesResponseType(400)]
        public IActionResult GetEventoNaturalByDate(DateTime dataEvento)
        {
            var eventoNatural = _eventoNaturalRepository.GetEventoNatural(dataEvento);

            if (eventoNatural == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(eventoNatural);
        }

        [HttpGet("byType/{tipo}")]
        [ProducesResponseType(200, Type = typeof(EventoNatural))]
        [ProducesResponseType(400)]
        public IActionResult GetEventoNaturalByType(string tipo)
        {
            var eventoNatural = _eventoNaturalRepository.GetEventoNatural(tipo);

            if (eventoNatural == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(eventoNatural);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateEventoNatural([FromBody] EventoNatural eventoNaturalCreate)
        {
            if (eventoNaturalCreate == null)
                return BadRequest(ModelState);

            var eventoNatural = _eventoNaturalRepository.GetEventosNaturais()
                .Where(c => c.DataEvento == eventoNaturalCreate.DataEvento)
                .FirstOrDefault();

            if (eventoNatural != null)
            {
                ModelState.AddModelError("", "EventoNatural already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var eventoNaturalMap = _mapper.Map<EventoNatural>(eventoNaturalCreate);

            if (!_eventoNaturalRepository.CreateEventoNatural(eventoNaturalMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{eventoNaturalId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateEventoNatural(int eventoNaturalId, [FromBody] EventoNatural updateEventoNatural)
        {
            if (updateEventoNatural == null)
                return BadRequest(ModelState);

            if (eventoNaturalId != updateEventoNatural.Id)
                return BadRequest(ModelState);

            if (!_eventoNaturalRepository.EventoNaturalExists(eventoNaturalId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var eventoNaturalMap = _mapper.Map<EventoNatural>(updateEventoNatural);

            if (!_eventoNaturalRepository.UpdateEventoNatural(eventoNaturalMap))
            {
                ModelState.AddModelError("", "Something went wrong updating eventoNatural");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{eventoNaturalId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteEventoNatural(int eventoNaturalId)
        {
            if (!_eventoNaturalRepository.EventoNaturalExists(eventoNaturalId))
            {
                return NotFound();
            }

            var eventoNaturalToDelete = _eventoNaturalRepository.GetEventoNatural(eventoNaturalId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_eventoNaturalRepository.DeleteEventoNatural(eventoNaturalToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting eventoNatural");
            }

            return NoContent();
        }
    }
}
