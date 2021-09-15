using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.netCore.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.netCore.Dominio.TaxasServicosModule
{
    public interface ITaxasServicosRepository : IRepository<TaxasServicos>
    {
        void InserirNovaTaxaUsada(Locacao registro);

        public void EditarTaxasUsadas(Locacao locacao);

        public bool ExcluirTaxaUsada(Locacao locacao);

        public List<TaxasServicos> SelecionarTaxasServicosUsados(int id);


        TaxasServicos ConverterEmTaxasServicosUsados(IDataReader reader);

        Dictionary<string, object> ObtemParametrosTaxasServicosUsados(Locacao locacao, TaxasServicos taxa);
    }
}
