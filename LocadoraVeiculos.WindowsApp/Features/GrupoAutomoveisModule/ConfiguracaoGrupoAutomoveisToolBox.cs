using LocadoraVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WindowsApp.Features.GrupoAutomoveisModule
{
    public class ConfiguracaoGrupoAutomoveisToolBox : IConfiguracaoToolBox
    {
        public string ToolTipAdicionar => "Adicionar um novo Grupo de Automóveis";

        public string TipoCadastro => "Cadastro de Grupo de Automóveis";

        public string ToolTipEditar => "Editar um Grupo de Automóveis existente";

        public string ToolTipExcluir => "Excluir um Grupo de Automóveis existente";

        public string ToolTipFiltrar => "Indisponivel";

        public string ToolTipAgrupar => "Agrupar um Grupo de Automóveis existente";

        public string ToolTipDesagrupar => "Desagrupar um Grupo de Automóveis existente";

        public bool BarraPesquisa => false;

        public bool BotaoAdicionar => true;

        public bool BotaoDevolucao => false;

        public bool BotaoEditar => true;

        public bool BotaoExcluir => true;

        public bool BotaoFiltrar => false;

        public bool BotaoAgrupar => true;

        public bool BotaoDesagrupar => true;
    }
}
