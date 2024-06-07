using AutoMapper;
using OceanGuard.Data;
using OceanGuard.Entities;
using OceanGuard.Interfaces;

namespace OceanGuard.Repository
{
    public class NotificacaoRepository : INotificacaoRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public NotificacaoRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreateNotificacao(Notificacao notificacao)
        {
            _context.Add(notificacao);
            return Save();
        }

        public bool DeleteNotificacao(Notificacao notificacao)
        {
            _context.Remove(notificacao);
            return Save();
        }

        public Notificacao GetNotificacao(int id)
        {
            return _context.Notificacoes.Where(x => x.Id == id).FirstOrDefault();
        }

        public Notificacao GetNotificacao(string status)
        {
            return _context.Notificacoes.Where(x => x.Status == status).FirstOrDefault();
        }

        public ICollection<Notificacao> GetNotificacoes()
        {
            return _context.Notificacoes.OrderBy(x => x.Id).ToList();
        }

        public bool NotificacaoExists(int notificacaoId)
        {
            return _context.Notificacoes.FirstOrDefault(x => x.Id == notificacaoId) != null;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateNotificacao(Notificacao notificacao)
        {
            _context.Update(notificacao);
            return Save();
        }
    }
}
