using System;
using System.Web;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace quartoesuite
{
    /// <summary>
    /// Descrição resumida de busca1
    /// </summary>
    public class busca1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string texto = context.Request.QueryString["texto"];
            string callback = context.Request.QueryString["callback"];
            int customerId = 0;
            int.TryParse(context.Request.QueryString["customerId"], out customerId);
            string json = this.GetCustomersJSON(customerId, texto);
            if (!string.IsNullOrEmpty(callback))
            {
                json = string.Format("{0}({1});", callback, json);
            }

            context.Response.ContentType = "text/json";
            context.Response.Write(json);
        }

        private string GetCustomersJSON(int customerId, string texto)
        {
            List<object> customers = new List<object>();

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                //MySqlCommand cmd = new MySqlCommand("SELECT * FROM anuncio WHERE posicao = @posicao AND  status = @status ", conn);
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM anuncio WHERE bairro LIKE @texto OR cidade LIKE @texto OR estado LIKE @texto GROUP BY bairro ORDER BY estado ASC, cidade ASC, bairro ASC", conn);
                cmd.Parameters.AddWithValue("@texto", texto +"%");
                cmd.Parameters.AddWithValue("@posicao", 1);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                string url;

                while (rdr.Read())
                {
                    url = "bairro=" + rdr.GetString("bairro") + "&cidade=" + rdr.GetString("cidade") + "&estado=" + rdr.GetString("estado");

                    customers.Add(new
                    {  
                        key = url.ToLower(),
                        value = rdr.GetString("bairro") + " - " + rdr.GetString("cidade") + " - " + rdr.GetString("estado")                      
                        
                    });

                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                conn.Close();
            }

            return (new JavaScriptSerializer().Serialize(customers));
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