using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.netCore.Dominio.TaxasServicosModule;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.TaxasServicosModule
{
    public class TaxasServicosAppService : BaseAppService<TaxasServicos>
    {

        private readonly ITaxasServicosRepository taxasRepository;

        public TaxasServicosAppService(ITaxasServicosRepository taxasRepository) : base(taxasRepository)
        {
            this.taxasRepository = taxasRepository;
        }

        public void RegistrarTaxaUsada(Locacao registro)
        {
            try
            {
                if (registro.Taxas != null)
                    taxasRepository.InserirNovaTaxaUsada(registro);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar registrar uma taxa usada na locaçao de Id: {Id},", registro.Id);
            }

        }
        public void EditarTaxasUsadas(Locacao locacao)
        {
            try
            {
                foreach (TaxasServicos taxa in locacao.Taxas)
                    taxasRepository.EditarTaxasUsadas(locacao);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar editar uma taxa usada na locaçao de Id: {Id},", locacao.Id);
            }
        }
        public bool ExcluirTaxaUsada(Locacao locacao)
        {
            try
            {
                if (taxasRepository.ExcluirTaxaUsada(locacao))
                    return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar excluir uma taxa usada na locaçao de Id: {Id},", locacao.Id);
            }
            return false;
            
        }
        public List<TaxasServicos> SelecionarTaxasServicosUsados(int id)
        {
            try
            {
                return taxasRepository.SelecionarTaxasServicosUsados(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar selecionar uma taxa usada na locaçao de Id: {Id},", id);
            }

            return null;
        }
    }
}
