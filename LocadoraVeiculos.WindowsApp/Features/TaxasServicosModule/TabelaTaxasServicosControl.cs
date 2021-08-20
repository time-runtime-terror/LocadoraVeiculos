﻿using LocadoraVeiculos.Controladores.TaxasServicosModule;
using LocadoraVeiculos.Dominio.TaxasServicosModule;
using LocadoraVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.TaxasServicosModule
{
    public partial class TabelaTaxasServicosControl : UserControl
    {
        private readonly ControladorTaxasServicos controladorTaxasServicos;
        private Subro.Controls.DataGridViewGrouper gridGrupoAutomoveisAgrupados;

        public TabelaTaxasServicosControl(ControladorTaxasServicos controladorTaxasServicos)
        {
            InitializeComponent();
            gridTaxasServicos.ConfigurarGridZebrado();
            gridTaxasServicos.ConfigurarGridSomenteLeitura();
            gridTaxasServicos.Columns.AddRange(ObterColunas());

            this.controladorTaxasServicos = controladorTaxasServicos;
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "servico", HeaderText = "Serviço"},

                new DataGridViewTextBoxColumn { DataPropertyName = "taxa", HeaderText = "Taxa"},

                new DataGridViewTextBoxColumn { DataPropertyName = "opcaoServico", HeaderText = "Plano"},

            };

            return colunas;
        }

        public void AtualizarRegistros()
        {
            List<TaxasServicos> taxasServicos = controladorTaxasServicos.SelecionarTodos();

            CarregarTabela(taxasServicos);
        }

        private void CarregarTabela(List<TaxasServicos> taxasServicos)
        {
            gridTaxasServicos.DataSource = taxasServicos;
        }

        public int ObtemIdSelecionado()
        {
            return gridTaxasServicos.SelecionarId<int>();
        }
    }
}