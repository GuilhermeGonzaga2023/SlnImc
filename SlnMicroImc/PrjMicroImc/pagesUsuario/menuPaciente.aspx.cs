using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjMicroImc.pages
{
    public partial class menuCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbkAvaliacaoUsu_Click(object sender, EventArgs e)
        {
            Response.Redirect("suaAvaliacao.aspx");
        }
        protected void lbkSair_Click(object sender, EventArgs e)
        {
            Response.Redirect("../default.aspx");

        }
    }
}