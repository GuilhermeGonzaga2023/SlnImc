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


namespace PrjMicroImc.pages
{
    public partial class dieta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void lbkIMC_Click(object sender, EventArgs e)
        {
            Response.Redirect("avaliacao.aspx");
        }

        protected void lbkMedico_Click(object sender, EventArgs e)
        {
            Response.Redirect("medicos.aspx");
        }

        protected void lbkUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("usuarios.aspx");
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
                //resgatando cookies de outras telas para usar aqui
                HttpCookie idUserPaciente = Request.Cookies["idPaciente"];              
                HttpCookie idUser = Request.Cookies["id"];
                HttpCookie idAva = Request.Cookies["idAva"];              
            try
            {

                SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings
                ["PrjMicroImc.Properties.Settings.strConexao"].ToString());
                SqlCommand cmd = new SqlCommand();

                /*nome da procedure que quero executar*/
                cmd.CommandText = "pi_Dieta";

                /////*tipo do comando, no caso é uma procedure*/
                cmd.CommandType = CommandType.StoredProcedure;

                /////*nome que coloquei ali em cima*/
                cmd.Connection = conexao;

                /////*parametros, o que vai ser passado para a procedure*/
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("idUsuario", Convert.ToInt32(idUserPaciente.Value));
                cmd.Parameters.AddWithValue("idMedico", Convert.ToInt32(idUser.Value));
                cmd.Parameters.AddWithValue("idAvaliacao", Convert.ToInt32(idAva.Value));
                cmd.Parameters.AddWithValue("restricoesAlimentares", txtRestricoes.Text);
                cmd.Parameters.AddWithValue("dieta", txtNomeDieta.Text);


                conexao.Open();
                cmd.ExecuteNonQuery();
                msgErro.Text = "dieta criada";
            }
            catch (SqlException ex)
            {
                msgErro.Text = ex.Message;
            }
            catch (NullReferenceException)
            {
                msgErro.Text = "Problemas com a string de conexão do banco de dados!!!";              
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("resultado.aspx");
        }

        protected void GridAvaliacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //armazenando ids em cookies para poder resgatar em outras telas
                HttpCookie idAva = new HttpCookie("idAva");
                Response.Cookies.Add(idAva);

                HttpCookie idUserPaciente = Request.Cookies["idPaciente"];
                Response.Cookies.Add(idUserPaciente);

                HttpCookie idUser = Request.Cookies["id"];
                Response.Cookies.Add(idUser);

                idAva.Value = HttpUtility.HtmlDecode(GridAvaliacao.SelectedRow.Cells[1].Text);
                idUserPaciente.Value = HttpUtility.HtmlDecode(GridAvaliacao.SelectedRow.Cells[2].Text);
                idUser.Value = HttpUtility.HtmlDecode(GridAvaliacao.SelectedRow.Cells[3].Text);

                lblNome.Text = HttpUtility.HtmlDecode(GridAvaliacao.SelectedRow.Cells[4].Text);             
            }
            catch (Exception ex)
            {
                msgErro.Text = ex.Message;
            }

        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            HttpCookie idAva = new HttpCookie("idAva");
            //filtrando avaliações por data porque foi a unica maneira que consegui
            try
            {
                SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings
                ["PrjMicroImc.Properties.Settings.strConexao"].ToString());

                SqlCommand cmd = new SqlCommand();


                cmd.CommandText = "ps_Ava";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conexao;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("nomeUsu", txtPesquisar.Text);

                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);//traduz a tabela que vem do banco de dados

                DataSet dados = new DataSet(); //cria um objeto para armazenar os dados na memoria


                adaptador.Fill(dados); //preencher o grid na tela com os dados do data set

                GridAvaliacao.DataSource = dados;
                GridAvaliacao.DataBind();
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

        protected void lbkSair_Click(object sender, EventArgs e)
        {
            Response.Redirect("../default.aspx");

        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            txtPesquisar.Text = "";
            txtNomeDieta.Text = "";
            txtRestricoes.Text = "";
            msgErro.Text = "";
        }

        protected void lbkDieta_Click(object sender, EventArgs e)
        {
            Response.Redirect("GerenciarDieta.aspx");

        }
    }
}