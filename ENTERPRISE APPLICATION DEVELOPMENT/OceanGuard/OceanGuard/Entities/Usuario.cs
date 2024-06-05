using System.ComponentModel.DataAnnotations.Schema;

namespace OceanGuard.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string Nome { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
