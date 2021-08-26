using LocadoraVeiculos.Dominio.ClienteModule;
using LocadoraVeiculos.Dominio.Shared;
using LocadoraVeiculos.Dominio.TaxasServicosModule;
using LocadoraVeiculos.Dominio.VeiculoModule;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.LocacaoModule
{
    public class Locacao : EntidadeBase, IEquatable<Locacao>
    {
        public Cliente Cliente { get; set; }
        public Veiculo Veiculo { get; set; }
        public List<TaxasServicos> Taxas { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime DataDevolucao { get; set; }
        public double Caucao { get; set; }
        public string Plano { get; set; }

        public Locacao(Cliente clienteEscolhido, Veiculo veiculoEscolhido, List<TaxasServicos> taxas,
            DateTime dataSaida, DateTime dataDevolucao, double caucao, string planoEscolhido)
        {
            Cliente = clienteEscolhido;
            Veiculo = veiculoEscolhido;
            Taxas = taxas;
            DataSaida = dataSaida;
            DataDevolucao = dataDevolucao;
            Caucao = caucao;
            Plano = planoEscolhido;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Locacao);
        }

        public bool Equals(Locacao obj)
        {
            return obj is Locacao locacao &&
                   id == locacao.id &&
                   Id == locacao.Id &&
                   EqualityComparer<Cliente>.Default.Equals(Cliente, locacao.Cliente) &&
                   EqualityComparer<Veiculo>.Default.Equals(Veiculo, locacao.Veiculo) &&
                   EqualityComparer<List<TaxasServicos>>.Default.Equals(Taxas, locacao.Taxas) &&
                   DataSaida == locacao.DataSaida &&
                   DataDevolucao == locacao.DataDevolucao &&
                   Caucao == locacao.Caucao &&
                   Plano == locacao.Plano;
        }

        public override int GetHashCode()
        {
            int hashCode = -465531437;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Cliente>.Default.GetHashCode(Cliente);
            hashCode = hashCode * -1521134295 + EqualityComparer<Veiculo>.Default.GetHashCode(Veiculo);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<TaxasServicos>>.Default.GetHashCode(Taxas);
            hashCode = hashCode * -1521134295 + DataSaida.GetHashCode();
            hashCode = hashCode * -1521134295 + DataDevolucao.GetHashCode();
            hashCode = hashCode * -1521134295 + Caucao.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Plano);
            return hashCode;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (Cliente == null)
                resultadoValidacao += "O Cliente deve ser inserido!";

            if (Veiculo == null)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O Veículo deve ser inserido!";

            if (DataDevolucao == DateTime.MinValue)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Data de Devolução é obrigatório!";

            if (DataDevolucao < DataSaida)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Data de Devolução necessita ser maior que a de saida do veículo!";

            if(Caucao == 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "É necessário, colocar um valor de caução!";

            if (string.IsNullOrEmpty(Plano))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "A escolha de um plano de locação é obrigatória!";


            else if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }


    }
}
