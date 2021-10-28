using LocadoraVeiculos.netCore.Dominio.Shared;
using System;

namespace LocadoraVeiculos.netCore.Dominio.LocacaoModule
{
    public class SolicitacaoEmail : EntidadeBase
    {
        public int LocacaoId;
        public Locacao Locacao { get; set; }
        public string CaminhoRecibo { get; set; }
        public bool EnvioPendente { get; set; }

        public SolicitacaoEmail()
        {

        }

        public SolicitacaoEmail(Locacao locacao, string caminhoRecibo)
        {
            Locacao = locacao;

            if (Locacao == null)
                throw new ArgumentNullException("Deve haver uma locação!");

            LocacaoId = Locacao.Id;

            CaminhoRecibo = caminhoRecibo;
        }

        public override string Validar()
        {
            throw new System.NotImplementedException();
        }
    }
}
