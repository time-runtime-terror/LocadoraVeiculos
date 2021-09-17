using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;

namespace LocadoraVeiculos.Aplicacao.GrupoAutomoveisModule
{
    public class GrupoAutomoveisAppService : BaseAppService<GrupoAutomoveis>
    {
        private readonly IGrupoAutomoveisRepository grupoRepository;

        public GrupoAutomoveisAppService(IGrupoAutomoveisRepository grupoAutomoveisRepository)
            : base(grupoAutomoveisRepository)
        {
            this.grupoRepository = grupoAutomoveisRepository;
        }
    }
}
