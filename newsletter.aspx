<%@ Page Language="C#" MasterPageFile="~/mestre.Master" AutoEventWireup="true" CodeBehind="newsletter.aspx.cs" Inherits="quartoesuite.newsletter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- breadcrumb -->
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="default.aspx">Home</a></li>
            <li class="breadcrumb-item active" aria-current="page">Anunciar</li>
        </ol>
    </nav>
    <!-- breadcrumb fim-->


    <div class="container-fluid">

        <div class="row">
            <div class="col-sm-10">
                <h1>Newsletter</h1>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col-sm-12">

                <asp:Panel ID="pnlSucesso" runat="server" Visible="false" CssClass="alert alert-success">Sucesso</asp:Panel>
                <asp:Panel ID="pnlEnviado" runat="server" Visible="false" CssClass="alert alert-success">Newsletter Enviada</asp:Panel>
                <asp:Panel ID="pnlAgendado" runat="server" Visible="false" CssClass="alert alert-success">Newsletter Agendada</asp:Panel>

                <div class="card mb-3 shadow-sm">

                    <div class="card-body">

                        <div class="row">
                            <div class="col-sm-12 text-right">
                                <a class="card-link" href="newsletter_criar.aspx">Criar</a>
                            </div>
                        </div>

                    </div>

                </div>

                <asp:Repeater ID="rpNewsletter" runat="server" OnItemDataBound="rpNewsletterItemOnItemDataBound">

                    <ItemTemplate>

                        <div class="card mb-3 shadow-sm">

                            <div class="card-body">

                                <div class="row">
                                    <div class="col-sm-6">
                                        <p class="card-text"><%# DataBinder.Eval(Container.DataItem, "assunto") %></p>
                                    </div>
                                    <div class="col-sm-2">
                                        <p class="card-text"><%# DataBinder.Eval(Container.DataItem, "data") %></p>
                                    </div>
                                    <div class="col-sm-2">
                                        <p class="card-text">
                                            <asp:Label ID="lblStatus" runat="server" Visible="false"></asp:Label>
                                        </p>
                                    </div>
                                    <div class="col-sm-2 text-right">                                        
                                        <asp:LinkButton ID="lbtNewsletterEditar" runat="server" Visible="false" CssClass="card-link">Editar/Enviar</asp:LinkButton>
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



    <!-- Modal  Contatos-->
    <div class="modal fade" id="modalContatos" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h3 class="modal-title" id="exampleModalLabel">Contatos</h3>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    ...
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal Contatos fim -->

    <!-- Modal Anuncios -->
    <div class="modal fade" id="modalAnuncios" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h3 class="modal-title" id="exampleModalLabel">Anuncios</h3>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    ...
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal Anuncios fim -->

</asp:Content>
