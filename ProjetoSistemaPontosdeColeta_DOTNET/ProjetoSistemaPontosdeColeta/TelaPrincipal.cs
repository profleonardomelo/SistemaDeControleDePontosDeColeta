﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoSistemaPontosdeColeta
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void buscaDePontosDeColetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaDeExclusaoPontoDeColetas teladeexclusaopontosdecoleta = new TelaDeExclusaoPontoDeColetas();
            teladeexclusaopontosdecoleta.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void alteraçãoDePontosDeColetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaAlteracaoPontosDeColeta telaalteracaopontosdecoleta = new TelaAlteracaoPontosDeColeta();
            telaalteracaopontosdecoleta.Show();
        }

        private void buscaDePontosDeColetaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TelaDeBuscaPontosDeColeta teladebuscapontosdecoleta = new TelaDeBuscaPontosDeColeta();
            teladebuscapontosdecoleta.Show();
        }

        private void cadastroDePontosDeColetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaCadastroPontosDeColeta telacadastropontosdecoleta = new TelaCadastroPontosDeColeta();
            telacadastropontosdecoleta.Show();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaSobre telasobre = new TelaSobre();
            telasobre.Show();
        }
    }
}
