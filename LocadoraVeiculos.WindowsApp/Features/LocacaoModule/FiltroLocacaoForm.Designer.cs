
namespace LocadoraVeiculos.WindowsApp.Features.LocacaoModule
{
    partial class FiltroLocacaoForm
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
            this.rbLocacoesConcluidas = new System.Windows.Forms.RadioButton();
            this.rbLocacoesPendentes = new System.Windows.Forms.RadioButton();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbLocacoesConcluidas
            // 
            this.rbLocacoesConcluidas.AutoSize = true;
            this.rbLocacoesConcluidas.Location = new System.Drawing.Point(109, 59);
            this.rbLocacoesConcluidas.Name = "rbLocacoesConcluidas";
            this.rbLocacoesConcluidas.Size = new System.Drawing.Size(176, 17);
            this.rbLocacoesConcluidas.TabIndex = 0;
            this.rbLocacoesConcluidas.TabStop = true;
            this.rbLocacoesConcluidas.Text = "Filtrar Por Locações Concluídas";
            this.rbLocacoesConcluidas.UseVisualStyleBackColor = true;
            this.rbLocacoesConcluidas.CheckedChanged += new System.EventHandler(this.rbLocacoesConcluidas_CheckedChanged);
            // 
            // rbLocacoesPendentes
            // 
            this.rbLocacoesPendentes.AutoSize = true;
            this.rbLocacoesPendentes.Location = new System.Drawing.Point(109, 91);
            this.rbLocacoesPendentes.Name = "rbLocacoesPendentes";
            this.rbLocacoesPendentes.Size = new System.Drawing.Size(173, 17);
            this.rbLocacoesPendentes.TabIndex = 1;
            this.rbLocacoesPendentes.TabStop = true;
            this.rbLocacoesPendentes.Text = "Filtrar Por Locações Pendentes";
            this.rbLocacoesPendentes.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGravar.Location = new System.Drawing.Point(202, 184);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(83, 31);
            this.btnGravar.TabIndex = 18;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(291, 184);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 31);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FiltroLocacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 227);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.rbLocacoesPendentes);
            this.Controls.Add(this.rbLocacoesConcluidas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FiltroLocacaoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtrar Locações";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbLocacoesConcluidas;
        private System.Windows.Forms.RadioButton rbLocacoesPendentes;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
    }
}