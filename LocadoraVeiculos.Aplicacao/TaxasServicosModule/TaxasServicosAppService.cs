using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.netCore.Dominio.TaxasServicosModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.TaxasServicosModule
{
    public class TaxasServicosAppService
    {

        private readonly ITaxasServicosRepository taxasRepository;

        public TaxasServicosAppService(ITaxasServicosRepository taxasRepository)
        {
            this.taxasRepository = taxasRepository;
        }

        public string RegistrarNovaTaxa(TaxasServicos taxas)
        {
            string resultadoValidacao = taxas.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                taxasRepository.InserirNovo(taxas);
            }

            return resultadoValidacao;
        }

        public void RegistrarTaxaUsada(Locacao registro)
        {
            if (registro.Taxas != null)
                taxasRepository.InserirNovaTaxaUsada(registro);
        }


        public string Editar(int id, TaxasServicos taxa)
        {
            string resultadoValidacao = taxa.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
                taxasRepository.Editar(id, taxa);

            return resultadoValidacao;
        }

        public void EditarTaxasUsadas(Locacao locacao)
        {
            foreach (TaxasServicos taxa in locacao.Taxas)
                taxasRepository.EditarTaxasUsadas(locacao);
        }

        public bool Excluir(int id)
        {

            if (taxasRepository.Excluir(id))
                return true;

            return false;
            
        }

        public bool ExcluirTaxaUsada(Locacao locacao)
        {

            if (taxasRepository.ExcluirTaxaUsada(locacao))
                return true;

            return false;
            
        }

        public  bool Existe(int id)
        {
            return taxasRepository.Existe(id);
        }

        public TaxasServicos SelecionarPorId(int id)
        {
            return taxasRepository.SelecionarPorId(id);
        }

        public  List<TaxasServicos> SelecionarTodos()
        {
            return (List<TaxasServicos>)taxasRepository.SelecionarTodos();
        }

        public List<TaxasServicos> SelecionarTaxasServicosUsados(int id)
        {
            return taxasRepository.SelecionarTaxasServicosUsados(id);
        }
    }
}
