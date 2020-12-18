using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using quartoesuite.App_Code;
using MySql.Data.MySqlClient;

namespace quartoesuite
{
    public partial class blog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Blog | " + ConfigurationManager.AppSettings["titulo"];
            Page.MetaDescription = ConfigurationManager.AppSettings["descricao"];           

            buscaBlog();
        }

        protected void buscaBlog()
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM blog WHERE blog.status = @status ORDER BY blog.posicao DESC", conn);
                cmd.Parameters.AddWithValue("@status", 1);
                //cmd.Parameters.AddWithValue("@id_usuario", Session["idUsuario"].ToString());
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    this.rpBlog.DataSource = rdr;
                    rpBlog.DataBind();
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

        protected void rpBlogItemOnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Reference the Repeater Item.
                RepeaterItem item = e.Item;                

                string alt = DataBinder.Eval(e.Item.DataItem, "[\"titulo\"]").ToString();
                string url = "blog-" + DataBinder.Eval(e.Item.DataItem, "[\"titulo\"]").ToString() + "-" + DataBinder.Eval(e.Item.DataItem, "[\"id\"]").ToString();
                string img = "imovel.jpg";

                if (DataBinder.Eval(e.Item.DataItem, "[\"img\"]").ToString() != "") {

                    img = DataBinder.Eval(e.Item.DataItem, "[\"img\"]").ToString();
                }

                (item.FindControl("ltlTitulo") as Literal).Text = DataBinder.Eval(e.Item.DataItem, "[\"titulo\"]").ToString();
                (item.FindControl("ltlSubTitulo") as Literal).Text = "Por: " + DataBinder.Eval(e.Item.DataItem, "[\"autor\"]").ToString() + " em " + Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "[\"data\"]").ToString()).ToString("dd/MM/yyyy");

                (item.FindControl("ImgBlog") as Image).ImageUrl = "../image/anuncio/400/" + img;
                (item.FindControl("ImgBlog") as Image).AlternateText = alt;
                (item.FindControl("ImgBlog") as Image).ToolTip = alt;

                (item.FindControl("hlLeiaMais") as HyperLink).Text = "Leia mais";
                (item.FindControl("hlLeiaMais") as HyperLink).ToolTip = alt;
                (item.FindControl("hlLeiaMais") as HyperLink).NavigateUrl = classes.removerAcentos(url) + ".aspx";

            }
        }


    }
}