using OceanGuard.Entities;

namespace OceanGuard.Interfaces
{
    public interface IAutoridadeRepository
    {
        ICollection<Notificacao> GetNotificacoes();
        Notificacao GetNotificacao(int id);
        Notificacao GetNotificacao(string nome);
        bool NotificacaoExists(int notificacaoLixoId);
        bool CreateNotificacao(Notificacao notificacao);
        bool UpdateNotificacao(Notificacao notificacao);
        bool DeleteNotificacao(Notificacao notificacao);
        bool Save();
    }
}
