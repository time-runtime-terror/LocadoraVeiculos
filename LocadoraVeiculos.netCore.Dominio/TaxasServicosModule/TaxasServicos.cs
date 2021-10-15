using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.netCore.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.netCore.Dominio.TaxasServicosModule
{
    public class TaxasServicos : EntidadeBase, IEquatable<TaxasServicos>
    {
        public TaxasServicos()
        {
        }

        public TaxasServicos(string servico, double taxa, string opcaoServico, string localServico)
        {
            Servico = servico;
            Taxa = taxa;
            OpcaoServico = opcaoServico;
            LocalServico = localServico;
        }

        public new int Id { get; set; }
        public string Servico { get; }
        public double Taxa { get; }
        public string OpcaoServico { get; }
        public string LocalServico { get; }
        public List<Locacao> Locacoes { get; set; } = new List<Locacao>();

        public override string ToString()
        {
            return $"{Servico}\t{OpcaoServico}\tR$ {Taxa}";
        }

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
              && OpcaoServico == other.OpcaoServico
              && LocalServico == other.LocalServico;
        }

        public override int GetHashCode()
        {
            int hashCode = -815075522;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Servico);
            hashCode = hashCode * -1521134295 + Taxa.GetHashCode();
            hashCode = hashCode * -1521134295 + OpcaoServico.GetHashCode();
            hashCode = hashCode * -1521134295 + LocalServico.GetHashCode();
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

            if (string.IsNullOrEmpty(LocalServico))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O local do serviço é obrigatório";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}
