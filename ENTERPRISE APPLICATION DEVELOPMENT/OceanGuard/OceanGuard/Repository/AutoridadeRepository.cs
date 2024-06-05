using AutoMapper;
using OceanGuard.Data;
using OceanGuard.Entities;
using OceanGuard.Interfaces;

namespace OceanGuard.Repository
{
    public class AutoridadeRepository : IAutoridadeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AutoridadeRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool AutoridadeExists(int autoridadeId)
        {
            return _context.Autoridades.Any(x => x.Id == autoridadeId);
        }

        public bool CreateAutoridade(Autoridade autoridade)
        {
            _context.Add(autoridade);
            return Save();
        }

        public bool DeleteAutoridade(Autoridade autoridade)
        {
            _context.Remove(autoridade);
            return Save();
        }

        public Autoridade GetAutoridade(int id)
        {
            return _context.Autoridades.Where(x => x.Id == id).FirstOrDefault();
        }

        public Autoridade GetAutoridade(string nome)
        {
            return _context.Autoridades.Where(x => x.Nome == nome).FirstOrDefault();
        }

        public ICollection<Autoridade> GetAutoridades()
        {
            return _context.Autoridades.OrderBy(x => x.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAutoridade(Autoridade autoridade)
        {
            _context.Update(autoridade);
            return Save();
        }
    }
}
