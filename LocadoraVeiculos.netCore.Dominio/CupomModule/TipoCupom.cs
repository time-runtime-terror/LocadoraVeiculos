using System.ComponentModel;

namespace LocadoraVeiculos.netCore.Dominio.CupomModule
{
    public enum TipoCupom : int
    {
        [Description("Valor Fixo")]
        ValorFixo = 0,

        [Description("Percentual")]
        Percentual = 1
    }
}
