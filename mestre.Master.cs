using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace quartoesuite
{
    public partial class mestre : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            

            if (!this.IsPostBack)
            {
                navebar();
            }
        }

        private void navebar()
        {

            if (Session["idUsuario"] == null)
            {
                hlPerfil.Visible = false;
                hlMeusAnuncios.Visible = false;
                hlNewsletter.Visible = false;
                //hlFavoritos.Visible = false;
                //hlMensagens.Visible = false;                
                hlAnunciar.Visible = true;
                hlEntrar.Visible = true;
                lbtnSair.Visible = false;
            }
            else
            {
                hlPerfil.Visible = true;
                hlMeusAnuncios.Visible = true;
                hlMeusAnuncios.Text = buscaMenuMeusAnuncios();
                hlNewsletter.Visible = true;

                //hlFavoritos.Visible = true;
                //hlMensagens.Visible = true;
                hlAnunciar.Visible = true;
                hlEntrar.Visible = false;
                lbtnSair.Visible = true;
            }
        }

        protected void lbtnSair_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("entrar.aspx");
        }

        protected string buscaMenuMeusAnuncios()
        {

            string retorno = "";

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM anuncio WHERE id_usuario = @id_usuario AND status = @status  ", conn);
                cmd.Parameters.AddWithValue("@status", 1);
                cmd.Parameters.AddWithValue("@id_usuario", Session["idUsuario"].ToString());
                MySqlDataReader rdr = cmd.ExecuteReader();

                int cont = 0;

                while (rdr.Read())
                {
                    cont++;
                }

                retorno = "Meus Anuncios <span class=\"badge badge-light\">" + cont.ToString() + "</span>";

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

            return retorno;
        }

    }
}