<%@ Page Title="" Language="C#" MasterPageFile="~/mestre.Master" AutoEventWireup="true" CodeBehind="meus-anuncios.aspx.cs" Inherits="quartoesuite.meus_anuncios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- breadcrumb -->
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="default.aspx">Home</a></li>
            <li class="breadcrumb-item active" aria-current="page">Meus Anúncios</li>
        </ol>
    </nav>
    <!-- breadcrumb fim-->


    <div class="container-fluid">

        <div class="row">
            <div class="col-sm-12">
                <h1>Meus Anúncios</h1>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col-sm-12">

                <asp:Panel ID="pnlSucesso" runat="server" Visible="false" CssClass="alert alert-success">Sucesso</asp:Panel>

                <asp:Repeater ID="rAnuncios" runat="server">
                    <ItemTemplate>

                        <div class="card mb-3 shadow-sm">
                            <div class="row no-gutters">
                                <div class="col-sm-2">
                                    <img src="../image/anuncio/400/<%# buscaAnuncioFoto(Convert.ToInt32(DataBinder.Eval(Container.DataItem, "[\"id\"]")))%>" class="card-img" alt="Foto">
                                    <div class="card-img-overlay">
                                        <small class="alert alert-secondary"><%# DataBinder.Eval(Container.DataItem, "situacao") %></small>
                                    </div>
                                </div>
                                <div class="col-sm-10">                                    
                                    <div class="card-body">
                                        <h2 class="card-title"><%# DataBinder.Eval(Container.DataItem, "imovel") %> / <%# DataBinder.Eval(Container.DataItem, "sub_imovel") %></h2>
                                        <h3 class="card-subtitle"><%# DataBinder.Eval(Container.DataItem, "edificacao") %>/<%# DataBinder.Eval(Container.DataItem, "contrato") %></h3>
                                        <div class="row">
                                            <div class="col-sm-3">
                                                <strong>Valor: </strong><%# DataBinder.Eval(Container.DataItem, "valor") %>
                                            </div>
                                            <div class="col-sm-3">
                                                <strong>Valor Condomínio:</strong> <%# DataBinder.Eval(Container.DataItem, "valor_condominio") %>
                                            </div>
                                            <div class="col-sm-3">
                                                <strong>Valor Iptu:</strong> <%# DataBinder.Eval(Container.DataItem, "valor_iptu") %>
                                            </div>
                                            <div class="col-sm-3">
                                                
                                            </div> 
                                            <div class="col-sm-3">
                                                <strong><%# DataBinder.Eval(Container.DataItem, "area_util") %></strong>m²
                                            </div>
                                            <div class="col-sm-3">
                                                <strong><%# DataBinder.Eval(Container.DataItem, "quartos") %></strong> Quarto(s)
                                            </div>
                                            <div class="col-sm-3">
                                                <strong><%# DataBinder.Eval(Container.DataItem, "banheiros") %></strong> Banheiro(s)
                                            </div>
                                            <div class="col-sm-3">
                                                <strong><%# DataBinder.Eval(Container.DataItem, "vagas") %></strong> Vaga(s)
                                            </div>                                                                                       
                                        </div>

                                        <div class="row">                                            
                                            <div class="col-sm-6">
                                               <%# DataBinder.Eval(Container.DataItem, "bairro") %> <%# DataBinder.Eval(Container.DataItem, "cidade") %> <%# DataBinder.Eval(Container.DataItem, "estado") %>
                                            </div>
                                            <div class="col-sm-3">
                                                <strong>Anunciante</strong> <%# DataBinder.Eval(Container.DataItem, "id") %>
                                            </div>   
                                            <div class="col-sm-3">
                                                <strong>Código Anúncio:</strong> <%# DataBinder.Eval(Container.DataItem, "codigo") %>
                                            </div>
                                        </div> 

                                        <div class="row">
                                            <div class="col-sm-12">
                                                <p class="card-text"><small class="text-muted">Publicado: <%# DataBinder.Eval(Container.DataItem, "data_anuncio") %></small></p>
                                                <p class="card-text">
                                                   <a class="card-link" href="detalhes.aspx?id=<%# DataBinder.Eval(Container.DataItem, "id") %>">Ver Detalhes</a>
                                                   <a class="card-link" href="anunciar.aspx?id=<%# DataBinder.Eval(Container.DataItem, "id") %>">Editar</a>
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
