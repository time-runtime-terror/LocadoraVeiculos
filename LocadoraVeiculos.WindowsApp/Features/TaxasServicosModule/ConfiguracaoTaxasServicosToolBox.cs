using LocadoraVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WindowsApp.Features.TaxasServicosModule
{
    public class ConfiguracaoTaxasServicosToolBox : IConfiguracaoToolBox
    {
        public string ToolTipAdicionar => "Adicionar nova taxa/serviço";

        public string TipoCadastro => "Cadastro de Taxas e Serviços";

        public string ToolTipEditar => "Editar uma taxa/serviço";

        public string ToolTipExcluir => "Excluir uma taxa/serviço";

        public string ToolTipFiltrar => "Indisponível";

        public string ToolTipAgrupar => "Indisponível";

        public string ToolTipDesagrupar => "Indisponível";

        public bool BarraPesquisa => false;

        public bool BotaoAdicionar => true;

        public bool BotaoDevolucao => false;

        public bool BotaoEditar => true;

        public bool BotaoExcluir => true;

        public bool BotaoFiltrar => false;

        public bool BotaoAgrupar => false;

        public bool BotaoDesagrupar => false;

        public string ToolTipDevolucao => "";
    }
}
