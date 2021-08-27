
namespace LocadoraVeiculos.WindowsApp
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.panelTopo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnLocacoes = new System.Windows.Forms.Button();
            this.btnConfiguracoes = new System.Windows.Forms.Button();
            this.btnTaxasServicos = new System.Windows.Forms.Button();
            this.btnCadastroGrupoAutomoveis = new System.Windows.Forms.Button();
            this.btnCadastroVeiculos = new System.Windows.Forms.Button();
            this.btnCadastroFuncionarioModules = new System.Windows.Forms.Button();
            this.btnCadastroClientes = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.toolBoxAcoes = new System.Windows.Forms.ToolStrip();
            this.txtPesquisa = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnAdicionar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnFiltrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnAgrupar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnDesagrupar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnDevolucao = new System.Windows.Forms.ToolStripButton();
            this.panelRegistros = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelRodape = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.panel4.SuspendLayout();
            this.toolBoxAcoes.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTopo
            // 
            this.panelTopo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.panelTopo.Controls.Add(this.label1);
            this.panelTopo.Controls.Add(this.label4);
            this.panelTopo.Controls.Add(this.pictureBox1);
            this.panelTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopo.Location = new System.Drawing.Point(0, 0);
            this.panelTopo.Name = "panelTopo";
            this.panelTopo.Size = new System.Drawing.Size(1069, 60);
            this.panelTopo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(91)))), ((int)(((byte)(235)))));
            this.label1.Location = new System.Drawing.Point(157, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 46);
            this.label1.TabIndex = 8;
            this.label1.Text = "LOCADORA RECH";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Location = new System.Drawing.Point(534, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(284, 28);
            this.label4.TabIndex = 7;
            this.label4.Text = "O carro certo para você!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LocadoraVeiculos.WindowsApp.Properties.Resources.sedan;
            this.pictureBox1.Location = new System.Drawing.Point(45, -11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.panelMenu.Controls.Add(this.panel4);
            this.panelMenu.Controls.Add(this.label3);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 60);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(242, 588);
            this.panelMenu.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.btnLocacoes);
            this.panel4.Controls.Add(this.btnConfiguracoes);
            this.panel4.Controls.Add(this.btnTaxasServicos);
            this.panel4.Controls.Add(this.btnCadastroGrupoAutomoveis);
            this.panel4.Controls.Add(this.btnCadastroVeiculos);
            this.panel4.Controls.Add(this.btnCadastroFuncionarioModules);
            this.panel4.Controls.Add(this.btnCadastroClientes);
            this.panel4.Location = new System.Drawing.Point(3, 76);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(233, 431);
            this.panel4.TabIndex = 1;
            // 
            // btnLocacoes
            // 
            this.btnLocacoes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLocacoes.FlatAppearance.BorderSize = 0;
            this.btnLocacoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocacoes.Font = new System.Drawing.Font("Arial", 12F);
            this.btnLocacoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(91)))), ((int)(((byte)(235)))));
            this.btnLocacoes.Location = new System.Drawing.Point(0, 364);
            this.btnLocacoes.Name = "btnLocacoes";
            this.btnLocacoes.Size = new System.Drawing.Size(233, 60);
            this.btnLocacoes.TabIndex = 7;
            this.btnLocacoes.Text = "Locações";
            this.btnLocacoes.UseVisualStyleBackColor = true;
            this.btnLocacoes.Click += new System.EventHandler(this.btnLocacoes_Click);
            // 
            // btnConfiguracoes
            // 
            this.btnConfiguracoes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConfiguracoes.FlatAppearance.BorderSize = 0;
            this.btnConfiguracoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguracoes.Font = new System.Drawing.Font("Arial", 12F);
            this.btnConfiguracoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(91)))), ((int)(((byte)(235)))));
            this.btnConfiguracoes.Location = new System.Drawing.Point(0, 304);
            this.btnConfiguracoes.Name = "btnConfiguracoes";
            this.btnConfiguracoes.Size = new System.Drawing.Size(233, 60);
            this.btnConfiguracoes.TabIndex = 6;
            this.btnConfiguracoes.Text = "Configurações";
            this.btnConfiguracoes.UseVisualStyleBackColor = true;
            this.btnConfiguracoes.Click += new System.EventHandler(this.btnConfiguracoes_Click);
            // 
            // btnTaxasServicos
            // 
            this.btnTaxasServicos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTaxasServicos.FlatAppearance.BorderSize = 0;
            this.btnTaxasServicos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaxasServicos.Font = new System.Drawing.Font("Arial", 12F);
            this.btnTaxasServicos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(91)))), ((int)(((byte)(235)))));
            this.btnTaxasServicos.Location = new System.Drawing.Point(0, 244);
            this.btnTaxasServicos.Name = "btnTaxasServicos";
            this.btnTaxasServicos.Size = new System.Drawing.Size(233, 60);
            this.btnTaxasServicos.TabIndex = 5;
            this.btnTaxasServicos.Text = "Taxas e serviços";
            this.btnTaxasServicos.UseVisualStyleBackColor = true;
            this.btnTaxasServicos.Click += new System.EventHandler(this.btnTaxasServicos_Click);
            // 
            // btnCadastroGrupoAutomoveis
            // 
            this.btnCadastroGrupoAutomoveis.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCadastroGrupoAutomoveis.FlatAppearance.BorderSize = 0;
            this.btnCadastroGrupoAutomoveis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastroGrupoAutomoveis.Font = new System.Drawing.Font("Arial", 12F);
            this.btnCadastroGrupoAutomoveis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(91)))), ((int)(((byte)(235)))));
            this.btnCadastroGrupoAutomoveis.Location = new System.Drawing.Point(0, 183);
            this.btnCadastroGrupoAutomoveis.Name = "btnCadastroGrupoAutomoveis";
            this.btnCadastroGrupoAutomoveis.Size = new System.Drawing.Size(233, 61);
            this.btnCadastroGrupoAutomoveis.TabIndex = 4;
            this.btnCadastroGrupoAutomoveis.Text = "Grupo Automóveis";
            this.btnCadastroGrupoAutomoveis.UseVisualStyleBackColor = true;
            this.btnCadastroGrupoAutomoveis.Click += new System.EventHandler(this.btnCadastroGrupoAutomoveis_Click);
            // 
            // btnCadastroVeiculos
            // 
            this.btnCadastroVeiculos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCadastroVeiculos.FlatAppearance.BorderSize = 0;
            this.btnCadastroVeiculos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastroVeiculos.Font = new System.Drawing.Font("Arial", 12F);
            this.btnCadastroVeiculos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(91)))), ((int)(((byte)(235)))));
            this.btnCadastroVeiculos.Location = new System.Drawing.Point(0, 122);
            this.btnCadastroVeiculos.Name = "btnCadastroVeiculos";
            this.btnCadastroVeiculos.Size = new System.Drawing.Size(233, 61);
            this.btnCadastroVeiculos.TabIndex = 3;
            this.btnCadastroVeiculos.Text = "Veículos";
            this.btnCadastroVeiculos.UseVisualStyleBackColor = true;
            this.btnCadastroVeiculos.Click += new System.EventHandler(this.btnCadastroVeiculoModules_Click);
            // 
            // btnCadastroFuncionarioModules
            // 
            this.btnCadastroFuncionarioModules.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCadastroFuncionarioModules.FlatAppearance.BorderSize = 0;
            this.btnCadastroFuncionarioModules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastroFuncionarioModules.Font = new System.Drawing.Font("Arial", 12F);
            this.btnCadastroFuncionarioModules.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(91)))), ((int)(((byte)(235)))));
            this.btnCadastroFuncionarioModules.Location = new System.Drawing.Point(0, 61);
            this.btnCadastroFuncionarioModules.Name = "btnCadastroFuncionarioModules";
            this.btnCadastroFuncionarioModules.Size = new System.Drawing.Size(233, 61);
            this.btnCadastroFuncionarioModules.TabIndex = 2;
            this.btnCadastroFuncionarioModules.Text = "Funcionários";
            this.btnCadastroFuncionarioModules.UseMnemonic = false;
            this.btnCadastroFuncionarioModules.UseVisualStyleBackColor = true;
            this.btnCadastroFuncionarioModules.Click += new System.EventHandler(this.btnCadastroFuncionario_Click);
            // 
            // btnCadastroClientes
            // 
            this.btnCadastroClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCadastroClientes.FlatAppearance.BorderSize = 0;
            this.btnCadastroClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastroClientes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastroClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(91)))), ((int)(((byte)(235)))));
            this.btnCadastroClientes.Location = new System.Drawing.Point(0, 0);
            this.btnCadastroClientes.Name = "btnCadastroClientes";
            this.btnCadastroClientes.Size = new System.Drawing.Size(233, 61);
            this.btnCadastroClientes.TabIndex = 1;
            this.btnCadastroClientes.Text = "Clientes";
            this.btnCadastroClientes.UseVisualStyleBackColor = true;
            this.btnCadastroClientes.Click += new System.EventHandler(this.btnCadastroClientes_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(53, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Menu Principal";
            // 
            // toolBoxAcoes
            // 
            this.toolBoxAcoes.BackColor = System.Drawing.Color.Silver;
            this.toolBoxAcoes.Enabled = false;
            this.toolBoxAcoes.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolBoxAcoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtPesquisa,
            this.toolStripSeparator6,
            this.toolStripBtnAdicionar,
            this.toolStripSeparator1,
            this.toolStripBtnEditar,
            this.toolStripSeparator2,
            this.toolStripBtnExcluir,
            this.toolStripSeparator4,
            this.toolStripBtnFiltrar,
            this.toolStripSeparator3,
            this.toolStripBtnAgrupar,
            this.toolStripSeparator5,
            this.toolStripBtnDesagrupar,
            this.toolStripSeparator7,
            this.toolStripBtnDevolucao});
            this.toolBoxAcoes.Location = new System.Drawing.Point(242, 60);
            this.toolBoxAcoes.Name = "toolBoxAcoes";
            this.toolBoxAcoes.Size = new System.Drawing.Size(827, 55);
            this.toolBoxAcoes.TabIndex = 4;
            this.toolBoxAcoes.Text = "toolStrip1";
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPesquisa.ForeColor = System.Drawing.Color.Black;
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(360, 55);
            this.txtPesquisa.Text = "Digite para Pesquisar";
            this.txtPesquisa.Enter += new System.EventHandler(this.txtPesquisa_Enter);
            this.txtPesquisa.Leave += new System.EventHandler(this.txtPesquisa_Leave);
            this.txtPesquisa.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripBtnAdicionar
            // 
            this.toolStripBtnAdicionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnAdicionar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripBtnAdicionar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnAdicionar.Image")));
            this.toolStripBtnAdicionar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnAdicionar.Name = "toolStripBtnAdicionar";
            this.toolStripBtnAdicionar.Size = new System.Drawing.Size(52, 52);
            this.toolStripBtnAdicionar.Text = "toolStripButton1";
            this.toolStripBtnAdicionar.ToolTipText = "Adicionar";
            this.toolStripBtnAdicionar.Click += new System.EventHandler(this.toolStripBtnAdicionar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripBtnEditar
            // 
            this.toolStripBtnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnEditar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnEditar.Image")));
            this.toolStripBtnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnEditar.Name = "toolStripBtnEditar";
            this.toolStripBtnEditar.Size = new System.Drawing.Size(52, 52);
            this.toolStripBtnEditar.Text = "toolStripButton3";
            this.toolStripBtnEditar.ToolTipText = "Editar";
            this.toolStripBtnEditar.Click += new System.EventHandler(this.toolStripBtnEditar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripBtnExcluir
            // 
            this.toolStripBtnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnExcluir.Image")));
            this.toolStripBtnExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnExcluir.Name = "toolStripBtnExcluir";
            this.toolStripBtnExcluir.Size = new System.Drawing.Size(52, 52);
            this.toolStripBtnExcluir.Text = "toolStripButton2";
            this.toolStripBtnExcluir.ToolTipText = "Excluir";
            this.toolStripBtnExcluir.Click += new System.EventHandler(this.toolStripBtnExcluir_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripBtnFiltrar
            // 
            this.toolStripBtnFiltrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnFiltrar.Image")));
            this.toolStripBtnFiltrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnFiltrar.Name = "toolStripBtnFiltrar";
            this.toolStripBtnFiltrar.Size = new System.Drawing.Size(52, 52);
            this.toolStripBtnFiltrar.Text = "toolStripButton4";
            this.toolStripBtnFiltrar.ToolTipText = "Filtrar";
            this.toolStripBtnFiltrar.Click += new System.EventHandler(this.toolStripBtnFiltrar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripBtnAgrupar
            // 
            this.toolStripBtnAgrupar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnAgrupar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnAgrupar.Image")));
            this.toolStripBtnAgrupar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnAgrupar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnAgrupar.Name = "toolStripBtnAgrupar";
            this.toolStripBtnAgrupar.Size = new System.Drawing.Size(52, 52);
            this.toolStripBtnAgrupar.Text = "toolStripButton5";
            this.toolStripBtnAgrupar.ToolTipText = "Agrupar";
            this.toolStripBtnAgrupar.Click += new System.EventHandler(this.toolStripBtnAgrupar_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripBtnDesagrupar
            // 
            this.toolStripBtnDesagrupar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnDesagrupar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnDesagrupar.Image")));
            this.toolStripBtnDesagrupar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnDesagrupar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnDesagrupar.Name = "toolStripBtnDesagrupar";
            this.toolStripBtnDesagrupar.Size = new System.Drawing.Size(52, 52);
            this.toolStripBtnDesagrupar.Text = "toolStripButton6";
            this.toolStripBtnDesagrupar.ToolTipText = "Desagrupar";
            this.toolStripBtnDesagrupar.Click += new System.EventHandler(this.toolStripBtnDesagrupar_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripBtnDevolucao
            // 
            this.toolStripBtnDevolucao.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnDevolucao.Image = global::LocadoraVeiculos.WindowsApp.Properties.Resources.outline_car_rental_black_24dp1;
            this.toolStripBtnDevolucao.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnDevolucao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnDevolucao.Name = "toolStripBtnDevolucao";
            this.toolStripBtnDevolucao.Size = new System.Drawing.Size(52, 52);
            this.toolStripBtnDevolucao.Text = "toolStripButton1";
            this.toolStripBtnDevolucao.Visible = false;
            this.toolStripBtnDevolucao.Click += new System.EventHandler(this.toolStripBtnDevolucao_Click);
            // 
            // panelRegistros
            // 
            this.panelRegistros.BackColor = System.Drawing.Color.Silver;
            this.panelRegistros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRegistros.Location = new System.Drawing.Point(242, 115);
            this.panelRegistros.Name = "panelRegistros";
            this.panelRegistros.Size = new System.Drawing.Size(827, 533);
            this.panelRegistros.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Silver;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelRodape});
            this.statusStrip1.Location = new System.Drawing.Point(242, 626);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(827, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelRodape
            // 
            this.labelRodape.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRodape.Name = "labelRodape";
            this.labelRodape.Size = new System.Drawing.Size(90, 17);
            this.labelRodape.Text = "Tudo certo ;)";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 648);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelRegistros);
            this.Controls.Add(this.toolBoxAcoes);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelTopo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tela Principal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Dashboard_FormClosed);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.toolBoxAcoes.ResumeLayout(false);
            this.toolBoxAcoes.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelTopo;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.ToolStrip toolBoxAcoes;
        private System.Windows.Forms.ToolStripTextBox txtPesquisa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripBtnAdicionar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripBtnExcluir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripBtnEditar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripBtnFiltrar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripBtnAgrupar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripBtnDesagrupar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelRegistros;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnCadastroGrupoAutomoveis;
        private System.Windows.Forms.Button btnCadastroVeiculos;
        private System.Windows.Forms.Button btnCadastroFuncionarioModules;
        private System.Windows.Forms.Button btnCadastroClientes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelRodape;
        private System.Windows.Forms.Button btnConfiguracoes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTaxasServicos;
        private System.Windows.Forms.Button btnLocacoes;
        private System.Windows.Forms.ToolStripButton toolStripBtnDevolucao;
    }
}

