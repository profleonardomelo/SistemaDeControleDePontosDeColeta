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
    public partial class TelaDeExclusaoPontoDeColetas : Form
    {
        public TelaDeExclusaoPontoDeColetas()
        {
            InitializeComponent();
            BloquearComponente();
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

        private void BloquearComponente()
        {
            lblId.Enabled = true;
            txtId.Enabled = true;

            btnPesquisar.Enabled = true;

            lblNome.Enabled = false;
            lblLogradouro.Enabled = false;
            lblNumero.Enabled = false;
            lblEstado.Enabled = false;
            lblCidade.Enabled = false;
            lblBairro.Enabled = false;

            txtNome.Enabled = false;
            txtLogradouro.Enabled = false;
            txtNumero.Enabled = false;

            cmbEstado.Enabled = false;
            cmbCidade.Enabled = false;
            cmbBairro.Enabled = false;

            btnLimpar.Enabled = false;
            btnExcluir.Enabled = false;

        }

        private void DesbloquearComponentes()
        {
            lblId.Enabled = false;
            txtId.Enabled = false;

            btnPesquisar.Enabled = false;

            btnLimpar.Enabled = true;
            btnExcluir.Enabled = true;

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                String id = txtId.Text.Trim();

                MySqlConnection conexao = null;

                try
                {
                    String enderecoConexaoMySql = Constantes.enderecoDeConexaoMySql;

                    conexao = new MySqlConnection(enderecoConexaoMySql);

                    String sql = "SELECT bd_lixo_eletronico.ponto_de_coleta.id, " +
                        "bd_lixo_eletronico.ponto_de_coleta.nome, " +
                        "bd_lixo_eletronico.ponto_de_coleta.logradouro, " +
                        "bd_lixo_eletronico.ponto_de_coleta.numero, " +
                        "bd_lixo_eletronico.bairro.nome as 'bairro', " +
                        "bd_lixo_eletronico.cidade.nome as 'cidade', " +
                        "bd_lixo_eletronico.estado.nome as 'estado' " +
                        "FROM bd_lixo_eletronico.ponto_de_coleta " +
                        "INNER JOIN bd_lixo_eletronico.bairro " +
                        "ON bd_lixo_eletronico.ponto_de_coleta.id_bairro = bd_lixo_eletronico.bairro.id " +
                        "INNER JOIN bd_lixo_eletronico.cidade " +
                        "ON bd_lixo_eletronico.bairro.id_cidade = bd_lixo_eletronico.cidade.id " +
                        "INNER JOIN bd_lixo_eletronico.estado " +
                        "ON bd_lixo_eletronico.cidade.id_estado = bd_lixo_eletronico.estado.id " +
                        "WHERE bd_lixo_eletronico.ponto_de_coleta.id = " + id + ";";

                    MySqlCommand comando = new MySqlCommand(sql, conexao);

                    conexao.Open();

                    MySqlDataReader reader = comando.ExecuteReader();

                    int qtdeLinhas = 0;

                    while (reader.Read())
                    {
                        txtNome.Text = reader["nome"].ToString();
                        txtLogradouro.Text = reader["logradouro"].ToString();
                        txtNumero.Text = reader["numero"].ToString();

                        CarregarComboEstado();
                        cmbEstado.SelectedIndex = cmbEstado.FindStringExact(reader["estado"].ToString());

                        CarregarComboCidade();
                        cmbCidade.SelectedIndex = cmbCidade.FindStringExact(reader["cidade"].ToString());

                        CarregarComboBairro();
                        cmbBairro.SelectedIndex = cmbBairro.FindStringExact(reader["bairro"].ToString());

                        qtdeLinhas++;
                    }

                    if (qtdeLinhas == 0)
                    {
                        MessageBox.Show("Ponto de coleta não encontrado!");
                    }
                    else
                    {
                        DesbloquearComponentes();
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
            else
            {
                MessageBox.Show("O campo 'Id' é obrigatório para realizar a pesquisa.");
            }

        }

        private void LimparCampos()
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtLogradouro.Text = "";
            txtNumero.Text = "";

            CarregarComboEstado();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            BloquearComponente();
            LimparCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                String id = txtId.Text;

                MySqlConnection conexao = null;

                try
                {
                    String enderecoConexaoMySql = Constantes.enderecoDeConexaoMySql;

                    conexao = new MySqlConnection(enderecoConexaoMySql);

                    String sql = "DELETE FROM `bd_lixo_eletronico`.`ponto_de_coleta` " +
                        "WHERE `id` = " + id + ";";

                    MySqlCommand comando = new MySqlCommand(sql, conexao);

                    conexao.Open();

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Ponto de Coleta excluído com sucesso!");

                    BloquearComponente();
                    LimparCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não possível excluir o ponto de coleta. Erro: " + ex.Message);
                }
                finally
                {
                    conexao.Close();
                }
            }
            else
            {
                MessageBox.Show("O campo Id é obrigatório.");
            }

        }
    }
}
