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
    public partial class TelaDeBuscaPontosDeColeta : Form
    {
        public TelaDeBuscaPontosDeColeta()
        {
            InitializeComponent();
            ConfigurarLstPontosDeColeta();

        }

        private void ConfigurarLstPontosDeColeta()
        {
            lstPontosDeColeta.View = View.Details;
            lstPontosDeColeta.AllowColumnReorder = true;
            lstPontosDeColeta.FullRowSelect = true;
            lstPontosDeColeta.GridLines = true;

            lstPontosDeColeta.Columns.Add("id", 30, HorizontalAlignment.Left);
            lstPontosDeColeta.Columns.Add("nome", 150, HorizontalAlignment.Left);
            lstPontosDeColeta.Columns.Add("logradouro", 150, HorizontalAlignment.Left);
            lstPontosDeColeta.Columns.Add("numero", 150, HorizontalAlignment.Left);
            lstPontosDeColeta.Columns.Add("bairro", 150, HorizontalAlignment.Left);
            lstPontosDeColeta.Columns.Add("cidade", 150, HorizontalAlignment.Left);
            lstPontosDeColeta.Columns.Add("estado", 150, HorizontalAlignment.Left);
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            String textoBuscado = txtPesquisar.Text.Trim();

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
                    "WHERE bd_lixo_eletronico.ponto_de_coleta.nome like '%" + textoBuscado + "%' " +
                    "OR bd_lixo_eletronico.ponto_de_coleta.logradouro like '%" + textoBuscado + "%' " +
                    "OR bd_lixo_eletronico.bairro.nome like '%" + textoBuscado + "%' " +
                    "OR bd_lixo_eletronico.cidade.nome like '%" + textoBuscado + "%' " +
                    "OR bd_lixo_eletronico.estado.nome like '%" + textoBuscado + "%'" +
                    "ORDER BY bd_lixo_eletronico.ponto_de_coleta.id;";

                MySqlCommand comando = new MySqlCommand(sql, conexao);

                conexao.Open();

                MySqlDataReader reader = comando.ExecuteReader();

                lstPontosDeColeta.Items.Clear();

                while (reader.Read())
                {
                    string[] linha = new string[7];

                    linha[0] = reader["id"].ToString();
                    linha[1] = reader["nome"].ToString();
                    linha[2] = reader["logradouro"].ToString();
                    linha[3] = reader["numero"].ToString();
                    linha[4] = reader["bairro"].ToString();
                    linha[5] = reader["cidade"].ToString();
                    linha[6] = reader["estado"].ToString();

                    ListViewItem listViewItem = new ListViewItem(linha);

                    lstPontosDeColeta.Items.Add(listViewItem);
                }

                if (lstPontosDeColeta.Items.Count == 0)
                {
                    MessageBox.Show("Sua pesquisa não gerou resultados.");
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
}
