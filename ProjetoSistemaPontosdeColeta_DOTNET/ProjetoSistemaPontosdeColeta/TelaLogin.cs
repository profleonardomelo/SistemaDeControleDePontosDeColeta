using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetoSistemaPontosdeColeta
{
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtLogin.Text = "";
            txtSenha.Text = "";
        }



      



        
        private void txtSenha_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntrar_Click(sender, e);
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            String login = txtLogin.Text.Trim();
            String senha = txtSenha.Text;

            if (login == "" && senha == "")
            {
                MessageBox.Show("Login e Senha são campos obrigatóros.");
            }
            else
            {
                MySqlConnection conexao = null;


                try
                {
                    String enderecoConexaoMySql = Constantes.enderecoDeConexaoMySql;

                    conexao = new MySqlConnection(enderecoConexaoMySql);

                    String sql = "SELECT id FROM `bd_lixo_eletronico`.`usuario` " +
                        "WHERE login = '" + login + "' AND senha = '" + senha + "';";


                    MySqlCommand comando = new MySqlCommand(sql, conexao);

                    conexao.Open();

                    MySqlDataReader reader = comando.ExecuteReader();

                    int qtdeRegistros = 0;

                    while (reader.Read())
                    {
                        qtdeRegistros++;
                    }

                    if (login.Equals("".ToString()) || senha.Equals("".ToString()))
                    {
                        MessageBox.Show("Os campos Login e Senha são campos obrigatórios!");
                    }
                    else
                    {
                        if (qtdeRegistros == 1)
                        {
                            this.Hide();
                            TelaPrincipal telaPrincipal = new TelaPrincipal();
                            telaPrincipal.Closed += (s, args) => this.Close();
                            telaPrincipal.Show();
                        }
                        else
                        {
                            MessageBox.Show("Login e/ou Senha inválidos!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel realizar consulta ao banco de dados.");
                }
                finally
                {
                    conexao.Close();
                }

            }
        }
    }
}
