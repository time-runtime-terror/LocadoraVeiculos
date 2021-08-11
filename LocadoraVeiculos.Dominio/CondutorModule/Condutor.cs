using LocadoraVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.CondutorModule
{
    public class Condutor : EntidadeBase, IEquatable<Condutor>
    {
        public string Nome { get; }
        public string CNH { get; }
        public string CPF { get; }
        public string RG { get; }
        public DateTime VencimentoCnh { get; }

        public Condutor(string nome, string cnh, string cpf, string rg, DateTime vencimentoCnh)
        {
            Nome = nome;
            CNH = cnh;
            CPF = cpf;
            RG = rg;
            VencimentoCnh = vencimentoCnh;
        }


        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(Nome))
                resultadoValidacao = "O campo Nome é obrigatório";

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
        public override bool Equals(object obj)
        {
            return Equals(obj as Condutor);
        }

        public bool Equals(Condutor other)
        {
            return other is Condutor condutor &&
                   Id == condutor.Id &&
                   Nome == condutor.Nome &&
                   CNH == condutor.CNH &&
                   CPF == condutor.CPF &&
                   RG == condutor.RG &&
                   VencimentoCnh == condutor.VencimentoCnh;
        }

        public override int GetHashCode()
        {
            int hashCode = 1223242860;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CNH);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CPF);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RG);
            hashCode = hashCode * -1521134295 + VencimentoCnh.GetHashCode();
            return hashCode;
        }
    }
}