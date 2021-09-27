using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using Serilog;
using System;

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
            try
            {
                veiculoRepository.AtualizarQuilometragem(veiculo);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar atualizar quilometragem do Veiculo id:{id}", veiculo.Id);
            }
        }

        public void AtualizarStatusAluguel(Veiculo veiculo, bool estaAlugado)
        {
            veiculo.EstaAlugado = estaAlugado;

            try
            {
                veiculoRepository.AtualizarStatusAluguel(veiculo);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar atualizar status do aluguel do Veiculo id:{id}", veiculo.Id);
            }
        }
    }
}
