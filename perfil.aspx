<%@ Page Language="C#" MasterPageFile="~/mestre.Master" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="quartoesuite.perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- breadcrumb -->
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="default.aspx">Perfil</a></li>
            <li class="breadcrumb-item active" aria-current="page">Editar</li>
        </ol>
    </nav>
    <!-- breadcrumb fim-->

    <div class="container-fluid">
        
        <div class="row">
            <div class="col-sm-12">
                <h1>Perfil</h1>
            </div>

        </div>

        <div class="row">
            <div class="col-sm-12">

                <!--Perfil-->
                <div class="card mb-4 shadow-sm">
                    
                    <div class="card-body">

                        <asp:Panel ID="pnlSucesso" runat="server" Visible="false" CssClass="alert alert-success">Sucesso</asp:Panel>
                        <asp:ValidationSummary ID="vsPerfil" runat="server" DisplayMode="BulletList" ValidationGroup="perfil" CssClass="alert alert-danger" HeaderText="Erro:" />

                        <!--Logo/Foto-->
                        <div class="form-group row">
                            <div class="col-sm-12">
                                <asp:HiddenField ID="hfLogo" runat="server" />
                                <asp:Image ID="imgLogo" runat="server" ImageUrl="../image/empresa/100/foto.jpg" CssClass="img-thumbnail" />
                                <asp:LinkButton ID="lbtnExcluirLogo" runat="server" OnClick="lbtnExcluirLogo_Click">Excluir</asp:LinkButton>
                            </div>
                        </div>

                        <div class="custom-file">
                            <div class="col-sm-12">
                                <label class="custom-file-label">Selecione o logotipo (Opcional)</label>
                                <asp:FileUpload ID="fuLogo" runat="server" class="custom-file-input" ValidationGroup="perfil" />
                                <asp:CustomValidator ID="cvLogo" runat="server" ControlToValidate="fuLogo" ErrorMessage="CustomValidator" ValidationGroup="perfil"></asp:CustomValidator>
                            </div>
                        </div>

                        <!--Anunciante-->
                        <div class="form-group">
                            <label>Perfil:</label>
                            <asp:DropDownList ID="ddlPerfil" runat="server" CssClass="form-control" ValidationGroup="cadastrar">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvPerfil" runat="server" ErrorMessage="Perfil obrigatório" ControlToValidate="ddlPerfil" ValidationGroup="cadastrar" Display="Dynamic" CssClass="alert-text"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group row">
                            <div class="col-sm-12">
                                <label>Empresa</label>
                                <asp:TextBox ID="txtEmpresa" runat="server" CssClass="form-control" ValidationGroup="perfil"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-12">
                                <label>CNPJ</label>
                                <asp:TextBox ID="txtCnpj" runat="server" CssClass="form-control" ValidationGroup="perfil"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-12">
                                <label>Nome (Obrigátorio)</label>
                                <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" ValidationGroup="perfil"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNome" runat="server" ErrorMessage="Preencha o campo nome" ControlToValidate="txtNome" ValidationGroup="perfil" Display="Dynamic" CssClass="alert-text"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-12">
                                <label>CPF</label>
                                <asp:TextBox ID="txtCpf" runat="server" CssClass="form-control" ValidationGroup="perfil"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-12">
                                <label>CRECI</label>
                                <asp:TextBox ID="txtCreci" runat="server" CssClass="form-control" ValidationGroup="perfil"></asp:TextBox>
                            </div>
                        </div>

                        <!--Contato-->
                        <div class="form-group row">
                            <div class="col-sm-12">
                                <label>Telefone</label>
                                <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-control" ValidationGroup="perfil"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-12">
                                <label>Celular</label>
                                <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control" ValidationGroup="perfil"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-12">
                                <label>Site (Opcional)</label>
                                <asp:TextBox ID="txtSite" runat="server" CssClass="form-control" ValidationGroup="perfil"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-12">
                                <label>E-mail (Obrigatório)</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ValidationGroup="perfil"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Preencha o campo e-mail" ControlToValidate="txtEmail" ValidationGroup="perfil" Display="Dynamic" CssClass="alert-text"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-12">
                                <label>Senha (Obrigatório)</label>
                                <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" TextMode="Password" ValidationGroup="perfil"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvSenha" runat="server" ErrorMessage="Preencha o campo senha" ControlToValidate="txtSenha" ValidationGroup="perfil" Display="Dynamic" CssClass="alert-text"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="card-footer text-right">
                        <asp:Button ID="btnSalvar" runat="server" CssClass="btn btn-secondary" Text="Salvar" ValidationGroup="perfil" OnClick="btnSalvar_Click" />
                    </div>
                </div>

            </div>

        </div>
    </div>


</asp:Content>
