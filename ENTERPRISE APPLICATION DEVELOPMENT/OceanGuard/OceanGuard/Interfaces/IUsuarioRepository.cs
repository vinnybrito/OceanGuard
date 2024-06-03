using OceanGuard.Entities;

namespace OceanGuard.Interfaces
{
    public interface IUsuarioRepository
    {
        ICollection<Usuario> GetUsuarios();
        Usuario GetUsuario(int id);
        Usuario GetUsuario(string nome);
        bool UsuarioExists(int usuarioId);
        bool CreateUsuario(Usuario usuario);
        bool UpdateUsuario(Usuario usuario);
        bool DeleteUsuario(Usuario usuario);
        bool Save();
    }
}
