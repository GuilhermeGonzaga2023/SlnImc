using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjMicroImc.classe
{
    public class operacao
    {
        public static double imc(double n1, double n2)
        {
            return Math.Round( n1 / (n2 * n2),2);

        }
        public static string menssagem(double resultado)
        {
            if (resultado < 20.7)
            {
                return "abaixo do peso";
            }
            else if (resultado > 20.7 && resultado < 26.4)
            {
                return "Peso Ideal";
            }
            else if (resultado > 26.5 && resultado < 27.8)
            {
                return "pouco acima do peso";
            }
            else if (resultado > 27.9 && resultado < 31.1)
            {
                return "acima do peso";
            }
            else
            {
                return "obesidade";
            }
        }
    }
}