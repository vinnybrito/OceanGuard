using AutoMapper;
using OceanGuard.Data;
using OceanGuard.Entities;
using OceanGuard.Interfaces;

namespace OceanGuard.Repository
{
    public class DensidadeBanhistaRepository : IDensidadeBanhistaRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DensidadeBanhistaRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreateDensidadeBanhista(DensidadeBanhista densidadeBanhista)
        {
            _context.Add(densidadeBanhista);
            return Save();
        }

        public bool DeleteDensidadeBanhista(DensidadeBanhista densidadeBanhista)
        {
            _context.Remove(densidadeBanhista);
            return Save();
        }

        public bool DensidadeBanhistaExists(int densidadeBanhistaId)
        {
            return _context.DensidadeBanhistas.FirstOrDefault(x => x.Id == densidadeBanhistaId) != null;
        }

        public DensidadeBanhista GetDensidadeBanhista(int id)
        {
            return _context.DensidadeBanhistas.Where(x => x.Id == id).FirstOrDefault();
        }

        public DensidadeBanhista GetDensidadeBanhista(DateTime dataReporte)
        {
            return _context.DensidadeBanhistas.Where(x => x.DataReporte == dataReporte).FirstOrDefault();
        }

        public ICollection<DensidadeBanhista> GetDensidadeBanhistas()
        {
            return _context.DensidadeBanhistas.OrderBy(x => x.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateDensidadeBanhista(DensidadeBanhista densidadeBanhista)
        {
            _context.Update(densidadeBanhista);
            return Save();
        }
    }
}
