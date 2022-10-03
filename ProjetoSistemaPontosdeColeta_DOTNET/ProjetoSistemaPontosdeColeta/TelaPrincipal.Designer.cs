namespace ProjetoSistemaPontosdeColeta
{
    partial class TelaPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pontosDeColetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDePontosDeColetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alteraçãoDePontosDeColetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscaDePontosDeColetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscaDePontosDeColetaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pontosDeColetaToolStripMenuItem,
            this.sobreToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pontosDeColetaToolStripMenuItem
            // 
            this.pontosDeColetaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroDePontosDeColetaToolStripMenuItem,
            this.alteraçãoDePontosDeColetaToolStripMenuItem,
            this.buscaDePontosDeColetaToolStripMenuItem,
            this.buscaDePontosDeColetaToolStripMenuItem1});
            this.pontosDeColetaToolStripMenuItem.Name = "pontosDeColetaToolStripMenuItem";
            this.pontosDeColetaToolStripMenuItem.Size = new System.Drawing.Size(160, 29);
            this.pontosDeColetaToolStripMenuItem.Text = "Pontos de coleta";
            // 
            // cadastroDePontosDeColetaToolStripMenuItem
            // 
            this.cadastroDePontosDeColetaToolStripMenuItem.Name = "cadastroDePontosDeColetaToolStripMenuItem";
            this.cadastroDePontosDeColetaToolStripMenuItem.Size = new System.Drawing.Size(352, 34);
            this.cadastroDePontosDeColetaToolStripMenuItem.Text = "Cadastro de pontos de coleta";
            this.cadastroDePontosDeColetaToolStripMenuItem.Click += new System.EventHandler(this.cadastroDePontosDeColetaToolStripMenuItem_Click);
            // 
            // alteraçãoDePontosDeColetaToolStripMenuItem
            // 
            this.alteraçãoDePontosDeColetaToolStripMenuItem.Name = "alteraçãoDePontosDeColetaToolStripMenuItem";
            this.alteraçãoDePontosDeColetaToolStripMenuItem.Size = new System.Drawing.Size(352, 34);
            this.alteraçãoDePontosDeColetaToolStripMenuItem.Text = "Alteração de pontos de coleta";
            this.alteraçãoDePontosDeColetaToolStripMenuItem.Click += new System.EventHandler(this.alteraçãoDePontosDeColetaToolStripMenuItem_Click);
            // 
            // buscaDePontosDeColetaToolStripMenuItem
            // 
            this.buscaDePontosDeColetaToolStripMenuItem.Name = "buscaDePontosDeColetaToolStripMenuItem";
            this.buscaDePontosDeColetaToolStripMenuItem.Size = new System.Drawing.Size(352, 34);
            this.buscaDePontosDeColetaToolStripMenuItem.Text = "Exclusão de pontos de coleta";
            this.buscaDePontosDeColetaToolStripMenuItem.Click += new System.EventHandler(this.buscaDePontosDeColetaToolStripMenuItem_Click);
            // 
            // buscaDePontosDeColetaToolStripMenuItem1
            // 
            this.buscaDePontosDeColetaToolStripMenuItem1.Name = "buscaDePontosDeColetaToolStripMenuItem1";
            this.buscaDePontosDeColetaToolStripMenuItem1.Size = new System.Drawing.Size(352, 34);
            this.buscaDePontosDeColetaToolStripMenuItem1.Text = "Busca de pontos de coleta";
            this.buscaDePontosDeColetaToolStripMenuItem1.Click += new System.EventHandler(this.buscaDePontosDeColetaToolStripMenuItem1_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(57, 29);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(75, 29);
            this.sobreToolStripMenuItem.Text = "Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TelaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaPrincipal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pontosDeColetaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroDePontosDeColetaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alteraçãoDePontosDeColetaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscaDePontosDeColetaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscaDePontosDeColetaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
    }
}