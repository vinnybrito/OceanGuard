using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OceanGuard.Entities;
using OceanGuard.Interfaces;

namespace OceanGuard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Usuario>))]
        public IActionResult GetUsuarios()
        {
            var usuarios = _usuarioRepository.GetUsuarios();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Usuario))]
        [ProducesResponseType(400)]
        public IActionResult GetUsuario(int id)
        {
            if (!_usuarioRepository.UsuarioExists(id))
            {
                return NotFound();
            }

            var usuario = _usuarioRepository.GetUsuario(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(usuario);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUsuario([FromBody] Usuario usuarioCreate)
        {
            if (usuarioCreate == null)
                return BadRequest(ModelState);

            var usuario = _usuarioRepository.GetUsuarios()
                .Where(c => c.Nome.Trim().ToUpper() == usuarioCreate.Nome.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (usuario != null)
            {
                ModelState.AddModelError("", "Usuario already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuarioMap = _mapper.Map<Usuario>(usuarioCreate);

            if (!_usuarioRepository.CreateUsuario(usuarioMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{usuarioId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUsuario(int usuarioId, [FromBody] Usuario updateUsuario)
        {
            if (updateUsuario == null)
                return BadRequest(ModelState);

            if (usuarioId != updateUsuario.Id)
                return BadRequest(ModelState);

            if (!_usuarioRepository.UsuarioExists(usuarioId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var usuarioMap = _mapper.Map<Usuario>(updateUsuario);

            if (!_usuarioRepository.UpdateUsuario(usuarioMap))
            {
                ModelState.AddModelError("", "Something went wrong updating usuario");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{usuarioId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUsuario(int usuarioId)
        {
            if (!_usuarioRepository.UsuarioExists(usuarioId))
            {
                return NotFound();
            }

            var usuarioToDelete = _usuarioRepository.GetUsuario(usuarioId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_usuarioRepository.DeleteUsuario(usuarioToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting usuario");
            }

            return NoContent();
        }
    }
}
