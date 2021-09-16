using LocadoraVeiculos.netCore.Dominio.ClienteModule;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using System;

namespace LocadoraVeiculos.TestDataBuilders
{
    public class LocacaoDataBuilder
    {
        private Locacao locacao;

        public LocacaoDataBuilder()
        {
            locacao = new Locacao();
        }

        public Locacao Build()
        {
            return locacao;
        }

        public LocacaoDataBuilder ParaCliente(Cliente cliente)
        {
            locacao.Cliente = cliente;
            return this;
        }

        public LocacaoDataBuilder DoVeiculo(Veiculo veiculo)
        {
            locacao.Veiculo = veiculo;
            return this;
        }
        public LocacaoDataBuilder ComDataSaida(DateTime data)
        {
            locacao.DataSaida = data;
            return this;
        }

        public LocacaoDataBuilder ComDataDevolucaoPrevista(DateTime data)
        {
            locacao.DataDevolucao = data;
            return this;
        }

        public LocacaoDataBuilder ComPlanoDeCobranca(string plano)
        {
            locacao.Plano = plano;
            return this;
        }

        public LocacaoDataBuilder ComValorDeEntrada(double entrada)
        {
            locacao.Caucao = entrada;
            return this;
        }
    }
}
