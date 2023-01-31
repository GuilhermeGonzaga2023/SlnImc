using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrjMicroImc.classe;
/*primeira coisa a se fazer para usar banco de daos*/
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.Security.Cryptography; //dll criptografia
using System.Text; //dll para trabalhar com textos


namespace PrjMicroImc
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            HttpCookie idUser = new HttpCookie("id");
            Response.Cookies.Add(idUser);

            HttpCookie idUserPaciente = new HttpCookie("idPaciente");
            Response.Cookies.Add(idUserPaciente);

            HttpCookie cookie = new HttpCookie("z");//criando cookie que armazena nome do usuário
            cookie.Value = txtLogin.Text;

            HttpCookie cookie2 = new HttpCookie("p");//cookie que armazena a senha
            cookie2.Value = txtSenha.Text;

            DateTime agora = DateTime.Now;//criando um objeto para retornar a data/hora atual
            TimeSpan tempo = new TimeSpan(0, 20, 0);//criando um tempo de expiração do cookie, no caso 20 minutos
            cookie.Expires = agora + tempo;//defini o tempo que o cookie vai expirar
            cookie2.Expires = agora + tempo;

            Response.Cookies.Add(cookie);//adicionando cookie no navegador
            Response.Cookies.Add(cookie2);//mesma coisa


            try
            {
                if (ddlPerfil.SelectedValue == "medico")
                {
                    SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings
                    ["PrjMicroImc.Properties.Settings.strConexao"].ToString());

                    SqlCommand cmd = new SqlCommand();
                    SqlDataReader leitor;

                    /*nome da procedure que quero executar*/
                    cmd.CommandText = "ps_validaLoginMedico";

                    /*tipo do comando, no caso é uma procedure*/
                    cmd.CommandType = CommandType.StoredProcedure;

                    /*nome que coloquei ali em cima*/
                    cmd.Connection = conexao;

                    senha sn = new senha();

                    /*parametros, o que vai ser passado para a procedure*/
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("loginMedico", txtLogin.Text);
                    cmd.Parameters.AddWithValue("SenhaMedico", sn.criarhash(txtSenha.Text));

                    string senhaArmazenada = txtSenha.Text;

                    conexao.Open();
                    leitor = cmd.ExecuteReader();
                    if (txtSenha.Text == senhaArmazenada)
                    {

                        if (leitor.HasRows)
                        {
                            leitor.Read();
                            idUser.Value = leitor.GetInt32(0).ToString();
                            conexao.Close();
                            leitor.Close();
                            Response.Redirect("pagesMedico/menuMedico.aspx");
                        }
                    }
                    else
                    {
                        conexao.Close();
                        leitor.Close();
                        lblMensagem.Text = "dados errados";
                    }

                }
                else if (ddlPerfil.SelectedValue == "paciente")
                {
                    SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings
                    ["PrjMicroImc.Properties.Settings.strConexao"].ToString());

                    SqlCommand cmd = new SqlCommand();
                    SqlDataReader leitor;

                    /*nome da procedure que quero executar*/
                    cmd.CommandText = "ps_validaLoginUsu";

                    /*tipo do comando, no caso é uma procedure*/
                    cmd.CommandType = CommandType.StoredProcedure;

                    /*nome que coloquei ali em cima*/
                    cmd.Connection = conexao;
                    senha sn = new senha();

                    /*parametros, o que vai ser passado para a procedure*/
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("loginUsu", txtLogin.Text);
                    cmd.Parameters.AddWithValue("SenhaUsu", sn.criarhash(txtSenha.Text));
                    //cmd.Parameters.AddWithValue("SenhaUsu", txtSenha.Text);

                    string senhaArmazenada = txtSenha.Text;

                    conexao.Open();
                    leitor = cmd.ExecuteReader();

                    if (txtSenha.Text == senhaArmazenada)
                    {

                        if (leitor.HasRows)
                        {
                            leitor.Read();
                            idUserPaciente.Value = leitor.GetInt32(0).ToString();
                            conexao.Close();
                            leitor.Close();
                            Response.Redirect("pagesUsuario/menuPaciente.aspx");
                        }

                    }
                    else
                    {
                        conexao.Close();
                        leitor.Close();
                        lblMensagem.Text = "dados errados";
                    }

                }
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;

            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlPerfil.SelectedValue == "medico")
                {
                    lblMensagem.Text = "Só pode ser feito cadastro de pacientes";

                }
                else if (ddlPerfil.SelectedValue == "paciente")
                {
                    Response.Redirect("pages/cadastrar.aspx");
                }
                else
                {
                    lblMensagem.Text = "Selecione paciente na lista acima";
                }

            }
            catch (Exception ex)
            {

                lblMensagem.Text = ex.Message;

            }
        }
    }
}