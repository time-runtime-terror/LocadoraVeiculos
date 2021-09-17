using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using System.Collections.Generic;

namespace LocadoraVeiculos.Aplicacao.VeiculosModule
{
    public class VeiculoAppService : BaseAppService<Veiculo>
    {
        private readonly IVeiculoRepository veiculoRepository;

        public VeiculoAppService(IVeiculoRepository veiculosRepository) : base(veiculosRepository)
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
    }
}
