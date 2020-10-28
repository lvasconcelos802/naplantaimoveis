<%@ Page Language="C#" MasterPageFile="~/mestre.Master" AutoEventWireup="true" CodeBehind="recuperar.aspx.cs" Inherits="quartoesuite.recuperar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- breadcrumb -->
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="default.aspx">Home</a></li>
            <li class="breadcrumb-item active" aria-current="page">Recuperar Senha</li>
        </ol>
    </nav>
    <!-- breadcrumb fim-->


    <div class="container-fluid">

        <div class="row">
            <div class="col-sm-12">
                <h1>Recuperar Senha</h1>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col-sm-4">

                <div class="card mb-4 shadow-sm">

                    <div class="card-body">

                        <asp:ValidationSummary ID="vsRecuperar" runat="server" DisplayMode="BulletList" ValidationGroup="recuperar" CssClass="alert alert-danger" HeaderText="Erro:" />

                        <div class="form-group">
                            <label>Email:</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" ValidationGroup="recuperar"></asp:TextBox>
                            <asp:CustomValidator ID="cvEmail" runat="server" ValidationGroup="recuperar" ControlToValidate="txtEmail" Display="Dynamic" CssClass="alert-text" />
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="E-mail obrigatorio" ControlToValidate="txtEmail" ValidationGroup="recuperar" Display="Dynamic" CssClass="alert-text"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="E-mail errado" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="recuperar" Display="Dynamic" CssClass="alert-text"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="card-footer">
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-secondary" OnClick="btnEnviar_Click" ValidationGroup="recuperar" />                        
                    </div>
                </div>

            </div>

        </div>

        <div class="row justify-content-center">
            <div class="col-sm-4 mb-4">
                <a href="entrar.aspx" title="Entrar">Entrar</a>
                <a href="cadastrar.aspx" title="Cadastre-se">Cadastre-se</a>
            </div>
        </div>

    </div>

</asp:Content>
