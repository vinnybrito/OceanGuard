using AutoMapper;
using OceanGuard.Data;
using OceanGuard.Entities;
using OceanGuard.Interfaces;

namespace OceanGuard.Repository
{
    public class EventoNaturalRepository : IEventoNaturalRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EventoNaturalRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreateEventoNatural(EventoNatural eventoNatural)
        {
            _context.Add(eventoNatural);
            return Save();
        }

        public bool DeleteEventoNatural(EventoNatural eventoNatural)
        {
            _context.Remove(eventoNatural);
            return Save();
        }

        public bool EventoNaturalExists(int eventoNaturalId)
        {
            return _context.EventosNaturais.Any(x => x.Id == eventoNaturalId);
        }

        public EventoNatural GetEventoNatural(int id)
        {
            return _context.EventosNaturais.Where(x => x.Id == id).FirstOrDefault();
        }

        public EventoNatural GetEventoNatural(DateTime dataEvento)
        {
            return _context.EventosNaturais.Where(x => x.DataEvento == dataEvento).FirstOrDefault();
        }

        public EventoNatural GetEventoNatural(string tipo)
        {
            return _context.EventosNaturais.Where(x => x.Tipo == tipo).FirstOrDefault();
        }

        public ICollection<EventoNatural> GetEventosNaturais()
        {
            return _context.EventosNaturais.OrderBy(x => x.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateEventoNatural(EventoNatural eventoNatural)
        {
            _context.Update(eventoNatural);
            return Save();
        }
    }
}
