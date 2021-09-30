using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.Infra.ExtensionMethods;
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
            Log.Logger.Aqui().Debug("Registrando taxas usadas: {@Taxas}", registro.Taxas);

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
            Log.Logger.Aqui().Debug("Editando taxas usadas: {@Taxas}", locacao.Taxas);

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
            Log.Logger.Aqui().Debug("Excluindo taxas usadas: {@Taxas}", locacao.Taxas);
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
            Log.Logger.Aqui().Debug("Selecionando todas as taxas usadas");
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
