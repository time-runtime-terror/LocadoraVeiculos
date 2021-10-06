using LocadoraVeiculos.netCore.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule
{
    public class GrupoAutomoveisEntity : IEntity, IEquatable<GrupoAutomoveis>
    {
        public GrupoAutomoveisEntity(string nomeGrupo, double planoDiarioUm, double planoDiarioDois, double kmControladoUm,
            double kmControladoDois, double kmLivreUm, double kmControladoIncluida)
        {
            NomeGrupo = nomeGrupo;
            PlanoDiarioUm = planoDiarioUm;
            PlanoDiarioDois = planoDiarioDois;
            KmControladoUm = kmControladoUm;
            KmControladoDois = kmControladoDois;
            KmControladoIncluida = kmControladoIncluida;
            KmLivreUm = kmLivreUm;
        }

        public new int Id { get; set; }

        public string NomeGrupo { get; }

        public double PlanoDiarioUm { get; }

        public double PlanoDiarioDois { get; }

        public double KmControladoUm { get; }

        public double KmControladoDois { get; }

        public double KmControladoIncluida { get; }

        public double KmLivreUm { get; }

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
              && KmControladoIncluida == other.KmControladoIncluida;
        }

        public override int GetHashCode()
        {
            int hashCode = -815075522;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NomeGrupo);
            hashCode = hashCode * -1521134295 + PlanoDiarioUm.GetHashCode();
            hashCode = hashCode * -1521134295 + PlanoDiarioDois.GetHashCode();
            hashCode = hashCode * -1521134295 + KmControladoUm.GetHashCode();
            hashCode = hashCode * -1521134295 + KmControladoDois.GetHashCode();
            hashCode = hashCode * -1521134295 + KmLivreUm.GetHashCode();
            hashCode = hashCode * -1521134295 + KmControladoIncluida.GetHashCode();

            return hashCode;
        }

        protected string QuebraDeLinha(string resultadoValidacao)
        {
            string quebraDeLinha = "";

            if (string.IsNullOrEmpty(resultadoValidacao) == false)
                quebraDeLinha = Environment.NewLine;

            return quebraDeLinha;
        }

        public string Validar()
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

            if (KmControladoIncluida == 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Quilometro Incluido é obrigatório";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}
