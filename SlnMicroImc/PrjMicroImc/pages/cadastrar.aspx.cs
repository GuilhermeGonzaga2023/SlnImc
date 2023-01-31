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

using System.Security.Cryptography; //dll criptografia
using System.Text; //dll para trabalhar com textos
using PrjMicroImc.classe; /*usar classe*/
using System.Globalization;

namespace PrjMicroImc
{
    public partial class cadastrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../default.aspx");

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings
                ["PrjMicroImc.Properties.Settings.strConexao"].ToString());

                SqlCommand cmd = new SqlCommand();

                /*nome da procedure que quero executar*/
                cmd.CommandText = "pi_Usuario";

                /*tipo do comando, no caso é uma procedure*/
                cmd.CommandType = CommandType.StoredProcedure;

                /*nome que coloquei ali em cima*/
                cmd.Connection = conexao;

                senha sn = new senha();


                if (txtNome.Text == "" || txtLogin.Text == "" || txtSenha.Text == "" || txtData.Text == "" || txtTelefone.Text == "")
                {
                    lblMensagem.Text = "preencha os campos corretamente";
                    txtNome.Text = "";
                    txtLogin.Text = "";
                    txtSenha.Text = "";
                    txtData.Text = "";
                    txtTelefone.Text = "";

                }
                else
                {
                    /*parametros, o que vai ser passado para a procedure*/
                    cmd.Parameters.AddWithValue("nomeUsu", txtNome.Text);
                    cmd.Parameters.AddWithValue("loginUsu", txtLogin.Text);
                    cmd.Parameters.AddWithValue("senhaUsu", sn.criarhash(txtSenha.Text));
                    //cmd.Parameters.AddWithValue("senhaUsu", txtSenha.Text);
                    cmd.Parameters.AddWithValue("dataNascimentoUsu", DateTime.Parse(txtData.Text, new CultureInfo("pt-BR")));
                    cmd.Parameters.AddWithValue("telefoneUsu", txtTelefone.Text);

                    conexao.Open();
                    cmd.ExecuteNonQuery();
                    lblMensagem.Text = "usuario registrado com sucesso";
                    txtNome.Text = "";
                    txtLogin.Text = "";
                    txtSenha.Text = "";
                    txtData.Text = "";
                    txtTelefone.Text = "";

                }
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
                txtNome.Text = "";
                txtLogin.Text = "";
                txtSenha.Text = "";
                txtData.Text = "";
                txtTelefone.Text = "";

            }
            //string[] dados = new string[] 
            //try
            //{
            //    if (txtNome.Text == "" || txtLogin.Text == "" || txtSenha.Text == "" || txtData.Text == "" || txtTelefone.Text == "")
            //    {
            //        lblMensagem.Text = "preencha os campos corretamente";
            //        txtNome.Text = "";
            //        txtLogin.Text = "";
            //        txtSenha.Text = "";
            //        txtData.Text = "";
            //        txtTelefone.Text = "";

            //    }
            //    else
            //    {
            //        login classe = new login();

            //        lblMensagem.Text = classe.cadastroPaciente(txtNome.Text, txtLogin.Text, txtSenha.Text, txtData.Text, txtTelefone.Text);

            //        lblMensagem.Text = "Paciente cadastrado";
            //        txtNome.Text = "";
            //        txtLogin.Text = "";
            //        txtSenha.Text = "";
            //        txtData.Text = "";
            //        txtTelefone.Text = "";

            //    }
            //}
            //catch (FormatException ex)
            //{
            //    lblMensagem.Text = "Erro: " + ex.Message;
            //}
        }
    }
}