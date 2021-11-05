using LocadoraVeiculos.netCore.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.netCore.Dominio.ParceiroModule
{
    public class Parceiro : EntidadeBase, IEquatable<Parceiro>
    {

        public string Nome { get; }

        public Parceiro(string nome)
        {
            Nome = nome;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(Nome))
                resultadoValidacao = "O campo Nome é obrigatório";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Parceiro);
        }

        public bool Equals(Parceiro other)
        {
            return other != null
              && Id == other.Id
              && Nome == other.Nome;
        }
        public override int GetHashCode()
        {
            int hashCode = 1695060689;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            return hashCode;
        }
    }
}
