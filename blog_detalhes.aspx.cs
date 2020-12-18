using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;
using quartoesuite.App_Code;

namespace quartoesuite
{
    public partial class blog_detalhes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {                     

            if (!this.IsPostBack)
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    buscaArtigo();
                }                
            }
        }

        protected void buscaArtigo()
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM blog WHERE id = @id AND status = @status ", conn);
                cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                //cmd.Parameters.AddWithValue("@id_usuario", Session["idUsuario"]);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Page.Title = rdr["titulo"].ToString() + " | " + ConfigurationManager.AppSettings["titulo"];
                        Page.MetaDescription = classes.limiteCaracteres(300, rdr.GetString("texto"));

                        ltlTitulo.Text = rdr["titulo"].ToString();
                        ltlSubTitulo.Text = "Por: " + rdr["autor"].ToString() + " em " + Convert.ToDateTime(rdr["data"].ToString()).ToString("dd/MM/yyyy");
                        ltlTexto.Text = classes.quebraLinha(rdr["texto"].ToString());
                    }
                }
                else
                {
                    pnlVazio.Visible = true;
                }
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
    }
}