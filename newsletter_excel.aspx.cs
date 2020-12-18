using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using quartoesuite.App_Code;
using System.Text;

namespace quartoesuite
{
    public partial class newsletter_excel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            buscatabelaNewsletterEmail();
        }

        private void buscatabelaNewsletterEmail()
        {
            string id_anuncio = "0";
            int cont = 0;

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM newsletter_email WHERE id_usuario=@id_usuario AND status=@status ", conn);
                cmd.Parameters.AddWithValue("@id_usuario", 9);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();


                if (rdr.HasRows)
                {

                    while (rdr.Read())
                    {
                        cont++;
                        id_anuncio = id_anuncio + "," + rdr["id"].ToString();

                        //inserirTabelaNewsletterRelatorio("1", rdr["id"].ToString());
                    }

                    id_anuncio = id_anuncio + ",0";

                    updatetabelaNewsletter(id_anuncio);
                    Response.Write(cont.ToString());

                }
                

                rdr.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();
            }            

        }

        private void updatetabelaNewsletter(string id_email)
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update newsletter set id_email=@id_email where id = @id";
                cmd.Parameters.AddWithValue("@id_email", id_email);
                cmd.Parameters.AddWithValue("@id", "1");                
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();
            }           
        }

        private void inserirTabelaNewsletterRelatorio(string id_newsletter, string id_email)
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                String sql = "INSERT INTO newsletter_relatorio (id_newsletter, id_email, status) VALUES (@id_newsletter, @id_email, @status)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id_newsletter", id_newsletter);
                cmd.Parameters.AddWithValue("@id_email", id_email);
                cmd.Parameters.AddWithValue("@status", 1);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
              

        private void inserirExcel()
        {
            string email = "";
            
            String name = "mailing";
            String constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:/sites/naplantaimoveis/arquivo/mailing.xls;Extended Properties='Excel 8.0;HDR=YES;';";

            OleDbConnection con = new OleDbConnection(constr);
            OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
            con.Open();

            OleDbDataReader rdr = oconn.ExecuteReader();


            if (rdr.HasRows)
            {
                while (rdr.Read())               {

                    //inserir(rdr["nome"].ToString(), rdr["email"].ToString(), rdr["cidade"].ToString(), rdr["estado"].ToString());
                    //inserirTabelaNewsletterEmail(rdr["nome"].ToString().Trim(), rdr["email"].ToString().Trim(), rdr["cidade"].ToString().Trim(), rdr["estado"].ToString().Trim());
                }
            }
        }

        
    }
}