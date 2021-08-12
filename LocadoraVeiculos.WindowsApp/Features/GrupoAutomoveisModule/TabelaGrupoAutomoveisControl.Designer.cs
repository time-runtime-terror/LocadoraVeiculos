
namespace LocadoraVeiculos.WindowsApp.Features.GrupoAutomoveisModule
{
    partial class TabelaGrupoAutomoveisControl
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
            this.gridGrupoAutomoveis = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridGrupoAutomoveis)).BeginInit();
            this.SuspendLayout();
            // 
            // gridGrupoAutomoveis
            // 
            this.gridGrupoAutomoveis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGrupoAutomoveis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridGrupoAutomoveis.Location = new System.Drawing.Point(0, 0);
            this.gridGrupoAutomoveis.Name = "gridGrupoAutomoveis";
            this.gridGrupoAutomoveis.Size = new System.Drawing.Size(272, 278);
            this.gridGrupoAutomoveis.TabIndex = 0;
            // 
            // TabelaGrupoAutomoveisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridGrupoAutomoveis);
            this.Name = "TabelaGrupoAutomoveisControl";
            this.Size = new System.Drawing.Size(272, 278);
            ((System.ComponentModel.ISupportInitialize)(this.gridGrupoAutomoveis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridGrupoAutomoveis;
    }
}
