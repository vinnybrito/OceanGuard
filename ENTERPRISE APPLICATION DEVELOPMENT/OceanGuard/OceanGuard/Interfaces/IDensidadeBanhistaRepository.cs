using OceanGuard.Entities;

namespace OceanGuard.Interfaces
{
    public interface IDensidadeBanhistaRepository
    {
        ICollection<DensidadeBanhista> GetDensidadeBanhistas();
        DensidadeBanhista GetDensidadeBanhista(int id);
        DensidadeBanhista GetDensidadeBanhista(DateTime dataReporte);
        bool DensidadeBanhistaExists(int densidadeBanhistaId);
        bool CreateDensidadeBanhista(DensidadeBanhista densidadeBanhista);
        bool UpdateDensidadeBanhista(DensidadeBanhista densidadeBanhista);
        bool DeleteDensidadeBanhista(DensidadeBanhista densidadeBanhista);
        bool Save();
    }
}
