using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrjMicroImc.classe; /*usar classe*/
/*primeira coisa a se fazer para usar banco de daos*/
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.Security.Cryptography; //dll criptografia
using System.Text; //dll para trabalhar com textos


namespace PrjMicroImc
{
    public partial class imc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string login, senha;//criando variaveis para receber as informações
            try               
            {
                //resgata o cookie que foi criado em outra pagina
                HttpCookie cookie = Request.Cookies["z"];              
                login = cookie.Value.ToString();//igualei a variavel string ao cookie após conversão
                lblNome.Text = login;

                HttpCookie cookie2 = Request.Cookies["p"];
                senha = cookie2.Value.ToString();

            }
            catch (NullReferenceException)
            {
                Response.Redirect("../default.aspx");
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            txtPesquisar.Text = "";
            txtDataAvaliacao.Text = "";
            txtAltura.Text= "";
            txtPeso.Text = "";
            lblNomePaciente.Text = "";
        }

        protected void btnCriarAva_Click(object sender, EventArgs e)
        {
            double resultado;
            string mensagem;

            HttpCookie idUser = Request.Cookies["id"];
            HttpCookie idUserPaciente = Request.Cookies["idPaciente"];

            HttpCookie idAva = new HttpCookie("idAva");
            Response.Cookies.Add(idAva);

            try
            {
                txtPeso.Text=txtPeso.Text.Replace(".", ",");//reconhece tanto ponto como virgula 
                txtAltura.Text=txtAltura.Text.Replace(".", ",");
                SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings
                ["PrjMicroImc.Properties.Settings.strConexao"].ToString());

                SqlCommand cmd = new SqlCommand();

                /*nome da procedure que quero executar*/
                cmd.CommandText = "pi_Avaliacao";

                /*tipo do comando, no caso é uma procedure*/
                cmd.CommandType = CommandType.StoredProcedure;

                /*nome que coloquei ali em cima*/

                cmd.Connection = conexao;

                /*parametros, o que vai ser passado para a procedure*/             
                cmd.Parameters.AddWithValue("idMedico", Convert.ToInt32(idUser.Value));
                cmd.Parameters.AddWithValue("idUsuario", Convert.ToInt32(idUserPaciente.Value));
                cmd.Parameters.AddWithValue("dataAvaliacao", txtDataAvaliacao.Text);
                cmd.Parameters.AddWithValue("peso", Convert.ToDouble(txtPeso.Text));
                cmd.Parameters.AddWithValue("altura", Convert.ToDouble(txtAltura.Text));

                
                if (txtPeso.Text == "0" || txtAltura.Text == "0")
                {
                    lblMensagem.Text = "não é possivel dividir por 0";

                }
                else if (Convert.ToDouble(txtPeso.Text) >= 400 || Convert.ToDouble(txtAltura.Text) >= 3.00)
                {
                    lblMensagem.Text = "Números fora do normal";
                }
                else
                {                  
                     /*faz o calculo usando a classe*/
                    resultado = operacao.imc(Double.Parse(txtPeso.Text), Convert.ToDouble(txtAltura.Text));
                    //pega a mensagem da classe
                    mensagem = operacao.menssagem(Convert.ToDouble(resultado));
                    conexao.Open();

                    cmd.ExecuteNonQuery();

                    conexao.Close();

                    Response.Redirect("resultado.aspx?nome=" + lblNome.Text + "&peso=" + txtPeso.Text + "&altura=" + txtAltura.Text + "&resultado=" + resultado + "&mensagem=" + mensagem);
                    
                }
            }
            catch (FormatException)
            {
                lblMensagem.Text = "preencha os campos";
            }
            catch(SqlException ex) 
            {
                lblMensagem.Text = "erro " + ex.HResult;
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("menuMedico.aspx");
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

        protected void GridUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //ta criando o cookie para armazenar o id do paciente e permitir resgatar em outra tela
                HttpCookie idUserPaciente = new HttpCookie("idPaciente");
                Response.Cookies.Add(idUserPaciente);
                idUserPaciente.Value = HttpUtility.HtmlDecode(GridUsuarios.SelectedRow.Cells[1].Text);
                lblNomePaciente.Text = HttpUtility.HtmlDecode(GridUsuarios.SelectedRow.Cells[2].Text);
              
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }

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
                cmd.Parameters.AddWithValue("nomeUsu", txtPesquisar.Text);

                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);//traduz a tabela que vem do banco de dados

                DataSet dados = new DataSet(); //cria um objeto para armazenar os dados na memoria


                adaptador.Fill(dados); //preencher o grid na tela com os dados do data set

                GridUsuarios.DataSource = dados;
                GridUsuarios.DataBind();

                if (dados.Tables[0].Rows.Count == 0)
                {
                    lblMensagem.Text = "nada por aqui...";

                }
                conexao.Close();
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;

            }


        }

        protected void lbkSair_Click(object sender, EventArgs e)
        {
            Response.Redirect("../default.aspx");

        }

        protected void lbkDieta_Click(object sender, EventArgs e)
        {
            Response.Redirect("GerenciarDieta.aspx");

        }
    }
}