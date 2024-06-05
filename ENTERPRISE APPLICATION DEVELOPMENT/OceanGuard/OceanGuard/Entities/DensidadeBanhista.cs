using System.ComponentModel.DataAnnotations.Schema;

namespace OceanGuard.Entities
{
    public class DensidadeBanhista
    {
        public int Id { get; set; }
        [Column(TypeName = "number(7)")]
        public int QuantidadeBanhistas { get; set; }
        [Column(TypeName = "number(7,2)")]
        public double Latitude { get; set; }
        [Column(TypeName = "number(7,2)")]
        public double Longitude { get; set; }
        public DateTime DataReporte { get; set; }
        public Usuario Usuario { get; set; }
    }
}
