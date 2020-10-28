<%@ Page Language="C#" MasterPageFile="~/mestre.Master" AutoEventWireup="true" CodeBehind="crm-imobiliario.aspx.cs" Inherits="quartoesuite.crm_imobiliario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- breadcrumb -->
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="default.aspx">Home</a></li>
            <li class="breadcrumb-item active" aria-current="page">CRM Imobiliário</li>
        </ol>
    </nav>
    <!-- breadcrumb fim-->


    <div class="container-fluid">

        <div class="row">
            <div class="col-sm-12">
                <h1>CRM Imobiliário</h1>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col-sm-12">

                <div class="card mb-3 shadow-sm">
                    <div class="card-body">                        
                         <p class="card-text">                             
                             O que é um CRM para imobiliária e como ele pode ajudar nas vendas e locações.<br /> 
                             É por isso que um bom corretor precisa ter um CRM para imobiliária.<br />
                             Sigla para Customer Relationship Management (ou, em bom português, Gestão de Relacionamento com o Cliente)<br /><br />
                             Portal de anúncios imobiliários.<br /><br />
                             <img alt="Portal" title="Portal" src="image/foto-portal.png" /><br /><br />
                             Newsletter e banco de e-mail.<br /><br />
                             <img alt="Newsletter" title="Newsletter" src="image/foto-newsletter.png" />
                         </p>                        
                    </div>
                </div>

            </div>
        </div>

    </div>

</asp:Content>
