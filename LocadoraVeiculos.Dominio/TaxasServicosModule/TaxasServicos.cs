using LocadoraVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.TaxasServicosModule
{
    public class TaxasServicos : EntidadeBase, IEquatable<TaxasServicos>
    {
        public TaxasServicos(string servico, double taxa, string opcaoServico)
        {
            Servico = servico;
            Taxa = taxa;
            OpcaoServico = opcaoServico;
        }

        public new int Id { get; set; }

        public string Servico { get; }

        public double Taxa { get; }

        public string OpcaoServico { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as TaxasServicos);
        }

        public bool Equals(TaxasServicos other)
        {
            return other != null
              && Id == other.Id
              && Servico == other.Servico
              && Taxa == other.Taxa
              && OpcaoServico == other.OpcaoServico;
        }

        public override int GetHashCode()
        {
            int hashCode = -815075522;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Servico);
            hashCode = hashCode * -1521134295 + Taxa.GetHashCode();
            hashCode = hashCode * -1521134295 + OpcaoServico.GetHashCode();
            return hashCode;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(Servico))
                resultadoValidacao = "O campo Serviço é obrigatório";

            if (Taxa == 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Taxa é obrigatório";

            if (string.IsNullOrEmpty(OpcaoServico))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo tipo do serviço é obrigatório";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}
