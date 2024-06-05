using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OceanGuard.Entities;
using OceanGuard.Interfaces;

namespace OceanGuard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcorrenciaLixoController : ControllerBase
    {
        private readonly IOcorrenciaLixoRepository _ocorrenciaLixoRepository;
        private readonly IMapper _mapper;

        public OcorrenciaLixoController(IOcorrenciaLixoRepository ocorrenciaLixoRepository, IMapper mapper)
        {
            _ocorrenciaLixoRepository = ocorrenciaLixoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<OcorrenciaLixo>))]
        public IActionResult GetOcorrenciaLixos()
        {
            var ocorrenciasLixo = _ocorrenciaLixoRepository.GetOcorrenciaLixos();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(ocorrenciasLixo);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(OcorrenciaLixo))]
        [ProducesResponseType(400)]
        public IActionResult GetOcorrenciaLixo(int id)
        {
            if (!_ocorrenciaLixoRepository.OcorrenciaLixoExists(id))
            {
                return NotFound();
            }

            var ocorrenciaLixo = _ocorrenciaLixoRepository.GetOcorrenciaLixo(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(ocorrenciaLixo);
        }

        [HttpGet("byDate/{dataOcorrencia}")]
        [ProducesResponseType(200, Type = typeof(OcorrenciaLixo))]
        [ProducesResponseType(400)]
        public IActionResult GetOcorrenciaLixoByDate(DateTime dataOcorrencia)
        {
            var ocorrenciaLixo = _ocorrenciaLixoRepository.GetOcorrenciaLixo(dataOcorrencia);

            if (ocorrenciaLixo == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(ocorrenciaLixo);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOcorrenciaLixo([FromBody] OcorrenciaLixo ocorrenciaLixoCreate)
        {
            if (ocorrenciaLixoCreate == null)
                return BadRequest(ModelState);

            var ocorrenciaLixo = _ocorrenciaLixoRepository.GetOcorrenciaLixos()
                .Where(c => c.DataOcorrencia == ocorrenciaLixoCreate.DataOcorrencia)
                .FirstOrDefault();

            if (ocorrenciaLixo != null)
            {
                ModelState.AddModelError("", "OcorrenciaLixo already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ocorrenciaLixoMap = _mapper.Map<OcorrenciaLixo>(ocorrenciaLixoCreate);

            if (!_ocorrenciaLixoRepository.CreateOcorrenciaLixo(ocorrenciaLixoMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{ocorrenciaLixoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateOcorrenciaLixo(int ocorrenciaLixoId, [FromBody] OcorrenciaLixo updateOcorrenciaLixo)
        {
            if (updateOcorrenciaLixo == null)
                return BadRequest(ModelState);

            if (ocorrenciaLixoId != updateOcorrenciaLixo.Id)
                return BadRequest(ModelState);

            if (!_ocorrenciaLixoRepository.OcorrenciaLixoExists(ocorrenciaLixoId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var ocorrenciaLixoMap = _mapper.Map<OcorrenciaLixo>(updateOcorrenciaLixo);

            if (!_ocorrenciaLixoRepository.UpdateOcorrenciaLixo(ocorrenciaLixoMap))
            {
                ModelState.AddModelError("", "Something went wrong updating ocorrenciaLixo");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{ocorrenciaLixoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteOcorrenciaLixo(int ocorrenciaLixoId)
        {
            if (!_ocorrenciaLixoRepository.OcorrenciaLixoExists(ocorrenciaLixoId))
            {
                return NotFound();
            }

            var ocorrenciaLixoToDelete = _ocorrenciaLixoRepository.GetOcorrenciaLixo(ocorrenciaLixoId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_ocorrenciaLixoRepository.DeleteOcorrenciaLixo(ocorrenciaLixoToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting ocorrenciaLixo");
            }

            return NoContent();
        }
    }
}
