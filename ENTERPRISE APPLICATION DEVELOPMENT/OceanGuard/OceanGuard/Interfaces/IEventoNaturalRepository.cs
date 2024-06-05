using OceanGuard.Entities;

namespace OceanGuard.Interfaces
{
    public interface IEventoNaturalRepository
    {
        ICollection<EventoNatural> GetEventosNaturais();
        EventoNatural GetEventoNatural(int id);
        EventoNatural GetEventoNatural(DateTime dataEvento);
        EventoNatural GetEventoNatural(string tipo);
        bool EventoNaturalExists(int eventoNaturalId);
        bool CreateEventoNatural(EventoNatural eventoNatural);
        bool UpdateEventoNatural(EventoNatural eventoNatural);
        bool DeleteEventoNatural(EventoNatural eventoNatural);
        bool Save();
    }
}
