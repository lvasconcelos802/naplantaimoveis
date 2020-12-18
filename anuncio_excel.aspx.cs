using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using quartoesuite.App_Code;
using System.Text;

namespace quartoesuite
{
    public partial class anuncio_excel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lerExcel();
        }

        private void lerExcel()
        {
            string email = "";            
            int cont = 0;

            String name = "anuncio";
            String constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:/sites/naplantaimoveis/arquivo/anuncio.xls;Extended Properties='Excel 8.0;HDR=YES;';";

            OleDbConnection con = new OleDbConnection(constr);
            OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
            con.Open();

            OleDbDataReader rdr = oconn.ExecuteReader();


            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    cont++;

                    if (cont >= 1)
                    {                        
                        
                        inserirAnuncio(rdr["id_imovel"].ToString(), rdr["id_edificacao"].ToString(), rdr["endereco"].ToString(), rdr["bairro"].ToString(), rdr["cidade"].ToString(), rdr["estado"].ToString(), 2, 1, 0, 1, "180", "250", "", "600,00", "00,00", "00,00");
                    }
                                       
                }
            }
        }

        private void inserirAnuncio(string id_imovel, string id_edificacao, string endereco,string bairro,string cidade,string estado,int quartos,int banheiros,int suites,int vagas,string area_util,string area_total, string descricao, string valor,string valor_condominio,string valor_iptu)
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                String sql = "INSERT INTO anuncio (id_usuario,id_contrato,id_edificacao,id_imovel,id_sub_imovel,id_situacao,codigo,cep,endereco,numero,complemento,bairro,cidade,estado,quartos,banheiros,suites,vagas,area_util,area_total,andar,pe_direito,descricao,valor,valor_condominio,valor_iptu,telefone,celular,email,comodidade,planta,data_anuncio,data_aprovacao,data_suspenso,posicao,status) VALUES (@id_usuario,@id_contrato,@id_edificacao,@id_imovel,@id_sub_imovel,@id_situacao,@codigo,@cep,@endereco,@numero,@complemento,@bairro,@cidade,@estado,@quartos,@banheiros,@suites,@vagas,@area_util,@area_total,@andar,@pe_direito,@descricao,@valor,@valor_condominio,@valor_iptu,@telefone,@celular,@email,@comodidade,@planta,@data_anuncio,@data_aprovacao,@data_suspenso,@posicao,@status)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                
                cmd.Parameters.AddWithValue("@id_usuario", 9);
                cmd.Parameters.AddWithValue("@id_contrato", 1);
                cmd.Parameters.AddWithValue("@id_edificacao", id_edificacao);
                cmd.Parameters.AddWithValue("@id_imovel", id_imovel);
                cmd.Parameters.AddWithValue("@id_sub_imovel", 1);
                cmd.Parameters.AddWithValue("@id_situacao", 3);
                cmd.Parameters.AddWithValue("@codigo", "");
                cmd.Parameters.AddWithValue("@cep", "");
                cmd.Parameters.AddWithValue("@endereco", endereco);
                cmd.Parameters.AddWithValue("@numero", "");
                cmd.Parameters.AddWithValue("@complemento", "");
                cmd.Parameters.AddWithValue("@bairro", bairro);
                cmd.Parameters.AddWithValue("@cidade", cidade);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@quartos", quartos);
                cmd.Parameters.AddWithValue("@banheiros", banheiros);
                cmd.Parameters.AddWithValue("@suites", suites);
                cmd.Parameters.AddWithValue("@vagas", vagas);
                cmd.Parameters.AddWithValue("@area_util", area_util);
                cmd.Parameters.AddWithValue("@area_total", area_total);
                cmd.Parameters.AddWithValue("@andar", 0);
                cmd.Parameters.AddWithValue("pe_direito", 0);
                cmd.Parameters.AddWithValue("@descricao","");
                cmd.Parameters.AddWithValue("@valor", valor);
                cmd.Parameters.AddWithValue("@valor_condominio", valor_condominio);
                cmd.Parameters.AddWithValue("@valor_iptu", valor_iptu);
                cmd.Parameters.AddWithValue("@telefone", "");
                cmd.Parameters.AddWithValue("@celular", "");
                cmd.Parameters.AddWithValue("@email", "");
                cmd.Parameters.AddWithValue("@comodidade", 0);
                cmd.Parameters.AddWithValue("@planta", 0);
                cmd.Parameters.AddWithValue("@data_anuncio", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@data_aprovacao", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@data_suspenso", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@posicao", 0);
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

    }
}