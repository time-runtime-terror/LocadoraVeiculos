using LocadoraVeiculos.Infra.ORM.Modules.Shared;
using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ORM.Modules.GrupoAutomoveisModule
{
    public class GrupoAutomoveisRepositoryEF : BaseRepository<GrupoAutomoveis>, IGrupoAutomoveisRepository
    {
        public GrupoAutomoveisRepositoryEF(GrupoAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

        public GrupoAutomoveis ConverterEmRegistro(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        public bool Existe(int id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, object> ObtemParametrosRegistro(GrupoAutomoveis registro)
        {
            throw new NotImplementedException();
        }
    }
}
