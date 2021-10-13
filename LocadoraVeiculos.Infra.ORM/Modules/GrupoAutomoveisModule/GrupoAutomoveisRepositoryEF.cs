using LocadoraVeiculos.Infra.ORM.Modules.Shared;
using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;

namespace LocadoraVeiculos.Infra.ORM.Modules.GrupoAutomoveisModule
{
    public class GrupoAutomoveisRepositoryEF : BaseRepository<GrupoAutomoveis>, IGrupoAutomoveisRepository
    {
        public GrupoAutomoveisRepositoryEF()
        {
        }
    }
}
