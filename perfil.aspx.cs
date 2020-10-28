using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
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
    public partial class perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Perfil | " + ConfigurationManager.AppSettings["titulo"];
            Page.MetaDescription = ConfigurationManager.AppSettings["descricao"];

            if (Session["idUsuario"] == null)
            {
                Response.Redirect("entrar.aspx?url=" + Request.ServerVariables["SCRIPT_NAME"] + "?" + Request.ServerVariables["QUERY_STRING"]);
            }

            if (!IsPostBack)
            {
                buscaNivel();
                buscaPerfil();
            }
        }

        protected void buscaNivel()
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuario_nivel WHERE posicao > 2 AND status=@status ORDER BY posicao ASC", conn);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                this.ddlPerfil.DataSource = rdr;
                this.ddlPerfil.DataValueField = "id";
                this.ddlPerfil.DataTextField = "nivel";
                ddlPerfil.DataBind();                

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

        protected void buscaPerfil()
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuario WHERE id = @id AND status = @status", conn);
                cmd.Parameters.AddWithValue("@id", Session["idUsuario"].ToString());
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    //perfil
                    ddlPerfil.SelectedValue = rdr.GetString("id_nivel");

                    //Empresa
                    txtEmpresa.Text = rdr["empresa"].ToString();
                    txtCnpj.Text = rdr["cnpj"].ToString();

                    if (rdr["logo"].ToString() != "")
                    {
                        imgLogo.ImageUrl = "image/empresa/100/" + rdr["logo"].ToString(); 
                        hfLogo.Value = rdr["logo"].ToString();
                    }
                    else
                    {
                        imgLogo.ImageUrl = "image/empresa/100/foto.jpg";
                        hfLogo.Value = "";
                    }

                    //Anunciante
                    txtNome.Text = rdr["nome"].ToString();
                    txtCpf.Text = rdr["cpf"].ToString();

                    txtCreci.Text = rdr["creci"].ToString();

                    //contato
                    txtTelefone.Text = rdr["telefone"].ToString();
                    txtCelular.Text = rdr["celular"].ToString();
                    txtSite.Text = rdr["site"].ToString();
                    txtEmail.Text = quartoesuite.App_Code.classes.Descriptografar(rdr["email"].ToString());
                    txtSenha.Text = quartoesuite.App_Code.classes.Descriptografar(rdr["senha"].ToString());
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

        protected string uploadLogo()
        {
            string srcImage = hfLogo.Value;
            string path = Server.MapPath("~/image/empresa/");
            string path50 = Server.MapPath("~/image/empresa/50/");
            string path100 = Server.MapPath("~/image/empresa/100/");
            string path200 = Server.MapPath("~/image/empresa/200/");
            string path400 = Server.MapPath("~/image/empresa/400/");
            string path600 = Server.MapPath("~/image/empresa/600/");
            string path900 = Server.MapPath("~/image/empresa/900/");

            try
            {
                if (Request.Files.Count > 0)
                {
                    HttpPostedFile postFile = Request.Files[0];

                    if (postFile.FileName != "")
                    {
                        srcImage = Session["idUsuario"].ToString() + Path.GetExtension(postFile.FileName);

                        if (Path.GetExtension(postFile.FileName) == ".jpg" || Path.GetExtension(postFile.FileName) == ".jpeg" || Path.GetExtension(postFile.FileName) == ".png" || Path.GetExtension(postFile.FileName) == ".gif")
                        {
                            postFile.SaveAs(path + srcImage);

                            quartoesuite.App_Code.resize.Resize(path + srcImage, path50 + srcImage, 50, 50);
                            quartoesuite.App_Code.resize.Resize(path + srcImage, path100 + srcImage, 100, 100);
                            quartoesuite.App_Code.resize.Resize(path + srcImage, path200 + srcImage, 200, 200);
                            quartoesuite.App_Code.resize.Resize(path + srcImage, path400 + srcImage, 400, 400);
                            quartoesuite.App_Code.resize.Resize(path + srcImage, path600 + srcImage, 600, 600);
                            quartoesuite.App_Code.resize.Resize(path + srcImage, path900 + srcImage, 900, 900);

                            System.IO.File.Delete(path + srcImage);
                        }
                        else
                        {
                            if (Page.IsValid)
                            {
                                vsPerfil.HeaderText = "Erro:";
                                vsPerfil.CssClass = "alert alert-danger";
                                cvLogo.IsValid = false;
                                cvLogo.ErrorMessage = "Formato da image jpg, gif, png";
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

            }

            return srcImage;
        }
       
        protected void lbtnExcluirLogo_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update usuario set logo = @logo where id = @id";
                cmd.Parameters.AddWithValue("@id", Session["idUsuario"].ToString());
                cmd.Parameters.AddWithValue("@logo", "");
                conn.Open();
                cmd.ExecuteNonQuery();
                
                buscaPerfil();
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
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update usuario set id_nivel = @id_nivel, logo = @logo, empresa = @empresa, cnpj = @cnpj, nome = @nome, cpf = @cpf, creci = @creci, telefone = @telefone, celular = @celular, site = @site, email = @email, senha = @senha where id = @id";
                cmd.Parameters.AddWithValue("@id", Session["idUsuario"].ToString());
                cmd.Parameters.AddWithValue("@id_nivel", ddlPerfil.SelectedValue);
                cmd.Parameters.AddWithValue("@logo", uploadLogo());                
                cmd.Parameters.AddWithValue("@empresa", txtEmpresa.Text);
                cmd.Parameters.AddWithValue("@cnpj", txtCnpj.Text);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
                cmd.Parameters.AddWithValue("@creci", txtCreci.Text);                
                //contato
                cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                cmd.Parameters.AddWithValue("@celular", txtCelular.Text);
                cmd.Parameters.AddWithValue("@site", txtSite.Text);
                cmd.Parameters.AddWithValue("@email", quartoesuite.App_Code.classes.Criptografar(txtEmail.Text));
                cmd.Parameters.AddWithValue("@senha", quartoesuite.App_Code.classes.Criptografar(txtSenha.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
                
                buscaPerfil();
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