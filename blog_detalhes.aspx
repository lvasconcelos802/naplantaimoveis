<%@ Page Language="C#" MasterPageFile="~/mestre.Master" AutoEventWireup="true" CodeBehind="blog_detalhes.aspx.cs" Inherits="quartoesuite.blog_detalhes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- breadcrumb -->
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="default.aspx" title="Home">Home</a></li>
            <li class="breadcrumb-item"><a href="blog.aspx" title="Blog">Blog</a></li>
            <li class="breadcrumb-item active" aria-current="page">Leia mais</li>
        </ol>
    </nav>
    <!-- breadcrumb fim-->


    <div class="container-fluid">

        <div class="row">
            <div class="col-sm-12">
                <h1>Blog</h1>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col-sm-12">

                <div class="card mb-3 shadow-sm">
                    <div class="card-body">                        
                        <h2 class="card-title">
                            <asp:Literal ID="ltlTitulo" runat="server"></asp:Literal>
                        </h2> 
                        <p class="card-subtitle">
                            <small class="text-muted"><asp:Literal ID="ltlSubTitulo" runat="server"></asp:Literal></small>
                        </p> 
                        <p class="card-text"></p>
                        <p class="card-text">                             
                             <asp:Literal ID="ltlTexto" runat="server"></asp:Literal>
                         </p>                        
                    </div>
                </div>

                <asp:Panel ID="pnlVazio" runat="server" Visible="false" CssClass="alert alert-success">Nenhum registro</asp:Panel>

            </div>
        </div>

    </div>

</asp:Content>
