
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
            this.lblCondutor = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.cmbCondutor = new System.Windows.Forms.ComboBox();
            this.btnGravar = new System.Windows.Forms.Button();
            this.lblDataDevolucao = new System.Windows.Forms.Label();
            this.dateDataDevolucao = new System.Windows.Forms.DateTimePicker();
            this.lblValorEntrada = new System.Windows.Forms.Label();
            this.cmbPlano = new System.Windows.Forms.ComboBox();
            this.lblPlano = new System.Windows.Forms.Label();
            this.cmbVeiculo = new System.Windows.Forms.ComboBox();
            this.lblVeiculo = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtValorEntrada = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtIdLocacao = new System.Windows.Forms.TextBox();
            this.lblIdLocacao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listaTaxasServicos
            // 
            this.listaTaxasServicos.Enabled = false;
            this.listaTaxasServicos.FormattingEnabled = true;
            this.listaTaxasServicos.Location = new System.Drawing.Point(71, 318);
            this.listaTaxasServicos.Name = "listaTaxasServicos";
            this.listaTaxasServicos.Size = new System.Drawing.Size(282, 121);
            this.listaTaxasServicos.TabIndex = 45;
            // 
            // btnSelecionarTaxas
            // 
            this.btnSelecionarTaxas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionarTaxas.Location = new System.Drawing.Point(71, 446);
            this.btnSelecionarTaxas.Name = "btnSelecionarTaxas";
            this.btnSelecionarTaxas.Size = new System.Drawing.Size(139, 31);
            this.btnSelecionarTaxas.TabIndex = 44;
            this.btnSelecionarTaxas.Text = "Selecionar Taxas";
            this.btnSelecionarTaxas.UseVisualStyleBackColor = true;
            // 
            // lblCondutor
            // 
            this.lblCondutor.AutoSize = true;
            this.lblCondutor.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCondutor.Location = new System.Drawing.Point(105, 117);
            this.lblCondutor.Name = "lblCondutor";
            this.lblCondutor.Size = new System.Drawing.Size(76, 18);
            this.lblCondutor.TabIndex = 43;
            this.lblCondutor.Text = "Condutor:";
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotal.Location = new System.Drawing.Point(336, 452);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(17, 18);
            this.lblValorTotal.TabIndex = 42;
            this.lblValorTotal.Text = "0";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(262, 452);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(68, 18);
            this.lblTotal.TabIndex = 41;
            this.lblTotal.Text = "Total: R$";
            // 
            // cmbCondutor
            // 
            this.cmbCondutor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCondutor.Enabled = false;
            this.cmbCondutor.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCondutor.FormattingEnabled = true;
            this.cmbCondutor.Location = new System.Drawing.Point(186, 114);
            this.cmbCondutor.Name = "cmbCondutor";
            this.cmbCondutor.Size = new System.Drawing.Size(167, 26);
            this.cmbCondutor.TabIndex = 40;
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
            // 
            // lblDataDevolucao
            // 
            this.lblDataDevolucao.AutoSize = true;
            this.lblDataDevolucao.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataDevolucao.Location = new System.Drawing.Point(35, 245);
            this.lblDataDevolucao.Name = "lblDataDevolucao";
            this.lblDataDevolucao.Size = new System.Drawing.Size(146, 18);
            this.lblDataDevolucao.TabIndex = 38;
            this.lblDataDevolucao.Text = "Data de Devolução:";
            // 
            // dateDataDevolucao
            // 
            this.dateDataDevolucao.Enabled = false;
            this.dateDataDevolucao.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDataDevolucao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDataDevolucao.Location = new System.Drawing.Point(186, 241);
            this.dateDataDevolucao.MinDate = new System.DateTime(2021, 8, 26, 0, 0, 0, 0);
            this.dateDataDevolucao.Name = "dateDataDevolucao";
            this.dateDataDevolucao.Size = new System.Drawing.Size(121, 26);
            this.dateDataDevolucao.TabIndex = 37;
            // 
            // lblValorEntrada
            // 
            this.lblValorEntrada.AutoSize = true;
            this.lblValorEntrada.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorEntrada.Location = new System.Drawing.Point(52, 213);
            this.lblValorEntrada.Name = "lblValorEntrada";
            this.lblValorEntrada.Size = new System.Drawing.Size(129, 18);
            this.lblValorEntrada.TabIndex = 34;
            this.lblValorEntrada.Text = "Valor de Entrada:";
            // 
            // cmbPlano
            // 
            this.cmbPlano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlano.Enabled = false;
            this.cmbPlano.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlano.FormattingEnabled = true;
            this.cmbPlano.Items.AddRange(new object[] {
            "Plano Diário",
            "Km Controlado",
            "Km Livre"});
            this.cmbPlano.Location = new System.Drawing.Point(186, 178);
            this.cmbPlano.Name = "cmbPlano";
            this.cmbPlano.Size = new System.Drawing.Size(167, 26);
            this.cmbPlano.TabIndex = 33;
            // 
            // lblPlano
            // 
            this.lblPlano.AutoSize = true;
            this.lblPlano.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlano.Location = new System.Drawing.Point(129, 181);
            this.lblPlano.Name = "lblPlano";
            this.lblPlano.Size = new System.Drawing.Size(52, 18);
            this.lblPlano.TabIndex = 32;
            this.lblPlano.Text = "Plano:";
            // 
            // cmbVeiculo
            // 
            this.cmbVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVeiculo.Enabled = false;
            this.cmbVeiculo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVeiculo.FormattingEnabled = true;
            this.cmbVeiculo.Location = new System.Drawing.Point(186, 146);
            this.cmbVeiculo.Name = "cmbVeiculo";
            this.cmbVeiculo.Size = new System.Drawing.Size(167, 26);
            this.cmbVeiculo.TabIndex = 31;
            // 
            // lblVeiculo
            // 
            this.lblVeiculo.AutoSize = true;
            this.lblVeiculo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVeiculo.Location = new System.Drawing.Point(119, 149);
            this.lblVeiculo.Name = "lblVeiculo";
            this.lblVeiculo.Size = new System.Drawing.Size(62, 18);
            this.lblVeiculo.TabIndex = 30;
            this.lblVeiculo.Text = "Veículo:";
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.Enabled = false;
            this.cmbCliente.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(186, 82);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(167, 26);
            this.cmbCliente.TabIndex = 29;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.cmbCliente_SelectedIndexChanged);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(120, 85);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(61, 18);
            this.lblCliente.TabIndex = 28;
            this.lblCliente.Text = "Cliente:";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(186, 21);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(96, 26);
            this.txtId.TabIndex = 27;
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
            // txtValorEntrada
            // 
            this.txtValorEntrada.Enabled = false;
            this.txtValorEntrada.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorEntrada.Location = new System.Drawing.Point(186, 210);
            this.txtValorEntrada.Name = "txtValorEntrada";
            this.txtValorEntrada.Size = new System.Drawing.Size(100, 26);
            this.txtValorEntrada.TabIndex = 25;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(157, 24);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(24, 18);
            this.lblId.TabIndex = 24;
            this.lblId.Text = "Id:";
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
            this.lblIdLocacao.Location = new System.Drawing.Point(70, 53);
            this.lblIdLocacao.Name = "lblIdLocacao";
            this.lblIdLocacao.Size = new System.Drawing.Size(111, 18);
            this.lblIdLocacao.TabIndex = 46;
            this.lblIdLocacao.Text = "Id da Locação:";
            // 
            // TelaRegistrarDevolucaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 548);
            this.Controls.Add(this.txtIdLocacao);
            this.Controls.Add(this.lblIdLocacao);
            this.Controls.Add(this.listaTaxasServicos);
            this.Controls.Add(this.btnSelecionarTaxas);
            this.Controls.Add(this.lblCondutor);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.cmbCondutor);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.lblDataDevolucao);
            this.Controls.Add(this.dateDataDevolucao);
            this.Controls.Add(this.lblValorEntrada);
            this.Controls.Add(this.cmbPlano);
            this.Controls.Add(this.lblPlano);
            this.Controls.Add(this.cmbVeiculo);
            this.Controls.Add(this.lblVeiculo);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtValorEntrada);
            this.Controls.Add(this.lblId);
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
        private System.Windows.Forms.Label lblCondutor;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ComboBox cmbCondutor;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Label lblDataDevolucao;
        private System.Windows.Forms.DateTimePicker dateDataDevolucao;
        private System.Windows.Forms.Label lblValorEntrada;
        private System.Windows.Forms.ComboBox cmbPlano;
        private System.Windows.Forms.Label lblPlano;
        private System.Windows.Forms.ComboBox cmbVeiculo;
        private System.Windows.Forms.Label lblVeiculo;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtValorEntrada;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtIdLocacao;
        private System.Windows.Forms.Label lblIdLocacao;
    }
}