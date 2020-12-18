<%@ Page Title="" Language="C#" MasterPageFile="~/mestre.Master" AutoEventWireup="true" CodeBehind="busca_temp.aspx.cs" Inherits="quartoesuite.busca_temp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="jumbotron text-center bac" style="background-image: url(../image/casa2_1024_600.jpg); background-position: center;">
        <div class="container">
            <div id="divBusca" class="row shadow-sm p-2 mb-8 bg-light rounded">
                <div class="col-sm-11">
                    <asp:TextBox ID="txtBusca" runat="server" CssClass="form-control my-2"></asp:TextBox>
                </div>
                <div class="col-sm-1">
                    <asp:Button ID="bntBuscaSalvar" runat="server" CssClass="btn btn-secondary my-2" Text="Buscar" ValidationGroup="busca" />
                </div>
            </div>
            <div id="divAnunciar" class="row shadow-sm p-2 mb-8">                
                <div class="col-sm-12">
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-warning my-2" NavigateUrl="~/anunciar.aspx">Anúnciar Imóvel</asp:HyperLink>                    
                </div>
            </div>

        </div>
    </section>

   



</asp:Content>
