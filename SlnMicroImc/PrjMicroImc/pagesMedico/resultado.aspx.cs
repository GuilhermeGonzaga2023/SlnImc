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
    public partial class resultado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //pega informações da tela avaliacao que foram passadas por query string
            //lblNome.Text="nome: "+Request.QueryString["nome"];
            lblPeso.Text = "peso: "+Request.QueryString["peso"];
            lblAltura.Text = "altura: "+Request.QueryString["altura"];
            lblResultado.Text ="imc: "+Request.QueryString["resultado"];
            lblMensagem.Text = Request.QueryString["mensagem"];

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

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("avaliacao.aspx");
        }

        protected void btnCriarDieta_Click(object sender, EventArgs e)
        {
            Response.Redirect("dieta.aspx");
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