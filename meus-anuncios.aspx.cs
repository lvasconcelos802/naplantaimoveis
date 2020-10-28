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
    public partial class meus_anuncios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Meus Anúncios | " + ConfigurationManager.AppSettings["titulo"];
            Page.MetaDescription = ConfigurationManager.AppSettings["descricao"];

            if (Session["idUsuario"] == null)
            {
                Response.Redirect("entrar.aspx?url=" + Request.ServerVariables["SCRIPT_NAME"] + "?" + Request.ServerVariables["QUERY_STRING"]);
            }

            if (Request.QueryString["status"] == "sucesso") {

                pnlSucesso.Visible = true;
            }

            buscaAnuncios();
        }

        protected void buscaAnuncios()
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM anuncio, anuncio_edificacao, anuncio_contrato, anuncio_sub_imovel, anuncio_imovel, anuncio_situacao WHERE anuncio_edificacao.id = anuncio.id_edificacao AND anuncio_contrato.id = anuncio.id_contrato AND anuncio_imovel.id = anuncio.id_imovel AND anuncio_sub_imovel.id = anuncio.id_sub_imovel AND anuncio_situacao.id = anuncio.id_situacao AND anuncio.id_usuario = @id_usuario AND anuncio.status = @status ORDER BY anuncio.id DESC", conn);
                cmd.Parameters.AddWithValue("@status", 1);
                cmd.Parameters.AddWithValue("@id_usuario", Session["idUsuario"].ToString());
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    this.rAnuncios.DataSource = rdr;
                    rAnuncios.DataBind();
                }
                else {

                    pnlVazio.Visible = true;
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

        protected string buscaAnuncioFoto(int id_anuncio)
        {
            string foto = "imovel.jpg";

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM anuncio_foto WHERE id_anuncio = @id_anuncio AND status = @status ORDER BY id DESC ";
                cmd.Parameters.AddWithValue("@id_anuncio", id_anuncio);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        foto = rdr["foto"].ToString();
                    }
                }
                else {
                    
                    foto = "imovel.jpg";
                }

                rdr.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            finally
            {
                conn.Close();
            }

            return foto;
        }
    }
}