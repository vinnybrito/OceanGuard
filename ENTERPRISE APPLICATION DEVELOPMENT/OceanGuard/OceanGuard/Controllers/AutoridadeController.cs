using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OceanGuard.Entities;
using OceanGuard.Interfaces;

namespace OceanGuard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoridadeController : ControllerBase
    {
        private readonly IAutoridadeRepository _autoridadeRepository;
        private readonly IMapper _mapper;

        public AutoridadeController(IAutoridadeRepository autoridadeRepository, IMapper mapper)
        {
            _autoridadeRepository = autoridadeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Autoridade>))]
        public IActionResult GetAutoridades()
        {
            var autoridades = _autoridadeRepository.GetAutoridades();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(autoridades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Autoridade))]
        [ProducesResponseType(400)]
        public IActionResult GetAutoridade(int id)
        {
            if (!_autoridadeRepository.AutoridadeExists(id))
            {
                return NotFound();
            }

            var autoridade = _autoridadeRepository.GetAutoridade(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(autoridade);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAutoridade([FromBody] Autoridade autoridadeCreate)
        {
            if (autoridadeCreate == null)
                return BadRequest(ModelState);

            var autoridade = _autoridadeRepository.GetAutoridades()
                .Where(c => c.Nome.Trim().ToUpper() == autoridadeCreate.Nome.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (autoridade != null)
            {
                ModelState.AddModelError("", "Autoridade already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var autoridadeMap = _mapper.Map<Autoridade>(autoridadeCreate);

            if (!_autoridadeRepository.CreateAutoridade(autoridadeMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{autoridadeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAutoridade(int autoridadeId, [FromBody] Autoridade updateAutoridade)
        {
            if (updateAutoridade == null)
                return BadRequest(ModelState);

            if (autoridadeId != updateAutoridade.Id)
                return BadRequest(ModelState);

            if (!_autoridadeRepository.AutoridadeExists(autoridadeId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var autoridadeMap = _mapper.Map<Autoridade>(updateAutoridade);

            if (!_autoridadeRepository.UpdateAutoridade(autoridadeMap))
            {
                ModelState.AddModelError("", "Something went wrong updating autoridade");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{autoridadeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteAutoridade(int autoridadeId)
        {
            if (!_autoridadeRepository.AutoridadeExists(autoridadeId))
            {
                return NotFound();
            }

            var autoridadeToDelete = _autoridadeRepository.GetAutoridade(autoridadeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_autoridadeRepository.DeleteAutoridade(autoridadeToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting autoridade");
            }

            return NoContent();
        }
    }
}
