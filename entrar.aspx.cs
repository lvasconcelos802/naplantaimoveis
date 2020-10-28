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
    public partial class entrar : System.Web.UI.Page
    {
        public string email;
        public string senha;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Entrar | " + ConfigurationManager.AppSettings["titulo"];
            Page.MetaDescription = ConfigurationManager.AppSettings["descricao"];
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            email = quartoesuite.App_Code.classes.Criptografar(txtEmail.Text);
            senha = quartoesuite.App_Code.classes.Criptografar(txtSenha.Text);

            if (validarLogin() == true)
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
            else
            {
                if (validarEmail())
                {
                    Page.Validate();
                    if (Page.IsValid)
                    {
                        vsEntrar.HeaderText = "Erro:";
                        cvSenha.IsValid = false;
                        cvSenha.ErrorMessage = "Senha errada";
                    }
                }
                else
                {

                    Page.Validate();
                    if (Page.IsValid)
                    {
                        vsEntrar.HeaderText = "Erro:";
                        cvEmail.IsValid = false;
                        cvEmail.ErrorMessage = "E-mail não cadastrado";
                    }
                }
            }
        }

        private bool validarLogin()
        {
            bool resposta = false;

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                string sql = "SELECT * FROM usuario WHERE email = @email AND senha = @senha AND status=@status ";
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
                        Session["idUsuario"] = rdr["id"].ToString();
                        Session["nivelUsuario"] = rdr["id_nivel"].ToString();
                        Session["emailUsuario"] = quartoesuite.App_Code.classes.Descriptografar(rdr["email"].ToString());
                        Session["nomeUsuario"] = rdr["nome"].ToString();
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

        private bool validarEmail()
        {
            bool resposta = false;

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                string sql = "SELECT * FROM usuario WHERE email=@email AND status=@status ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    resposta = true;
                }
                else
                {
                    resposta = false;
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