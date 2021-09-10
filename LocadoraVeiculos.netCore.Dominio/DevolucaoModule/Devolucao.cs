using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.netCore.Dominio.Shared;
using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.netCore.Dominio.DevolucaoModule
{
    public class Devolucao : EntidadeBase, IEquatable<Devolucao>
    {
        public Locacao Locacao { get; set; }
        public Veiculo Veiculo { get; set; }
        public int Quilometragem { get; set; }
        public int CombustivelTanque { get; set; }
        public double Total { get; set; }

        public Devolucao(Locacao locacao, int quilometragem, int combustivel, double total)
        {
            Locacao = locacao;
            Veiculo = locacao.Veiculo;
            Quilometragem = quilometragem;
            CombustivelTanque = combustivel;
            Total = total;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (Locacao == null)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O Cliente deve ser inserido!";


            else if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Devolucao);
        }

        public bool Equals(Devolucao obj)
        {
            return obj is Devolucao devolucao &&
                   Id == devolucao.Id &&
                   EqualityComparer<Locacao>.Default.Equals(Locacao, devolucao.Locacao) &&
                   EqualityComparer<Veiculo>.Default.Equals(Veiculo, devolucao.Veiculo) &&
                   Quilometragem == devolucao.Quilometragem &&
                   CombustivelTanque == devolucao.CombustivelTanque &&
                   Total == devolucao.Total;
        }

        public override int GetHashCode()
        {
            int hashCode = -1413251597;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Locacao>.Default.GetHashCode(Locacao);
            hashCode = hashCode * -1521134295 + EqualityComparer<Veiculo>.Default.GetHashCode(Veiculo);
            hashCode = hashCode * -1521134295 + Quilometragem.GetHashCode();
            hashCode = hashCode * -1521134295 + CombustivelTanque.GetHashCode();
            hashCode = hashCode * -1521134295 + Total.GetHashCode();
            return hashCode;
        }

    }
}
