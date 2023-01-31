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

namespace PrjMicroImc.pagesMedico
{
    public partial class GerenciarDieta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbkDieta_Click(object sender, EventArgs e)
        {
            Response.Redirect("GerenciarDieta.aspx");
        }
        protected void lbkSair_Click(object sender, EventArgs e)
        {
            Response.Redirect("../default.aspx");

        }
        protected void lbkUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("usuarios.aspx");

        }
        protected void lbkMedico_Click(object sender, EventArgs e)
        {
            Response.Redirect("medicos.aspx");

        }
        protected void lbkIMC_Click(object sender, EventArgs e)
        {
            Response.Redirect("avaliacao.aspx");

        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            txtPesquisar.Text = "";
            txtNomeDieta.Text = "";
            txtRestricoes.Text = "";
            msgErro.Text = "";

        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings
                ["PrjMicroImc.Properties.Settings.strConexao"].ToString());

                SqlCommand cmd = new SqlCommand();


                cmd.CommandText = "ps_Dieta";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conexao;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("nomeUsu", txtPesquisar.Text);

                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);//traduz a tabela que vem do banco de dados

                DataSet dados = new DataSet(); //cria um objeto para armazenar os dados na memoria


                adaptador.Fill(dados); //preencher o grid na tela com os dados do data set

                GridDieta.DataSource = dados;
                GridDieta.DataBind();
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
        protected void GridAvaliacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtIdDieta.Text = HttpUtility.HtmlDecode(GridDieta.SelectedRow.Cells[1].Text);
                lblNome.Text = HttpUtility.HtmlDecode(GridDieta.SelectedRow.Cells[2].Text);
                txtNomeDieta.Text = HttpUtility.HtmlDecode(GridDieta.SelectedRow.Cells[6].Text);
                txtRestricoes.Text = HttpUtility.HtmlDecode(GridDieta.SelectedRow.Cells[7].Text);
            }
            catch (Exception ex)
            {
                msgErro.Text = ex.Message;
            }


        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexao;
                conexao = new SqlConnection(ConfigurationManager.ConnectionStrings
                ["PrjMicroImc.Properties.Settings.strConexao"].ToString());
                SqlCommand cmd = new SqlCommand();



                cmd.CommandText = "pu_Dieta";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conexao;



                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("idDieta", txtIdDieta.Text);
                cmd.Parameters.AddWithValue("restricoesAlimentares", txtRestricoes.Text);
                cmd.Parameters.AddWithValue("dieta", txtNomeDieta.Text);

                conexao.Open();
                cmd.ExecuteNonQuery();
                conexao.Close();
                if (txtRestricoes.Text == "" || txtNomeDieta.Text == "")
                {
                    msgErro.Text = "preencha os campos corretamente!!";
                }
                else
                {
                    msgErro.Text = "dieta atulizada!!!";

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

    }
}