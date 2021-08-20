using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WindowsApp.Shared
{
    public interface IConfiguracaoToolBox
    {
        string ToolTipAdicionar { get; }
        string TipoCadastro { get; }
        string ToolTipEditar { get; }
        string ToolTipExcluir { get; }
        string ToolTipFiltrar { get; }
        string ToolTipAgrupar { get; }
        string ToolTipDesagrupar { get; }

        bool BarraPesquisa { get; }
        bool BotaoAdicionar { get; }
        bool BotaoCadastro { get; }
        bool BotaoEditar { get; }
        bool BotaoExcluir { get; }
        bool BotaoFiltrar { get; }
        bool BotaoAgrupar { get; }
        bool BotaoDesagrupar { get; }

    }
}
