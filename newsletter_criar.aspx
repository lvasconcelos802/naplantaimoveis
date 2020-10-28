<%@ Page Language="C#" MasterPageFile="~/mestre.Master" AutoEventWireup="true" CodeBehind="newsletter_criar.aspx.cs" Inherits="quartoesuite.newsletter_criar" %>

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
            <div class="col-sm-12">
                <h1>Newsletter</h1>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12">

                <asp:Panel ID="pnlSucesso" runat="server" Visible="false" CssClass="alert alert-success">Sucesso</asp:Panel>
                <asp:Panel ID="pnlSucessoEnviarTeste" runat="server" Visible="false" CssClass="alert alert-success">
                    <asp:Literal ID="ltlSucessoEnviarTeste" runat="server"></asp:Literal>
                </asp:Panel>

                <asp:ValidationSummary ID="vsNewsletter" runat="server" DisplayMode="BulletList" ValidationGroup="newsletter" CssClass="alert alert-danger" HeaderText="Erro:" />

                <!-- Newsletter -->
                <div class="card mb-4 shadow-sm">

                    <div class="card-body">                        

                        <div class="form-group row">
                            <div class="col-sm-12">
                                <label>Assunto</label>
                                <asp:TextBox ID="txtAssunto" runat="server" CssClass="form-control" ValidationGroup="newsletter"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-sm-12">
                                <label>Mensagem (Opcional)</label>
                                <asp:TextBox ID="txtMensagem" runat="server" CssClass="form-control" ValidationGroup="newsletter"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">

                            <div class="col-sm-12">
                                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalContatos">Adicionar contatos (<asp:Label ID="lblQtdeEmail" runat="server"></asp:Label> de <asp:Label ID="lblQtdeTotalEmail" runat="server"></asp:Label>)</button>
                            </div>

                        </div>

                        <div class="form-group row">

                            <div class="col-sm-12">
                                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalAnuncios">Adicionar anuncios (<asp:Label ID="lblQtdeAnuncio" runat="server"></asp:Label> de <asp:Label ID="lblQtdeTotalAnuncio" runat="server"></asp:Label>)</button>
                            </div>
                        </div>

                    </div>

                    <div class="card-footer">                        
                        <asp:Button ID="btnNewsletterVisualizar" runat="server" CssClass="btn btn-primary" Text="Visualizar" ValidationGroup="newsletter" OnClick="bntNewsletterVisualizar_Click" />
                        <asp:Button ID="btnNewsletterSalvar" runat="server" CssClass="btn btn-secondary" Text="Salvar" ValidationGroup="newsletter" OnClick="bntNewsletterSalvar_Click" />
                        <asp:Button ID="btnNewsletterEnviarTeste" runat="server" CssClass="btn btn-secondary" Text="Enviar Teste" ValidationGroup="newsletter" OnClick="bntNewsletterEnviarTeste_Click" />
                        <asp:Button ID="bntNewsletterEnviar" runat="server" CssClass="btn btn-secondary" Text="Enviar" ValidationGroup="newsletter" OnClick="bntNewsletterEnviar_Click" OnClientClick="if(!confirm('Deseja enviar a newsletter ?')) return false;" />
                    </div>

                </div>
                <!-- Newsletter fim -->

            </div>

        </div>
    </div>

    <!-- Modal  Contatos-->
    <div class="modal fade" id="modalContatos" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                    <h3 class="modal-title" id="exampleModalLabel">Contatos</h3>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">

                    <asp:ValidationSummary ID="vsContatos" runat="server" DisplayMode="BulletList" ValidationGroup="contatos" CssClass="alert alert-danger" HeaderText="Erro:" />

                    <div class="form-group">
                        <label>Grupo:</label>
                        <asp:TextBox ID="txtContatosGrupo" runat="server" CssClass="form-control" ValidationGroup="contatos"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label>Nome:</label>
                        <asp:TextBox ID="txtContatosNome" runat="server" CssClass="form-control" ValidationGroup="contatos"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label>E-mail:</label>
                        <asp:TextBox ID="txtContatosEmail" runat="server" CssClass="form-control" ValidationGroup="contatos"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvContatosEmail" runat="server" ErrorMessage="E-mail obrigatório" ControlToValidate="txtContatosEmail" ValidationGroup="contatos" Display="Dynamic" CssClass="alert-text"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revContatosEmail" runat="server" ErrorMessage="E-mail Errado" ControlToValidate="txtContatosEmail" ValidationGroup="contatos" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="alert-text"></asp:RegularExpressionValidator>
                        <asp:CustomValidator ID="cvContatosEmail" runat="server" ValidationGroup="contatos" ControlToValidate="txtContatosEmail" Display="Dynamic" CssClass="alert-text" />
                    </div>

                    <div class="form-group text-right">
                        <asp:Button ID="btnContatosAdicionar" runat="server" CssClass="btn btn-secondary" Text="Adicionar" ValidationGroup="contatos" OnClick="bntContatosAdicionar_Click" />
                    </div>

                    <asp:Repeater ID="rpListaEmail" runat="server">
                        <HeaderTemplate>
                            <hr />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="form-group row">
                                
                                <div class="col-sm-5">
                                    <%# DataBinder.Eval(Container.DataItem, "email") %>
                                </div>
                                <div class="col-sm-3">
                                    <%# DataBinder.Eval(Container.DataItem, "nome") %>
                                </div>
                                <div class="col-sm-3">
                                    <%# DataBinder.Eval(Container.DataItem, "grupo") %>
                                </div>
                                <div class="col-sm-1">
                                    <asp:CheckBox ID="cbEmail" runat="server"/>
                                    <asp:HiddenField ID="hfIdEmail" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "id") %>' />
                                </div>

                            </div>
                        </ItemTemplate>
                        <SeparatorTemplate>
                            <hr />
                        </SeparatorTemplate>
                    </asp:Repeater>

                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                    <asp:Button ID="btnContatosExcluir" runat="server" CssClass="btn btn-secondary" Text="Excluir" ValidationGroup="contatosSalvar" OnClick="bntContatosExcluir_Click" OnClientClick="if(!confirm('Deseja excluir os e-mails selecionados ?')) return false;" />
                    <asp:Button ID="btnContatosSalvar" runat="server" CssClass="btn btn-secondary" Text="Salvar" ValidationGroup="contatosSalvar" OnClick="bntContatosSalvar_Click" />
                </div>
            </div>
        </div>
    </div>
    <!-- Modal Contatos fim -->

    <!-- Modal Anuncios -->
    <div class="modal fade" id="modalAnuncios" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                    <h3 class="modal-title" id="exampleModalLabel">Anuncios</h3>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:Repeater ID="rpListaAnuncio" runat="server">
                        <ItemTemplate>
                            <div class="form-group row">
                                
                                <div class="col-sm-4">
                                    <img src="../image/anuncio/100/<%# buscaAnuncioFoto(Convert.ToInt32(DataBinder.Eval(Container.DataItem, "[\"id\"]")))%>" class="card-img" alt="Foto">
                                </div>
                                <div class="col-sm-7">
                                    <%# DataBinder.Eval(Container.DataItem, "imovel") %> / <%# DataBinder.Eval(Container.DataItem, "sub_imovel") %><br />
                                    <%# DataBinder.Eval(Container.DataItem, "edificacao") %>/<%# DataBinder.Eval(Container.DataItem, "contrato") %><br />
                                    Código: <%# DataBinder.Eval(Container.DataItem, "codigo") %><br />
                                    Valor: <%# DataBinder.Eval(Container.DataItem, "valor") %>  
                                </div>
                                <div class="col-sm-1">
                                    <asp:CheckBox ID="cbAnuncio" runat="server" ValidationGroup="anuncios" />
                                    <asp:HiddenField ID="hfIdAnuncio" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "id") %>' />
                                </div>

                            </div>
                        </ItemTemplate>
                        <SeparatorTemplate><hr /></SeparatorTemplate>
                    </asp:Repeater>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                    <asp:Button ID="btnAnuncioSalvar" runat="server" CssClass="btn btn-secondary" Text="Salvar" ValidationGroup="anuncios" OnClick="bntAnuncioSalvar_Click" />
                </div>
            </div>
        </div>
    </div>
    <!-- Modal Anuncios fim -->

    <!-- Modal Visualizar -->
    <div class="modal fade" id="modalVisualizar" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                    <h3 class="modal-title" id="exampleModalLabel">Visualizar</h3>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:Literal ID="ltlNewsletterVisualizar" runat="server"></asp:Literal>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal Visualizar fim -->

</asp:Content>
