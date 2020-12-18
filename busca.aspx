<%@ Page Language="C#" MasterPageFile="~/mestre.Master" AutoEventWireup="true" CodeBehind="busca.aspx.cs" Inherits="quartoesuite.busca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="jumbotron text-center bac" style="background-image: url(../image/casa2_1024_600.jpg); background-position: center;">
        <div class="container">
            <div id="divBusca" class="row shadow-sm p-2 mb-8 bg-light rounded">
                <div class="col-sm-11">
                    <asp:TextBox ID="txtBusca" runat="server" CssClass="form-control my-2" ValidationGroup="busca" placeholder="bairro, cidade ou estado"></asp:TextBox>
                    <asp:HiddenField ID="hidKey" runat="server" />                    
                </div>
                <div class="col-sm-1">
                    <asp:Button ID="bntBuscaSalvar" runat="server" CssClass="btn btn-secondary my-2" Text="Buscar" ValidationGroup="busca" OnClick="bntBuscaSalvar_Click" />
                </div>
            </div>
            <div id="divAnunciar" class="row shadow-sm p-2 mb-8">                
                <div class="col-sm-12">
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-warning my-2" NavigateUrl="~/anunciar.aspx">Anúnciar Imóvel</asp:HyperLink>                    
                </div>
            </div>            

        </div>
    </section>   
    


    <div class="container-fluid">

        <div class="row">
            <div class="col-sm-12">
                <h1>Resultados da busca</h1>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col-sm-12">                

                <asp:Repeater ID="rpAnuncioLista" runat="server" OnItemDataBound="rpAnuncioListaItemOnItemDataBound">
                    <ItemTemplate>

                        <div class="card mb-3 shadow-sm">
                            <div class="row no-gutters">
                                <div class="col-sm-1">
                                    <asp:Image ID="ImgBlog" runat="server" CssClass="card-img" />                                                                       
                                </div>
                                <div class="col-sm-11">                                    
                                    <div class="card-body">
                                        <h2 class="card-title"><asp:Literal ID="ltlTitulo" runat="server"></asp:Literal></h2>                                          

                                        <div class="row">
                                            <div class="col-sm-12">  
                                                <p class="card-text">
                                                    <asp:Literal ID="ltlDescricao" runat="server"></asp:Literal>                                                   
                                                </p>                                                
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
