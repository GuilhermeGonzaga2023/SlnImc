using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjMicroImc.pages
{
    public partial class MenuPro : System.Web.UI.Page
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

        //protected void btnVoltar_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("../default.aspx");
        //}

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