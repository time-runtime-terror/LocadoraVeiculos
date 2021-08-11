using System;
using System.Collections.Generic;
using System.Linq;
using LocadoraVeiculos.Dominio.Shared;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.GrupoAutomoveisModule
{
    public class GrupoAutomoveis : EntidadeBase
    {
        public GrupoAutomoveis(string nomeGrupo, string planoDiarioUm, string planoDiarioDois, string kmControladoUm, 
            string kmControladoDois, string kmLivreUm, string kmLivreDois)
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

        public string PlanoDiarioUm { get; }

        public string PlanoDiarioDois { get; }

        public string KmControladoUm { get; }

        public string KmControladoDois { get; }

        public string KmLivreUm { get; }

        public string KmLivreDois { get; }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(NomeGrupo))
                resultadoValidacao = "O campo Nome do Grupo de Automóveis é obrigatório";

            if (string.IsNullOrEmpty(PlanoDiarioUm))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Plano Diário é obrigatório";

            if (string.IsNullOrEmpty(KmControladoUm))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Quilometro Controlado é obrigatório";

            if (string.IsNullOrEmpty(KmLivreUm))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Quilometro Livre é obrigatório";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}
