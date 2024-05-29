namespace OceanGuard.Entities
{
    public class EventoNatural
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DataEvento { get; set; }
    }
}
