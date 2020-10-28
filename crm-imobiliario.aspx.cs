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
    public partial class crm_imobiliario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "CRM Imobiliário | " + ConfigurationManager.AppSettings["titulo"];
            Page.MetaDescription = "O que é um CRM para imobiliária e como ele pode ajudar nas vendas e locações. É por isso que um bom corretor precisa ter um CRM para imobiliária.";
        }
    }
}