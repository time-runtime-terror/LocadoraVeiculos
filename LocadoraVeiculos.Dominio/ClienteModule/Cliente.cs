using LocadoraVeiculos.Dominio.CondutorModule;
using LocadoraVeiculos.Dominio.Shared;
using System;

namespace LocadoraVeiculos.Dominio.ClienteModule
{
    public class Cliente : EntidadeBase
    {
        private Condutor condutor;

        public string Nome { get; }
        public string Endereco { get; }
        public string Telefone { get; }
        public string TipoPessoa { get; }
        public string CNH { get; }
        public DateTime VencimentoCnh { get; }
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

        public Cliente(string nome, string endereco, string telefone, string tipoPessoa, string cnh, DateTime vencimentoCnh, string cpf, string cnpj, Condutor condutor)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            TipoPessoa = tipoPessoa;
            CNH = cnh;
            VencimentoCnh = vencimentoCnh;
            CPF = cpf;
            CNPJ = cnpj;
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
    }
}
