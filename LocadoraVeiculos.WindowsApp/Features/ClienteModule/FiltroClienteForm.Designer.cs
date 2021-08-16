
namespace LocadoraVeiculos.WindowsApp.Features.ClienteModule
{
    partial class FiltroClienteForm
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
            this.rdbFiltroPessoasFisicas = new System.Windows.Forms.RadioButton();
            this.rdbFiltroPessoasJuridicas = new System.Windows.Forms.RadioButton();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdbFiltroPessoasFisicas
            // 
            this.rdbFiltroPessoasFisicas.AutoSize = true;
            this.rdbFiltroPessoasFisicas.Location = new System.Drawing.Point(113, 66);
            this.rdbFiltroPessoasFisicas.Name = "rdbFiltroPessoasFisicas";
            this.rdbFiltroPessoasFisicas.Size = new System.Drawing.Size(146, 17);
            this.rdbFiltroPessoasFisicas.TabIndex = 0;
            this.rdbFiltroPessoasFisicas.TabStop = true;
            this.rdbFiltroPessoasFisicas.Text = "Filtrar por Pessoas Fisicas";
            this.rdbFiltroPessoasFisicas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbFiltroPessoasFisicas.UseVisualStyleBackColor = true;
            this.rdbFiltroPessoasFisicas.CheckedChanged += new System.EventHandler(this.rdbFiltroPessoasFisicas_CheckedChanged);
            // 
            // rdbFiltroPessoasJuridicas
            // 
            this.rdbFiltroPessoasJuridicas.AutoSize = true;
            this.rdbFiltroPessoasJuridicas.Location = new System.Drawing.Point(113, 101);
            this.rdbFiltroPessoasJuridicas.Name = "rdbFiltroPessoasJuridicas";
            this.rdbFiltroPessoasJuridicas.Size = new System.Drawing.Size(157, 17);
            this.rdbFiltroPessoasJuridicas.TabIndex = 1;
            this.rdbFiltroPessoasJuridicas.TabStop = true;
            this.rdbFiltroPessoasJuridicas.Text = "Filtrar por Pessoas Jurídicas";
            this.rdbFiltroPessoasJuridicas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbFiltroPessoasJuridicas.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(286, 167);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 13;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(205, 167);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FiltroClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 202);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.rdbFiltroPessoasJuridicas);
            this.Controls.Add(this.rdbFiltroPessoasFisicas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FiltroClienteForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtragem de Clientes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbFiltroPessoasFisicas;
        private System.Windows.Forms.RadioButton rdbFiltroPessoasJuridicas;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
    }
}