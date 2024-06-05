using AutoMapper;
using OceanGuard.Data;
using OceanGuard.Entities;
using OceanGuard.Interfaces;

namespace OceanGuard.Repository
{
    public class OcorrenciaLixoRepository : IOcorrenciaLixoRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public OcorrenciaLixoRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreateOcorrenciaLixo(OcorrenciaLixo ocorrenciaLixo)
        {
            _context.Add(ocorrenciaLixo);
            return Save();
        }

        public bool DeleteOcorrenciaLixo(OcorrenciaLixo ocorrenciaLixo)
        {
            _context.Remove(ocorrenciaLixo);
            return Save();
        }

        public OcorrenciaLixo GetOcorrenciaLixo(int id)
        {
            return _context.OcorrenciasLixo.Where(x => x.Id == id).FirstOrDefault();
        }

        public OcorrenciaLixo GetOcorrenciaLixo(DateTime dataOcorrencia)
        {
            return _context.OcorrenciasLixo.Where(x => x.DataOcorrencia == dataOcorrencia).FirstOrDefault();
        }

        public ICollection<OcorrenciaLixo> GetOcorrenciaLixos()
        {
            return _context.OcorrenciasLixo.OrderBy(x => x.Id).ToList();
        }

        public bool OcorrenciaLixoExists(int ocorrenciaLixoId)
        {
            return _context.OcorrenciasLixo.Any(x => x.Id == ocorrenciaLixoId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateOcorrenciaLixo(OcorrenciaLixo ocorrenciaLixo)
        {
            _context.Update(ocorrenciaLixo);
            return Save();
        }
    }
}
