using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Net.Configuration;

namespace quartoesuite
{
    public partial class newsletter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Newsletter| " + ConfigurationManager.AppSettings["titulo"];
            Page.MetaDescription = ConfigurationManager.AppSettings["descricao"];

            if (Session["idUsuario"] == null)
            {
                Response.Redirect("entrar.aspx?url=" + Request.ServerVariables["SCRIPT_NAME"] + "?" + Request.ServerVariables["QUERY_STRING"]);
            }

            if (Request.QueryString["status"] == "sucesso")
            {
                pnlSucesso.Visible = true;
            }
            else if (Request.QueryString["status"] == "enviado")
            {
                pnlEnviado.Visible = true;
            }
            else if (Request.QueryString["status"] == "agendado")
            {
                pnlAgendado.Visible = true;
            }

            if (!this.IsPostBack)
            {
                buscaNewsletter();
            }
        }

        protected void buscaNewsletter()
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM newsletter WHERE newsletter.id_usuario = @id_usuario AND newsletter.status >= @status ORDER BY newsletter.id DESC", conn);
                cmd.Parameters.AddWithValue("@status", 1);
                cmd.Parameters.AddWithValue("@id_usuario", Session["idUsuario"].ToString());
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    this.rpNewsletter.DataSource = rdr;
                    rpNewsletter.DataBind();
                }
                else
                {

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

        protected void rpNewsletterItemOnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Reference the Repeater Item.
                RepeaterItem item = e.Item;

                string status = DataBinder.Eval(e.Item.DataItem, "[\"status\"]").ToString();
                string id = DataBinder.Eval(e.Item.DataItem, "[\"id\"]").ToString();



                //Reference the Controls.                
                if (status == "1")
                {
                    (item.FindControl("lbtNewsletterEditar") as LinkButton).Text = "Editar/Enviar";
                    (item.FindControl("lbtNewsletterEditar") as LinkButton).PostBackUrl = "newsletter_criar.aspx?id=" + id;
                    (item.FindControl("lbtNewsletterEditar") as LinkButton).Visible = true;

                    (item.FindControl("lblStatus") as Label).Text = "Pendente";
                    (item.FindControl("lblStatus") as Label).Visible = true;
                }
                else if(status == "2")
                {
                    (item.FindControl("lbtNewsletterEditar") as LinkButton).Text = "Visualizar";
                    (item.FindControl("lbtNewsletterEditar") as LinkButton).Visible = false;

                    (item.FindControl("lblStatus") as Label).Text = "Agendado";
                    (item.FindControl("lblStatus") as Label).Visible = true;
                }
                else if (status == "3")
                {
                    (item.FindControl("lbtNewsletterEditar") as LinkButton).Text = "Visualizar";
                    (item.FindControl("lbtNewsletterEditar") as LinkButton).Visible = false;

                    (item.FindControl("lblStatus") as Label).Text = "Enviado";
                    (item.FindControl("lblStatus") as Label).Visible = true;
                }

            }
        }
    }
}