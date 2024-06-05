using System.ComponentModel.DataAnnotations.Schema;

namespace OceanGuard.Entities
{
    public class Autoridade
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string Nome { get; set;}
        [Column(TypeName = "varchar(60)")]
        public string Contato { get; set;}
    }
}
