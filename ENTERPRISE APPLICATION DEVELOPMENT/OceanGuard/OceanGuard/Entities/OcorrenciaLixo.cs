namespace OceanGuard.Entities
{
    public class OcorrenciaLixo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DataOcorrencia { get; set; }
    }
}
