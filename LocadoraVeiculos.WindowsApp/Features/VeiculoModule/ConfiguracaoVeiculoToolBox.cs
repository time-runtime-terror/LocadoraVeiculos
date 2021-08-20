using LocadoraVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WindowsApp.Features.VeiculoModule
{
    class ConfiguracaoVeiculoToolBox : IConfiguracaoToolBox
    {
        public string TipoCadastro
        {
            get { return "Cadastro de Veiculos"; }
        }

        public string ToolTipAdicionar
        {
            get { return "Adicionar um novo Veiculo"; }
        }

        public string ToolTipEditar
        {
            get { return "Editar um Veiculo existente"; }
        }

        public string ToolTipExcluir
        {
            get { return "Excluir um Veiculo existente"; }
        }

        public string ToolTipFiltrar => "";

        public string ToolTipAgrupar => "Agrupar Veiculos";

        public string ToolTipDesagrupar => "Desagrupar Veiculos";

        public bool BarraPesquisa => true;

        public bool BotaoAdicionar => true;

        public bool BotaoCadastro => true;

        public bool BotaoEditar => true;

        public bool BotaoExcluir => true;

        public bool BotaoFiltrar => false;

        public bool BotaoAgrupar => true;

        public bool BotaoDesagrupar => true;

        public string ObterDescricao()
        {
            return TipoCadastro;
        }

        public ConfiguracaoEstadoBotoes ObterEstadoBotoes()
        {
            return new ConfiguracaoEstadoBotoes()
            {
                Agrupar = false,
                Desagrupar = false,
                Filtrar = true
            };
        }

        public ConfiguracaoToolTips ObterToolTips()
        {
            return new ConfiguracaoToolTips()
            {
                Adicionar = "Adicionar um novo veiculo",
                Editar = "Atualizar um veiculo",
                Excluir = "Excluir um veiculo",
                Filtrar = "Filtrar veiculo"
            };
        }
    }
}
