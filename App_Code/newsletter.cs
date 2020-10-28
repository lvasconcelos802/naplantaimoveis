using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace quartoesuite.App_Code
{
    public class newsletter
    {
        public static void criarSitemap()
        {

        }


        public static string criarNewsletterHtml(string id_newsletter)
        {
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
                cmd1.Parameters.AddWithValue("@id", id_newsletter);
                cmd1.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr1 = cmd1.ExecuteReader();

                if (rdr1.HasRows)
                {
                    while (rdr1.Read())
                    {
                        assunto = rdr1["assunto"].ToString();
                        mensagem = rdr1["mensagem"].ToString();
                        //id_anuncio = Request.QueryString["id"];
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
                            html = html + "<span style=\"font-size:13px;\">" + rdr1["mensagem"].ToString() + "</span>";
                            html = html + "</td>";
                            html = html + "</tr>";
                            html = html + "</table>";
                        }

                    }
                }

                rdr1.Close();



                MySqlCommand cmd = new MySqlCommand("SELECT * FROM anuncio, usuario, usuario_nivel, anuncio_edificacao, anuncio_imovel, anuncio_sub_imovel, anuncio_contrato, anuncio_situacao WHERE anuncio_edificacao.id = anuncio.id_edificacao AND anuncio_imovel.id = anuncio.id_imovel AND anuncio_contrato.id = anuncio.id_contrato AND anuncio_sub_imovel.id = anuncio.id_sub_imovel AND anuncio_situacao.id = anuncio.id_situacao AND usuario.id = anuncio.id_usuario AND usuario_nivel.id = usuario.id_nivel AND anuncio.status = @status AND anuncio.id IN (" + id_anuncios + ")", conn);
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
                        html = html + "<img style=\"width:300px\" title=\"" + alt + "\" alt=\"" + alt + "\" src=\"https://www.naplantaimoveis.com.br/image/anuncio/300/" + buscaAnuncioFoto(Convert.ToInt32(rdr["id"].ToString())) + "\"/>";
                        html = html + "</td>";
                        html = html + "</tr>";

                        html = html + "<tr>";
                        html = html + "<td>";

                        html = html + "<span style=\"font-size:18px;\">" + rdr["imovel"].ToString() + " " + rdr["sub_imovel"].ToString() + "</span><br/>";
                        html = html + "<span style=\"font-size:13px;\">" + rdr["edificacao"].ToString() + " / " + rdr["contrato"].ToString() + " / " + rdr["situacao"].ToString() + "</span><br/>";

                        html = html + "<span style=\"font-size:24px\">" + classes.real(rdr["valor"].ToString()) + "</span><br/>";
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
                ex.ToString();
            }
            finally
            {
                conn.Close();
            }

            return html;
        }

        public static string buscaAnuncioFoto(int id_anuncio)
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
                ex.ToString();
            }
            finally
            {
                conn.Close();
            }

            return foto;
        }
    }
}