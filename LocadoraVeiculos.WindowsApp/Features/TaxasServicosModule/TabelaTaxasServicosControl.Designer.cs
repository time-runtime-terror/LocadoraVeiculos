
namespace LocadoraVeiculos.WindowsApp.Features.TaxasServicosModule
{
    partial class TabelaTaxasServicosControl
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
            this.gridTaxasServicos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridTaxasServicos)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTaxasServicos
            // 
            this.gridTaxasServicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTaxasServicos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTaxasServicos.Location = new System.Drawing.Point(0, 0);
            this.gridTaxasServicos.Name = "gridTaxasServicos";
            this.gridTaxasServicos.Size = new System.Drawing.Size(247, 253);
            this.gridTaxasServicos.TabIndex = 0;
            // 
            // TabelaTaxasServicosControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridTaxasServicos);
            this.Name = "TabelaTaxasServicosControl";
            this.Size = new System.Drawing.Size(247, 253);
            ((System.ComponentModel.ISupportInitialize)(this.gridTaxasServicos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridTaxasServicos;
    }
}
