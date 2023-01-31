using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*primeira coisa a se fazer para usar banco de daos*/
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.Security.Cryptography; //dll criptografia
using System.Text; //dll para trabalhar com textos

namespace PrjMicroImc.classe
{
    public class senha
    {
        public string criarhash(string texto)
        {
            /*criptografia da senha*/
            MD5 criaCripto = MD5.Create();

            //vetor byte
            byte[] vetorByte = Encoding.ASCII.GetBytes(texto); //pegando a senha e transformando em vetor de byte
            byte[] vetorHash = criaCripto.ComputeHash(vetorByte); //computeHash é quem vai criptografar o vetorByte

            StringBuilder senhaCriptografado = new StringBuilder(); //transforma em texto novamente

            for (int i = 0; i < vetorHash.Length; i = i + 1)
            {
                senhaCriptografado.Append(vetorHash[1].ToString("X2")); //para usar o append tem que usar o StringBuilder
                                                                        //cada vez que passar por aqui, vai aumentando
            }
            return senhaCriptografado.ToString();
        }      
    }
}