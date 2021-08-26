using LocadoraVeiculos.WindowsApp.Shared;
using System;

namespace LocadoraVeiculos.WindowsApp.Features.DevolucaoModule
{
    public class ConfiguracoesDevolucaoToolBox : IConfiguracaoToolBox
    {
        public string ToolTipAdicionar => "Registrar uma nova devolução";

        public string TipoCadastro => "Cadastro de Devoluções";

        public string ToolTipEditar => "Editar uma devolução";

        public string ToolTipExcluir => "Excluir uma devolução";

        public string ToolTipFiltrar => throw new NotImplementedException();

        public string ToolTipAgrupar => throw new NotImplementedException();

        public string ToolTipDesagrupar => throw new NotImplementedException();

        public bool BarraPesquisa => false;

        public bool BotaoAdicionar => true;

        public bool BotaoDevolucao => true;

        public bool BotaoEditar => false;

        public bool BotaoExcluir => true;

        public bool BotaoFiltrar => false;

        public bool BotaoAgrupar => false;

        public bool BotaoDesagrupar => false;
    }
}
