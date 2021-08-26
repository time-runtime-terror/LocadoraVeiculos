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
            get { return "Indisponivel"; }
        }

        public string ToolTipEditar
        {
            get { return "Indisponivel"; }
        }

        public string ToolTipExcluir
        {
            get { return "Indisponivel"; }
        }

        public string ToolTipFiltrar
        {
            get { return "Indisponivel"; }
        }

        public string ToolTipAgrupar
        {
            get { return "Indisponivel"; }
        }

        public string ToolTipDesagrupar
        {
            get { return "Indisponivel"; }
        }

        public bool BarraPesquisa => false;

        public bool BotaoAdicionar
        {
            get { return false; }
        }

        public bool BotaoDevolucao
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
