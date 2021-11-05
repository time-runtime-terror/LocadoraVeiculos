using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.netCore.Dominio.ParceiroModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ParceiroModule
{
    public class ParceiroAppService : BaseAppService<Parceiro>
    {

        private readonly IParceiroRepository parceiroRepository;


        public ParceiroAppService(IParceiroRepository parceiroRepository) : base(parceiroRepository)
        {
            this.parceiroRepository = parceiroRepository;
        }
    }
}
