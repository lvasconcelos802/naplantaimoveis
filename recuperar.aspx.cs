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
    public partial class recuperar : System.Web.UI.Page
    {

        public string email;        

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Recuperar | " + ConfigurationManager.AppSettings["titulo"];
            Page.MetaDescription = ConfigurationManager.AppSettings["descricao"];
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            email = quartoesuite.App_Code.classes.Criptografar(txtEmail.Text);

            if (validarEmail())
            {

                if (enviarEmail())
                {
                    Page.Validate();
                    if (Page.IsValid)
                    {
                        vsRecuperar.HeaderText = "Sucesso:";
                        vsRecuperar.CssClass = "alert alert-success";
                        cvEmail.IsValid = false;
                        cvEmail.ErrorMessage = "E-mail enviado";
                    }
                };

            }
            else
            {
                Page.Validate();
                if (Page.IsValid)
                {
                    vsRecuperar.HeaderText = "Erro:";
                    vsRecuperar.CssClass = "alert alert-danger";
                    cvEmail.IsValid = false;
                    cvEmail.ErrorMessage = "E-mail não cadastrado";
                }
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
                    //Este e-mail está cadastrado.
                    resposta = true;
                }
                else
                {
                    //Este e-mail não está cadastrado.
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

        private bool enviarEmail()
        {            

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                string sql = "SELECT * FROM usuario WHERE email = @email AND status=@status ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    string to = "comercial@quartoesuite.com.br";//ConfigurationManager.AppSettings["emailTo"];
                    string from = "lvasconcelos802@gmail.com";//quartoesuite.App_Code.classes.Descriptografar(rdr.GetInt32("email").ToString());  //E-mail de remetente cadastrado.
                    string subject = "Recuperar senha";
                    string body = @"email:xxx senha:xxx";//@"e-mail: " + quartoesuite.App_Code.classes.Descriptografar(rdr.GetInt32("email").ToString()) + "<br>senha: " + quartoesuite.App_Code.classes.Descriptografar(rdr.GetInt32("senha").ToString()) + "<br><br>" + ConfigurationManager.AppSettings["titulo"];
                    MailMessage message = new MailMessage(from, to, subject, body);
                    SmtpClient client = new SmtpClient("mail.quartoesuite.com.br");
                    client.Credentials = CredentialCache.DefaultNetworkCredentials;
                    client.Send(message);  
                }

                rdr.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Console.Read();
            }

            return true;
        }


    }
}