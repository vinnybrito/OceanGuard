using System.ComponentModel.DataAnnotations.Schema;

namespace OceanGuard.Entities
{
    public class EventoNatural
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Descricao { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Tipo { get; set; }
        [Column(TypeName = "number(7,2)")]
        public double Latitude { get; set; }
        [Column(TypeName = "number(7,2)")]
        public double Longitude { get; set; }
        public DateTime DataEvento { get; set; }
        public Usuario Usuario { get; set; }
    }
}
