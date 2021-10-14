using LocadoraVeiculos.Infra.ORM.Modules.Shared;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.netCore.Dominio.TaxasServicosModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.Infra.ORM.Modules.TaxasServicosModule
{
    public class TaxasServicosRepositoryEF : BaseRepository<TaxasServicos>, ITaxasServicosRepository
    {
        public void InserirNovaTaxaUsada(Locacao registro)
        {
            throw new NotImplementedException();
        }

        public void EditarTaxasUsadas(Locacao locacao)
        {
            throw new NotImplementedException();
        }

        public bool ExcluirTaxaUsada(Locacao locacao)
        {
            throw new NotImplementedException();
        }

        public List<TaxasServicos> SelecionarTaxasServicosUsados(int id)
        {
            throw new NotImplementedException();
        }
    }
}
