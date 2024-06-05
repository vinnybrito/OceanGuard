using OceanGuard.Entities;

namespace OceanGuard.Interfaces
{
    public interface IAutoridadeRepository
    {
        ICollection<Autoridade> GetAutoridades();
        Autoridade GetAutoridade(int id);
        Autoridade GetAutoridade(string nome);
        bool AutoridadeExists(int autoridadeId);
        bool CreateAutoridade(Autoridade autoridade);
        bool UpdateAutoridade(Autoridade autoridade);
        bool DeleteAutoridade(Autoridade autoridade);
        bool Save();
    }
}
