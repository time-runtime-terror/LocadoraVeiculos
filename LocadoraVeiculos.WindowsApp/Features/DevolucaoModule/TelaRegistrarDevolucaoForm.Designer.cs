
namespace LocadoraVeiculos.WindowsApp.Features.DevolucaoModule
{
    partial class TelaRegistrarDevolucaoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listaTaxasServicos = new System.Windows.Forms.ListBox();
            this.btnSelecionarTaxas = new System.Windows.Forms.Button();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnGravar = new System.Windows.Forms.Button();
            this.lblDataDevolucao = new System.Windows.Forms.Label();
            this.dateDataDevolucao = new System.Windows.Forms.DateTimePicker();
            this.lblValorEntrada = new System.Windows.Forms.Label();
            this.lblPlano = new System.Windows.Forms.Label();
            this.lblVeiculo = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtIdLocacao = new System.Windows.Forms.TextBox();
            this.lblIdLocacao = new System.Windows.Forms.Label();
            this.lblNomePlano = new System.Windows.Forms.Label();
            this.lblModeloVeiculo = new System.Windows.Forms.Label();
            this.lblNomeCliente = new System.Windows.Forms.Label();
            this.lblEntrada = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listaTaxasServicos
            // 
            this.listaTaxasServicos.Enabled = false;
            this.listaTaxasServicos.FormattingEnabled = true;
            this.listaTaxasServicos.Location = new System.Drawing.Point(73, 269);
            this.listaTaxasServicos.Name = "listaTaxasServicos";
            this.listaTaxasServicos.Size = new System.Drawing.Size(282, 121);
            this.listaTaxasServicos.TabIndex = 45;
            // 
            // btnSelecionarTaxas
            // 
            this.btnSelecionarTaxas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionarTaxas.Location = new System.Drawing.Point(73, 397);
            this.btnSelecionarTaxas.Name = "btnSelecionarTaxas";
            this.btnSelecionarTaxas.Size = new System.Drawing.Size(139, 31);
            this.btnSelecionarTaxas.TabIndex = 44;
            this.btnSelecionarTaxas.Text = "Selecionar Taxas";
            this.btnSelecionarTaxas.UseVisualStyleBackColor = true;
            this.btnSelecionarTaxas.Click += new System.EventHandler(this.btnSelecionarTaxas_Click);
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotal.Location = new System.Drawing.Point(338, 403);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(17, 18);
            this.lblValorTotal.TabIndex = 42;
            this.lblValorTotal.Text = "0";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(264, 403);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(68, 18);
            this.lblTotal.TabIndex = 41;
            this.lblTotal.Text = "Total: R$";
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGravar.Location = new System.Drawing.Point(238, 505);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(83, 31);
            this.btnGravar.TabIndex = 39;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // lblDataDevolucao
            // 
            this.lblDataDevolucao.AutoSize = true;
            this.lblDataDevolucao.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataDevolucao.Location = new System.Drawing.Point(35, 210);
            this.lblDataDevolucao.Name = "lblDataDevolucao";
            this.lblDataDevolucao.Size = new System.Drawing.Size(146, 18);
            this.lblDataDevolucao.TabIndex = 38;
            this.lblDataDevolucao.Text = "Data de Devolução:";
            // 
            // dateDataDevolucao
            // 
            this.dateDataDevolucao.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDataDevolucao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDataDevolucao.Location = new System.Drawing.Point(190, 204);
            this.dateDataDevolucao.MinDate = new System.DateTime(2021, 8, 26, 0, 0, 0, 0);
            this.dateDataDevolucao.Name = "dateDataDevolucao";
            this.dateDataDevolucao.Size = new System.Drawing.Size(121, 26);
            this.dateDataDevolucao.TabIndex = 37;
            // 
            // lblValorEntrada
            // 
            this.lblValorEntrada.AutoSize = true;
            this.lblValorEntrada.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorEntrada.Location = new System.Drawing.Point(52, 179);
            this.lblValorEntrada.Name = "lblValorEntrada";
            this.lblValorEntrada.Size = new System.Drawing.Size(129, 18);
            this.lblValorEntrada.TabIndex = 34;
            this.lblValorEntrada.Text = "Valor de Entrada:";
            // 
            // lblPlano
            // 
            this.lblPlano.AutoSize = true;
            this.lblPlano.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlano.Location = new System.Drawing.Point(129, 148);
            this.lblPlano.Name = "lblPlano";
            this.lblPlano.Size = new System.Drawing.Size(52, 18);
            this.lblPlano.TabIndex = 32;
            this.lblPlano.Text = "Plano:";
            // 
            // lblVeiculo
            // 
            this.lblVeiculo.AutoSize = true;
            this.lblVeiculo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVeiculo.Location = new System.Drawing.Point(119, 117);
            this.lblVeiculo.Name = "lblVeiculo";
            this.lblVeiculo.Size = new System.Drawing.Size(62, 18);
            this.lblVeiculo.TabIndex = 30;
            this.lblVeiculo.Text = "Veículo:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(120, 86);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(61, 18);
            this.lblCliente.TabIndex = 28;
            this.lblCliente.Text = "Cliente:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(327, 505);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 31);
            this.btnCancelar.TabIndex = 26;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtIdLocacao
            // 
            this.txtIdLocacao.Enabled = false;
            this.txtIdLocacao.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdLocacao.Location = new System.Drawing.Point(186, 50);
            this.txtIdLocacao.Name = "txtIdLocacao";
            this.txtIdLocacao.Size = new System.Drawing.Size(96, 26);
            this.txtIdLocacao.TabIndex = 47;
            // 
            // lblIdLocacao
            // 
            this.lblIdLocacao.AutoSize = true;
            this.lblIdLocacao.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdLocacao.Location = new System.Drawing.Point(70, 55);
            this.lblIdLocacao.Name = "lblIdLocacao";
            this.lblIdLocacao.Size = new System.Drawing.Size(111, 18);
            this.lblIdLocacao.TabIndex = 46;
            this.lblIdLocacao.Text = "Id da Locação:";
            // 
            // lblNomePlano
            // 
            this.lblNomePlano.AutoSize = true;
            this.lblNomePlano.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomePlano.Location = new System.Drawing.Point(187, 145);
            this.lblNomePlano.Name = "lblNomePlano";
            this.lblNomePlano.Size = new System.Drawing.Size(46, 18);
            this.lblNomePlano.TabIndex = 50;
            this.lblNomePlano.Text = "plano";
            // 
            // lblModeloVeiculo
            // 
            this.lblModeloVeiculo.AutoSize = true;
            this.lblModeloVeiculo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModeloVeiculo.Location = new System.Drawing.Point(187, 114);
            this.lblModeloVeiculo.Name = "lblModeloVeiculo";
            this.lblModeloVeiculo.Size = new System.Drawing.Size(111, 18);
            this.lblModeloVeiculo.TabIndex = 49;
            this.lblModeloVeiculo.Text = "modeloVeiculo";
            // 
            // lblNomeCliente
            // 
            this.lblNomeCliente.AutoSize = true;
            this.lblNomeCliente.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeCliente.Location = new System.Drawing.Point(187, 85);
            this.lblNomeCliente.Name = "lblNomeCliente";
            this.lblNomeCliente.Size = new System.Drawing.Size(96, 18);
            this.lblNomeCliente.TabIndex = 48;
            this.lblNomeCliente.Text = "nomeCliente";
            // 
            // lblEntrada
            // 
            this.lblEntrada.AutoSize = true;
            this.lblEntrada.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntrada.Location = new System.Drawing.Point(187, 178);
            this.lblEntrada.Name = "lblEntrada";
            this.lblEntrada.Size = new System.Drawing.Size(96, 18);
            this.lblEntrada.TabIndex = 51;
            this.lblEntrada.Text = "valorEntrada";
            // 
            // TelaRegistrarDevolucaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 548);
            this.Controls.Add(this.lblEntrada);
            this.Controls.Add(this.lblNomePlano);
            this.Controls.Add(this.lblModeloVeiculo);
            this.Controls.Add(this.lblNomeCliente);
            this.Controls.Add(this.txtIdLocacao);
            this.Controls.Add(this.lblIdLocacao);
            this.Controls.Add(this.listaTaxasServicos);
            this.Controls.Add(this.btnSelecionarTaxas);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.lblDataDevolucao);
            this.Controls.Add(this.dateDataDevolucao);
            this.Controls.Add(this.lblValorEntrada);
            this.Controls.Add(this.lblPlano);
            this.Controls.Add(this.lblVeiculo);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaRegistrarDevolucaoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Devolução";
            this.Load += new System.EventHandler(this.TelaRegistrarDevolucaoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listaTaxasServicos;
        private System.Windows.Forms.Button btnSelecionarTaxas;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Label lblDataDevolucao;
        private System.Windows.Forms.DateTimePicker dateDataDevolucao;
        private System.Windows.Forms.Label lblValorEntrada;
        private System.Windows.Forms.Label lblPlano;
        private System.Windows.Forms.Label lblVeiculo;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtIdLocacao;
        private System.Windows.Forms.Label lblIdLocacao;
        private System.Windows.Forms.Label lblNomePlano;
        private System.Windows.Forms.Label lblModeloVeiculo;
        private System.Windows.Forms.Label lblNomeCliente;
        private System.Windows.Forms.Label lblEntrada;
    }
}