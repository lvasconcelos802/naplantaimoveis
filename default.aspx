<%@ Page Language="C#" MasterPageFile="~/mestre.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="quartoesuite._default" %>

<%@ Import Namespace="System.Data" %>


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
                <h1>Imóveis para vender e alugar</h1>
            </div>
        </div>

        <div class="row">

            <div class="col-sm-12">

                <!--Carousel Wrapper-->
                <div id="carousel-home-imoveis" class="carousel slide carousel-multi-item" data-ride="carousel">

                    <!--Controls-->
                    <a class="carousel-control-prev" href="#carousel-home-imoveis" role="button" data-slide="prev">
                        <i class="fa fa-arrow-circle-left" style="font-size: 50px;"></i>
                    </a>
                    <a class="carousel-control-next" href="#carousel-home-imoveis" role="button" data-slide="next">
                        <i class="fa fa-arrow-circle-right" style="font-size: 50px;"></i>
                    </a>
                    <!--/.Controls-->


                    <!--Slides-->
                    <div class="carousel-inner" role="listbox">

                        <asp:Repeater ID="rpLista" runat="server" OnItemDataBound="rpListaOnItemDataBound">
                            <ItemTemplate>
                                <!--First slide-->
                                <asp:Panel ID="pnlCarouselItem" runat="server" CssClass="carousel-item active">

                                    <div class="row">

                                        <asp:Repeater ID="rpListaItem" runat="server" DataSource='<%# ((DataRowView)Container.DataItem).Row.GetChildRows("myrelation") %>' OnItemDataBound="rpListaItemOnItemDataBound">
                                            <ItemTemplate>
                                                <asp:Panel ID="pnlCarouselItemCol" runat="server" CssClass="col-md-3">
                                                    <div class="card mb-3 shadow-sm">

                                                        <asp:Image ID="ImgImovel" runat="server" CssClass="card-img-top" Height="300" />

                                                        <div class="card-img-overlay">
                                                            <small class="alert alert-secondary">
                                                                <asp:Literal ID="ltlSituacao" runat="server"></asp:Literal></small>
                                                        </div>

                                                        <div class="card-body">

                                                            <h2 class="card-title">
                                                                <asp:Literal ID="ltlImovel" runat="server"></asp:Literal>
                                                                <asp:Literal ID="ltlSubImovel" runat="server"></asp:Literal></h2>
                                                            <h3 class="card-subtitle mb-2 text-muted">
                                                                <asp:Literal ID="ltlSubtitulo" runat="server"></asp:Literal></h3>
                                                            <h3 class="card-subtitle">
                                                                <asp:Literal ID="ltlValor" runat="server"></asp:Literal></h3>
                                                            <p class="card-text">
                                                                <asp:Literal ID="ltlEndereco" runat="server"></asp:Literal><br />
                                                                <small class="text-muted"><strong>
                                                                    <asp:Literal ID="ltlMedida" runat="server"></asp:Literal></strong> m² <strong>
                                                                        <asp:Literal ID="ltlQuartos" runat="server"></asp:Literal></strong> Quarto(s) <strong>
                                                                            <asp:Literal ID="ltlBanheiros" runat="server"></asp:Literal></strong> Banheiro(s) <strong>
                                                                                <asp:Literal ID="ltlVagas" runat="server"></asp:Literal></strong> Vaga(s)</small><br />
                                                                <small class="text-muted">
                                                                    <asp:Literal ID="ltlUsuarioNivel" runat="server"></asp:Literal>: <strong>
                                                                        <asp:Literal ID="ltlUsuario" runat="server"></asp:Literal></strong></small>
                                                                <br />
                                                                <small class="text-muted">Publicado
                                                                    <asp:Literal ID="ltlData" runat="server"></asp:Literal></small>
                                                            </p>
                                                            <div class="row">
                                                                <div class="col-sm-12">
                                                                    <asp:HyperLink ID="hlVerDetalhes" runat="server" CssClass="card-link"></asp:HyperLink>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </asp:Panel>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </div>

                                </asp:Panel>
                                <!--/.First slide-->
                            </ItemTemplate>
                        </asp:Repeater>


                    </div>
                    <!--/.Slides-->

                </div>
                <!--/.Carousel Wrapper-->

            </div>
        </div>



    </div>



</asp:Content>
