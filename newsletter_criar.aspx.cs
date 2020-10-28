using System;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Net.Configuration;
using quartoesuite.App_Code;
using System.Reflection.Emit;

namespace quartoesuite
{
    public partial class newsletter_criar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {         
            //Response.Write()


            if (Session["idUsuario"] == null)
            {
                Response.Redirect("entrar.aspx?url=" + Request.ServerVariables["SCRIPT_NAME"] + "?" + Request.ServerVariables["QUERY_STRING"]);
            }

            if (!this.IsPostBack)
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    buscaNewsletter();                    
                }
                else
                {
                    buscaNewsletterId();
                }                             
            }
        }

        protected void buscaNewsletter()
        {

            string idAnuncios = "0";

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM newsletter WHERE id = @id AND id_usuario = @id_usuario AND status = @status", conn);
                cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                cmd.Parameters.AddWithValue("@id_usuario", Session["idUsuario"]);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        txtAssunto.Text = rdr["assunto"].ToString();
                        txtMensagem.Text = rdr["mensagem"].ToString();
                        idAnuncios = rdr["id_anuncio"].ToString();
                    }
                }

                buscaListaEmail();
                buscaListaAnuncio();
                ltlNewsletterVisualizar.Text = newsletterHtml();

                int qtdEmails = 0;                
                int qtdAnuncios = 0;                

                string[] emails = rdr["id_email"].ToString().Split(',');
                foreach (string idEmail in emails)
                {
                    for (int i = 0; i <= rpListaEmail.Items.Count - 1; i++)
                    {
                       
                        RepeaterItem item = rpListaEmail.Items[i];
                        CheckBox cbEmail = (CheckBox)item.FindControl("cbEmail");
                        HiddenField hfIdEmail = (HiddenField)item.FindControl("hfIdEmail");

                        if (idEmail == hfIdEmail.Value)
                        {

                            qtdEmails++;
                            cbEmail.Checked = true;
                        }
                    }
                }

                string[] anuncios = rdr["id_anuncio"].ToString().Split(',');
                foreach (string idAnuncio in anuncios)
                {
                    for (int i = 0; i <= rpListaAnuncio.Items.Count - 1; i++)
                    {                       

                        RepeaterItem item = rpListaAnuncio.Items[i];
                        CheckBox cbAnuncio = (CheckBox)item.FindControl("cbAnuncio");
                        HiddenField hfIdAnuncio = (HiddenField)item.FindControl("hfIdAnuncio");

                        if (idAnuncio == hfIdAnuncio.Value)
                        {

                            qtdAnuncios++;
                            cbAnuncio.Checked = true;
                        }
                    }
                }

                lblQtdeEmail.Text = qtdEmails.ToString();
                lblQtdeAnuncio.Text = qtdAnuncios.ToString();

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

        protected void buscaNewsletterId()
        {
            int id = 0;

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM newsletter WHERE id_usuario = @id_usuario AND status = @status ORDER BY id ASC ", conn);
                cmd.Parameters.AddWithValue("@id_usuario", Session["idUsuario"]);                
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        id = Convert.ToInt32(rdr["id"].ToString());
                    }

                    Response.Redirect("newsletter_criar.aspx?id=" + id.ToString());                    
                }
                else
                {
                    inserirNewsletter();                    
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

        protected void buscaListaEmail()
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM newsletter_email WHERE status=@status ORDER BY id DESC, email ASC", conn);
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                this.rpListaEmail.DataSource = rdr;
                rpListaEmail.DataBind();

                lblQtdeTotalEmail.Text = rpListaEmail.Items.Count.ToString();

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

        protected void buscaListaAnuncio()
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM anuncio, anuncio_edificacao, anuncio_contrato, anuncio_sub_imovel, anuncio_imovel, anuncio_situacao WHERE anuncio_edificacao.id = anuncio.id_edificacao AND anuncio_contrato.id = anuncio.id_contrato AND anuncio_imovel.id = anuncio.id_imovel AND anuncio_sub_imovel.id = anuncio.id_sub_imovel AND anuncio_situacao.id = anuncio.id_situacao AND anuncio.id_usuario = @id_usuario AND anuncio.status = @status ORDER BY anuncio.id DESC", conn);
                cmd.Parameters.AddWithValue("@status", 1);
                cmd.Parameters.AddWithValue("@id_usuario", Session["idUsuario"].ToString());
                MySqlDataReader rdr = cmd.ExecuteReader();

                this.rpListaAnuncio.DataSource = rdr;
                rpListaAnuncio.DataBind();

                lblQtdeTotalAnuncio.Text = rpListaAnuncio.Items.Count.ToString();

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
                        foto = rdr["foto"].ToString();
                    }
                }
                else
                {

                    foto = "imovel.jpg";
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

        private void inserirNewsletter()
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                String sql = "INSERT INTO newsletter (id_usuario, status) VALUES (@id_usuario, @status)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id_usuario", Session["idUsuario"]);               
                cmd.Parameters.AddWithValue("@status", 1);
                conn.Open();
                cmd.ExecuteNonQuery();

                buscaNewsletterId();
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

        private bool inserirNewsletterRelatorio(int id_newsletter, int id_email)
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO newsletter_relatorio (id_newsletter, id_email, status) VALUES (@id_newsletter, @id_email, @status)";
                cmd.Parameters.AddWithValue("@id_newsletter", id_newsletter);
                cmd.Parameters.AddWithValue("@id_email", id_email);                                         
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

        private bool agendarNewsletter()
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update newsletter set status=@status where id = @id";
                cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
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

        protected bool newsletterSalvar()
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update newsletter set assunto = @assunto, mensagem = @mensagem where id = @id";
                cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                cmd.Parameters.AddWithValue("@assunto", txtAssunto.Text);
                cmd.Parameters.AddWithValue("@mensagem", txtMensagem.Text);
                conn.Open();
                cmd.ExecuteNonQuery();

                buscaNewsletter();
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

        protected void bntContatosAdicionar_Click(object sender, EventArgs e)
        {
            if (validarEmail() == true)
            {
                Page.Validate();
                if (Page.IsValid)
                {                    
                    vsContatos.HeaderText = "Erro:";
                    cvContatosEmail.IsValid = false;
                    cvContatosEmail.ErrorMessage = "E-mail já está cadastrado";                    
                }
            }
            else {                

                ContatosAdicionar();
                buscaListaEmail();

                txtContatosGrupo.Text = "";
                txtContatosNome.Text = "";
                txtContatosEmail.Text = "";               

            }            

            Page.ClientScript.RegisterStartupScript(this.GetType(), "modalContatos", "modal_contatos();", true);
        }

        protected void bntContatosSalvar_Click(object sender, EventArgs e)
        {            
            string id_email = "0,";            
            
            for (int i = 0; i <= rpListaEmail.Items.Count - 1; i++)

            {

                RepeaterItem item = rpListaEmail.Items[i];
                CheckBox cbEmail = (CheckBox)item.FindControl("cbEmail");
                HiddenField hfIdEmail = (HiddenField)item.FindControl("hfIdEmail"); 

                if (cbEmail.Checked == true)
                {
                    id_email = id_email + hfIdEmail.Value + ",";                    
                }

            }

            id_email = id_email + "0";            

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update newsletter set id_email = @id_email where id = @id";
                cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                cmd.Parameters.AddWithValue("@id_email", id_email); 
                conn.Open();
                cmd.ExecuteNonQuery();

                buscaNewsletter();
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

        protected void bntContatosExcluir_Click(object sender, EventArgs e)
        {            

            for (int i = 0; i <= rpListaEmail.Items.Count - 1; i++)
            {
                RepeaterItem item = rpListaEmail.Items[i];
                CheckBox cbEmail = (CheckBox)item.FindControl("cbEmail");
                HiddenField hfIdEmail = (HiddenField)item.FindControl("hfIdEmail");

                if (cbEmail.Checked == true)
                {
                    MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
                    try
                    {
                        MySqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = "update newsletter_email set status = @status where id = @id";
                        cmd.Parameters.AddWithValue("@id", hfIdEmail.Value);                       
                        cmd.Parameters.AddWithValue("@status", 0);
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

            }

            buscaNewsletter();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "modalContatos", "modal_contatos();", true);
        }

        protected void bntAnuncioSalvar_Click(object sender, EventArgs e)
        {
            string id_anuncio = "0,";
            

            for (int i = 0; i <= rpListaAnuncio.Items.Count - 1; i++)

            {

                RepeaterItem item = rpListaAnuncio.Items[i];
                CheckBox cbAnuncio = (CheckBox)item.FindControl("cbAnuncio");
                HiddenField hfIdAnuncio = (HiddenField)item.FindControl("hfIdAnuncio");

                if (cbAnuncio.Checked == true)
                {
                    id_anuncio = id_anuncio + hfIdAnuncio.Value + ",";
                }

            }

            id_anuncio = id_anuncio + "0";

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update newsletter set id_anuncio = @id_anuncio where id = @id";
                cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                cmd.Parameters.AddWithValue("@id_anuncio", id_anuncio);
                conn.Open();
                cmd.ExecuteNonQuery();

                buscaNewsletter();
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

        protected void bntNewsletterVisualizar_Click(object sender, EventArgs e)
        {            

            if (newsletterSalvar())
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "modalVisualizar", "modal_visualizar();", true);
            }
        }

        protected void bntNewsletterSalvar_Click(object sender, EventArgs e)
        {
            if (newsletterSalvar())
            {
                pnlSucesso.Visible = true;
            }
            
        }       

        protected void bntNewsletterEnviar_Click(object sender, EventArgs e)
        {
            int id_newsletter = Convert.ToInt32(Request.QueryString["id"]);
            int id_email = 0;
            string id_emails = "0";

            if (newsletterSalvar())
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                try
                {
                    conn.Open();

                    MySqlCommand cmd1 = new MySqlCommand();
                    cmd1.Connection = conn;
                    cmd1.CommandText = "SELECT * FROM newsletter, usuario WHERE usuario.id=newsletter.id_usuario AND newsletter.id=@id ";
                    cmd1.Parameters.AddWithValue("@id", id_newsletter);
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();

                    if (rdr1.HasRows)
                    {
                        while (rdr1.Read())
                        {   
                            id_emails = rdr1["id_email"].ToString();
                        }
                    }

                    rdr1.Close();

                    MySqlCommand cmd2 = new MySqlCommand();
                    cmd2.Connection = conn;
                    cmd2.CommandText = "SELECT * FROM newsletter_email WHERE id IN (" + id_emails + ")  ";
                    MySqlDataReader rdr2 = cmd2.ExecuteReader();

                    if (rdr2.HasRows)
                    {
                        while (rdr2.Read())
                        {
                            id_email = Convert.ToInt32(rdr2["id"].ToString());                            

                            inserirNewsletterRelatorio(id_newsletter, id_email);
                        }
                    }

                    rdr2.Close();

                    agendarNewsletter();

                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
                finally
                {
                    conn.Close();

                    Response.Redirect("newsletter.aspx?status=agendado");
                }
            }
        }
         
        protected void bntNewsletterEnviarTeste_Click(object sender, EventArgs e)
        {
            string remetenteNome = "";
            string remetenteEmail = "";
            string destinatarioNome = "";
            string destinatarioEmail = "";
            string assunto = "";
            string mensagem = "";            

            if (newsletterSalvar())
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                try
                {
                    conn.Open();

                    MySqlCommand cmd1 = new MySqlCommand();
                    cmd1.Connection = conn;
                    cmd1.CommandText = "SELECT * FROM newsletter, usuario WHERE usuario.id=newsletter.id_usuario AND newsletter.id=@id ";
                    cmd1.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();

                    if (rdr1.HasRows)
                    {
                        while (rdr1.Read())
                        {
                            if (rdr1["empresa"].ToString() != "")
                            {
                                remetenteNome = rdr1["empresa"].ToString();
                            }
                            else
                            {

                                remetenteNome = rdr1["nome"].ToString();
                            }
                            
                            remetenteEmail = "newsletter@naplantaimoveis.com.br";
                            destinatarioNome = rdr1["nome"].ToString();
                            destinatarioEmail = classes.Descriptografar(rdr1["email"].ToString());
                            assunto = rdr1["assunto"].ToString();
                            mensagem = newsletterHtml();

                            if (EnviaMensagem(remetenteNome, remetenteEmail, destinatarioNome, destinatarioEmail, assunto, mensagem)) {

                                Response.Write("email: "+ destinatarioEmail + " enviado");

                                pnlSucessoEnviarTeste.Visible = true;
                                ltlSucessoEnviarTeste.Text = "e-mail: " + destinatarioEmail + " enviado.";

                            };

                        }
                    }

                    rdr1.Close();                      

                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
                finally
                {
                    conn.Close();
                }                
            }
        }

        public static bool EnviaMensagem(string remetenteNome, string remetenteEmail, string destinatarioNome, string destinatarioEmail, string assunto, string mensagem)
        {            

            try
            {

                using (MailMessage emailMessage = new MailMessage())
                {
                    emailMessage.From = new MailAddress(remetenteEmail, remetenteNome);
                    emailMessage.To.Add(new MailAddress(destinatarioEmail, destinatarioNome));
                    //emailMessage.ReplyTo = "comercial@naplantaimoveis.com.br"; 
                    emailMessage.Subject = assunto;
                    emailMessage.IsBodyHtml = true;
                    emailMessage.Body = mensagem;
                    emailMessage.Priority = MailPriority.Normal;
                    using (SmtpClient MailClient = new SmtpClient("mail.naplantaimoveis.com.br", 587))
                    {
                        MailClient.EnableSsl = true;
                        MailClient.Credentials = new System.Net.NetworkCredential("newsletter@naplantaimoveis.com.br", "elefante2020!");
                        MailClient.Send(emailMessage);
                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static bool ValidaEnderecoEmail(string enderecoEmail)
        {

            try

            {
                //define a expressão regulara para validar o email
                string texto_Validar = enderecoEmail;

                Regex expressaoRegex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");

                // testa o email com a expressão

                if (expressaoRegex.IsMatch(texto_Validar))
                {

                    // o email é valido
                    return true;

                }
                else
                {

                    // o email é inválido
                    return false;

                }

            }

            catch (Exception)
            {

                throw;

            }

        }

        private bool ContatosAdicionar()
        {
            bool resposta = true;

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                String sql = "INSERT INTO newsletter_email (id_usuario, grupo, nome, email, data, status) VALUES (@id_usuario, @grupo, @nome, @email, @data, @status)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id_usuario", Session["idUsuario"]);
                cmd.Parameters.AddWithValue("@grupo", txtContatosGrupo.Text);
                cmd.Parameters.AddWithValue("@nome", txtContatosNome.Text);
                cmd.Parameters.AddWithValue("@email", txtContatosEmail.Text);
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

            return resposta;
        }

        private bool validarEmail()
        {
            bool resposta = true;

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                conn.Open();

                string sql = "SELECT * FROM newsletter_email WHERE id_usuario=@id_usuario AND email=@email  AND status=@status ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id_usuario", Session["idUsuario"]);
                cmd.Parameters.AddWithValue("@email", txtContatosEmail.Text);
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
                 
        protected string newsletterHtml() {

            string html = "";
            string url = "";
            string alt = "";
            string assunto = "";
            string mensagem = "";
            string id_anuncio = "";
            string id_anuncios = "";
            string data_newsletter = "";
            string foto = "";
            

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();


                html = html + "<table width=\"100%\" cellpadding=\"10\" cellspacing=\"0\" border=\"0\" style=\"font-family:Roboto,Arial,sans-serif;background-color:#f8f9fa\">";
                html = html + "<tr>";
                html = html + "<td>";  


                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM newsletter, usuario, usuario_nivel WHERE usuario.id = newsletter.id_usuario AND usuario_nivel.id = usuario.id_nivel AND newsletter.id =@id", conn);                
                cmd1.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                cmd1.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr1 = cmd1.ExecuteReader();

                if (rdr1.HasRows)
                {
                    while (rdr1.Read())
                    {
                        assunto = rdr1["assunto"].ToString();
                        mensagem = rdr1["mensagem"].ToString();
                        id_anuncio = Request.QueryString["id"];
                        id_anuncios = rdr1["id_anuncio"].ToString();
                        data_newsletter = Convert.ToDateTime(rdr1["data"].ToString()).ToString("dd/MM/yyyy");                        


                        html = html + "<table  cellpadding=\"10\" cellspacing=\"0\" border=\"0\" style=\"margin-left:auto;margin-right:auto;margin-bottom:5px;background-color:#ffffff\">";
                        html = html + "<tr>";
                        html = html + "<td style=\"text-align:center;width:320px\">";

                        if (rdr1["logo"].ToString() != "")
                        {
                            if (rdr1["empresa"].ToString() != "")
                            {
                                html = html + "<img style=\"margin-left:auto;margin-right:auto;\" title=\"" + rdr1["empresa"].ToString() + "\" alt=\"" + rdr1["empresa"].ToString() + "\" src=\"https://www.naplantaimoveis.com.br/image/empresa/50/" + rdr1["logo"].ToString() + "\"/><br/>";
                            }
                            else
                            {
                                html = html + "<img style=\"margin-left:auto;margin-right:auto;\" title=\"" + rdr1["nome"].ToString() + "\" alt=\"" + rdr1["nome"].ToString() + "\" src=\"https://www.naplantaimoveis.com.br/image/empresa/50/" + rdr1["logo"].ToString() + "\"/><br/>";
                            }

                        }                        
                        
                        if (rdr1["empresa"].ToString() != "")
                        {
                            html = html + "<span style=\"font-size:13px;\">" + rdr1["nivel"].ToString() + "<br/>" + rdr1["empresa"].ToString() + "</span><br/>";
                        }
                        else
                        {
                            html = html + "<span style=\"font-size:13px;\">" + rdr1["nivel"].ToString() + "<br/>" + rdr1["nome"].ToString() + "</span><br/>";
                        }

                        if (rdr1["site"].ToString() != "")
                        {
                            html = html + "<span style=\"font-size:13px;\"><a href=\"" + rdr1["site"].ToString() + "\" target=\"_blank\">" + rdr1["site"].ToString() + "</a></span><br/>";
                        }

                        html = html + "</td>";
                        html = html + "</tr>";
                        html = html + "</table>";


                        if (rdr1["mensagem"].ToString() != "")
                        {
                            //mensagem
                            html = html + "<table cellpadding=\"10\" cellspacing=\"0\" border=\"0\" style=\"margin-left:auto;margin-right:auto;margin-bottom:5px;background-color:#ffffff\">";
                            html = html + "<tr>";
                            html = html + "<td style=\"width:320px\">";
                            html = html + "<span style=\"font-size:13px;\">"+ rdr1["mensagem"].ToString() + "</span>";
                            html = html + "</td>";
                            html = html + "</tr>";
                            html = html + "</table>";
                        }                       
                        
                    }
                }

                rdr1.Close();                
                      


                MySqlCommand cmd = new MySqlCommand("SELECT * FROM anuncio, usuario, usuario_nivel, anuncio_edificacao, anuncio_imovel, anuncio_sub_imovel, anuncio_contrato, anuncio_situacao WHERE anuncio_edificacao.id = anuncio.id_edificacao AND anuncio_imovel.id = anuncio.id_imovel AND anuncio_contrato.id = anuncio.id_contrato AND anuncio_sub_imovel.id = anuncio.id_sub_imovel AND anuncio_situacao.id = anuncio.id_situacao AND usuario.id = anuncio.id_usuario AND usuario_nivel.id = usuario.id_nivel AND anuncio.status = @status AND anuncio.id IN ("+ id_anuncios + ")", conn);
                cmd.Parameters.AddWithValue("@status", 1);
                //cmd.Parameters.AddWithValue("@id_usuario", Session["idUsuario"].ToString());
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        url = classes.removerAcentos(rdr["imovel"].ToString() + "-" + rdr["sub_imovel"].ToString() + "-para-" + rdr["contrato"].ToString() + "-" + rdr["bairro"].ToString() + "-" + rdr["cidade"].ToString() + "-" + rdr["estado"].ToString() + "-" + rdr["id"].ToString()) + ".aspx";
                        alt = rdr["imovel"].ToString() + " " + rdr["sub_imovel"].ToString() + " para " + rdr["contrato"].ToString();

                        html = html + "<table cellpadding=\"10\" cellspacing=\"0\" border=\"0\" style=\"margin-left:auto;margin-right:auto;margin-bottom:5px;background-color:#ffffff\">";
                        
                        //anuncio
                        html = html + "<tr>";
                        html = html + "<td style=\"width:320px\">";
                        html = html + "<img style=\"width:300px\" title=\"" + alt + "\" alt=\""+ alt + "\" src=\"https://www.naplantaimoveis.com.br/image/anuncio/300/" + buscaAnuncioFoto(Convert.ToInt32(rdr["id"].ToString())) + "\"/>";
                        html = html + "</td>";
                        html = html + "</tr>";

                        html = html + "<tr>";
                        html = html + "<td>";

                        html = html + "<span style=\"font-size:18px;\">"+ rdr["imovel"].ToString() + " " + rdr["sub_imovel"].ToString() + "</span><br/>";
                        html = html + "<span style=\"font-size:13px;\">" + rdr["edificacao"].ToString() + " / " + rdr["contrato"].ToString() + " / " + rdr["situacao"].ToString() + "</span><br/>";
                        
                        html = html + "<span style=\"font-size:24px\">"+ classes.real(rdr["valor"].ToString()) + "</span><br/>";
                        html = html + "<span style=\"font-size:13px;\">" + rdr["endereco"].ToString() + ", " + rdr["numero"].ToString() + "</span><br/>";
                        html = html + "<span style=\"font-size:16px;\">" + rdr["bairro"].ToString() + ", " + rdr["cidade"].ToString() + "</span><br/>";
                        html = html + "<span style=\"font-size:13px;\">" + rdr["area_util"].ToString() + "m² | " + rdr["quartos"].ToString() + " Quarto | " + rdr["suites"].ToString() + " Suíte | " + rdr["banheiros"].ToString() + " Banheiro | " + rdr["vagas"].ToString() + " Vaga</span><br/>";
                        html = html + "<span style=\"font-size:13px;\">Publicado " + Convert.ToDateTime(rdr["data_anuncio"].ToString()).ToString("dd/MM/yyyy") + "</span>";

                        html = html + "</td>";
                        html = html + "</tr>";

                        html = html + "<tr>";
                        html = html + "<td>";                        
                        html = html + "<a href=\"https://www.naplantaimoveis.com.br/" + url + "\" style=\"text-decoration:none;text-align:center;color:#ffffff;display:block;width:auto!important;background:#6c757d;padding:11px 0px;border:none;text-transform:uppercase;font-size:16px;font-weight:500\" target=\"_blank\">VER MAIS</a>";
                        html = html + "</td>";
                        html = html + "</tr>";
                        html = html + "<tr>";
                        html = html + "<td>";                        
                        html = html + "</td>";
                        html = html + "</tr>";
                        //anuncio fim   

                        html = html + "</table>";

                    }
                }

                rdr.Close();

                html = html + "<table cellpadding=\"10\" cellspacing=\"0\" border=\"0\" style=\"margin-left:auto;margin-right:auto;margin-bottom:5px;background-color:#ffffff\">";

                html = html + "<tr>";
                html = html + "<td style=\"text-align:center;width:320px\">";
                html = html + "<img style=\"margin-left:auto;margin-right:auto;\" title=\"Na Planta Imóveis\" alt=\"Na Planta Imóveis\" src=\"https://www.naplantaimoveis.com.br/image/logo_150_150.png\"/><br/>";
                html = html + "<span style=\"font-size:13px;\">CRM Imobiliário</span><br/>";
                html = html + "<span style=\"font-size:13px;\"><a href=\"http://www.naplantaimoveis.com.br\" target=\"_blank\">www.naplantaimoveis.com.br</a></span><br/>";
                html = html + "<span style=\"font-size:13px;\"><a href=\"https://www.naplantaimoveis.com.br/anunciar.aspx\" target=\"_blank\" title=\"Anunciar Imóvel\" style=\"margin:2px;\">Anunciar Imóvel</a></span>";
                html = html + "</td>";
                html = html + "</tr>";

                //redes sociais
                html = html + "<tr>";
                html = html + "<td style=\"text-align:center;width:320px\">";                
                html = html + "<a href=\"https://www.facebook.com/naplantaimovel/\" target=\"_blank\" title=\"Facebook\" style=\"margin:2px;\"><img src=\"https://www.naplantaimoveis.com.br/image/icons/icon_facebook.png\" alt=\"Facebook\" title=\"Facebook\" class=\"img-thumbnail\" /></a>";
                html = html + "<a href=\"https://twitter.com/naplantaimovel\" target=\"_blank\" title=\"Twitter\" style=\"margin:2px;\"><img src=\"https://www.naplantaimoveis.com.br/image/icons/icon_twitter.png\" alt=\"Twitter\" title=\"Twitter\" class=\"img-thumbnail\" /></a>";
                html = html + "<a href=\"https://www.instagram.com/naplantaimovel/\" target=\"_blank\" title=\"Instagram\" style=\"margin:2px;\"><img src=\"https://www.naplantaimoveis.com.br/image/icons/icon_instagram.png\" alt=\"Instagram\" title=\"Instagram\" class=\"img-thumbnail\" /></a>";
                html = html + "</td>";
                html = html + "</tr>";
                //redes sociais fim

                html = html + "<tr>";
                html = html + "<td style=\"text-align:center;width:320px\">";
                html = html + "<span style=\"font-size:13px;\">Deseja cancelar este e-mail? <a href=\"https://www.naplantaimoveis.com.br/newsletter_cancelar.aspx?email=\" target=\"_blank\" title=\"Facebook\" style=\"margin:2px;\">clique aqui</a></span>";
                html = html + "</td>";
                html = html + "</tr>";


                html = html + "</table>";

                html = html + "</td>";
                html = html + "</tr>";
                html = html + "</table>";

               

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return html;
        }
    }
}