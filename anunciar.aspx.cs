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
    public partial class anunciar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {  

            Page.Title = "Perfil | " + ConfigurationManager.AppSettings["titulo"];
            Page.MetaDescription = ConfigurationManager.AppSettings["descricao"];

            if (Session["idUsuario"] == null)
            {
                Response.Redirect("entrar.aspx?url=" + Request.ServerVariables["SCRIPT_NAME"] + "?" + Request.ServerVariables["QUERY_STRING"]);
            }

            if (!this.IsPostBack)
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    buscaAnuncio();
                }
                else
                {
                    buscaAnuncioId();
                }
            }
        }

        protected void redirecionaAnuncio(string id)
        {
            Response.Redirect("anunciar.aspx?id=" + id);
        }

        protected void buscaAnuncioId()
        {
            int id = 0;

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM anuncio WHERE id_usuario = @id_usuario AND status = @status ", conn);
                cmd.Parameters.AddWithValue("@id_usuario", Session["idUsuario"]);
                cmd.Parameters.AddWithValue("@status", 0);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        id = Convert.ToInt32(rdr["id"].ToString());
                    }

                    redirecionaAnuncio(id.ToString());
                }
                else
                {
                    inserirAnuncio();
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

        protected void buscaAnuncio()
        {
            buscaContrato();
            buscaEdificacao();
            buscaImovel();            
            buscaSubImovel();
            buscaSituacao();
            buscaComodidade();
            buscaPlanta();

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM anuncio WHERE id = @id AND id_usuario = @id_usuario ", conn);
                cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                cmd.Parameters.AddWithValue("@id_usuario", Session["idUsuario"]);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        txtTelefone.Text = rdr["telefone"].ToString();
                        txtCelular.Text = rdr["celular"].ToString();
                        txtEmail.Text = rdr["email"].ToString();

                        txtCep.Text = rdr["cep"].ToString();
                        txtEndereco.Text = rdr["endereco"].ToString();
                        txtNumero.Text = rdr["numero"].ToString();
                        txtComplemento.Text = rdr["complemento"].ToString();
                        txtBairro.Text = rdr["bairro"].ToString();
                        txtCidade.Text = rdr["cidade"].ToString();
                        txtEstado.Text = rdr["estado"].ToString();

                        txtDescricao.Text = rdr["descricao"].ToString();
                        txtValor.Text = rdr["valor"].ToString();
                        txtValorIptu.Text = rdr["valor_iptu"].ToString();
                        txtValorCondominio.Text = rdr["valor_condominio"].ToString();

                        txtQuartos.Text = rdr["quartos"].ToString();
                        txtBanheiros.Text = rdr["banheiros"].ToString();
                        txtSuites.Text = rdr["suites"].ToString();
                        txtVagas.Text = rdr["vagas"].ToString();
                        txtAreaUtil.Text = rdr["area_util"].ToString();
                        txtAreaTotal.Text = rdr["area_total"].ToString();
                        txtAndar.Text = rdr["andar"].ToString();
                        txtPeDireito.Text = rdr["pe_direito"].ToString();                        

                        ddlContrato.SelectedValue = rdr["id_contrato"].ToString();
                        ddlEdificacao.SelectedValue = rdr["id_edificacao"].ToString();
                        ddlImovel.SelectedValue = rdr["id_imovel"].ToString();
                        ddlSubImovel.SelectedValue = rdr["id_sub_imovel"].ToString();
                        ddlSituacao.SelectedValue = rdr["id_situacao"].ToString();
                        txtCodigo.Text = rdr["codigo"].ToString();

                        buscaAnuncioFotos(rdr["id"].ToString());                         

                        string[] comodidades = rdr["comodidade"].ToString().Split(',');
                        foreach (string comodidade in comodidades)
                        {
                            for (int i = 0; i < cblComodidade.Items.Count; i++)
                            {
                                if (cblComodidade.Items[i].Value == comodidade)
                                {
                                    cblComodidade.Items[i].Selected = true;
                                }
                            }
                        }

                        string[] plantas = rdr["planta"].ToString().Split(',');
                        foreach (string planta in plantas)
                        {
                            for (int i = 0; i < cblPlanta.Items.Count; i++)
                            {
                                if (cblPlanta.Items[i].Value == planta)
                                {
                                    cblPlanta.Items[i].Selected = true;
                                }
                            }
                        }
                    }
                }
                else
                {

                    Response.Redirect("meus-anuncios.aspx");
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

        protected void buscaAnuncioFotos(string id)
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM anuncio_foto WHERE id_anuncio = @id_anuncio AND status = @status ORDER BY posicao ASC", conn);
                cmd.Parameters.AddWithValue("@id_anuncio", id);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    this.rpFotos.DataSource = rdr;
                    rpFotos.DataBind();
                }
                else {

                    pnlFotos.Visible = true;                
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

        protected void buscaUsuario()
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuario WHERE id=@id AND status=@status", conn);
                cmd.Parameters.AddWithValue("@id", Session["idUsuario"].ToString());
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    txtTelefone.Text = rdr["telefone"].ToString();
                    txtCelular.Text = rdr["celular"].ToString();
                    txtEmail.Text = rdr["email"].ToString();
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

        protected void buscaContrato()
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM anuncio_contrato WHERE status=@status ORDER BY posicao ASC", conn);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                this.ddlContrato.DataSource = rdr;
                this.ddlContrato.DataValueField = "id";
                this.ddlContrato.DataTextField = "contrato";
                ddlContrato.DataBind();

                ddlContrato.Items.Insert(0, new ListItem("Selecione", ""));

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

        protected void buscaEdificacao()
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM anuncio_edificacao WHERE status=@status ORDER BY posicao ASC", conn);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                this.ddlEdificacao.DataSource = rdr;
                this.ddlEdificacao.DataValueField = "id";
                this.ddlEdificacao.DataTextField = "edificacao";
                ddlEdificacao.DataBind();

                ddlEdificacao.Items.Insert(0, new ListItem("Selecione", ""));

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

        protected void buscaImovel()
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM anuncio_imovel WHERE status=@status ORDER BY posicao ASC", conn);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                this.ddlImovel.DataSource = rdr;
                this.ddlImovel.DataValueField = "id";
                this.ddlImovel.DataTextField = "imovel";
                ddlImovel.DataBind();

                ddlImovel.Items.Insert(0, new ListItem("Selecione", ""));

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

        protected void buscaSubImovel()
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM anuncio_sub_imovel WHERE status=@status ORDER BY posicao ASC", conn);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                this.ddlSubImovel.DataSource = rdr;
                this.ddlSubImovel.DataValueField = "id";
                this.ddlSubImovel.DataTextField = "sub_imovel";
                ddlSubImovel.DataBind();

                ddlSubImovel.Items.Insert(0, new ListItem("Selecione", ""));

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

        protected void buscaSituacao()
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM anuncio_situacao WHERE status=@status ORDER BY posicao ASC", conn);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                this.ddlSituacao.DataSource = rdr;
                this.ddlSituacao.DataValueField = "id";
                this.ddlSituacao.DataTextField = "situacao";
                ddlSituacao.DataBind();

                ddlSituacao.Items.Insert(0, new ListItem("Selecione", ""));

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

        protected void buscaComodidade()
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM anuncio_comodidade WHERE status=@status ORDER BY posicao ASC", conn);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                this.cblComodidade.DataSource = rdr;
                this.cblComodidade.DataValueField = "id";
                this.cblComodidade.DataTextField = "comodidade";
                cblComodidade.DataBind();

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

        protected void buscaPlanta()
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM anuncio_planta WHERE status=@status ORDER BY posicao ASC", conn);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                this.cblPlanta.DataSource = rdr;
                this.cblPlanta.DataValueField = "id";
                this.cblPlanta.DataTextField = "planta";
                cblPlanta.DataBind();

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

        protected void anuncioStatus()
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update anuncio set status = @status where id = @id";
                cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
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

        private void inserirAnuncio()
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                String sql = "INSERT INTO anuncio (id_usuario, status) VALUES (@id_usuario, @status)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id_usuario", Session["idUsuario"]);
                cmd.Parameters.AddWithValue("@status", 0);
                conn.Open();
                cmd.ExecuteNonQuery();

                buscaAnuncioId();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }            
        }

        private void inserirFoto()
        {
            string tituloImage = "";
            string srcImage = "";
            string path = Server.MapPath("~/image/anuncio/");
            string path50 = Server.MapPath("~/image/anuncio/50/");
            string path100 = Server.MapPath("~/image/anuncio/100/");
            string path200 = Server.MapPath("~/image/anuncio/200/");
            string path300 = Server.MapPath("~/image/anuncio/300/");
            string path400 = Server.MapPath("~/image/anuncio/400/");
            string path600 = Server.MapPath("~/image/anuncio/600/");
            string path900 = Server.MapPath("~/image/anuncio/900/");

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                if (Request.Files.Count > 0)
                {
                    HttpPostedFile postFile = Request.Files[0];

                    if (postFile.FileName != "")
                    {
                        tituloImage = ddlImovel.SelectedItem + " " + ddlSubImovel.SelectedItem + " para " + ddlContrato.SelectedItem + " - " + txtBairro.Text + " - " + txtCidade.Text + " - " + txtEstado.Text;
                        srcImage = ddlImovel.SelectedItem + "-" + ddlSubImovel.SelectedItem + "-para-" + ddlContrato.SelectedItem + "-" + txtBairro.Text + "-" + txtCidade.Text + "-" + txtEstado.Text + "-" + Request.QueryString["id"] + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss");

                        srcImage = classes.removerAcentos(srcImage) + Path.GetExtension(postFile.FileName);

                        if (Path.GetExtension(postFile.FileName) == ".jpg" || Path.GetExtension(postFile.FileName) == ".jpeg" || Path.GetExtension(postFile.FileName) == ".png" || Path.GetExtension(postFile.FileName) == ".gif")
                        {
                            postFile.SaveAs(path + srcImage);

                            String sql = "INSERT INTO anuncio_foto (id_anuncio, titulo, foto, status) VALUES (@id_anuncio, @titulo, @foto, @status)";

                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@id_anuncio", Request.QueryString["id"]);
                            cmd.Parameters.AddWithValue("@titulo", tituloImage);
                            cmd.Parameters.AddWithValue("@foto", srcImage);
                            cmd.Parameters.AddWithValue("@status", 1);
                            conn.Open();
                            cmd.ExecuteNonQuery();

                            quartoesuite.App_Code.resize.Resize(path + srcImage, path50 + srcImage, 50, 50);
                            quartoesuite.App_Code.resize.Resize(path + srcImage, path100 + srcImage, 100, 100);
                            quartoesuite.App_Code.resize.Resize(path + srcImage, path200 + srcImage, 200, 200);
                            quartoesuite.App_Code.resize.Resize(path + srcImage, path300 + srcImage, 300, 300);
                            quartoesuite.App_Code.resize.Resize(path + srcImage, path400 + srcImage, 400, 400);
                            quartoesuite.App_Code.resize.Resize(path + srcImage, path600 + srcImage, 600, 600);
                            quartoesuite.App_Code.resize.Resize(path + srcImage, path900 + srcImage, 900, 900);

                            System.IO.File.Delete(path + srcImage);

                            anuncioStatus();
                            buscaAnuncio();
                        }
                        else
                        {
                            if (Page.IsValid)
                            {
                                vsAnuncio.HeaderText = "Erro:";
                                vsAnuncio.CssClass = "alert alert-danger";
                                cvFoto.IsValid = false;
                                cvFoto.ErrorMessage = "Formato da image jpg, jpeg, gif, png";
                            }
                        }

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
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
           
            string comodidade = "0,";
            string planta = "0,"; 

            for (int i = 0; i < cblComodidade.Items.Count; i++)
            {
                if (cblComodidade.Items[i].Selected)
                {
                    comodidade = comodidade + cblComodidade.Items[i].Value + ",";
                }
            }
            

            for (int i = 0; i < cblPlanta.Items.Count; i++)
            {
                if (cblPlanta.Items[i].Selected)
                {
                    planta = planta + cblPlanta.Items[i].Value + ",";
                }
            }

            comodidade = comodidade + "0";
            planta = planta + "0";

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update anuncio set telefone = @telefone, celular = @celular, email = @email, cep = @cep, endereco = @endereco, numero = @numero, complemento = @complemento, bairro = @bairro, cidade = @cidade, estado = @estado, quartos = @quartos, banheiros = @banheiros, suites = @suites, vagas = @vagas, area_util = @area_util, area_total = @area_total, andar = @andar, pe_direito = @pe_direito, descricao = @descricao, valor = @valor, valor_iptu = @valor_iptu, valor_condominio = @valor_condominio, id_contrato = @id_contrato, id_edificacao = @id_edificacao, id_imovel = @id_imovel, id_sub_imovel = @id_sub_imovel, id_situacao = @id_situacao, codigo = @codigo, comodidade = @comodidade, planta = @planta, status = @status where id = @id";
                cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                cmd.Parameters.AddWithValue("@celular", txtCelular.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@cep", txtCep.Text);
                cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                cmd.Parameters.AddWithValue("@numero", txtNumero.Text);
                cmd.Parameters.AddWithValue("@complemento", txtComplemento.Text);
                cmd.Parameters.AddWithValue("@bairro", txtBairro.Text);
                cmd.Parameters.AddWithValue("@cidade", txtCidade.Text);
                cmd.Parameters.AddWithValue("@estado", txtEstado.Text);
                cmd.Parameters.AddWithValue("@quartos", txtQuartos.Text);
                cmd.Parameters.AddWithValue("@banheiros", txtBanheiros.Text);
                cmd.Parameters.AddWithValue("@suites", txtSuites.Text);
                cmd.Parameters.AddWithValue("@vagas", txtVagas.Text);
                cmd.Parameters.AddWithValue("@area_util", txtAreaUtil.Text);
                cmd.Parameters.AddWithValue("@area_total", txtAreaTotal.Text);
                cmd.Parameters.AddWithValue("@andar", txtAndar.Text);
                cmd.Parameters.AddWithValue("@pe_direito", txtPeDireito.Text); 
                cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
                cmd.Parameters.AddWithValue("@valor", txtValor.Text);
                cmd.Parameters.AddWithValue("@valor_iptu", txtValorIptu.Text);
                cmd.Parameters.AddWithValue("@valor_condominio", txtValorCondominio.Text);
                cmd.Parameters.AddWithValue("@id_contrato", ddlContrato.SelectedValue);
                cmd.Parameters.AddWithValue("@id_edificacao", ddlEdificacao.SelectedValue);
                cmd.Parameters.AddWithValue("@id_imovel", ddlImovel.SelectedValue);
                cmd.Parameters.AddWithValue("@id_sub_imovel", ddlSubImovel.SelectedValue);
                cmd.Parameters.AddWithValue("@id_situacao", ddlSituacao.SelectedValue);
                cmd.Parameters.AddWithValue("@codigo", txtCodigo.Text);
                cmd.Parameters.AddWithValue("@comodidade", comodidade);
                cmd.Parameters.AddWithValue("@planta", planta);
                cmd.Parameters.AddWithValue("@status", 1);
                conn.Open();
                cmd.ExecuteNonQuery();

                inserirFoto();

                sitemap.criarSitemap();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();

                pnlSucesso.Visible = true;
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update anuncio set status = @status where id = @id";
                cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                cmd.Parameters.AddWithValue("@status", 2);
                conn.Open();
                cmd.ExecuteNonQuery();

                inserirFoto();

                sitemap.criarSitemap();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();

                Response.Redirect("meus-anuncios.aspx?status=sucesso");
            }

        }

        protected void ItemCommand(Object Sender, RepeaterCommandEventArgs e)
        {
            if (((LinkButton)e.CommandSource).CommandName == "excluir")
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
                try
                {
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "update anuncio_foto set status = @status where id = @id";
                    cmd.Parameters.AddWithValue("@id", ((LinkButton)e.CommandSource).CommandArgument);
                    cmd.Parameters.AddWithValue("@status", 0);
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    buscaAnuncio();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
                finally
                {
                    conn.Close();

                    pnlSucesso.Visible = true;
                }
            }
        }


    }
}