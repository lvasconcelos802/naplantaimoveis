<%@ Page Language="C#" MasterPageFile="~/mestre.Master" AutoEventWireup="true" CodeBehind="cadastrar.aspx.cs" Inherits="quartoesuite.cadastrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- breadcrumb -->
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="default.aspx">Home</a></li>
            <li class="breadcrumb-item active" aria-current="page">Cadastrar</li>
        </ol>
    </nav>
    <!-- breadcrumb fim-->


    <div class="container-fluid">

        <div class="row">
            <div class="col-sm-12">
                <h1>Cadastrar</h1>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col-sm-4">

                <div class="card mb-4 shadow-sm">
                    
                    <div class="card-body">

                        <asp:ValidationSummary ID="vsCadastrar" runat="server" DisplayMode="BulletList" ValidationGroup="cadastrar" CssClass="alert alert-danger" HeaderText="Erro:" />

                        <div class="form-group">
                            <label>Perfil:</label>
                            <asp:DropDownList ID="ddlPerfil" runat="server" CssClass="form-control" ValidationGroup="cadastrar">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvPerfil" runat="server" ErrorMessage="Perfil obrigatório" ControlToValidate="ddlPerfil" ValidationGroup="cadastrar" Display="Dynamic" CssClass="alert-text"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label>Nome: (Obrigatório)</label>
                            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" ValidationGroup="cadastrar"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNome" runat="server" ErrorMessage="Nome obrigatorio" ControlToValidate="txtNome" ValidationGroup="cadastrar" Display="Dynamic" CssClass="alert-text"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label>Email: (Obrigatório)</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ValidationGroup="cadastrar"></asp:TextBox>
                            <asp:CustomValidator ID="cvEmail" runat="server" ValidationGroup="cadastrar" ControlToValidate="txtEmail" Display="Dynamic" CssClass="alert-text" />
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="E-mail obrigatorio" ControlToValidate="txtEmail" ValidationGroup="cadastrar" Display="Dynamic" CssClass="alert-text"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="E-mail errado" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="cadastrar" Display="Dynamic" CssClass="alert-text"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <label>Senha: (Obrigatório)</label>
                            <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" ValidationGroup="cadastrar" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvSenha" runat="server" ErrorMessage="Senha obrigatorio" ControlToValidate="txtSenha" ValidationGroup="cadastrar" Display="Dynamic" CssClass="alert-text"></asp:RequiredFieldValidator>
                        </div>

                    </div>
                    <div class="card-footer">
                        <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" CssClass="btn btn-secondary" OnClick="btnCadastrar_Click" ValidationGroup="cadastrar" />
                    </div>
                </div>

            </div>

        </div>
    </div>

</asp:Content>
