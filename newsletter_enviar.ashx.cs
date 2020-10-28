using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using quartoesuite.App_Code;
using System.Configuration;

namespace quartoesuite
{
    /// <summary>
    /// Descrição resumida de newsletter_enviar
    /// </summary>
    public class newsletter_enviar : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                String sql = "INSERT INTO newsletter_teste (texto) VALUES (@texto)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@texto", DateTime.Now.ToString());
                conn.Open();
                cmd.ExecuteNonQuery();

                context.Response.ContentType = "text/plain";
                context.Response.Write("e-mail enviado");


                //context.Response.Redirect("https://www.naplantaimoveis.com.br/newsletter_enviar.ashx?status=2");
                //context.Response.StatusCode = 200;
                //context.Response.StatusCode = 200;
                //context.Response.SuppressContent = true;
                //HttpContext.Current.ApplicationInstance.CompleteRequest();




            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}