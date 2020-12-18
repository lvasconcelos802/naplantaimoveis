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
    public partial class busca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Resultados da busca | " + ConfigurationManager.AppSettings["titulo"];
            Page.MetaDescription = ConfigurationManager.AppSettings["descricao"];

            if (Request.QueryString["bairro"] != null || Request.QueryString["cidade"] != null || Request.QueryString["estado"] != null)
            {                
                buscaAnuncioListaResultado();
            }
            else {

                buscaAnuncioLista();
            }
        }

        protected void buscaAnuncioListaResultado()
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT anuncio.id, anuncio_edificacao.edificacao, anuncio_contrato.contrato, anuncio_imovel.imovel, anuncio_sub_imovel.sub_imovel, anuncio.bairro, anuncio.cidade, anuncio.estado, anuncio.quartos, anuncio.suites, anuncio.banheiros, anuncio.vagas, anuncio.valor, anuncio.descricao, anuncio_situacao.situacao, anuncio.data_anuncio FROM anuncio, anuncio_edificacao, anuncio_contrato, anuncio_imovel, anuncio_sub_imovel, anuncio_situacao WHERE anuncio_edificacao.id = anuncio.id_edificacao AND anuncio_contrato.id = anuncio.id_contrato AND anuncio_imovel.id = anuncio.id_imovel AND anuncio_sub_imovel.id = anuncio.id_sub_imovel AND anuncio_situacao.id = anuncio.id_situacao AND anuncio.status = 1 AND anuncio.estado = @estado AND anuncio.cidade = @cidade AND anuncio.bairro LIKE @bairro ORDER BY estado ASC, cidade ASC ", conn);

                cmd.Parameters.AddWithValue("@bairro", Request.QueryString["bairro"] + "%");
                cmd.Parameters.AddWithValue("@cidade", Request.QueryString["cidade"]);
                cmd.Parameters.AddWithValue("@estado", Request.QueryString["estado"]);
                cmd.Parameters.AddWithValue("@status", 1);
                //cmd.Parameters.AddWithValue("@id_usuario", Session["idUsuario"].ToString());
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    this.rpAnuncioLista.DataSource = rdr;
                    rpAnuncioLista.DataBind();
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

        protected void buscaAnuncioLista()
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT anuncio.id, anuncio_edificacao.edificacao, anuncio_contrato.contrato, anuncio_imovel.imovel, anuncio_sub_imovel.sub_imovel, anuncio.bairro, anuncio.cidade, anuncio.estado, anuncio.quartos, anuncio.suites, anuncio.banheiros, anuncio.vagas, anuncio.valor, anuncio.descricao, anuncio_situacao.situacao, anuncio.data_anuncio FROM anuncio, anuncio_edificacao, anuncio_contrato, anuncio_imovel, anuncio_sub_imovel, anuncio_situacao WHERE anuncio_edificacao.id = anuncio.id_edificacao AND anuncio_contrato.id = anuncio.id_contrato AND anuncio_imovel.id = anuncio.id_imovel AND anuncio_sub_imovel.id = anuncio.id_sub_imovel AND anuncio_situacao.id = anuncio.id_situacao AND anuncio.status = 1 ORDER BY RAND() LIMIT 10", conn);
                cmd.Parameters.AddWithValue("@status", 1);
                //cmd.Parameters.AddWithValue("@id_usuario", Session["idUsuario"].ToString());
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    this.rpAnuncioLista.DataSource = rdr;
                    rpAnuncioLista.DataBind();
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

        protected void rpAnuncioListaItemOnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Reference the Repeater Item.
                RepeaterItem item = e.Item;

                string alt = DataBinder.Eval(e.Item.DataItem, "[\"imovel\"]").ToString() + " " + DataBinder.Eval(e.Item.DataItem, "[\"sub_imovel\"]").ToString() + " para " + DataBinder.Eval(e.Item.DataItem, "[\"contrato\"]").ToString() + " - " + DataBinder.Eval(e.Item.DataItem, "[\"bairro\"]").ToString() + " - " + DataBinder.Eval(e.Item.DataItem, "[\"cidade\"]").ToString() + " - " + DataBinder.Eval(e.Item.DataItem, "[\"estado\"]").ToString();
                string url = "imovel-" + DataBinder.Eval(e.Item.DataItem, "[\"imovel\"]").ToString() + "-" + DataBinder.Eval(e.Item.DataItem, "[\"sub_imovel\"]").ToString() + "-para-" + DataBinder.Eval(e.Item.DataItem, "[\"contrato\"]").ToString() + "-" + DataBinder.Eval(e.Item.DataItem, "[\"bairro\"]").ToString() + "-" + DataBinder.Eval(e.Item.DataItem, "[\"cidade\"]").ToString() + "-" + DataBinder.Eval(e.Item.DataItem, "[\"estado\"]").ToString() + "-" + DataBinder.Eval(e.Item.DataItem, "[\"id\"]").ToString();
                string img = "imovel.jpg";                

                (item.FindControl("ltlTitulo") as Literal).Text = DataBinder.Eval(e.Item.DataItem, "[\"imovel\"]").ToString() + " " + DataBinder.Eval(e.Item.DataItem, "[\"sub_imovel\"]").ToString() + " para " + DataBinder.Eval(e.Item.DataItem, "[\"contrato\"]").ToString() + " - " + DataBinder.Eval(e.Item.DataItem, "[\"bairro\"]").ToString() + " - " + DataBinder.Eval(e.Item.DataItem, "[\"cidade\"]").ToString() + " - " + DataBinder.Eval(e.Item.DataItem, "[\"estado\"]").ToString();
                   
                //(item.FindControl("ltlSubTitulo") as Literal).Text = "Publicado: " + Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "[\"data_anuncio\"]").ToString()).ToString("dd/MM/yyyy");

                (item.FindControl("ltlDescricao") as Literal).Text = DataBinder.Eval(e.Item.DataItem, "[\"imovel\"]").ToString() + " " + DataBinder.Eval(e.Item.DataItem, "[\"sub_imovel\"]").ToString() + " " + DataBinder.Eval(e.Item.DataItem, "[\"edificacao\"]").ToString() + " para " + DataBinder.Eval(e.Item.DataItem, "[\"contrato\"]").ToString() + ", " + DataBinder.Eval(e.Item.DataItem, "[\"quartos\"]").ToString() + " quarto(s), " + DataBinder.Eval(e.Item.DataItem, "[\"suites\"]").ToString() + " suíte(s), " + DataBinder.Eval(e.Item.DataItem, "[\"banheiros\"]").ToString() + " banheiro(s), " + DataBinder.Eval(e.Item.DataItem, "[\"vagas\"]").ToString() + " vaga(s) - Valor " + classes.real(DataBinder.Eval(e.Item.DataItem, "[\"valor\"]").ToString()) + ", " + DataBinder.Eval(e.Item.DataItem, "[\"bairro\"]").ToString() + " - " + DataBinder.Eval(e.Item.DataItem, "[\"cidade\"]").ToString() + " - " + DataBinder.Eval(e.Item.DataItem, "[\"estado\"]").ToString();

                (item.FindControl("ImgBlog") as Image).ImageUrl = "../image/anuncio/400/" + img;
                (item.FindControl("ImgBlog") as Image).AlternateText = alt;
                (item.FindControl("ImgBlog") as Image).ToolTip = alt;

                (item.FindControl("hlLeiaMais") as HyperLink).Text = "Leia mais";
                (item.FindControl("hlLeiaMais") as HyperLink).ToolTip = alt;
                (item.FindControl("hlLeiaMais") as HyperLink).NavigateUrl = classes.removerAcentos(url) + ".aspx";

            }
        }

        protected void bntBuscaSalvar_Click(object sender, EventArgs e)
        {
            string key = hidKey.Value;

            Response.Redirect("busca.aspx?" + key);
        }
    }
}