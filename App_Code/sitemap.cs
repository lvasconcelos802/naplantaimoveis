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
    public class sitemap
    {        

        public static void criarSitemap() {

            string nomeArquivo = HttpContext.Current.Server.MapPath("/sitemap.xml");  

            StreamWriter writer = new StreamWriter(nomeArquivo);
              

            writer.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");

            writer.WriteLine("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">");


            //Página
            //writer.WriteLine(buscaPagina());

            writer.WriteLine("<url>");
            writer.WriteLine("<loc>" + ConfigurationManager.AppSettings["url"] + "/</loc>");
            writer.WriteLine("<lastmod>" + DateTime.Now.ToString("yyyy-MM-dd") + "</lastmod>");
            writer.WriteLine("<priority>1.00</priority>");
            writer.WriteLine("</url>");

            writer.WriteLine("<url>");
            writer.WriteLine("<loc>" + ConfigurationManager.AppSettings["url"] + "/default.aspx</loc>");
            writer.WriteLine("<lastmod>" + DateTime.Now.ToString("yyyy-MM-dd") + "</lastmod>");            
            writer.WriteLine("<priority>0.80</priority>");
            writer.WriteLine("</url>");
            

            writer.WriteLine("<url>");
            writer.WriteLine("<loc>" + ConfigurationManager.AppSettings["url"] + "/crm-imobiliario.aspx</loc>");
            writer.WriteLine("<lastmod>" + DateTime.Now.ToString("yyyy-MM-dd") + "</lastmod>");
            writer.WriteLine("<priority>0.64</priority>");
            writer.WriteLine("</url>");

            writer.WriteLine("<url>");
            writer.WriteLine("<loc>" + ConfigurationManager.AppSettings["url"] + "/blog.aspx</loc>");
            writer.WriteLine("<lastmod>" + DateTime.Now.ToString("yyyy-MM-dd") + "</lastmod>");
            writer.WriteLine("<priority>0.64</priority>");
            writer.WriteLine("</url>");

            writer.WriteLine("<url>");
            writer.WriteLine("<loc>" + ConfigurationManager.AppSettings["url"] + "/cadastrar.aspx</loc>");
            writer.WriteLine("<lastmod>" + DateTime.Now.ToString("yyyy-MM-dd") + "</lastmod>");            
            writer.WriteLine("<priority>0.64</priority>");
            writer.WriteLine("</url>");

            writer.WriteLine("<url>");
            writer.WriteLine("<loc>" + ConfigurationManager.AppSettings["url"] + "/entrar.aspx</loc>");
            writer.WriteLine("<lastmod>" + DateTime.Now.ToString("yyyy-MM-dd") + "</lastmod>");            
            writer.WriteLine("<priority>0.64</priority>");
            writer.WriteLine("</url>");

            writer.WriteLine("<url>");
            writer.WriteLine("<loc>" + ConfigurationManager.AppSettings["url"] + "/busca.aspx</loc>");
            writer.WriteLine("<lastmod>" + DateTime.Now.ToString("yyyy-MM-dd") + "</lastmod>");
            writer.WriteLine("<priority>0.64</priority>");
            writer.WriteLine("</url>");

            writer.WriteLine("<url>");
            writer.WriteLine("<loc>" + ConfigurationManager.AppSettings["url"] + "/anunciar.aspx</loc>");
            writer.WriteLine("<lastmod>" + DateTime.Now.ToString("yyyy-MM-dd") + "</lastmod>");            
            writer.WriteLine("<priority>0.64</priority>");
            writer.WriteLine("</url>");

            writer.WriteLine("<url>");
            writer.WriteLine("<loc>" + ConfigurationManager.AppSettings["url"] + "/recuperar.aspx</loc>");
            writer.WriteLine("<lastmod>" + DateTime.Now.ToString("yyyy-MM-dd") + "</lastmod>");            
            writer.WriteLine("<priority>0.64</priority>");
            writer.WriteLine("</url>");

            writer.WriteLine(buscaBlog());

            writer.WriteLine(buscaAnuncio());                        

            writer.WriteLine("</urlset>");
            

            writer.Close();           

        }

        public static string buscaAnuncio() {

            string texto = "";

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();
                
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM anuncio, anuncio_edificacao, anuncio_imovel, anuncio_sub_imovel, anuncio_contrato, anuncio_situacao WHERE anuncio_edificacao.id = anuncio.id_edificacao AND anuncio_imovel.id = anuncio.id_imovel AND anuncio_contrato.id = anuncio.id_contrato AND anuncio_sub_imovel.id = anuncio.id_sub_imovel AND anuncio_situacao.id = anuncio.id_situacao AND anuncio.status = @status ORDER BY anuncio.id DESC";
                cmd.Parameters.AddWithValue("@status", 1);               
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                { 
                    while (rdr.Read())
                    {  
                        texto += "<url>";
                        texto += "<loc>"+ ConfigurationManager.AppSettings["url"] + "/imovel-" + classes.removerAcentos(rdr.GetString("imovel") + "-" + rdr.GetString("sub_imovel") + "-para-" + rdr.GetString("contrato") + "-" + rdr.GetString("bairro") + "-" + rdr.GetString("cidade") + "-" + rdr.GetString("estado") + "-" + rdr.GetString("id")) + ".aspx</loc>";
                        texto += "<lastmod>" + DateTime.Now.ToString("yyyy-MM-dd") + "</lastmod>";                        
                        texto += "<priority>0.80</priority>";
                        texto += "</url>";
                    }
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

            return texto;

        }

        public static string buscaBlog()
        {

            string texto = "";

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM blog WHERE blog.status = @status ORDER BY blog.id DESC";
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        texto += "<url>";
                        texto += "<loc>" + ConfigurationManager.AppSettings["url"] + "/blog-" + classes.removerAcentos(rdr.GetString("titulo") + "-" + rdr.GetString("id")) + ".aspx</loc>";
                        texto += "<lastmod>" + DateTime.Now.ToString("yyyy-MM-dd") + "</lastmod>";
                        texto += "<priority>0.80</priority>";
                        texto += "</url>";
                    }
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

            return texto;

        }

        public static string buscaPagina()
        {

            string texto = "";

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM pagina WHERE status=@status ORDER BY posicao ASC";
                cmd.Parameters.AddWithValue("@status", 1);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        texto += "<url>";
                        texto += "<loc>" + ConfigurationManager.AppSettings["url"] + "/" + rdr.GetString("url") + "</loc>";
                        texto += "<lastmod>" + DateTime.Now.ToString("yyyy-MM-dd") + "</lastmod>";                       
                        texto += "<priority>1</priority>";
                        texto += "</url>";
                    }
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

            return texto;

        }





    }
}