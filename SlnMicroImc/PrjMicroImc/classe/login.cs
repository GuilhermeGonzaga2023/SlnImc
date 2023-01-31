//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
///*primeira coisa a se fazer para usar banco de daos*/
//using System.Data;
//using System.Data.SqlClient;
//using System.Configuration;

//using System.Security.Cryptography; //dll criptografia
//using System.Text; //dll para trabalhar com textos

//namespace PrjMicroImc.classe
//{
//    public class login
//    {
//        public string cadastroPaciente(string nome, string loginUsu, string senha, string dt, string tel)
//        {
//            try
//            {
//                SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings
//                ["PrjMicroImc.Properties.Settings.strConexao"].ToString());

//                SqlCommand cmd = new SqlCommand();

//                /*nome da procedure que quero executar*/
//                cmd.CommandText = "pi_Usuario";

//                /*tipo do comando, no caso é uma procedure*/
//                cmd.CommandType = CommandType.StoredProcedure;

//                /*nome que coloquei ali em cima*/
//                cmd.Connection = conexao;






//                /*criptografia da senha*/
//                MD5 criaCripto = MD5.Create();

//                //vetor byte
//                byte[] vetorByte = Encoding.ASCII.GetBytes(senha); //pegando a senha e transformando em vetor de byte
//                byte[] vetorHash = criaCripto.ComputeHash(vetorByte); //computeHash é quem vai criptografar o vetorByte

//                StringBuilder senhaCriptografado = new StringBuilder(); //

//                for (int i = 0; i < vetorHash.Length; i = i + 1)
//                {
//                    senhaCriptografado.Append(vetorHash[1].ToString("X2")); //para usar o append tem que usar o StringBuilder
//                    //cada vez que passar por aqui, vai aumentando
//                }







//                /*parametros, o que vai ser passado para a procedure*/
//                cmd.Parameters.AddWithValue("nomeUsu", nome);
//                cmd.Parameters.AddWithValue("loginUsu", loginUsu);
//                //cmd.Parameters.AddWithValue("senhaUsu", senhaCriptografado.ToString());
//                cmd.Parameters.AddWithValue("senhaUsu", senha);
//                cmd.Parameters.AddWithValue("dataNascimentoUsu", dt);
//                cmd.Parameters.AddWithValue("telefoneUsu", tel);

//                conexao.Open();
//                cmd.ExecuteNonQuery();
//                conexao.Close();
//                return "ok";
//            }
//            catch (SqlException ex)
//            {
//                //lblMensagem.Text = ex.Message;
//                return "Erro: " + ex.HResult;
//            }
//            catch (NullReferenceException)
//            {
//                return "problema com a conexão do bando de dados";

//            }
//            catch (FormatException ex)
//            {
//                return "Erro: " + ex.HResult + "" + ex.Message;

//            }

//        }
//        public string validarLoginUsuario(string login, string senha)
//        {
//            try
//            {                              
//                    SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings
//                    ["PrjMicroImc.Properties.Settings.strConexao"].ToString());

//                    SqlCommand cmd = new SqlCommand();
//                    SqlDataReader leitor;

//                    /*nome da procedure que quero executar*/
//                    cmd.CommandText = "ps_validaLoginUsu";

//                    /*tipo do comando, no caso é uma procedure*/
//                    cmd.CommandType = CommandType.StoredProcedure;

//                    /*nome que coloquei ali em cima*/
//                    cmd.Connection = conexao;

//                    /*parametros, o que vai ser passado para a procedure*/
//                    cmd.Parameters.Clear();
//                    cmd.Parameters.AddWithValue("loginUsu", login);
//                    cmd.Parameters.AddWithValue("SenhaUsu", senha);

//                    conexao.Open();
//                    leitor = cmd.ExecuteReader();

//                    if (leitor.HasRows)
//                    {
//                        leitor.Read();
//                        //idUserPaciente.Value = leitor.GetInt32(0).ToString();
//                        conexao.Close();
//                        leitor.Close();
//                        //Response.Redirect("pagesUsuario/menuPaciente.aspx");
//                        return "ok";

//                    }
//                    else
//                    {
//                        conexao.Close();
//                        leitor.Close();
//                        return "erro !";
//                    }
                
//            }

//            catch (SqlException ex)
//            {
//                //lblMensagem.Text = ex.Message;
//                return "Erro: " + ex.HResult;
//            }
//            catch (NullReferenceException)
//            {
//                return "problema com a conexão do bando de dados";

//            }
//            catch (FormatException ex)
//            {
//                return "Erro: " + ex.HResult + "" + ex.Message;

//            }

//        }
//        public string validarLoginMedico(string login, string senha)
//        {
//            try
//            {
//                SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings
//                ["PrjMicroImc.Properties.Settings.strConexao"].ToString());

//                SqlCommand cmd = new SqlCommand();
//                SqlDataReader leitor;

//                /*nome da procedure que quero executar*/
//                cmd.CommandText = "ps_validaLoginMedico";

//                /*tipo do comando, no caso é uma procedure*/
//                cmd.CommandType = CommandType.StoredProcedure;

//                /*nome que coloquei ali em cima*/
//                cmd.Connection = conexao;

//                /*parametros, o que vai ser passado para a procedure*/
//                cmd.Parameters.Clear();
//                cmd.Parameters.AddWithValue("loginMedico", login);
//                cmd.Parameters.AddWithValue("SenhaMedico", senha);

//                conexao.Open();
//                leitor = cmd.ExecuteReader();
//                if (leitor.HasRows)
//                {
//                    leitor.Read();
//                    //idUser.Value = leitor.GetInt32(0).ToString();

//                    conexao.Close();
//                    leitor.Close();
//                    return "ok";

//                    //Response.Redirect("pagesMedico/menuMedico.aspx");
//                }
//                else
//                {
//                    conexao.Close();
//                    leitor.Close();
//                    return "erro";
//                }

//            }
//            catch (SqlException ex)
//            {
//                //lblMensagem.Text = ex.Message;
//                return "Erro: " + ex.HResult;
//            }
//            catch (NullReferenceException)
//            {
//                return "problema com a conexão do bando de dados";

//            }
//            catch (FormatException ex)
//            {
//                return "Erro: " + ex.HResult + "" + ex.Message;

//            }

//        }

//    }
//}