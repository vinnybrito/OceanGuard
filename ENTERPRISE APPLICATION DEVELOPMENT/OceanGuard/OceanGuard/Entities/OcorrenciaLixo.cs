using System.ComponentModel.DataAnnotations.Schema;

namespace OceanGuard.Entities
{
    public class OcorrenciaLixo
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Descricao { get; set; }
        [Column(TypeName = "number(7,2)")]
        public double Latitude { get; set; }
        [Column(TypeName = "number(7,2)")]
        public double Longitude { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public Usuario Usuario { get; set; }
    }
}
