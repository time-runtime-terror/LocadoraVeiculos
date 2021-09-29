
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
            this.listaTaxasServicos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listaTaxasServicos.FormattingEnabled = true;
            this.listaTaxasServicos.ItemHeight = 16;
            this.listaTaxasServicos.Location = new System.Drawing.Point(225, 465);
            this.listaTaxasServicos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listaTaxasServicos.Name = "listaTaxasServicos";
            this.listaTaxasServicos.Size = new System.Drawing.Size(318, 68);
            this.listaTaxasServicos.TabIndex = 2;
            // 
            // btnSelecionarTaxas
            // 
            this.btnSelecionarTaxas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSelecionarTaxas.Location = new System.Drawing.Point(310, 539);
            this.btnSelecionarTaxas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSelecionarTaxas.Name = "btnSelecionarTaxas";
            this.btnSelecionarTaxas.Size = new System.Drawing.Size(162, 36);
            this.btnSelecionarTaxas.TabIndex = 4;
            this.btnSelecionarTaxas.Text = "Selecionar Taxas";
            this.btnSelecionarTaxas.UseVisualStyleBackColor = true;
            this.btnSelecionarTaxas.Click += new System.EventHandler(this.btnSelecionarTaxas_Click);
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblValorTotal.Location = new System.Drawing.Point(224, 573);
            this.lblValorTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(18, 19);
            this.lblValorTotal.TabIndex = 42;
            this.lblValorTotal.Text = "0";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotal.Location = new System.Drawing.Point(139, 573);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(71, 19);
            this.lblTotal.TabIndex = 41;
            this.lblTotal.Text = "Total: R$";
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Enabled = false;
            this.btnGravar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGravar.Location = new System.Drawing.Point(430, 595);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(97, 36);
            this.btnGravar.TabIndex = 6;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // lblDataDevolucao
            // 
            this.lblDataDevolucao.AutoSize = true;
            this.lblDataDevolucao.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDataDevolucao.Location = new System.Drawing.Point(236, 226);
            this.lblDataDevolucao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataDevolucao.Name = "lblDataDevolucao";
            this.lblDataDevolucao.Size = new System.Drawing.Size(136, 17);
            this.lblDataDevolucao.TabIndex = 38;
            this.lblDataDevolucao.Text = "Data de Devolução:";
            // 
            // dateDataDevolucao
            // 
            this.dateDataDevolucao.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateDataDevolucao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDataDevolucao.Location = new System.Drawing.Point(398, 226);
            this.dateDataDevolucao.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateDataDevolucao.MinDate = new System.DateTime(2021, 8, 26, 0, 0, 0, 0);
            this.dateDataDevolucao.Name = "dateDataDevolucao";
            this.dateDataDevolucao.Size = new System.Drawing.Size(140, 25);
            this.dateDataDevolucao.TabIndex = 1;
            // 
            // lblValorEntrada
            // 
            this.lblValorEntrada.AutoSize = true;
            this.lblValorEntrada.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblValorEntrada.Location = new System.Drawing.Point(251, 194);
            this.lblValorEntrada.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorEntrada.Name = "lblValorEntrada";
            this.lblValorEntrada.Size = new System.Drawing.Size(119, 17);
            this.lblValorEntrada.TabIndex = 34;
            this.lblValorEntrada.Text = "Valor de Entrada:";
            // 
            // lblPlano
            // 
            this.lblPlano.AutoSize = true;
            this.lblPlano.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPlano.Location = new System.Drawing.Point(321, 161);
            this.lblPlano.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlano.Name = "lblPlano";
            this.lblPlano.Size = new System.Drawing.Size(49, 17);
            this.lblPlano.TabIndex = 32;
            this.lblPlano.Text = "Plano:";
            // 
            // lblVeiculo
            // 
            this.lblVeiculo.AutoSize = true;
            this.lblVeiculo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblVeiculo.Location = new System.Drawing.Point(314, 129);
            this.lblVeiculo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVeiculo.Name = "lblVeiculo";
            this.lblVeiculo.Size = new System.Drawing.Size(58, 17);
            this.lblVeiculo.TabIndex = 30;
            this.lblVeiculo.Text = "Veículo:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCliente.Location = new System.Drawing.Point(315, 97);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(57, 17);
            this.lblCliente.TabIndex = 28;
            this.lblCliente.Text = "Cliente:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(534, 595);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 36);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtIdLocacao
            // 
            this.txtIdLocacao.Enabled = false;
            this.txtIdLocacao.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtIdLocacao.Location = new System.Drawing.Point(398, 55);
            this.txtIdLocacao.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIdLocacao.Name = "txtIdLocacao";
            this.txtIdLocacao.Size = new System.Drawing.Size(111, 25);
            this.txtIdLocacao.TabIndex = 47;
            // 
            // lblIdLocacao
            // 
            this.lblIdLocacao.AutoSize = true;
            this.lblIdLocacao.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIdLocacao.Location = new System.Drawing.Point(354, 65);
            this.lblIdLocacao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdLocacao.Name = "lblIdLocacao";
            this.lblIdLocacao.Size = new System.Drawing.Size(23, 17);
            this.lblIdLocacao.TabIndex = 46;
            this.lblIdLocacao.Text = "Id:";
            // 
            // lblNomePlano
            // 
            this.lblNomePlano.AutoSize = true;
            this.lblNomePlano.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNomePlano.Location = new System.Drawing.Point(398, 161);
            this.lblNomePlano.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomePlano.Name = "lblNomePlano";
            this.lblNomePlano.Size = new System.Drawing.Size(43, 17);
            this.lblNomePlano.TabIndex = 50;
            this.lblNomePlano.Text = "plano";
            // 
            // lblModeloVeiculo
            // 
            this.lblModeloVeiculo.AutoSize = true;
            this.lblModeloVeiculo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblModeloVeiculo.Location = new System.Drawing.Point(398, 129);
            this.lblModeloVeiculo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblModeloVeiculo.Name = "lblModeloVeiculo";
            this.lblModeloVeiculo.Size = new System.Drawing.Size(102, 17);
            this.lblModeloVeiculo.TabIndex = 49;
            this.lblModeloVeiculo.Text = "modeloVeiculo";
            // 
            // lblNomeCliente
            // 
            this.lblNomeCliente.AutoSize = true;
            this.lblNomeCliente.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNomeCliente.Location = new System.Drawing.Point(398, 97);
            this.lblNomeCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomeCliente.Name = "lblNomeCliente";
            this.lblNomeCliente.Size = new System.Drawing.Size(90, 17);
            this.lblNomeCliente.TabIndex = 48;
            this.lblNomeCliente.Text = "nomeCliente";
            // 
            // lblEntrada
            // 
            this.lblEntrada.AutoSize = true;
            this.lblEntrada.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEntrada.Location = new System.Drawing.Point(398, 194);
            this.lblEntrada.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEntrada.Name = "lblEntrada";
            this.lblEntrada.Size = new System.Drawing.Size(90, 17);
            this.lblEntrada.TabIndex = 51;
            this.lblEntrada.Text = "valorEntrada";
            // 
            // btnCalcularTotal
            // 
            this.btnCalcularTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCalcularTotal.Location = new System.Drawing.Point(142, 595);
            this.btnCalcularTotal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCalcularTotal.Name = "btnCalcularTotal";
            this.btnCalcularTotal.Size = new System.Drawing.Size(162, 36);
            this.btnCalcularTotal.TabIndex = 5;
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
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(644, 49);
            this.panel2.TabIndex = 53;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LocadoraVeiculos.WindowsApp.Properties.Resources.sedan;
            this.pictureBox1.Location = new System.Drawing.Point(15, -11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(79, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(91)))), ((int)(((byte)(235)))));
            this.label3.Location = new System.Drawing.Point(102, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(267, 34);
            this.label3.TabIndex = 6;
            this.label3.Text = "LOCADORA RECH";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Location = new System.Drawing.Point(412, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "O carro certo para você!";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 49);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(114, 590);
            this.panel3.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(188, 261);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 17);
            this.label1.TabIndex = 55;
            this.label1.Text = "Quilometragem do veículo:";
            // 
            // txbQuilometragemAtual
            // 
            this.txbQuilometragemAtual.AllowDrop = true;
            this.txbQuilometragemAtual.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbQuilometragemAtual.Location = new System.Drawing.Point(398, 261);
            this.txbQuilometragemAtual.Margin = new System.Windows.Forms.Padding(2);
            this.txbQuilometragemAtual.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.txbQuilometragemAtual.Name = "txbQuilometragemAtual";
            this.txbQuilometragemAtual.ReadOnly = true;
            this.txbQuilometragemAtual.Size = new System.Drawing.Size(145, 25);
            this.txbQuilometragemAtual.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(255, 294);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(115, 166);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 58;
            this.pictureBox2.TabStop = false;
            // 
            // rdbCheio
            // 
            this.rdbCheio.AutoSize = true;
            this.rdbCheio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdbCheio.Location = new System.Drawing.Point(9, 10);
            this.rdbCheio.Margin = new System.Windows.Forms.Padding(2);
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
            this.rdbTresQuartos.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdbTresQuartos.Location = new System.Drawing.Point(9, 40);
            this.rdbTresQuartos.Margin = new System.Windows.Forms.Padding(2);
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
            this.rdbMeio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdbMeio.Location = new System.Drawing.Point(8, 70);
            this.rdbMeio.Margin = new System.Windows.Forms.Padding(2);
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
            this.rdbUmQuarto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdbUmQuarto.Location = new System.Drawing.Point(8, 100);
            this.rdbUmQuarto.Margin = new System.Windows.Forms.Padding(2);
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
            this.rdbVazio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdbVazio.Location = new System.Drawing.Point(9, 130);
            this.rdbVazio.Margin = new System.Windows.Forms.Padding(2);
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
            this.pnlMedidasTanque.Location = new System.Drawing.Point(398, 294);
            this.pnlMedidasTanque.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMedidasTanque.Name = "pnlMedidasTanque";
            this.pnlMedidasTanque.Size = new System.Drawing.Size(103, 166);
            this.pnlMedidasTanque.TabIndex = 3;
            // 
            // btHabilitarMedidas
            // 
            this.btHabilitarMedidas.Enabled = false;
            this.btHabilitarMedidas.FlatAppearance.BorderSize = 0;
            this.btHabilitarMedidas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btHabilitarMedidas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btHabilitarMedidas.Image = ((System.Drawing.Image)(resources.GetObject("btHabilitarMedidas.Image")));
            this.btHabilitarMedidas.Location = new System.Drawing.Point(510, 339);
            this.btHabilitarMedidas.Margin = new System.Windows.Forms.Padding(2);
            this.btHabilitarMedidas.Name = "btHabilitarMedidas";
            this.btHabilitarMedidas.Size = new System.Drawing.Size(51, 51);
            this.btHabilitarMedidas.TabIndex = 66;
            this.btHabilitarMedidas.UseVisualStyleBackColor = true;
            this.btHabilitarMedidas.Click += new System.EventHandler(this.btHabilitarMedidas_Click);
            // 
            // TelaRegistrarDevolucaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(644, 639);
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
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
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