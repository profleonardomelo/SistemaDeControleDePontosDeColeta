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
    public partial class TelaCadastroPontosDeColeta : Form
    {
        public TelaCadastroPontosDeColeta()
        {
            InitializeComponent();
            CarregarComboEstado();
        }

        private void CarregarComboEstado()
        {
            cmbEstado.Items.Clear();
            cmbEstado.DisplayMember = "Nome";
            cmbEstado.ValueMember = "Id";
            cmbEstado.Items.Add(new Item(0, "--------"));
            cmbEstado.SelectedIndex = 0;

            //Carregar do banco de dados

            MySqlConnection conexao = null;

            try
            {

                String enderecoConexaoMySql = Constantes.enderecoDeConexaoMySql;

                conexao = new MySqlConnection(enderecoConexaoMySql);

                String sql = "SELECT id, nome FROM `bd_lixo_eletronico`.`estado`;";

                MySqlCommand comando = new MySqlCommand(sql, conexao);

                conexao.Open();

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    String nome = reader["nome"].ToString();

                    cmbEstado.Items.Add(new Item(id, nome));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível realizar consulta ao banco de dados.");
            }
            finally
            {
                conexao.Close();
            }

            CarregarComboCidade();
        }

        private void CarregarComboCidade()
        {
            cmbCidade.Items.Clear();
            cmbCidade.DisplayMember = "Nome";
            cmbCidade.ValueMember = "Id";
            cmbCidade.Items.Add(new Item(0, "--------"));
            cmbCidade.SelectedIndex = 0;

            if (cmbEstado.SelectedIndex != 0)
            {
                //Carregar do banco de dados

                MySqlConnection conexao = null;

                try
                {

                    String enderecoConexaoMySql = Constantes.enderecoDeConexaoMySql;

                    conexao = new MySqlConnection(enderecoConexaoMySql);

                    String sql = "SELECT id, nome FROM `bd_lixo_eletronico`.`cidade`"
                        + " WHERE id_estado = " + ((Item)cmbEstado.SelectedItem).Id.ToString() + ";";
                    MySqlCommand comando = new MySqlCommand(sql, conexao);

                    conexao.Open();

                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        String nome = reader["nome"].ToString();

                        cmbCidade.Items.Add(new Item(id, nome));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível realizar consulta ao banco de dados.");
                }
                finally
                {
                    conexao.Close();
                }
            }

            CarregarComboBairro();
        }

        private void CarregarComboBairro()
        {
            cmbBairro.Items.Clear();
            cmbBairro.DisplayMember = "Nome";
            cmbBairro.ValueMember = "Id";
            cmbBairro.Items.Add(new Item(1, "--------"));
            cmbBairro.SelectedIndex = 0;

            if (cmbCidade.SelectedIndex != 0)
            {
                //Acrescenta do bando de dados de forma filtrada

                //Carregar do banco de dados

                MySqlConnection conexao = null;

                try
                {

                    String enderecoConexaoMySql = Constantes.enderecoDeConexaoMySql;

                    conexao = new MySqlConnection(enderecoConexaoMySql);

                    String sql = "SELECT id, nome FROM `bd_lixo_eletronico`.`bairro`"
                        + " WHERE id_cidade = " + ((Item)cmbCidade.SelectedItem).Id.ToString() + ";";
                    MySqlCommand comando = new MySqlCommand(sql, conexao);

                    conexao.Open();

                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        String nome = reader["nome"].ToString();

                        cmbBairro.Items.Add(new Item(id, nome));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível realizar consulta ao banco de dados.");
                }
                finally
                {
                    conexao.Close();
                }
            }
        }

        

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && txtLogradouro.Text != "" && txtNumero.Text != "" && cmbBairro.SelectedIndex != 0)
            {
                String nome = txtNome.Text;
                String logradouro = txtLogradouro.Text;
                String numero = txtNumero.Text;
                String idBairro = ((Item)cmbBairro.SelectedItem).Id.ToString();

                MySqlConnection conexao = null;

                try
                {
                    String enderecoConexaoMySql = Constantes.enderecoDeConexaoMySql;

                    conexao = new MySqlConnection(enderecoConexaoMySql);

                    String sql = "INSERT INTO `bd_lixo_eletronico`.`ponto_de_coleta` " +
                        "(`nome`,`logradouro`,`numero`, `id_bairro`) " +
                        "VALUES " +
                        "('" + nome + "', '" + logradouro + "', " + numero + ", " + idBairro + "); ";

                    MySqlCommand comando = new MySqlCommand(sql, conexao);

                    conexao.Open();

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Contato cadastrado com Sucesso!");

                    LimparCampos();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não é possível cadastrar o ponto de contato. Erro: " + ex.Message);
                }
                finally
                {
                    conexao.Close();
                }
            }
            else
            {
                MessageBox.Show("Os campos 'Nome', 'Logradouro', 'Número' e 'Bairro' são obrigatórios.");
            }
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarComboCidade();
        }

        private void cmbCidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarComboBairro();
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtLogradouro.Text = "";
            txtNumero.Text = "";

            CarregarComboEstado();
        }

    }
}
