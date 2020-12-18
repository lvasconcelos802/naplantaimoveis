using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MySql.Data.MySqlClient;
using quartoesuite.App_Code;

namespace quartoesuite
{
    /// <summary>
    /// Descrição resumida de newsletter_click
    /// </summary>
    public class newsletter_click : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {


            if (context.Request.QueryString["id"] != "" && context.Request.QueryString["id"] != null)
            {

                string id = context.Request.QueryString["id"];

                if (updateNewsletterRelatorio(id) == true)
                {

                    context.Response.ContentType = "text/plain";
                    context.Response.Write("Atualizado");
                }
            }
        }

        public bool updateNewsletterRelatorio(string id)
        {


            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update newsletter_relatorio set click=@click, click_data=@click_data where id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@click", 1);
                cmd.Parameters.AddWithValue("@click_data", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                conn.Close();
            }

            return true;

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