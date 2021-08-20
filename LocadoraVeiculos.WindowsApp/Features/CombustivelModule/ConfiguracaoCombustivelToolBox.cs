using LocadoraVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WindowsApp.Features.CombustivelModule
{
    public class ConfiguracaoCombustivelToolBox : IConfiguracaoToolBox
    {
        public string TipoCadastro {
            get { return "Configuração de Combustível"; }
        }

        public string ToolTipAdicionar
        {
            get { return ""; }
        }

        public string ToolTipEditar
        {
            get { return ""; }
        }

        public string ToolTipExcluir
        {
            get { return ""; }
        }

        public string ToolTipFiltrar
        {
            get { return ""; }
        }

        public string ToolTipAgrupar
        {
            get { return ""; }
        }

        public string ToolTipDesagrupar
        {
            get { return ""; }
        }

        public bool BarraPesquisa => false;

        public bool BotaoAdicionar
        {
            get { return false; }
        }

        public bool BotaoCadastro
        {
            get { return false; }
        }

        public bool BotaoEditar
        {
            get { return false; }
        }

        public bool BotaoExcluir
        {
            get { return false; }
        }

        public bool BotaoFiltrar
        {
            get { return false; }
        }

        public bool BotaoAgrupar
        {
            get { return false; }
        }

        public bool BotaoDesagrupar
        {
            get { return false; }
        }
    }
}
