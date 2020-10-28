<%@ Page Language="C#" MasterPageFile="~/mestre.Master" AutoEventWireup="true" CodeBehind="entrar.aspx.cs" Inherits="quartoesuite.entrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- breadcrumb -->
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="default.aspx">Home</a></li>
            <li class="breadcrumb-item active" aria-current="page">Entrar</li>
        </ol>
    </nav>
    <!-- breadcrumb fim-->


    <div class="container-fluid">

        <div class="row">
            <div class="col-sm-12">
                <h1>Entrar</h1>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col-sm-4">

                <div class="card mb-4 shadow-sm">
                    
                    <div class="card-body">

                        <asp:ValidationSummary ID="vsEntrar" runat="server" DisplayMode="BulletList" ValidationGroup="entrar" CssClass="alert alert-danger" HeaderText="Erro:" />

                        <div class="form-group">
                            <label>E-mail:</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" CausesValidation="True" ToolTip="E-mail" ValidationGroup="entrar"></asp:TextBox>
                            <asp:CustomValidator ID="cvEmail" runat="server" ValidationGroup="entrar" ControlToValidate="txtEmail" Display="Dynamic" CssClass="alert-text" />
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="E-mail obrigatorio" ControlToValidate="txtEmail" ValidationGroup="entrar" Display="Dynamic" CssClass="alert-text"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="E-mail errado" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="entrar" Display="Dynamic" CssClass="alert-text"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <label>Senha:</label>
                            <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" TextMode="Password" ValidationGroup="entrar"></asp:TextBox>
                            <asp:CustomValidator ID="cvSenha" runat="server" ValidationGroup="entrar" ControlToValidate="txtSenha" Display="Dynamic" CssClass="alert-text" />
                            <asp:RequiredFieldValidator ID="rfvSenha" runat="server" ErrorMessage="Senha obrigatorio" ControlToValidate="txtSenha" ValidationGroup="entrar" Display="Dynamic" CssClass="alert-text"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="card-footer">
                        <asp:Button ID="btnEntrar" runat="server" Text="Entrar" CssClass="btn btn-secondary" OnClick="btnEntrar_Click" ValidationGroup="entrar" />                        
                    </div>
                </div>

            </div>

        </div>

        <div class="row justify-content-center">
            <div class="col-sm-4 mb-4">
                <a href="recuperar.aspx" title="Esqueceu a senha?">Esqueceu a senha?</a>
                <a href="cadastrar.aspx" title="Cadastre-se">Cadastre-se</a>
            </div>
        </div>

    </div>
</asp:Content>
