using LocadoraVeiculos.Dominio.CondutorModule;
using LocadoraVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.ClienteModule
{
    public class Cliente : EntidadeBase, IEquatable<Cliente>
    {
        private Condutor condutor;

        public string Nome { get; }
        public string Endereco { get; }
        public string Telefone { get; }
        public string TipoPessoa { get; }
        public string CNH { get; }
        public DateTime? VencimentoCnh { get; }
        public string CPF { get; }
        public string CNPJ { get; }
        public string RG { get; }
        public Condutor Condutor { get => condutor; }

        public Cliente(string nome, string endereco, string telefone, string tipoPessoa,
            string cnh, DateTime vencimentoCnh, string cpf, string cpnj, string rg, Condutor condutor) 
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            TipoPessoa = tipoPessoa;
            CNH = cnh;
            VencimentoCnh = vencimentoCnh;
            CPF = cpf;
            CNPJ = cpnj;
            RG = rg;
            this.condutor = condutor;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(Nome))
                resultadoValidacao = "O campo Nome é obrigatório";

            if (string.IsNullOrEmpty(Endereco))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Endereço é obrigatório";

            if (string.IsNullOrEmpty(Telefone))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Telefone é obrigatório";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Cliente);
        }

        public bool Equals(Cliente other)
        {
            return other != null
                   && Id == other.Id
                   && Nome == other.Nome 
                   && Endereco == other.Endereco &&
                   Telefone == other.Telefone &&
                   TipoPessoa == other.TipoPessoa &&
                   CNH == other.CNH &&
                   VencimentoCnh == other.VencimentoCnh &&
                   CPF == other.CPF &&
                   CNPJ == other.CNPJ &&
                   RG == other.RG
                   && EqualityComparer<Condutor>.Default.Equals(Condutor, other.Condutor);
        }

        public override int GetHashCode()
        {
            int hashCode = 1766002315;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Condutor>.Default.GetHashCode(condutor);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Endereco);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Telefone);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TipoPessoa);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CNH);
            hashCode = hashCode * -1521134295 + VencimentoCnh.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CPF);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CNPJ);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RG);
            hashCode = hashCode * -1521134295 + EqualityComparer<Condutor>.Default.GetHashCode(Condutor);
            return hashCode;
        }
    }
}
