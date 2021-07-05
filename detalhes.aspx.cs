using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using quartoesuite.App_Code;
using MySql.Data.MySqlClient;

namespace quartoesuite
{
    public partial class detalhes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!this.IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("default.aspx");
                }
                else
                {
                    if (buscaAnuncio() == false) {

                        Response.Redirect("https://www.naplantaimoveis.com.br/default.aspx?status=nao-encontrado", false);
                        Response.StatusCode = 301;
                        Response.End();
                    }

                    if (Request.QueryString["id_newsletter_relatorio"] != null)
                    {
                        updateNewsletterRelatorio();
                    }
                }
            }
        }
          
        protected bool buscaAnuncio()
        { 
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            bool retorno = false;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM anuncio, anuncio_edificacao, anuncio_contrato, anuncio_imovel, anuncio_sub_imovel, anuncio_situacao, usuario, usuario_nivel WHERE anuncio_edificacao.id = anuncio.id_edificacao AND anuncio_contrato.id = anuncio.id_contrato AND anuncio_imovel.id = anuncio.id_imovel AND anuncio_sub_imovel.id = anuncio.id_sub_imovel AND anuncio_situacao.id = anuncio.id_situacao AND anuncio.id = @id AND anuncio.status = @status AND usuario_nivel.id = usuario.id_nivel ", conn);
                cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);                
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    retorno = true;

                    while (rdr.Read())
                    {
                        Page.Title = classes.limiteCaracteres(70, rdr.GetString("imovel") + " " + rdr.GetString("sub_imovel") + " para " + rdr.GetString("contrato") + " - " + rdr.GetString("bairro") + " - " + rdr.GetString("cidade") + " - " + rdr.GetString("estado"));
                        Page.MetaDescription = classes.limiteCaracteres(300, rdr.GetString("imovel") + " " + rdr.GetString("sub_imovel") + " " + rdr.GetString("edificacao") + " para " + rdr.GetString("contrato") + ", " + rdr.GetString("quartos") + " quarto(s), " + rdr.GetString("suites") + " suíte(s), " + rdr.GetString("banheiros") + " banheiro(s), " + rdr.GetString("vagas") + " vaga(s) - Valor " + classes.real(rdr.GetString("valor")) + ", " + rdr.GetString("bairro") + " - " + rdr.GetString("cidade") + " - " + rdr.GetString("estado"));


                        //ltlEdificacao.Text = rdr.GetString("edificacao");
                        //ltlContrato.Text = rdr.GetString("contrato");
                        //ltlImovel.Text = rdr.GetString("imovel");
                        //ltlSubImovel.Text = rdr.GetString("sub_imovel");   

                        ltlTitulo.Text = classes.limiteCaracteres(70, rdr.GetString("imovel") + " " + rdr.GetString("sub_imovel") + " para " + rdr.GetString("contrato") + " - " + rdr.GetString("bairro") + " - " + rdr.GetString("cidade") + " - " + rdr.GetString("estado"));

                        //Anunciante                    
                        if (rdr.GetString("logo") != "")
                        {
                            imgLogo.ImageUrl = "../image/empresa/100/" + rdr.GetString("logo");
                            imgLogo.AlternateText = rdr.GetString("empresa");
                            imgLogo.ToolTip = rdr.GetString("empresa");
                        }
                        else
                        {
                            imgLogo.ImageUrl = "../image/empresa/100/foto.jpg";
                            imgLogo.AlternateText = rdr.GetString("empresa");
                            imgLogo.ToolTip = rdr.GetString("empresa");
                        }

                        ltlNivel.Text = rdr.GetString("nivel");
                        ltlEmpresa.Text = rdr.GetString("empresa");
                        ltlNome.Text = rdr.GetString("nome");
                        ltlCreci.Text = rdr.GetString("creci");

                        ltlTelefone.Text = rdr.GetString("telefone");
                        ltlCelular.Text = rdr.GetString("celular");
                        ltlEmail.Text = rdr.GetString("email");
                        ltlSite.Text = rdr.GetString("site");

                        //Código                    
                        ltlCodigoAnuncio.Text = rdr.GetString("codigo");

                        //Endereço
                        ltlCep.Text = rdr.GetString("cep");
                        ltlEndereco.Text = rdr.GetString("endereco");
                        ltlNumero.Text = rdr.GetString("numero");
                        ltlComplemento.Text = rdr.GetString("complemento");
                        ltlBairro.Text = rdr.GetString("bairro");
                        ltlCidade.Text = rdr.GetString("cidade");
                        ltlEstado.Text = rdr.GetString("estado");

                        //Caracteristicas
                        ltlAreaUtil.Text = rdr.GetString("area_util");
                        ltlAreaTotal.Text = rdr.GetString("area_total");
                        ltlPeDireito.Text = rdr.GetString("pe_direito");
                        ltlAndar.Text = rdr.GetString("andar");
                        ltlQuartos.Text = rdr.GetString("quartos");
                        ltlSuites.Text = rdr.GetString("suites");
                        ltlBanheiros.Text = rdr.GetString("banheiros");
                        ltlVagas.Text = rdr.GetString("vagas");


                        //Descrição 
                        ltlDescricao.Text = classes.limiteCaracteres(300, rdr.GetString("imovel") + " " + rdr.GetString("sub_imovel") + " " + rdr.GetString("edificacao") + " para " + rdr.GetString("contrato") + ", " + rdr.GetString("quartos") + " quarto(s), " + rdr.GetString("suites") + " suíte(s), " + rdr.GetString("banheiros") + " banheiro(s), " + rdr.GetString("vagas") + " - Valor " + classes.real(rdr.GetString("valor")) + ", " + rdr.GetString("bairro") + " - " + rdr.GetString("cidade") + " - " + rdr.GetString("estado")) + "<br/><br/>" + rdr.GetString("descricao");



                        //Valor
                        ltlEdificacao.Text = rdr.GetString("edificacao");
                        ltlContrato.Text = rdr.GetString("contrato");
                        ltlValor.Text = classes.real(rdr.GetString("valor"));
                        ltlValorCondominio.Text = classes.real(rdr.GetString("valor_condominio"));
                        ltlValorIptu.Text = classes.real(rdr.GetString("valor_iptu"));

                        buscaAnuncioFotos(Convert.ToInt32(rdr.GetString("id")));
                        buscaComodidade(rdr.GetString("comodidade"));
                        buscaPlanta(rdr.GetString("planta"));

                    }                   
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


            return retorno;
        }       

        protected void buscaAnuncioFotos(int id_anuncio)
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM anuncio_foto, anuncio, anuncio_situacao WHERE anuncio.id = anuncio_foto.id_anuncio AND anuncio_situacao.id = anuncio.id_situacao AND anuncio_foto.id_anuncio = @id_anuncio", conn);
                cmd.Parameters.AddWithValue("@id_anuncio", id_anuncio);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();                  

                if (rdr.HasRows)
                {
                    pnlFoto.Visible = true;

                    this.rpFotos.DataSource = rdr;
                    rpFotos.DataBind();                    
                }
                else
                {
                    pnlSemFoto.Visible = true;
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

        protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {            
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Reference the Repeater Item.
                RepeaterItem item = e.Item;

                //Reference the Controls.
                string srcActive = (item.FindControl("ltlActive") as Literal).Text;
                if (item.ItemIndex == 0)
                {
                    (item.FindControl("ltlActive") as Literal).Text = "active";
                }

                //Reference the Controls.
                string srcImage = (item.FindControl("ibtnImgAnuncio") as Image).ImageUrl;
                (item.FindControl("ibtnImgAnuncio") as Image).ImageUrl = "../image/anuncio/900/" + (item.FindControl("ibtnImgAnuncio") as Image).ImageUrl;
            }

            
        }        
                
        protected void buscaComodidade(string id)
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM anuncio_comodidade WHERE id IN (" + id + ") AND status=@status ORDER BY posicao ASC", conn);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    pnlComodidade.Visible = true;
                    this.rpComodidade.DataSource = rdr;
                    this.rpComodidade.DataBind();
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

        protected void buscaPlanta(string id)
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM anuncio_planta WHERE id IN (" + id + ") AND status=@status ORDER BY posicao ASC", conn);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    pnlPlanta.Visible = true;
                    this.rpPlanta.DataSource = rdr;
                    this.rpPlanta.DataBind();
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

        protected bool updateNewsletterRelatorio()
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update newsletter_relatorio set id_anuncio=@id_anuncio where id = @id";
                cmd.Parameters.AddWithValue("@id", Request.QueryString["id_newsletter_relatorio"]);
                cmd.Parameters.AddWithValue("@id_anuncio", Request.QueryString["id"]);                
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

            return true;
        }
    }
}