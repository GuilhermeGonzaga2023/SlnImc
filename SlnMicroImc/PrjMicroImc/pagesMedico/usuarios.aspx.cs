using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*primeira coisa a se fazer para usar banco de daos*/
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using PrjMicroImc.classe; /*usar classe*/
using System.Globalization;

namespace PrjMicroImc.pages
{
    public partial class usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void lbkIMC_Click(object sender, EventArgs e)
        {
            Response.Redirect("avaliacao.aspx");
        }

        protected void lbkDieta_Click(object sender, EventArgs e)
        {
            Response.Redirect("dieta.aspx");
        }
        protected void lbkMedico_Click(object sender, EventArgs e)
        {
            Response.Redirect("medicos.aspx");
        }

        protected void lbkUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("usuarios.aspx");
        }


        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            SqlConnection conexao;
            conexao = new SqlConnection(ConfigurationManager.ConnectionStrings
            ["PrjMicroImc.Properties.Settings.strConexao"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader leitor;



            cmd.CommandText = "ps_Usuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexao;



            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("nomeUsu", txtPesquisarUsuario.Text);
            conexao.Open();

            leitor = cmd.ExecuteReader();


            if (leitor.HasRows)
            {
                leitor.Read();


                txtIdUsuario.Text = leitor.GetInt32(0).ToString();
                txtNomeUsu.Text = leitor.GetString(1);
                txtLoginUsu.Text = leitor.GetString(2);
                txtSenhaUsu.Text = leitor.GetString(3);
                txtDataNascimentoUsu.Text = leitor.GetDateTime(4).ToString("dd/MM/yyyy");
                txtTelefoneUsu.Text = leitor.GetString(5);

                if (txtPesquisarUsuario.Text == "")
                {
                    msgErro.Text = "Paciente não encontrado";

                    txtIdUsuario.Text = String.Empty;
                    txtNomeUsu.Text = String.Empty;
                    txtLoginUsu.Text = String.Empty;
                    txtSenhaUsu.Text = String.Empty;
                    txtDataNascimentoUsu.Text = String.Empty;
                    txtTelefoneUsu.Text = String.Empty;
                }
            }

            else
            {
                msgErro.Text = "Paciente não encontrado";

                txtIdUsuario.Text = String.Empty;
                txtNomeUsu.Text = String.Empty;
                txtLoginUsu.Text = String.Empty;
                txtSenhaUsu.Text = String.Empty;
                txtDataNascimentoUsu.Text = String.Empty;
                txtTelefoneUsu.Text = String.Empty;
            }

            leitor.Close();
            conexao.Close();

        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings
                ["PrjMicroImc.Properties.Settings.strConexao"].ToString());

                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "ps_Usuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conexao;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("nomeUsu", txtPesquisarUsuario.Text);

                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);//traduz a tabela que vem do banco de dados

                DataSet dados = new DataSet(); //cria um objeto para armazenar os dados na memoria


                adaptador.Fill(dados); //preencher o grid na tela com os dados do data set

                GridUsuarios.DataSource = dados;
                GridUsuarios.DataBind();

                if (dados.Tables[0].Rows.Count == 0)
                {
                    msgErro.Text = "nada por aqui...";

                }
                conexao.Close();
            }
            catch (Exception ex)
            {
                msgErro.Text = ex.Message;

            }

        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings
                ["PrjMicroImc.Properties.Settings.strConexao"].ToString());

                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "pd_Usuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conexao;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("loginUsu", txtLoginUsu.Text);

                if (txtLoginUsu.Text == "")
                {
                    msgErro.Text = "nenhum paciente excluido";
                }
                else
                {
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                    conexao.Close();
                    msgErro.Text = "Paciente excluido com sucesso!!!";
                    txtPesquisarUsuario.Text = String.Empty;
                    txtIdUsuario.Text = String.Empty;
                    txtNomeUsu.Text = String.Empty;
                    txtLoginUsu.Text = String.Empty;
                    txtSenhaUsu.Text = String.Empty;
                    txtDataNascimentoUsu.Text = String.Empty;
                    txtTelefoneUsu.Text = String.Empty;
                    lblNome.Text = String.Empty;

                }

            }
            catch (NullReferenceException)
            {
                msgErro.Text = "Problemas com a string de conexão do banco de dados!!!";
            }
            catch (SqlException)
            {
                msgErro.Text = "Problemas com acesso ao banco de dados!!!";
            }
            catch (Exception ex)
            {
                msgErro.Text = ex.HResult.ToString(); //"Erro desconhecido!!!;
            }

        }

        protected void btnAtuaizar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexao;
                conexao = new SqlConnection(ConfigurationManager.ConnectionStrings
                ["PrjMicroImc.Properties.Settings.strConexao"].ToString());
                SqlCommand cmd = new SqlCommand();



                cmd.CommandText = "pu_usuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conexao;

                //senha sn = new senha();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("idUsuario", txtIdUsuario.Text);
                cmd.Parameters.AddWithValue("nomeUsu", txtNomeUsu.Text);
                cmd.Parameters.AddWithValue("loginUsu", txtLoginUsu.Text);
                //cmd.Parameters.AddWithValue("senhaUsu", sn.criarhash(txtSenhaUsu.Text));
                cmd.Parameters.AddWithValue("senhaUsu", txtSenhaUsu.Text);
                cmd.Parameters.AddWithValue("dataNascimentoUsu", DateTime.Parse(txtDataNascimentoUsu.Text, new CultureInfo("pt-BR")));
                cmd.Parameters.AddWithValue("telefoneUsu", txtTelefoneUsu.Text);

                string senhaArmazenada = txtSenhaUsu.Text;

                conexao.Open();
                cmd.ExecuteNonQuery();
                conexao.Close();
                if (txtSenhaUsu.Text == senhaArmazenada)
                {
                    if (txtNomeUsu.Text == "" || txtLoginUsu.Text == "" || txtDataNascimentoUsu.Text == "" 
                        || txtTelefoneUsu.Text == "")
                    {
                        
                        msgErro.Text = "preencha os campos corretamente!!!";
                    }
                    else
                    {
                        
                        msgErro.Text = "Paciente atualizado com sucesso!!!";
                        txtPesquisarUsuario.Text = String.Empty;
                        txtIdUsuario.Text = String.Empty;
                        txtNomeUsu.Text = String.Empty;
                        txtLoginUsu.Text = String.Empty;
                        txtSenhaUsu.Text = String.Empty;
                        txtDataNascimentoUsu.Text = String.Empty;
                        txtTelefoneUsu.Text = String.Empty;
                        lblNome.Text = String.Empty;
                    }
                }
                else
                {
                    
                    msgErro.Text = "senha incorreta";
                    txtPesquisarUsuario.Text = String.Empty;
                    txtIdUsuario.Text = String.Empty;
                    txtNomeUsu.Text = String.Empty;
                    txtLoginUsu.Text = String.Empty;
                    txtSenhaUsu.Text = String.Empty;
                    txtDataNascimentoUsu.Text = String.Empty;
                    txtTelefoneUsu.Text = String.Empty;
                    lblNome.Text = String.Empty;
                }

            }
            catch (NullReferenceException)
            {
                msgErro.Text = "Problemas com a string de conexão do banco de dados!!!";
            }
            catch (SqlException)
            {
                msgErro.Text = "Problemas com acesso ao banco de dados!!!";
            }
            catch (Exception)
            {
                msgErro.Text = "Erro desconhecido!!!";
            }

        }
        protected void GridUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                HttpCookie idUserPaciente = new HttpCookie("idPaciente");
                Response.Cookies.Add(idUserPaciente);

                //idUserPaciente.Value = HttpUtility.HtmlDecode(GridUsuarios.SelectedRow.Cells[1].Text);
                txtIdUsuario.Text = HttpUtility.HtmlDecode(GridUsuarios.SelectedRow.Cells[1].Text);
                txtNomeUsu.Text = HttpUtility.HtmlDecode(GridUsuarios.SelectedRow.Cells[2].Text);
                lblNome.Text = txtNomeUsu.Text;
                txtLoginUsu.Text = HttpUtility.HtmlDecode(GridUsuarios.SelectedRow.Cells[3].Text);
                txtSenhaUsu.Text = HttpUtility.HtmlDecode(GridUsuarios.SelectedRow.Cells[4].Text);
                txtDataNascimentoUsu.Text = Convert.ToDateTime(HttpUtility.HtmlDecode(GridUsuarios.SelectedRow.Cells[5].Text)).ToString("dd/MM/yyyy");
                txtTelefoneUsu.Text = HttpUtility.HtmlDecode(GridUsuarios.SelectedRow.Cells[6].Text);

            }
            catch (Exception ex)
            {
                msgErro.Text = ex.Message;
            }

        }

        protected void lbkSair_Click(object sender, EventArgs e)
        {
            Response.Redirect("../default.aspx");

        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            txtPesquisarUsuario.Text = String.Empty;
            txtIdUsuario.Text = String.Empty;
            txtNomeUsu.Text = String.Empty;
            txtLoginUsu.Text = String.Empty;
            txtSenhaUsu.Text = String.Empty;
            txtDataNascimentoUsu.Text = String.Empty;
            txtTelefoneUsu.Text = String.Empty;
            lblNome.Text = String.Empty;
            msgErro.Text = String.Empty;
        }
    }
}