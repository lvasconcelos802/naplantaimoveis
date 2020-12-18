using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using quartoesuite.App_Code;
using System.Configuration;

namespace quartoesuite
{
    /// <summary>
    /// Descrição resumida de newsletter_enviar
    /// </summary>
    public class newsletter_enviar : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(buscaNewsletter());
        }

        private string buscaNewsletter()
        {
            string retorno = "";
            string id = "0";

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM newsletter WHERE status=@status ORDER BY id ASC LIMIT 80  ", conn);
                cmd.Parameters.AddWithValue("@status", 2);
                MySqlDataReader rdr = cmd.ExecuteReader();



                if (rdr.HasRows)
                {

                    while (rdr.Read())
                    {
                        id = rdr["id"].ToString();

                        retorno = buscaNewsletterRelatorio(id);
                    }

                }
                else
                {
                    retorno = "Nenhuma newsletter a ser enviada.";
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                conn.Close();
            }

            return retorno;


        }

        private string buscaNewsletterRelatorio(string id_newsletter)
        {

            string retorno = "";
            string id = "0";
            string remetenteNome = "";
            string remetenteEmail = "";
            string destinatarioNome = "";
            string destinatarioEmail = "";
            string assunto = "";
            string mensagem = "";
            int cont = 0;

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT newsletter_relatorio.id, newsletter.assunto, newsletter_email.nome as nome_destinatario, newsletter_email.email as email_destinatario, usuario.empresa as empresa_remetente, usuario.nome as nome_remetente, usuario.email as email_remetente FROM newsletter, newsletter_relatorio, newsletter_email, usuario WHERE newsletter_relatorio.id_newsletter = newsletter.id AND newsletter_email.id = newsletter_relatorio.id_email AND newsletter_email.status = @newsletter_email_status AND usuario.id = newsletter_email.id_usuario AND newsletter_relatorio.status=@status ORDER BY id ASC LIMIT 80  ", conn);
                cmd.Parameters.AddWithValue("@id_newsletter", id_newsletter);
                cmd.Parameters.AddWithValue("@newsletter_email_status", 1);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {

                    while (rdr.Read())
                    {
                        cont++;

                        if (rdr["empresa_remetente"].ToString() != "")
                        {
                            remetenteNome = rdr["empresa_remetente"].ToString();
                        }
                        else
                        {
                            remetenteNome = rdr["nome_remetente"].ToString();
                        }

                        id = rdr["id"].ToString();
                        remetenteEmail = rdr["email_remetente"].ToString();
                        destinatarioNome = rdr["nome_destinatario"].ToString();
                        destinatarioEmail = classes.Descriptografar(rdr["email_destinatario"].ToString());
                        assunto = rdr["assunto"].ToString();
                        mensagem = csNewsletter.criarNewsletterHtml(id_newsletter, id, destinatarioEmail);


                        csEnviarEmail.EnviaMensagem(remetenteNome, remetenteEmail, destinatarioNome, destinatarioEmail, assunto, mensagem);
                        updateNewsletterRelatorio(id);
                    }

                    retorno = cont.ToString() + " e-mail enviado.";

                }
                else
                {
                    updateNewsletter(id_newsletter);
                    buscaNewsletter();
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                conn.Close();
            }

            return retorno;
        }

        private bool updateNewsletter(string id)
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update newsletter set status=@status where id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@status", 3);
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

        private bool updateNewsletterRelatorio(string id)
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update newsletter_relatorio set status=@status where id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@status", 2);
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


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}