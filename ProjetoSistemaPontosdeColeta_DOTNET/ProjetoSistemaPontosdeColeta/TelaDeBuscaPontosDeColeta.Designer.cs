namespace ProjetoSistemaPontosdeColeta
{
    partial class TelaDeBuscaPontosDeColeta
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lstPontosDeColeta = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.lblTitulo.Location = new System.Drawing.Point(177, 41);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(396, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Pesquisa de Pontos de Coleta";
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.txtPesquisar.Location = new System.Drawing.Point(51, 108);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(548, 35);
            this.txtPesquisar.TabIndex = 1;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.SystemColors.Window;
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnPesquisar.Location = new System.Drawing.Point(617, 108);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(144, 35);
            this.btnPesquisar.TabIndex = 2;
            this.btnPesquisar.TabStop = false;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // lstPontosDeColeta
            // 
            this.lstPontosDeColeta.HideSelection = false;
            this.lstPontosDeColeta.Location = new System.Drawing.Point(51, 167);
            this.lstPontosDeColeta.Name = "lstPontosDeColeta";
            this.lstPontosDeColeta.Size = new System.Drawing.Size(710, 227);
            this.lstPontosDeColeta.TabIndex = 3;
            this.lstPontosDeColeta.UseCompatibleStateImageBehavior = false;
            this.lstPontosDeColeta.View = System.Windows.Forms.View.Details;
            // 
            // TelaDeBuscaPontosDeColeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 450);
            this.Controls.Add(this.lstPontosDeColeta);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.lblTitulo);
            this.DoubleBuffered = true;
            this.Name = "TelaDeBuscaPontosDeColeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaDeBuscaPontosDeColeta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.ListView lstPontosDeColeta;
    }
}