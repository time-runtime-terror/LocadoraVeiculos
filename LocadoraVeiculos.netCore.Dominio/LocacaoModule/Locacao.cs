using LocadoraVeiculos.netCore.Dominio.ClienteModule;
using LocadoraVeiculos.netCore.Dominio.Shared;
using LocadoraVeiculos.netCore.Dominio.TaxasServicosModule;
using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.netCore.Dominio.LocacaoModule
{
    public class Locacao : EntidadeBase, IEquatable<Locacao>
    {
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime DataDevolucao { get; set; }
        public double Caucao { get; set; }
        public string Plano { get; set; }
        public string Condutor { get;  set; }
        public string Devolucao { get; set; }
        public double Total { get; set; }
        public List<TaxasServicos> Taxas { get; set; } = new List<TaxasServicos>();
        public List<SolicitacaoEmail> SolicitacoesEmail{ get; set; }

        public Locacao(Cliente clienteEscolhido, Veiculo veiculoEscolhido, List<TaxasServicos> taxas,
            DateTime dataSaida, DateTime dataDevolucao, double caucao, string planoEscolhido, string condutor, string devolucao)
        {
            Cliente = clienteEscolhido;

            if (Cliente == null)
                throw new ArgumentNullException("O cliente deve ser inserido!");

            ClienteId = Cliente.Id;

            Veiculo = veiculoEscolhido;

            if (Veiculo == null)
                throw new ArgumentNullException("O veículo deve ser inserido!");

            VeiculoId = Veiculo.Id;
            DataSaida = dataSaida;
            DataDevolucao = dataDevolucao;
            Caucao = caucao;
            Plano = planoEscolhido;
            Condutor = condutor;
            Devolucao = devolucao;

            if (taxas != null)
                Taxas = taxas;
        }

        public Locacao()
        {
        }

        public void AdicionarTaxa(TaxasServicos taxa)
        {
            Taxas.Add(taxa);
            taxa.Locacoes.Add(this);
        }

        public void AdicionarTaxas(List<TaxasServicos> taxas)
        {
            Taxas.AddRange(taxas);

            foreach (var taxa in taxas)
                taxa.Locacoes.Add(this);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Locacao);
        }

        public bool Equals(Locacao obj)
        {
            return obj is Locacao locacao &&
                   Id == locacao.Id &&
                   EqualityComparer<Cliente>.Default.Equals(Cliente, locacao.Cliente) &&
                   EqualityComparer<Veiculo>.Default.Equals(Veiculo, locacao.Veiculo) &&
                   //EqualityComparer<ICollection<TaxasServicos>>.Default.Equals(Taxas, locacao.Taxas) &&
                   DataSaida == locacao.DataSaida &&
                   DataDevolucao == locacao.DataDevolucao &&
                   Caucao == locacao.Caucao &&
                   Condutor == locacao.Condutor &&
                   Devolucao == locacao.Devolucao &&
                   Plano == locacao.Plano;
        }

        public override int GetHashCode()
        {
            int hashCode = -465531437;
            
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Cliente>.Default.GetHashCode(Cliente);
            hashCode = hashCode * -1521134295 + EqualityComparer<Veiculo>.Default.GetHashCode(Veiculo);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<TaxasServicos>>.Default.GetHashCode(Taxas);
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

            else if(Cliente.TipoCadastro == "CNPJ" && Condutor == null)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "A empresa deve  ter um condutor!";

            if (Veiculo == null)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O Veículo deve ser inserido!";

            if (DataDevolucao == DateTime.MinValue)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Data de Devolução é obrigatório!";

            if (DataDevolucao.Date < DataSaida.Date)
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
