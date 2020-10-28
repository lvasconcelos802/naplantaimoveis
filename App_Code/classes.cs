using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Globalization;

namespace quartoesuite.App_Code
{
    public class classes
    {
        public static string Criptografar(string valor)
        {
            string chaveCripto;
            Byte[] cript = System.Text.ASCIIEncoding.ASCII.GetBytes(valor);
            chaveCripto = Convert.ToBase64String(cript);
            return chaveCripto;


        }

        public static string Descriptografar(string valor)
        {
            string chaveCripto;
            Byte[] cript = Convert.FromBase64String(valor);
            chaveCripto = System.Text.ASCIIEncoding.ASCII.GetString(cript);
            return chaveCripto;

        }

        public static string removerAcentos(string texto)
        {

            string comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç /&";
            string semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc--e";

            for (int i = 0; i < comAcentos.Length; i++)
            {
                texto = texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
            }

            texto = texto.ToLower();

            return texto;
        }

        public static string primeiraMaiuscula(string input)
        {
            //if (String.IsNullOrEmpty(input))
            //    throw new ArgumentException("Insira uma palavra diferente de nula ou vazia");
            //return input.First().ToString().ToUpper() + input.Substring(1);4

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        public static string limiteCaracteres(int qtde, string texto) {

            if (texto.Length > qtde)
            {
                texto = texto.Substring(0, qtde);
                texto = texto + "...";
            }

            return texto;
        }

        public static string quebraLinha(string texto)
        { 

            texto = texto.Replace("\r\n", "<br>");

            return texto;
        }

        public static string dataDias(string texto)
        {
            string dataAtual = DateTime.Now.ToString("dd-MM-yyyy");
            string dataAnuncio = DateTime.Parse(texto).ToString("dd-MM-yyyy");

            TimeSpan date = Convert.ToDateTime(dataAtual) - Convert.ToDateTime(dataAnuncio);

            int totalDias = date.Days;

            texto = totalDias.ToString();  

            return texto;
        }

        public static string real(string texto) {
             
            double media = Convert.ToDouble(texto);
            texto = media.ToString("C");

            return texto;
        }
    }
}