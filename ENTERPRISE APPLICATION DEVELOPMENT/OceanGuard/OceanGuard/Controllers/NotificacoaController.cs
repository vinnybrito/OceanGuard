using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OceanGuard.Entities;
using OceanGuard.Interfaces;

namespace OceanGuard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacaoController : ControllerBase
    {
        private readonly INotificacaoRepository _notificacaoRepository;
        private readonly IMapper _mapper;

        public NotificacaoController(INotificacaoRepository notificacaoRepository, IMapper mapper)
        {
            _notificacaoRepository = notificacaoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Notificacao>))]
        public IActionResult GetNotificacoes()
        {
            var notificacoes = _notificacaoRepository.GetNotificacoes();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(notificacoes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Notificacao))]
        [ProducesResponseType(400)]
        public IActionResult GetNotificacao(int id)
        {
            if (!_notificacaoRepository.NotificacaoExists(id))
            {
                return NotFound();
            }

            var notificacao = _notificacaoRepository.GetNotificacao(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(notificacao);
        }

        [HttpGet("byStatus/{status}")]
        [ProducesResponseType(200, Type = typeof(Notificacao))]
        [ProducesResponseType(400)]
        public IActionResult GetNotificacaoByStatus(string status)
        {
            var notificacao = _notificacaoRepository.GetNotificacao(status);

            if (notificacao == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(notificacao);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateNotificacao([FromBody] Notificacao notificacaoCreate)
        {
            if (notificacaoCreate == null)
                return BadRequest(ModelState);

            if (!_notificacaoRepository.CreateNotificacao(notificacaoCreate))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{notificacaoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateNotificacao(int notificacaoId, [FromBody] Notificacao updateNotificacao)
        {
            if (updateNotificacao == null)
                return BadRequest(ModelState);

            if (notificacaoId != updateNotificacao.Id)
                return BadRequest(ModelState);

            if (!_notificacaoRepository.NotificacaoExists(notificacaoId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            if (!_notificacaoRepository.UpdateNotificacao(updateNotificacao))
            {
                ModelState.AddModelError("", "Something went wrong updating notificacao");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{notificacaoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteNotificacao(int notificacaoId)
        {
            if (!_notificacaoRepository.NotificacaoExists(notificacaoId))
            {
                return NotFound();
            }

            var notificacaoToDelete = _notificacaoRepository.GetNotificacao(notificacaoId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_notificacaoRepository.DeleteNotificacao(notificacaoToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting notificacao");
            }

            return NoContent();
        }
    }
}
