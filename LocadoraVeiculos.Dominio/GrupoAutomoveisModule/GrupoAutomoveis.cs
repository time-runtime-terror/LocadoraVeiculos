using System;
using System.Collections.Generic;
using System.Linq;
using LocadoraVeiculos.Dominio.Shared;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.GrupoAutomoveisModule
{
    public class GrupoAutomoveis : EntidadeBase, IEquatable<GrupoAutomoveis>
    {
        public GrupoAutomoveis(string nomeGrupo, double planoDiarioUm, double planoDiarioDois, double kmControladoUm,
            double kmControladoDois, double kmLivreUm, double kmLivreDois)
        {
            NomeGrupo = nomeGrupo;
            PlanoDiarioUm = planoDiarioUm;
            PlanoDiarioDois = planoDiarioDois;
            KmControladoUm = kmControladoUm;
            KmControladoDois = kmControladoDois;
            KmLivreUm = kmLivreUm;
            KmLivreDois = kmLivreDois;
        }

        public string NomeGrupo { get; }

        public double PlanoDiarioUm { get; }

        public double PlanoDiarioDois { get; }

        public double KmControladoUm { get; }

        public double KmControladoDois { get; }

        public double KmLivreUm { get; }

        public double KmLivreDois { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as GrupoAutomoveis);
        }

        public bool Equals(GrupoAutomoveis other)
        {
            return other != null
              && Id == other.Id
              && NomeGrupo == other.NomeGrupo
              && PlanoDiarioUm == other.PlanoDiarioUm
              && PlanoDiarioDois == other.PlanoDiarioDois
              && KmControladoUm == other.KmControladoUm
              && KmControladoDois == other.KmControladoDois
              && KmLivreUm == other.KmLivreUm
              && KmLivreDois == other.KmLivreDois;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(NomeGrupo))
                resultadoValidacao = "O campo Nome do Grupo de Automóveis é obrigatório";

            if (PlanoDiarioUm == 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Plano Diário é obrigatório";

            if (KmControladoUm == 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Quilometro Controlado é obrigatório";

            if (KmLivreUm == 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Quilometro Livre é obrigatório";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}
