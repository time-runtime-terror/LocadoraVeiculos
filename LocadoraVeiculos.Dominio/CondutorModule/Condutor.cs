using LocadoraVeiculos.Dominio.Shared;
using System;

namespace LocadoraVeiculos.Dominio.CondutorModule
{
    public class Condutor : EntidadeBase
    {
        public string CNH { get; }
        public string CPF { get; }
        public string RG { get; }
        public DateTime VencimentoCnh { get; }

        public Condutor(string cnh, string cpf, string rg, DateTime vencimentoCnh)
        {
            CNH = cnh;
            CPF = cpf;
            RG = rg;
            VencimentoCnh = vencimentoCnh;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(CNH))
                resultadoValidacao = "O campo CNH é obrigatório";

            if (string.IsNullOrEmpty(CPF))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo CPF é obrigatório";

            if (string.IsNullOrEmpty(RG))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo RG é obrigatório";

            if (VencimentoCnh == null)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Vencimento da CNH é obrigatório";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}