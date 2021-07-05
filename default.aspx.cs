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
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Imóveis para vender e alugar | " + ConfigurationManager.AppSettings["titulo"];
            Page.MetaDescription = ConfigurationManager.AppSettings["descricao"];

            if (!this.IsPostBack)
            {
                if (Request.QueryString["status"] == "nao-encontrado") {                     
                    pnlNaoEncontrado.Visible = true;
                }
                
                buscaAnuncio();
            }
        }

        private void buscaAnuncio()
        {

            //create Dataset:
            DataSet ds = new DataSet();

            //Create the "Letter" DataTable:
            DataTable dt = new DataTable();
            dt = dataTableLista();
            ds.Tables.Add(dt);

            DataTable dt2 = new DataTable();
            dt2 = dataTableListaItem();
            ds.Tables.Add(dt2);


            //Create Relation and Bind:
            ds.Relations.Add("myrelation", ds.Tables["lista"].Columns["id"], ds.Tables["listaItem"].Columns["id_lista_item"], false);

            rpLista.DataSource = ds.Tables["lista"];
            Page.DataBind();

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
                        foto = rdr.GetString("foto");
                    }
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

        private DataTable dataTableLista()
        {
            int cont = 0;

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            DataTable dtLista = new DataTable();

            try
            {
                dtLista.TableName = "lista";
                dtLista.Columns.Add("id", typeof(int));

                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM anuncio, usuario, usuario_nivel, anuncio_edificacao, anuncio_imovel, anuncio_sub_imovel, anuncio_contrato, anuncio_situacao WHERE anuncio_edificacao.id = anuncio.id_edificacao AND anuncio_imovel.id = anuncio.id_imovel AND anuncio_contrato.id = anuncio.id_contrato AND anuncio_sub_imovel.id = anuncio.id_sub_imovel AND anuncio_situacao.id = anuncio.id_situacao AND usuario.id = anuncio.id_usuario AND usuario_nivel.id = usuario.id_nivel AND anuncio.posicao = @posicao AND anuncio.status = @status ORDER BY anuncio.id ASC", conn);
                cmd.Parameters.AddWithValue("@posicao", 1);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    cont++;

                    if (cont == 1)
                    {
                        dtLista.Rows.Add(rdr.GetString("id"));
                    }

                    if (cont == 4)
                    {
                        cont = 0;
                    }
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


            return dtLista;

        }

        private DataTable dataTableListaItem()
        {
            int cont = 0;
            int idListaItem = 0;

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            DataTable dtListaItem = new DataTable();

            try
            {
                dtListaItem.TableName = "listaItem";
                dtListaItem.Columns.Add("id", typeof(int));
                dtListaItem.Columns.Add("id_lista_item", typeof(int));
                dtListaItem.Columns.Add("foto", typeof(string));
                dtListaItem.Columns.Add("imovel", typeof(string));
                dtListaItem.Columns.Add("sub_imovel", typeof(string));
                dtListaItem.Columns.Add("edificacao", typeof(string));
                dtListaItem.Columns.Add("contrato", typeof(string));
                dtListaItem.Columns.Add("situacao", typeof(string));
                dtListaItem.Columns.Add("bairro", typeof(string));
                dtListaItem.Columns.Add("cidade", typeof(string));
                dtListaItem.Columns.Add("estado", typeof(string));
                dtListaItem.Columns.Add("valor", typeof(string));
                dtListaItem.Columns.Add("area_util", typeof(string));
                dtListaItem.Columns.Add("quartos", typeof(string));
                dtListaItem.Columns.Add("banheiros", typeof(string));
                dtListaItem.Columns.Add("vagas", typeof(string));
                dtListaItem.Columns.Add("usuario_nivel", typeof(string));
                dtListaItem.Columns.Add("usuario_nome", typeof(string));
                dtListaItem.Columns.Add("usuario_empresa", typeof(string));
                dtListaItem.Columns.Add("data_aprovacao", typeof(string));

                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT anuncio.id, anuncio_imovel.imovel, anuncio_sub_imovel.sub_imovel, anuncio_edificacao.edificacao, anuncio_contrato.contrato, anuncio_situacao.situacao, anuncio.bairro, anuncio.cidade, anuncio.estado, anuncio.valor, anuncio.area_util, anuncio.quartos, anuncio.banheiros, anuncio.vagas, usuario_nivel.nivel, usuario.nome, usuario.empresa, anuncio.data_aprovacao FROM anuncio, usuario, usuario_nivel, anuncio_edificacao, anuncio_imovel, anuncio_sub_imovel, anuncio_contrato, anuncio_situacao WHERE anuncio_edificacao.id = anuncio.id_edificacao AND anuncio_imovel.id = anuncio.id_imovel AND anuncio_contrato.id = anuncio.id_contrato AND anuncio_sub_imovel.id = anuncio.id_sub_imovel AND anuncio_situacao.id = anuncio.id_situacao AND usuario.id = anuncio.id_usuario AND usuario_nivel.id = usuario.id_nivel AND anuncio.status = @status ORDER BY anuncio.id ASC", conn);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    cont++;

                    if (cont == 1)
                    {
                        idListaItem = Convert.ToInt32(rdr.GetString("id"));
                    }

                    dtListaItem.Rows.Add(rdr.GetString("id"), idListaItem, buscaAnuncioFoto(Convert.ToInt32(rdr.GetString("id"))), rdr.GetString("imovel"), rdr.GetString("sub_imovel"), rdr.GetString("edificacao"), rdr.GetString("contrato"), rdr.GetString("situacao"), rdr.GetString("bairro"), rdr.GetString("cidade"), rdr.GetString("estado"), rdr.GetString("valor"), rdr.GetString("area_util"), rdr.GetString("quartos"), rdr.GetString("banheiros"), rdr.GetString("vagas"), rdr.GetString("nivel"), rdr.GetString("nome"), rdr.GetString("empresa"), rdr.GetString("data_aprovacao"));

                    if (cont == 4)
                    {
                        cont = 0;
                    }
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


            return dtListaItem;

        }

        protected void rpListaOnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Reference the Repeater Item.
                RepeaterItem item = e.Item;

                //Reference the Controls.                
                if (item.ItemIndex == 0)
                {
                    (item.FindControl("pnlCarouselItem") as Panel).CssClass = "carousel-item active";
                }
                else
                {
                    (item.FindControl("pnlCarouselItem") as Panel).CssClass = "carousel-item";
                }
            }
        }

        protected void rpListaItemOnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Reference the Repeater Item.
                RepeaterItem item = e.Item;

                //Reference the Controls.                
                if (item.ItemIndex == 0)
                {
                    (item.FindControl("pnlCarouselItemCol") as Panel).CssClass = "col-md-3";
                }
                else
                {
                    (item.FindControl("pnlCarouselItemCol") as Panel).CssClass = "col-md-3 clearfix d-none d-md-block";
                }

                
                string alt = DataBinder.Eval(e.Item.DataItem, "[\"imovel\"]").ToString() + " " + DataBinder.Eval(e.Item.DataItem, "[\"sub_imovel\"]").ToString() + " para " + DataBinder.Eval(e.Item.DataItem, "[\"contrato\"]").ToString() + " - " + DataBinder.Eval(e.Item.DataItem, "[\"bairro\"]").ToString() + " - " + DataBinder.Eval(e.Item.DataItem, "[\"cidade\"]").ToString() + " - " + DataBinder.Eval(e.Item.DataItem, "[\"estado\"]").ToString();
                string url = "imovel-" + DataBinder.Eval(e.Item.DataItem, "[\"imovel\"]").ToString() + "-" + DataBinder.Eval(e.Item.DataItem, "[\"sub_imovel\"]").ToString() + "-para-" + DataBinder.Eval(e.Item.DataItem, "[\"contrato\"]").ToString() + "-" + DataBinder.Eval(e.Item.DataItem, "[\"bairro\"]").ToString() + "-" + DataBinder.Eval(e.Item.DataItem, "[\"cidade\"]").ToString() + "-" + DataBinder.Eval(e.Item.DataItem, "[\"estado\"]").ToString() + "-" + DataBinder.Eval(e.Item.DataItem, "[\"id\"]").ToString();

                (item.FindControl("ImgImovel") as Image).ImageUrl = "../image/anuncio/400/" + DataBinder.Eval(e.Item.DataItem, "[\"foto\"]").ToString();
                (item.FindControl("ImgImovel") as Image).AlternateText = alt;
                (item.FindControl("ImgImovel") as Image).ToolTip = alt;

                (item.FindControl("ltlImovel") as Literal).Text = DataBinder.Eval(e.Item.DataItem, "[\"imovel\"]").ToString();
                (item.FindControl("ltlSubImovel") as Literal).Text = DataBinder.Eval(e.Item.DataItem, "[\"sub_imovel\"]").ToString();
                (item.FindControl("ltlSituacao") as Literal).Text = DataBinder.Eval(e.Item.DataItem, "[\"situacao\"]").ToString();

                (item.FindControl("ltlSubTitulo") as Literal).Text = DataBinder.Eval(e.Item.DataItem, "[\"edificacao\"]").ToString() + " / " + DataBinder.Eval(e.Item.DataItem, "[\"contrato\"]").ToString();

                (item.FindControl("ltlValor") as Literal).Text = classes.real(DataBinder.Eval(e.Item.DataItem, "[\"valor\"]").ToString());
                
                (item.FindControl("ltlEndereco") as Literal).Text = DataBinder.Eval(e.Item.DataItem, "[\"bairro\"]").ToString() + " - " + DataBinder.Eval(e.Item.DataItem, "[\"cidade\"]").ToString() + " - " + DataBinder.Eval(e.Item.DataItem, "[\"estado\"]").ToString();

                (item.FindControl("ltlMedida") as Literal).Text = DataBinder.Eval(e.Item.DataItem, "[\"area_util\"]").ToString();
                (item.FindControl("ltlQuartos") as Literal).Text = DataBinder.Eval(e.Item.DataItem, "[\"quartos\"]").ToString();
                (item.FindControl("ltlBanheiros") as Literal).Text = DataBinder.Eval(e.Item.DataItem, "[\"banheiros\"]").ToString();
                (item.FindControl("ltlVagas") as Literal).Text = DataBinder.Eval(e.Item.DataItem, "[\"vagas\"]").ToString();

                (item.FindControl("ltlUsuarioNivel") as Literal).Text = DataBinder.Eval(e.Item.DataItem, "[\"usuario_nivel\"]").ToString();

                if (DataBinder.Eval(e.Item.DataItem, "[\"usuario_empresa\"]").ToString() != "")
                {
                    (item.FindControl("ltlUsuario") as Literal).Text = DataBinder.Eval(e.Item.DataItem, "[\"usuario_empresa\"]").ToString();
                }
                else
                {

                    (item.FindControl("ltlUsuario") as Literal).Text = DataBinder.Eval(e.Item.DataItem, "[\"usuario_nome\"]").ToString();
                }




                (item.FindControl("hlVerDetalhes") as HyperLink).Text = "Ver Detalhes";
                (item.FindControl("hlVerDetalhes") as HyperLink).ToolTip = alt;
                (item.FindControl("hlVerDetalhes") as HyperLink).NavigateUrl = classes.removerAcentos(url) + ".aspx";


                (item.FindControl("ltlData") as Literal).Text = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "[\"data_aprovacao\"]").ToString()).ToString("dd/MM/yyyy");


            }
        }

        protected void bntBuscaSalvar_Click(object sender, EventArgs e)
        {
            string key = hidKey.Value;

            Response.Redirect("busca.aspx?" + key);
        }
    }
}