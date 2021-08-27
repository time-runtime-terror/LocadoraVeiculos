
namespace LocadoraVeiculos.WindowsApp.Features.LocacaoModule
{
    partial class TabelaLocacaoControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridLocacoes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridLocacoes)).BeginInit();
            this.SuspendLayout();
            // 
            // gridLocacoes
            // 
            this.gridLocacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLocacoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLocacoes.Location = new System.Drawing.Point(0, 0);
            this.gridLocacoes.Name = "gridLocacoes";
            this.gridLocacoes.Size = new System.Drawing.Size(359, 278);
            this.gridLocacoes.TabIndex = 0;
            this.gridLocacoes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLocacoes_CellClick);
            // 
            // TabelaLocacaoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridLocacoes);
            this.Name = "TabelaLocacaoControl";
            this.Size = new System.Drawing.Size(359, 278);
            ((System.ComponentModel.ISupportInitialize)(this.gridLocacoes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridLocacoes;
    }
}
