using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.netCore.Dominio.ParceiroModule;
using LocadoraVeiculos.netCore.Dominio.Shared;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.netCore.Dominio.CupomModule
{
    public class Cupom : EntidadeBase
    {
        public Cupom()
        {
            DataValidade = DateTime.Now;
        }

        public Cupom(string nome, decimal valor, DateTime dataValidade,
           int parceiroId, decimal valorMinimo)
        {
            Nome = nome;
            Valor = valor;
            DataValidade = dataValidade;
            ParceiroId = parceiroId;
            ValorMinimo = valorMinimo;
        }

        public Cupom(string nome, decimal valor, DateTime dataValidade,
          Parceiro parceiro, decimal valorMinimo, TipoCupom tipo)
            : this(nome, valor, dataValidade, parceiro.Id, valorMinimo)
        {
            Parceiro = parceiro;
            Tipo = tipo;
        }

        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataValidade { get; set; }

        public int? ParceiroId { get; set; }

        public decimal ValorMinimo { get; set; }

        public virtual TipoCupom Tipo { get; set; }

        public virtual Parceiro Parceiro { get; set; }

        public virtual List<Locacao> Locacoes { get; set; }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(Nome))
                resultadoValidacao += "O campo nome é obrigatório e não pode ser vazio.";

            if (DataValidade == DateTime.MinValue || DataValidade == DateTime.MaxValue)
                resultadoValidacao += "A data Invalida, Insira uma data valida";

            if (ParceiroId == 0)
                resultadoValidacao += "O campo Parceiro é obrigatório e não pode ser vazio.";

            if (ValorMinimo < 0)
                resultadoValidacao += "O campo Valor Minimo não pode ser menor que Zero.";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}
