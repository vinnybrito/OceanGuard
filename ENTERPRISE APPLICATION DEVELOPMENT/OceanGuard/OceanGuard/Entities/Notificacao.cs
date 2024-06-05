using System.ComponentModel.DataAnnotations.Schema;

namespace OceanGuard.Entities
{
    public class Notificacao
    {
        public int Id { get; set; }
        public DateTime DataNotificacao { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Status { get; set; }
        public Autoridade Autoridade { get; set; }
        public OcorrenciaLixo OcorrenciaLixo { get; set; }
        public EventoNatural EventoNatural { get; set; }
        public DensidadeBanhista DensidadeBanhista { get; set; }
    }
}
