using LocadoraVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.FuncionarioModule
{
    public class Funcionario : EntidadeBase, IEquatable<Funcionario>
    {
        //Devem ser registrados nome, usuário de acesso,
        //senha de acesso, data de entrada na empresa e o salário do funcionário.
        public Funcionario(string nome, string nomeUsuario, string senha, DateTime dataEntrada, string salario)
        {
            Nome = nome;
            NomeUsuario = nomeUsuario;
            Senha = senha;
            DataEntrada = dataEntrada;
            Salario = salario;
        }

        

        public string Nome { get; }

        public string NomeUsuario { get; }

        public string Senha { get; }

        public DateTime DataEntrada { get; }

        public string Salario { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Funcionario);
        }

        public bool Equals(Funcionario other)
        {
            return other != null
               && Id == other.Id
               && Nome == other.Nome
               && NomeUsuario == other.NomeUsuario
               && Senha == other.Senha
               && DataEntrada == other.DataEntrada
               && Salario == other.Salario;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(Nome))
                resultadoValidacao = "O campo Nome é obrigatório";

            if (string.IsNullOrEmpty(NomeUsuario))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Nome de Usuário é obrigatório";

            if (Senha.Length < 3)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Senha necessita ter ao mínimo 3 caracteres";

            if (DataEntrada == DateTime.MinValue)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Data de Entrada é obrigatório";

            if (string.IsNullOrEmpty(Salario))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Salário é obrigatório";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public override int GetHashCode()
        {
            int hashCode = 1695060689;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NomeUsuario);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Senha);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTime>.Default.GetHashCode(DataEntrada);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Salario);
            return hashCode;
        }

    }
}
