
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaRegistrarDevolucaoForm));
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
            this.btnCalcularTotal = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txbQuilometragemAtual = new System.Windows.Forms.NumericUpDown();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.rdbCheio = new System.Windows.Forms.RadioButton();
            this.rdbTresQuartos = new System.Windows.Forms.RadioButton();
            this.rdbMeio = new System.Windows.Forms.RadioButton();
            this.rdbUmQuarto = new System.Windows.Forms.RadioButton();
            this.rdbVazio = new System.Windows.Forms.RadioButton();
            this.pnlMedidasTanque = new System.Windows.Forms.Panel();
            this.btHabilitarMedidas = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbQuilometragemAtual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlMedidasTanque.SuspendLayout();
            this.SuspendLayout();
            // 
            // listaTaxasServicos
            // 
            this.listaTaxasServicos.Enabled = false;
            this.listaTaxasServicos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaTaxasServicos.FormattingEnabled = true;
            this.listaTaxasServicos.ItemHeight = 16;
            this.listaTaxasServicos.Location = new System.Drawing.Point(199, 449);
            this.listaTaxasServicos.Name = "listaTaxasServicos";
            this.listaTaxasServicos.Size = new System.Drawing.Size(273, 68);
            this.listaTaxasServicos.TabIndex = 2;
            // 
            // btnSelecionarTaxas
            // 
            this.btnSelecionarTaxas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionarTaxas.Location = new System.Drawing.Point(267, 523);
            this.btnSelecionarTaxas.Name = "btnSelecionarTaxas";
            this.btnSelecionarTaxas.Size = new System.Drawing.Size(139, 31);
            this.btnSelecionarTaxas.TabIndex = 3;
            this.btnSelecionarTaxas.Text = "Selecionar Taxas";
            this.btnSelecionarTaxas.UseVisualStyleBackColor = true;
            this.btnSelecionarTaxas.Click += new System.EventHandler(this.btnSelecionarTaxas_Click);
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotal.Location = new System.Drawing.Point(233, 554);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(18, 19);
            this.lblValorTotal.TabIndex = 42;
            this.lblValorTotal.Text = "0";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(160, 554);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(71, 19);
            this.lblTotal.TabIndex = 41;
            this.lblTotal.Text = "Total: R$";
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Enabled = false;
            this.btnGravar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGravar.Location = new System.Drawing.Point(353, 576);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(83, 31);
            this.btnGravar.TabIndex = 5;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // lblDataDevolucao
            // 
            this.lblDataDevolucao.AutoSize = true;
            this.lblDataDevolucao.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataDevolucao.Location = new System.Drawing.Point(196, 214);
            this.lblDataDevolucao.Name = "lblDataDevolucao";
            this.lblDataDevolucao.Size = new System.Drawing.Size(136, 17);
            this.lblDataDevolucao.TabIndex = 38;
            this.lblDataDevolucao.Text = "Data de Devolução:";
            // 
            // dateDataDevolucao
            // 
            this.dateDataDevolucao.Enabled = false;
            this.dateDataDevolucao.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDataDevolucao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDataDevolucao.Location = new System.Drawing.Point(351, 208);
            this.dateDataDevolucao.MinDate = new System.DateTime(2021, 8, 26, 0, 0, 0, 0);
            this.dateDataDevolucao.Name = "dateDataDevolucao";
            this.dateDataDevolucao.Size = new System.Drawing.Size(121, 25);
            this.dateDataDevolucao.TabIndex = 1;
            // 
            // lblValorEntrada
            // 
            this.lblValorEntrada.AutoSize = true;
            this.lblValorEntrada.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorEntrada.Location = new System.Drawing.Point(213, 183);
            this.lblValorEntrada.Name = "lblValorEntrada";
            this.lblValorEntrada.Size = new System.Drawing.Size(119, 17);
            this.lblValorEntrada.TabIndex = 34;
            this.lblValorEntrada.Text = "Valor de Entrada:";
            // 
            // lblPlano
            // 
            this.lblPlano.AutoSize = true;
            this.lblPlano.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlano.Location = new System.Drawing.Point(290, 152);
            this.lblPlano.Name = "lblPlano";
            this.lblPlano.Size = new System.Drawing.Size(49, 17);
            this.lblPlano.TabIndex = 32;
            this.lblPlano.Text = "Plano:";
            // 
            // lblVeiculo
            // 
            this.lblVeiculo.AutoSize = true;
            this.lblVeiculo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVeiculo.Location = new System.Drawing.Point(280, 121);
            this.lblVeiculo.Name = "lblVeiculo";
            this.lblVeiculo.Size = new System.Drawing.Size(58, 17);
            this.lblVeiculo.TabIndex = 30;
            this.lblVeiculo.Text = "Veículo:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(281, 90);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(57, 17);
            this.lblCliente.TabIndex = 28;
            this.lblCliente.Text = "Cliente:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(442, 576);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 31);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtIdLocacao
            // 
            this.txtIdLocacao.Enabled = false;
            this.txtIdLocacao.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdLocacao.Location = new System.Drawing.Point(347, 54);
            this.txtIdLocacao.Name = "txtIdLocacao";
            this.txtIdLocacao.Size = new System.Drawing.Size(96, 25);
            this.txtIdLocacao.TabIndex = 47;
            // 
            // lblIdLocacao
            // 
            this.lblIdLocacao.AutoSize = true;
            this.lblIdLocacao.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdLocacao.Location = new System.Drawing.Point(317, 62);
            this.lblIdLocacao.Name = "lblIdLocacao";
            this.lblIdLocacao.Size = new System.Drawing.Size(23, 17);
            this.lblIdLocacao.TabIndex = 46;
            this.lblIdLocacao.Text = "Id:";
            // 
            // lblNomePlano
            // 
            this.lblNomePlano.AutoSize = true;
            this.lblNomePlano.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomePlano.Location = new System.Drawing.Point(348, 149);
            this.lblNomePlano.Name = "lblNomePlano";
            this.lblNomePlano.Size = new System.Drawing.Size(43, 17);
            this.lblNomePlano.TabIndex = 50;
            this.lblNomePlano.Text = "plano";
            // 
            // lblModeloVeiculo
            // 
            this.lblModeloVeiculo.AutoSize = true;
            this.lblModeloVeiculo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModeloVeiculo.Location = new System.Drawing.Point(348, 118);
            this.lblModeloVeiculo.Name = "lblModeloVeiculo";
            this.lblModeloVeiculo.Size = new System.Drawing.Size(102, 17);
            this.lblModeloVeiculo.TabIndex = 49;
            this.lblModeloVeiculo.Text = "modeloVeiculo";
            // 
            // lblNomeCliente
            // 
            this.lblNomeCliente.AutoSize = true;
            this.lblNomeCliente.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeCliente.Location = new System.Drawing.Point(348, 89);
            this.lblNomeCliente.Name = "lblNomeCliente";
            this.lblNomeCliente.Size = new System.Drawing.Size(90, 17);
            this.lblNomeCliente.TabIndex = 48;
            this.lblNomeCliente.Text = "nomeCliente";
            // 
            // lblEntrada
            // 
            this.lblEntrada.AutoSize = true;
            this.lblEntrada.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntrada.Location = new System.Drawing.Point(348, 182);
            this.lblEntrada.Name = "lblEntrada";
            this.lblEntrada.Size = new System.Drawing.Size(90, 17);
            this.lblEntrada.TabIndex = 51;
            this.lblEntrada.Text = "valorEntrada";
            // 
            // btnCalcularTotal
            // 
            this.btnCalcularTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcularTotal.Location = new System.Drawing.Point(163, 576);
            this.btnCalcularTotal.Name = "btnCalcularTotal";
            this.btnCalcularTotal.Size = new System.Drawing.Size(139, 31);
            this.btnCalcularTotal.TabIndex = 4;
            this.btnCalcularTotal.Text = "Calcular Total";
            this.btnCalcularTotal.UseVisualStyleBackColor = true;
            this.btnCalcularTotal.Click += new System.EventHandler(this.btnCalcularTotal_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(552, 48);
            this.panel2.TabIndex = 53;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LocadoraVeiculos.WindowsApp.Properties.Resources.sedan;
            this.pictureBox1.Location = new System.Drawing.Point(13, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(91)))), ((int)(((byte)(235)))));
            this.label3.Location = new System.Drawing.Point(87, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(267, 34);
            this.label3.TabIndex = 6;
            this.label3.Text = "LOCADORA RECH";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Location = new System.Drawing.Point(353, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "O carro certo para você!";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(98, 561);
            this.panel3.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(149, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 17);
            this.label1.TabIndex = 55;
            this.label1.Text = "Quilometragem do veículo:";
            // 
            // txbQuilometragemAtual
            // 
            this.txbQuilometragemAtual.AllowDrop = true;
            this.txbQuilometragemAtual.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbQuilometragemAtual.Location = new System.Drawing.Point(351, 250);
            this.txbQuilometragemAtual.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txbQuilometragemAtual.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.txbQuilometragemAtual.Name = "txbQuilometragemAtual";
            this.txbQuilometragemAtual.ReadOnly = true;
            this.txbQuilometragemAtual.Size = new System.Drawing.Size(124, 25);
            this.txbQuilometragemAtual.TabIndex = 57;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(224, 285);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(99, 159);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 58;
            this.pictureBox2.TabStop = false;
            // 
            // rdbCheio
            // 
            this.rdbCheio.AutoSize = true;
            this.rdbCheio.Font = new System.Drawing.Font("Arial", 12F);
            this.rdbCheio.Location = new System.Drawing.Point(8, 9);
            this.rdbCheio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbCheio.Name = "rdbCheio";
            this.rdbCheio.Size = new System.Drawing.Size(68, 22);
            this.rdbCheio.TabIndex = 59;
            this.rdbCheio.TabStop = true;
            this.rdbCheio.Text = "Cheio";
            this.rdbCheio.UseVisualStyleBackColor = true;
            // 
            // rdbTresQuartos
            // 
            this.rdbTresQuartos.AutoSize = true;
            this.rdbTresQuartos.Font = new System.Drawing.Font("Arial", 12F);
            this.rdbTresQuartos.Location = new System.Drawing.Point(8, 35);
            this.rdbTresQuartos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbTresQuartos.Name = "rdbTresQuartos";
            this.rdbTresQuartos.Size = new System.Drawing.Size(48, 22);
            this.rdbTresQuartos.TabIndex = 60;
            this.rdbTresQuartos.TabStop = true;
            this.rdbTresQuartos.Text = "3/4";
            this.rdbTresQuartos.UseVisualStyleBackColor = true;
            // 
            // rdbMeio
            // 
            this.rdbMeio.AutoSize = true;
            this.rdbMeio.Font = new System.Drawing.Font("Arial", 12F);
            this.rdbMeio.Location = new System.Drawing.Point(7, 61);
            this.rdbMeio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbMeio.Name = "rdbMeio";
            this.rdbMeio.Size = new System.Drawing.Size(61, 22);
            this.rdbMeio.TabIndex = 61;
            this.rdbMeio.TabStop = true;
            this.rdbMeio.Text = "Meio";
            this.rdbMeio.UseVisualStyleBackColor = true;
            // 
            // rdbUmQuarto
            // 
            this.rdbUmQuarto.AutoSize = true;
            this.rdbUmQuarto.Font = new System.Drawing.Font("Arial", 12F);
            this.rdbUmQuarto.Location = new System.Drawing.Point(7, 87);
            this.rdbUmQuarto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbUmQuarto.Name = "rdbUmQuarto";
            this.rdbUmQuarto.Size = new System.Drawing.Size(48, 22);
            this.rdbUmQuarto.TabIndex = 62;
            this.rdbUmQuarto.TabStop = true;
            this.rdbUmQuarto.Text = "1/4";
            this.rdbUmQuarto.UseVisualStyleBackColor = true;
            // 
            // rdbVazio
            // 
            this.rdbVazio.AutoSize = true;
            this.rdbVazio.Font = new System.Drawing.Font("Arial", 12F);
            this.rdbVazio.Location = new System.Drawing.Point(8, 113);
            this.rdbVazio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbVazio.Name = "rdbVazio";
            this.rdbVazio.Size = new System.Drawing.Size(65, 22);
            this.rdbVazio.TabIndex = 63;
            this.rdbVazio.TabStop = true;
            this.rdbVazio.Text = "Vazio";
            this.rdbVazio.UseVisualStyleBackColor = true;
            // 
            // pnlMedidasTanque
            // 
            this.pnlMedidasTanque.Controls.Add(this.rdbCheio);
            this.pnlMedidasTanque.Controls.Add(this.rdbTresQuartos);
            this.pnlMedidasTanque.Controls.Add(this.rdbVazio);
            this.pnlMedidasTanque.Controls.Add(this.rdbMeio);
            this.pnlMedidasTanque.Controls.Add(this.rdbUmQuarto);
            this.pnlMedidasTanque.Location = new System.Drawing.Point(346, 285);
            this.pnlMedidasTanque.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlMedidasTanque.Name = "pnlMedidasTanque";
            this.pnlMedidasTanque.Size = new System.Drawing.Size(88, 144);
            this.pnlMedidasTanque.TabIndex = 65;
            // 
            // btHabilitarMedidas
            // 
            this.btHabilitarMedidas.Enabled = false;
            this.btHabilitarMedidas.FlatAppearance.BorderSize = 0;
            this.btHabilitarMedidas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btHabilitarMedidas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHabilitarMedidas.Image = ((System.Drawing.Image)(resources.GetObject("btHabilitarMedidas.Image")));
            this.btHabilitarMedidas.Location = new System.Drawing.Point(442, 324);
            this.btHabilitarMedidas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btHabilitarMedidas.Name = "btHabilitarMedidas";
            this.btHabilitarMedidas.Size = new System.Drawing.Size(44, 44);
            this.btHabilitarMedidas.TabIndex = 66;
            this.btHabilitarMedidas.UseVisualStyleBackColor = true;
            this.btHabilitarMedidas.Click += new System.EventHandler(this.btHabilitarMedidas_Click);
            // 
            // TelaRegistrarDevolucaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(552, 609);
            this.Controls.Add(this.btHabilitarMedidas);
            this.Controls.Add(this.pnlMedidasTanque);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txbQuilometragemAtual);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnCalcularTotal);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaRegistrarDevolucaoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Devolução";
            this.Load += new System.EventHandler(this.TelaRegistrarDevolucaoForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbQuilometragemAtual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlMedidasTanque.ResumeLayout(false);
            this.pnlMedidasTanque.PerformLayout();
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
        private System.Windows.Forms.Button btnCalcularTotal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txbQuilometragemAtual;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RadioButton rdbCheio;
        private System.Windows.Forms.RadioButton rdbTresQuartos;
        private System.Windows.Forms.RadioButton rdbMeio;
        private System.Windows.Forms.RadioButton rdbUmQuarto;
        private System.Windows.Forms.RadioButton rdbVazio;
        private System.Windows.Forms.Panel pnlMedidasTanque;
        private System.Windows.Forms.Button btHabilitarMedidas;
    }
}