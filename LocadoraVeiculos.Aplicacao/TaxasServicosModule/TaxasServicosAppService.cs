using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.netCore.Dominio.TaxasServicosModule;
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

        public override string InserirNovo(TaxasServicos registro)
        {
            throw new Exception("Teste taxas");
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
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
            }
        }
    }
}
