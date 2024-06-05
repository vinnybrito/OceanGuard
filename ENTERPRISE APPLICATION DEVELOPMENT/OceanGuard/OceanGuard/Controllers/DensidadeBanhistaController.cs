using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OceanGuard.Entities;
using OceanGuard.Interfaces;

namespace OceanGuard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DensidadeBanhistaController : ControllerBase
    {
        private readonly IDensidadeBanhistaRepository _densidadeBanhistaRepository;
        private readonly IMapper _mapper;

        public DensidadeBanhistaController(IDensidadeBanhistaRepository densidadeBanhistaRepository, IMapper mapper)
        {
            _densidadeBanhistaRepository = densidadeBanhistaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<DensidadeBanhista>))]
        public IActionResult GetDensidadeBanhistas()
        {
            var densidadeBanhistas = _densidadeBanhistaRepository.GetDensidadeBanhistas();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(densidadeBanhistas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(DensidadeBanhista))]
        [ProducesResponseType(400)]
        public IActionResult GetDensidadeBanhista(int id)
        {
            if (!_densidadeBanhistaRepository.DensidadeBanhistaExists(id))
            {
                return NotFound();
            }

            var densidadeBanhista = _densidadeBanhistaRepository.GetDensidadeBanhista(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(densidadeBanhista);
        }

        [HttpGet("byDate/{dataReporte}")]
        [ProducesResponseType(200, Type = typeof(DensidadeBanhista))]
        [ProducesResponseType(400)]
        public IActionResult GetDensidadeBanhistaByDate(DateTime dataReporte)
        {
            var densidadeBanhista = _densidadeBanhistaRepository.GetDensidadeBanhista(dataReporte);

            if (densidadeBanhista == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(densidadeBanhista);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDensidadeBanhista([FromBody] DensidadeBanhista densidadeBanhistaCreate)
        {
            if (densidadeBanhistaCreate == null)
                return BadRequest(ModelState);

            if (!_densidadeBanhistaRepository.CreateDensidadeBanhista(densidadeBanhistaCreate))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{densidadeBanhistaId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateDensidadeBanhista(int densidadeBanhistaId, [FromBody] DensidadeBanhista updateDensidadeBanhista)
        {
            if (updateDensidadeBanhista == null)
                return BadRequest(ModelState);

            if (densidadeBanhistaId != updateDensidadeBanhista.Id)
                return BadRequest(ModelState);

            if (!_densidadeBanhistaRepository.DensidadeBanhistaExists(densidadeBanhistaId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            if (!_densidadeBanhistaRepository.UpdateDensidadeBanhista(updateDensidadeBanhista))
            {
                ModelState.AddModelError("", "Something went wrong updating densidadeBanhista");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{densidadeBanhistaId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteDensidadeBanhista(int densidadeBanhistaId)
        {
            if (!_densidadeBanhistaRepository.DensidadeBanhistaExists(densidadeBanhistaId))
            {
                return NotFound();
            }

            var densidadeBanhistaToDelete = _densidadeBanhistaRepository.GetDensidadeBanhista(densidadeBanhistaId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_densidadeBanhistaRepository.DeleteDensidadeBanhista(densidadeBanhistaToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting densidadeBanhista");
            }

            return NoContent();
        }
    }
}
