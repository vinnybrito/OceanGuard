using AutoMapper;
using OceanGuard.Data;
using OceanGuard.Entities;
using OceanGuard.Interfaces;

namespace OceanGuard.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UsuarioRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreateUsuario(Usuario usuario)
        {
            _context.Add(usuario);
            return Save();
        }

        public bool DeleteUsuario(Usuario usuario)
        {
            _context.Remove(usuario);
            return Save();
        }

        public Usuario GetUsuario(int id)
        {
            return _context.Usuarios.Where(x => x.Id == id).FirstOrDefault();
        }

        public Usuario GetUsuario(string nome)
        {
            return _context.Usuarios.Where(x => x.Nome == nome).FirstOrDefault();
        }

        public ICollection<Usuario> GetUsuarios()
        {
            return _context.Usuarios.OrderBy(x => x.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateUsuario(Usuario usuario)
        {
            _context.Update(usuario);
            return Save();
        }

        public bool UsuarioExists(int usuarioId)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == usuarioId) != null;
        }
    }
}
