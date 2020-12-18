<%@ Page Language="C#" MasterPageFile="~/mestre.Master" AutoEventWireup="true" CodeBehind="blog.aspx.cs" Inherits="quartoesuite.blog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- breadcrumb -->
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="default.aspx">Home</a></li>
            <li class="breadcrumb-item active" aria-current="page">Blog</li>
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

                <asp:Repeater ID="rpBlog" runat="server" OnItemDataBound="rpBlogItemOnItemDataBound">
                    <ItemTemplate>

                        <div class="card mb-3 shadow-sm">
                            <div class="row no-gutters">
                                <div class="col-sm-1">
                                    <asp:Image ID="ImgBlog" runat="server" CssClass="card-img" />                                                                       
                                </div>
                                <div class="col-sm-11">                                    
                                    <div class="card-body">
                                        <h2 class="card-title"><asp:Literal ID="ltlTitulo" runat="server"></asp:Literal></h2>
                                        <h3 class="card-subtitle"><small class="text-muted"><asp:Literal ID="ltlSubTitulo" runat="server"></asp:Literal></small></h3>  

                                        <div class="row">
                                            <div class="col-sm-12">                                                
                                                <p class="card-text">
                                                    <asp:HyperLink ID="hlLeiaMais" runat="server"></asp:HyperLink>                                                    
                                                </p>
                                            </div>                                           
                                        </div>
                                        
                                    </div>                                   
                                </div>                                
                            </div>
                        </div>

                    </ItemTemplate>
                </asp:Repeater>

                <asp:Panel ID="pnlVazio" runat="server" Visible="false" CssClass="alert alert-success">Nenhum registro</asp:Panel>

            </div>
        </div>

    </div>

</asp:Content>
