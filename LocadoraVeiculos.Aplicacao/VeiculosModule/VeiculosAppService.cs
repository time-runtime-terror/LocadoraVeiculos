using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.VeiculosModule
{
    public class VeiculosAppService
    {
        private readonly IVeiculoRepository veiculoRepository;

        public VeiculosAppService(IVeiculoRepository veiculosRepository)
        {
            this.veiculoRepository = veiculosRepository;
        }

        public void AtualizarQuilometragem(Veiculo veiculo)
        {
            veiculoRepository.AtualizarQuilometragem(veiculo);
        }

        public void AtualizarStatusAluguel(Veiculo veiculo)
        {
            veiculoRepository.AtualizarStatusAluguel(veiculo);
        }

        public string InserirNovo(Veiculo veiculo)
        {
            string resultadoValidacao = veiculo.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
                veiculoRepository.InserirNovo(veiculo);

            return resultadoValidacao;
        }

        public string Editar(int id, Veiculo veiculo)
        {
            string resultadoValidacao = veiculo.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
                veiculoRepository.Editar(id, veiculo);

            return resultadoValidacao;
        }

        public bool Excluir(int id)
        {
            if (veiculoRepository.Excluir(id))
                return true;

            return false;
        }

        public Veiculo SelecionarPorId(int id)
        {
            return veiculoRepository.SelecionarPorId(id);
        }

        public List<Veiculo> SelecionarTodos()
        {
            return (List<Veiculo>)veiculoRepository.SelecionarTodos();
        }

        public List<Veiculo> Pesquisar(string texto)
        {
            return (List<Veiculo>)veiculoRepository.Pesquisar(texto);
        }
    }
}
