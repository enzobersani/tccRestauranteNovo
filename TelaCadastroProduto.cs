﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TccRestaurante
{
    public partial class TelaCadastroProduto : Form
    {
        public TelaCadastroProduto()
        {
            InitializeComponent();
        }

        MySqlConnection sqlCon = null;
        private string strCon = "Server = localhost; Database=restaurantetcc;Uid=root;Pwd=";
        private string strSql = string.Empty;

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            txtCodigoProduto.Text = "";
            txtProduto.Text = "";
            txtDescProduto.Text = "";
            txtValorUnit.Text = "";
            txtEstoque.Text = "";
            txtCodigoFornecedor.Text = "";
            txtFornecedor.Text = "";
            txtCodigoProduto.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCodigoProduto.Text == "" || txtProduto.Text == "" || txtValorUnit.Text == "")
            {
                MessageBox.Show("Existem campos obrigatórios sem conteúdo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                strSql = "insert into produto (id, nomeProduto, descProduto, valorUnit, qtEstoque) " +
                    "values ('" + txtCodigoProduto.Text + "', '" + txtProduto.Text + "', '" + txtDescProduto.Text + "', '" + txtValorUnit.Text + "','" + txtEstoque.Text + "')";
                sqlCon = new MySqlConnection(strCon);
                MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                try
                {
                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Cadastro realizado com sucesso!");
                    txtCodigoProduto.Text = "";
                    txtProduto.Text = "";
                    txtDescProduto.Text = "";
                    txtValorUnit.Text = "";
                    txtEstoque.Text = "";
                    txtCodigoFornecedor.Text = "";
                    txtFornecedor.Text = "";
                    txtCodigoProduto.Focus();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Código de produto ja existente!");
                }
                finally
                {
                    sqlCon.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListaProduto listaProduto = new ListaProduto();
            listaProduto.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtCodigoProduto.Text == "")
            {
                MessageBox.Show("Existem campos obrigatórios sem conteúdo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                strSql = "DELETE FROM produto WHERE id = '" + txtCodigoProduto.Text + "'";
                sqlCon = new MySqlConnection(strCon);
                MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                try
                {
                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Produto exluído com sucesso!");
                    button1.Enabled = true;
                    txtCodigoProduto.Text = "";
                    txtProduto.Text = "";
                    txtDescProduto.Text = "";
                    txtValorUnit.Text = "";
                    txtEstoque.Text = "";
                    txtCodigoFornecedor.Text = "";
                    txtFornecedor.Text = "";
                    txtCodigoProduto.Focus();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlCon.Close();
                }
            }

        }

        private void txtCodigoProduto_Leave(object sender, EventArgs e)
        {
           if(txtCodigoProduto.Text != "")
            {
                
                strSql = "SELECT * FROM produto WHERE id='" + txtCodigoProduto.Text + "'";
                sqlCon = new MySqlConnection(strCon);

                try
                {
                    sqlCon.Open();

                    MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                    MySqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        button1.Enabled = false;
                        txtCodigoProduto.Text = reader.GetString(0);
                        txtProduto.Text = reader.GetString(1);
                        txtDescProduto.Text = reader.GetString(2);
                        txtValorUnit.Text = Convert.ToString(reader.GetDecimal(3));
                        txtEstoque.Text = Convert.ToString(reader.GetInt32(4));
                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlCon.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtCodigoProduto.Text == "" || txtProduto.Text == "" || txtValorUnit.Text == "")
            {
                MessageBox.Show("Existem campos obrigatórios sem conteúdo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                strSql = "UPDATE produto SET nomeProduto='" + txtProduto.Text + "', descProduto='" + txtDescProduto.Text + "'," +
                    " valorUnit='" + txtValorUnit.Text + "', qtEstoque='" + txtEstoque.Text + "' WHERE id='" + txtCodigoProduto.Text + "'";
                sqlCon = new MySqlConnection(strCon);
                MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                try
                {
                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Cadastro realizado com sucesso!");
                    txtCodigoProduto.Text = "";
                    txtProduto.Text = "";
                    txtDescProduto.Text = "";
                    txtValorUnit.Text = "";
                    txtEstoque.Text = "";
                    txtCodigoFornecedor.Text = "";
                    txtFornecedor.Text = "";
                    txtCodigoProduto.Focus();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Código de produto ja existente!");
                }
                finally
                {
                    sqlCon.Close();
                }
            }
        }

        private void txtCodigoProduto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

