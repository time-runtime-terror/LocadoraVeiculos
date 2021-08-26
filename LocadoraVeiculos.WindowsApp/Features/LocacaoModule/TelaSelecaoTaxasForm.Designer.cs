
namespace LocadoraVeiculos.WindowsApp.Features.LocacaoModule
{
    partial class TelaSelecaoTaxasForm
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
            this.listaTaxasServicos = new System.Windows.Forms.CheckedListBox();
            this.btnGravarTaxas = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listaTaxasServicos
            // 
            this.listaTaxasServicos.CheckOnClick = true;
            this.listaTaxasServicos.FormattingEnabled = true;
            this.listaTaxasServicos.Location = new System.Drawing.Point(53, 23);
            this.listaTaxasServicos.Name = "listaTaxasServicos";
            this.listaTaxasServicos.Size = new System.Drawing.Size(278, 154);
            this.listaTaxasServicos.TabIndex = 18;
            this.listaTaxasServicos.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listaTaxasServicos_ItemCheck);
            // 
            // btnGravarTaxas
            // 
            this.btnGravarTaxas.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravarTaxas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGravarTaxas.Location = new System.Drawing.Point(203, 259);
            this.btnGravarTaxas.Name = "btnGravarTaxas";
            this.btnGravarTaxas.Size = new System.Drawing.Size(83, 31);
            this.btnGravarTaxas.TabIndex = 20;
            this.btnGravarTaxas.Text = "Gravar";
            this.btnGravarTaxas.UseVisualStyleBackColor = true;
            this.btnGravarTaxas.Click += new System.EventHandler(this.btnGravarTaxas_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(292, 259);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 31);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaSelecaoTaxasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 302);
            this.Controls.Add(this.btnGravarTaxas);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.listaTaxasServicos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaSelecaoTaxasForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaSelecaoTaxasForm";
            this.Load += new System.EventHandler(this.TelaSelecaoTaxasForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox listaTaxasServicos;
        private System.Windows.Forms.Button btnGravarTaxas;
        private System.Windows.Forms.Button btnCancelar;
    }
}