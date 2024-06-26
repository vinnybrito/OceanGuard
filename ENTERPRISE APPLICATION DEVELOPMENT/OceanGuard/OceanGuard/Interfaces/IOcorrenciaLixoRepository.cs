﻿using OceanGuard.Entities;

namespace OceanGuard.Interfaces
{
    public interface IOcorrenciaLixoRepository
    {
        ICollection<OcorrenciaLixo> GetOcorrenciaLixos();
        OcorrenciaLixo GetOcorrenciaLixo(int id);
        OcorrenciaLixo GetOcorrenciaLixo(DateTime dataOcorrencia);
        bool OcorrenciaLixoExists(int ocorrenciaLixoId);
        bool CreateOcorrenciaLixo(OcorrenciaLixo ocorrenciaLixo);
        bool UpdateOcorrenciaLixo(OcorrenciaLixo ocorrenciaLixo);
        bool DeleteOcorrenciaLixo(OcorrenciaLixo ocorrenciaLixo);
        bool Save();
    }
}
