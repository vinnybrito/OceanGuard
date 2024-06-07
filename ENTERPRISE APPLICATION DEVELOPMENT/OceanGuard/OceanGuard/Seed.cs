using Microsoft.EntityFrameworkCore;
using OceanGuard.Data;
using OceanGuard.Entities;
using System.Linq;


namespace OceanGuard
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedDataContext()
        {
            var result = _context.Usuarios.Count();

            bool usuarioExists = result.Equals(0);

            if (usuarioExists)
            {
                var usuarios = new List<Usuario>
                {
                    new Usuario { Nome = "Alice", Email = "alice@example.com", Senha = "password123", DataCadastro = DateTime.Now },
                    new Usuario { Nome = "Bob", Email = "bob@example.com", Senha = "password456", DataCadastro = DateTime.Now }
                };
                _context.Usuarios.AddRange(usuarios);
                _context.SaveChanges();

                var ocorrenciasLixo = new List<OcorrenciaLixo>
                {
                    new OcorrenciaLixo
                    {
                        Descricao = "Lixo na praia",
                        Latitude = -23.5505,
                        Longitude = -46.6333,
                        DataOcorrencia = DateTime.Now.AddDays(-1),
                        Usuario = usuarios[0]
                    },
                    new OcorrenciaLixo
                    {
                        Descricao = "Resíduos plásticos",
                        Latitude = -22.9083,
                        Longitude = -43.1964,
                        DataOcorrencia = DateTime.Now.AddDays(-2),
                        Usuario = usuarios[1]
                    }
                };
                _context.OcorrenciasLixo.AddRange(ocorrenciasLixo);
                _context.SaveChanges();

                var eventosNaturais = new List<EventoNatural>
                {
                    new EventoNatural
                    {
                        Descricao = "Tempestade tropical",
                        Tipo = "Tempestade",
                        Latitude = -15.7801,
                        Longitude = -47.9292,
                        DataEvento = DateTime.Now.AddDays(-5),
                        Usuario = usuarios[0]
                    },
                    new EventoNatural
                    {
                        Descricao = "Deslizamento de terra",
                        Tipo = "Deslizamento",
                        Latitude = -19.9167,
                        Longitude = -43.9345,
                        DataEvento = DateTime.Now.AddDays(-10),
                        Usuario = usuarios[1]
                    }
                };
                _context.EventosNaturais.AddRange(eventosNaturais);
                _context.SaveChanges();

                var densidadeBanhistas = new List<DensidadeBanhista>
                {
                    new DensidadeBanhista
                    {
                        QuantidadeBanhistas = 100,
                        Latitude = -23.5505,
                        Longitude = -46.6333,
                        DataReporte = DateTime.Now,
                        Usuario = usuarios[0]
                    },
                    new DensidadeBanhista
                    {
                        QuantidadeBanhistas = 200,
                        Latitude = -22.9083,
                        Longitude = -43.1964,
                        DataReporte = DateTime.Now,
                        Usuario = usuarios[1]
                    }
                };
                _context.DensidadeBanhistas.AddRange(densidadeBanhistas);
                _context.SaveChanges();

                var autoridades = new List<Autoridade>
                {
                    new Autoridade { Nome = "Autoridade A", Contato = "contatoA@example.com" },
                    new Autoridade { Nome = "Autoridade B", Contato = "contatoB@example.com" }
                };
                _context.Autoridades.AddRange(autoridades);
                _context.SaveChanges();

                //var notificacoes = new List<Notificacao>
                //{
                //    new Notificacao
                //    {
                //        DataNotificacao = DateTime.Now,
                //        Status = "Pendente",
                //        Autoridade = autoridades[0],
                //        OcorrenciaLixo = ocorrenciasLixo[0]
                //    },
                //    new Notificacao
                //    {
                //        DataNotificacao = DateTime.Now.AddHours(-1),
                //        Status = "Resolvido",
                //        Autoridade = autoridades[1],
                //        EventoNatural = eventosNaturais[0]
                //    }
                //};
                //_context.Notificacoes.AddRange(notificacoes);
                //_context.SaveChanges();
            }
        }
    }
}
