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


namespace quartoesuite
{
    public partial class cadastrar : System.Web.UI.Page
    {        
        public string email;
        public string senha;   

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Cadastrar | " + ConfigurationManager.AppSettings["titulo"];
            Page.MetaDescription = ConfigurationManager.AppSettings["descricao"];

            if (!this.IsPostBack)
            {
                buscaPerfil();
            }            
        }

        protected void buscaPerfil()
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

                ddlPerfil.Items.Insert(0, new ListItem("Selecione", ""));

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

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {

            email = quartoesuite.App_Code.classes.Criptografar(txtEmail.Text);
            senha = quartoesuite.App_Code.classes.Criptografar(txtSenha.Text);

            if (validarEmail())
            {
                Page.Validate();
                if (Page.IsValid)
                {
                    vsCadastrar.HeaderText = "Erro:";
                    cvEmail.IsValid = false;
                    cvEmail.ErrorMessage = "E-mail já está cadastrado";
                }
            }
            else
            {

                if (inserirCadastro())
                {

                    if (validarLogin())
                    {

                        if (Request.QueryString["url"] != null)
                        {
                            Response.Redirect(Request.QueryString["url"]);
                        }
                        else
                        {
                            Response.Redirect("perfil.aspx");
                        }
                    }
                };
            }

        }

        private bool validarEmail()
        {
            bool resposta = true;

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                conn.Open();

                string sql = "SELECT * FROM usuario WHERE email = @email AND status=@status ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@status", 1);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    //Este e-mail já está sendo ultilizado.
                    resposta = true;
                }
                else
                {
                    //Este e-mail está disponível.
                    resposta = false;
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

            return resposta;
        }

        private bool inserirCadastro()
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                String sql = "INSERT INTO usuario (id_nivel, id_pessoa, nome,email,senha,data,status) VALUES (@id_nivel, @id_pessoa, @nome,@email,@senha,@data,@status)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id_nivel", ddlPerfil.SelectedValue);
                cmd.Parameters.AddWithValue("@id_pessoa", 1);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@senha", senha); 
                cmd.Parameters.AddWithValue("@data", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@status", 1);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return true;
        }

        private bool validarLogin()
        {
            bool resposta = false;

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                string sql = "SELECT * FROM usuario WHERE email = @email AND senha = @senha AND status = @status ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@senha", senha);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    resposta = true;

                    while (rdr.Read())
                    {
                        Session["idUsuario"] = rdr.GetInt32("id");
                        Session["nivelUsuario"] = rdr.GetInt32("id_nivel");
                        Session["emailUsuario"] = rdr.GetString("email");
                        Session["nomeUsuario"] = rdr.GetString("nome");
                    }
                }
                else
                {
                    resposta = false;

                    Session["idUsuario"] = "";
                    Session["nivelUsuario"] = "";
                    Session["emailUsuario"] = "";
                    Session["nomeUsuario"] = "";
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

            return resposta;
        }

    }
}