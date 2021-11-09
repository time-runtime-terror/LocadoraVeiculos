using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.netCore.Dominio.CupomModule;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Aplicacao.CupomModule
{
    public class CupomAppService: BaseAppService<Cupom>
    {
        private readonly ICupomRepository cupomRepository;

        public CupomAppService(ICupomRepository cupomRepository) : base(cupomRepository)
        {
            this.cupomRepository = cupomRepository;
        }


        public List<Cupom> SelecionarCuponsAtivos(DateTime data)
        {
            return cupomRepository.SelecionarCuponsAtivos(data);
        }

    }
}
