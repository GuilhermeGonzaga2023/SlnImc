using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*usar a classe operacoes*/
using PrjMicroImc.classe;
/*primeira coisa a se fazer para usar banco de daos*/
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PrjMicroImc.pagesUsuario
{
    public partial class suaAvaliacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie idUserPaciente = Request.Cookies["idPaciente"];

            SqlConnection conexao;
            conexao = new SqlConnection(ConfigurationManager.ConnectionStrings
            ["PrjMicroImc.Properties.Settings.strConexao"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader leitor;



            cmd.CommandText = "ps_Tudo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexao;



            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("idUsuario", idUserPaciente.Value);
            conexao.Open();

            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);//traduz a tabela que vem do banco de dados

            DataSet dados = new DataSet(); //cria um objeto para armazenar os dados na memoria


            adaptador.Fill(dados); //preencher o grid na tela com os dados do data set

            GridAvaPac.DataSource = dados;
            GridAvaPac.DataBind();

            leitor = cmd.ExecuteReader();


            if (leitor.HasRows)
            {
                leitor.Read();

                txtNomeUsu.Visible = true;
                txtNomeMedico.Visible = true;
                txtPeso.Visible = true;
                txtAltura.Visible = true;
                txtDieta.Visible = true;
                txtRestricoesDieta.Visible = true;
                txtDataAva.Visible = true;

                //txtNomeUsu.Text = leitor.GetString(0);
                //txtNomeMedico.Text = leitor.GetString(1);
                //txtPeso.Text = leitor.GetDecimal(2).ToString();
                //txtAltura.Text = leitor.GetDecimal(3).ToString();
                //txtDieta.Text = leitor.GetString(4);
                //txtRestricoesDieta.Text = leitor.GetString(5);
                //txtDataAva.Text = leitor.GetDateTime(6).ToString();
            }

            else
            {
                msgErro.Text = "PACIENTE NÃO TEM AVALIAÇÃO";
                msgErro.ForeColor = System.Drawing.Color.Red;
            }
            leitor.Close();
            conexao.Close();
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                txtPeso.Text = txtPeso.Text.Replace(".", ",");
                txtAltura.Text = txtAltura.Text.Replace(".", ",");

                //permiti fazer o calculo IMC e mostar o resultado puxando a classe operacao
                lblIMC.Text = operacao.imc(Convert.ToDouble(txtPeso.Text),Convert.ToDouble(txtAltura.Text)).ToString();

                lblResultado.Text = Convert.ToDouble(lblIMC.Text).ToString();
                lblResultado.Text = operacao.menssagem(Convert.ToDouble(lblResultado.Text));
            }
            catch (Exception)
            {
                msgErro.Text = "algum erro";
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("menuPaciente.aspx");
        }

        protected void GridAvaPac_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtNomeUsu.Text = HttpUtility.HtmlDecode(GridAvaPac.SelectedRow.Cells[1].Text);
                txtNomeMedico.Text = HttpUtility.HtmlDecode(GridAvaPac.SelectedRow.Cells[2].Text);
                txtPeso.Text = HttpUtility.HtmlDecode(GridAvaPac.SelectedRow.Cells[3].Text);
                txtAltura.Text = HttpUtility.HtmlDecode(GridAvaPac.SelectedRow.Cells[4].Text);
                txtDieta.Text = HttpUtility.HtmlDecode(GridAvaPac.SelectedRow.Cells[5].Text);
                txtRestricoesDieta.Text = HttpUtility.HtmlDecode(GridAvaPac.SelectedRow.Cells[6].Text);
                txtDataAva.Text = HttpUtility.HtmlDecode(GridAvaPac.SelectedRow.Cells[7].Text);
                lblData.Text = txtDataAva.Text;
                lblIMC.Text = "";
                lblResultado.Text = "";
            }
            catch (Exception ex)
            {
                msgErro.Text = ex.Message;
            }


        }

        protected void lbkAvaliacaoUsu_Click(object sender, EventArgs e)
        {
            Response.Redirect("../menuPaciente.aspx");
        }

        protected void lbkSair_Click(object sender, EventArgs e)
        {
            Response.Redirect("../default.aspx");
        }
    }
}