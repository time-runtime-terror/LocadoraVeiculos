using LocadoraVeiculos.Infra.ORM.Modules.Shared;
using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ORM.Modules.GrupoAutomoveisModule
{
    public class GrupoAutomoveisRepositoryEF : BaseRepository<GrupoAutomoveis>, IGrupoAutomoveisRepositoryEntity
    {
        public GrupoAutomoveisRepositoryEF(GrupoAutomoveisDbContext dbContext) : base(dbContext)
        {
        }
    }
}
