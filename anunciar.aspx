<%@ Page Language="C#" MasterPageFile="~/mestre.Master" AutoEventWireup="true" CodeBehind="anunciar.aspx.cs" Inherits="quartoesuite.anunciar" %>

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
                <h1>Anunciar</h1>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12">

                <asp:Panel ID="pnlSucesso" runat="server" Visible="false" CssClass="alert alert-success">Sucesso</asp:Panel>

                <asp:ValidationSummary ID="vsAnuncio" runat="server" DisplayMode="BulletList" ValidationGroup="anuncio" CssClass="alert alert-danger" HeaderText="Erro:" />

                <!-- Ímovel -->
                <div class="card mb-4 shadow-sm">
                    <h2 class="card-header">Ímovel</h2>
                    <div class="card-body">

                        <div class="form-group row">

                            <div class="col-sm-2">
                                <label>Edificação</label>
                                <asp:DropDownList ID="ddlEdificacao" runat="server" CssClass="form-control" ValidationGroup="anuncio">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvEdificacao" runat="server" ErrorMessage="Edificação obrigatório" ControlToValidate="ddlEdificacao" ValidationGroup="anuncio" Display="Dynamic" CssClass="alert-text"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-2">
                                <label>Contrato</label>
                                <asp:DropDownList ID="ddlContrato" runat="server" CssClass="form-control" ValidationGroup="anuncio">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvContrato" runat="server" ErrorMessage="Contrato obrigatório" ControlToValidate="ddlContrato" ValidationGroup="anuncio" Display="Dynamic" CssClass="alert-text"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-2">
                                <label>Ímovel</label>
                                <asp:DropDownList ID="ddlImovel" runat="server" CssClass="form-control" ValidationGroup="anuncio">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvImovel" runat="server" ErrorMessage="Imóvel obrigatório" ControlToValidate="ddlImovel" ValidationGroup="anuncio" Display="Dynamic" CssClass="alert-text"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-2">
                                <label>Sub Ímovel</label>
                                <asp:DropDownList ID="ddlSubImovel" runat="server" CssClass="form-control" ValidationGroup="anuncio">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvSubImovel" runat="server" ErrorMessage="Sub Ímovel obrigatório" ControlToValidate="ddlSubImovel" ValidationGroup="anuncio" Display="Dynamic" CssClass="alert-text"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-2">
                                <label>Situação</label>
                                <asp:DropDownList ID="ddlSituacao" runat="server" CssClass="form-control" ValidationGroup="anuncio">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvSituacao" runat="server" ErrorMessage="Situação obrigatório" ControlToValidate="ddlSituacao" ValidationGroup="anuncio" Display="Dynamic" CssClass="alert-text"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-2">
                                <label>Código Interno <a title="Utilize o código interno para localizar seu anúncio.">(i)</a></label>
                                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" ValidationGroup="anuncio"></asp:TextBox>
                            </div>

                        </div>
                    </div>
                </div>
                <!-- Ímovel fim -->

                <!-- Valor -->
                <div class="card mb-4 shadow-sm">
                    <h2 class="card-header">Valor</h2>
                    <div class="card-body">
                        <div class="form-group row">

                            <div class="col-sm-3">
                                <label>Valor</label>
                                <asp:TextBox ID="txtValor" runat="server" CssClass="form-control" ValidationGroup="anuncio" Text="0,00"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvValor" runat="server" ErrorMessage="Valor obrigatório" ControlToValidate="txtValor" ValidationGroup="anuncio" Display="Dynamic" CssClass="alert-text"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rvValor" runat="server" ErrorMessage="Valor Formato 0,00" Type="Currency" ControlToValidate="txtValor" ValidationGroup="anuncio" Display="Dynamic" MinimumValue="0,00" MaximumValue="999.999.999,99"></asp:RangeValidator>
                            </div>
                            <div class="col-sm-3">
                                <label>Valor Iptu (Anual)</label>
                                <asp:TextBox ID="txtValorIptu" runat="server" CssClass="form-control" ValidationGroup="anuncio" Text="0,00"></asp:TextBox>
                                <asp:RangeValidator ID="rvValorIptu" runat="server" ErrorMessage="Valor Iptu Formato 0,00" Type="Currency" ControlToValidate="txtValorIptu" ValidationGroup="anuncio" Display="Dynamic" MinimumValue="0,00" MaximumValue="999.999.999,99"></asp:RangeValidator>
                            </div>
                            <div class="col-sm-3">
                                <label>Valor Condomínio (Mensal)</label>
                                <asp:TextBox ID="txtValorCondominio" runat="server" CssClass="form-control" ValidationGroup="anuncio" Text="0,00"></asp:TextBox>
                                <asp:RangeValidator ID="rvValorCondominio" runat="server" ErrorMessage="Valor Condomínio Formato 0,00" Type="Currency" ControlToValidate="txtValorCondominio" ValidationGroup="anuncio" Display="Dynamic" MinimumValue="0,00" MaximumValue="999.999.999,99"></asp:RangeValidator>
                            </div>

                        </div>
                    </div>
                </div>
                <!-- Valor fim -->

                <!-- Característica -->
                <div class="card mb-4 shadow-sm">
                    <h2 class="card-header">Características</h2>
                    <div class="card-body">
                        <div class="form-group row">

                            <div class="col-sm-3">
                                <label>Quartos</label>
                                <asp:TextBox ID="txtQuartos" runat="server" CssClass="form-control" ValidationGroup="anuncio" Text="0"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvTxtQuartos" runat="server" ErrorMessage="Quartos obrigatório" ControlToValidate="txtQuartos" ValidationGroup="anuncio" Display="Dynamic" CssClass="alert-text"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rfQuartos" runat="server" ErrorMessage="Quartos Formato 0" Type="Integer" ControlToValidate="txtQuartos" ValidationGroup="anuncio" Display="Dynamic" MinimumValue="0" MaximumValue="1000" ToolTip="0"></asp:RangeValidator>
                            </div>
                            <div class="col-sm-3">
                                <label>Banheiros</label>
                                <asp:TextBox ID="txtBanheiros" runat="server" CssClass="form-control" ValidationGroup="anuncio" Text="0"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvBanheiros" runat="server" ErrorMessage="Banheiros obrigatório" ControlToValidate="txtBanheiros" ValidationGroup="anuncio" Display="Dynamic" CssClass="alert-text"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rv" runat="server" ErrorMessage="Banheiros Formato 0" Type="Integer" ControlToValidate="txtBanheiros" ValidationGroup="anuncio" Display="Dynamic" MinimumValue="0" MaximumValue="1000" ToolTip="0"></asp:RangeValidator>
                            </div>
                            <div class="col-sm-3">
                                <label>Suítes (Opcional)</label>
                                <asp:TextBox ID="txtSuites" runat="server" CssClass="form-control" ValidationGroup="anuncio" Text="0"></asp:TextBox>
                                <asp:RangeValidator ID="rvSuites" runat="server" ErrorMessage="Suítes Formato 0" Type="Integer" ControlToValidate="txtSuites" ValidationGroup="anuncio" Display="Dynamic" MinimumValue="0" MaximumValue="1000" ToolTip="0"></asp:RangeValidator>
                            </div>
                            <div class="col-sm-3">
                                <label>Vagas (Opcional)</label>
                                <asp:TextBox ID="txtVagas" runat="server" CssClass="form-control" ValidationGroup="anuncio" Text="0"></asp:TextBox>
                                <asp:RangeValidator ID="rvVagas" runat="server" ErrorMessage="Vagas Formato 0" Type="Integer" ControlToValidate="txtVagas" ValidationGroup="anuncio" Display="Dynamic" MinimumValue="0" MaximumValue="1000" ToolTip="0"></asp:RangeValidator>
                            </div>
                            <div class="col-sm-3">
                                <label>Área Últil m2</label>
                                <asp:TextBox ID="txtAreaUtil" runat="server" CssClass="form-control" ValidationGroup="anuncio" Text="0"></asp:TextBox>
                                <asp:RangeValidator ID="rvAreaUtil" runat="server" ErrorMessage="Área Útil Formato 0" Type="Integer" ControlToValidate="txtAreaUtil" ValidationGroup="anuncio" Display="Dynamic" MinimumValue="0" MaximumValue="1000" ToolTip="0"></asp:RangeValidator>
                            </div>
                            <div class="col-sm-3">
                                <label>Área Total m2 (Opcional)</label>
                                <asp:TextBox ID="txtAreaTotal" runat="server" CssClass="form-control" ValidationGroup="anuncio" Text="0"></asp:TextBox>
                                <asp:RangeValidator ID="rvAreaTotal" runat="server" ErrorMessage="Área total Formato 0" Type="Integer" ControlToValidate="txtAreaTotal" ValidationGroup="anuncio" Display="Dynamic" MinimumValue="0" MaximumValue="1000" ToolTip="0"></asp:RangeValidator>
                            </div>
                            <div class="col-sm-3">
                                <label>Andar (Opcional) </label>
                                <asp:TextBox ID="txtAndar" runat="server" CssClass="form-control" ValidationGroup="anuncio" Text="0"></asp:TextBox>
                                <asp:RangeValidator ID="rvAndar" runat="server" ErrorMessage="Andar Formato 0" Type="Integer" ControlToValidate="txtAndar" ValidationGroup="anuncio" Display="Dynamic" MinimumValue="0" MaximumValue="1000" ToolTip="0"></asp:RangeValidator>
                            </div>
                            <div class="col-sm-3">
                                <label>Altura do pé direito (Cm Opcional)</label>
                                <asp:TextBox ID="txtPeDireito" runat="server" CssClass="form-control" ValidationGroup="anuncio" Text="0"></asp:TextBox>
                                <asp:RangeValidator ID="rvPeDireito" runat="server" ErrorMessage="Pé Direito Formato 0" Type="Integer" ControlToValidate="txtPeDireito" ValidationGroup="anuncio" Display="Dynamic" MinimumValue="0" MaximumValue="100000" ToolTip="0"></asp:RangeValidator>
                            </div>

                        </div>
                    </div>
                </div>
                <!-- Característica -->

                <!-- Descrição -->
                <div class="card mb-4 shadow-sm">
                    <h2 class="card-header">Descrição</h2>
                    <div class="card-body">
                        <div class="form-group row">

                            <div class="col-sm-12">
                                <label>Descrição</label>
                                <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control" TextMode="MultiLine" ValidationGroup="anuncio"></asp:TextBox>
                            </div>

                        </div>
                    </div>
                </div>
                <!-- Descrição fim -->

                <!--Localização-->
                <div class="card mb-4 shadow-sm">
                    <h2 class="card-header">Localização</h2>
                    <div class="card-body">
                        <div class="form-group row">
                            <div class="col-sm-2">
                                <label>CEP</label>
                                <asp:TextBox ID="txtCep" runat="server" CssClass="form-control" ValidationGroup="anuncio"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCep" runat="server" ErrorMessage="CEP obrigatório" ControlToValidate="txtCep" ValidationGroup="anuncio" Display="Dynamic" CssClass="alert-text"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-6">
                                <label>Endereço</label>
                                <asp:TextBox ID="txtEndereco" runat="server" CssClass="form-control" ValidationGroup="anuncio"></asp:TextBox>
                            </div>
                            <div class="col-sm-2">
                                <label>Número</label>
                                <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" ValidationGroup="anuncio"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNumero" runat="server" ErrorMessage="Número obrigatório" ControlToValidate="txtNumero" ValidationGroup="anuncio" Display="Dynamic" CssClass="alert-text"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-2">
                                <label>Complemento</label>
                                <asp:TextBox ID="txtComplemento" runat="server" CssClass="form-control" ValidationGroup="anuncio"></asp:TextBox>
                            </div>
                            <div class="col-sm-12"></div>
                            <div class="col-sm-4">
                                <label>Bairro</label>
                                <asp:TextBox ID="txtBairro" runat="server" CssClass="form-control" ValidationGroup="anuncio"></asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <label>Cidade</label>
                                <asp:TextBox ID="txtCidade" runat="server" CssClass="form-control" ValidationGroup="anuncio"></asp:TextBox>
                            </div>
                            <div class="col-sm-1">
                                <label>Estado</label>
                                <asp:TextBox ID="txtEstado" runat="server" CssClass="form-control" ValidationGroup="anuncio"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <!--Localização fim-->

                <!--Foto-->
                <div class="card mb-4 shadow-sm">
                    <h2 class="card-header">Fotos</h2>
                    
                    <div class="card-body">

                        <div class="form-group row">

                            <asp:Repeater ID="rpFotos" runat="server" OnItemCommand="ItemCommand">
                                <ItemTemplate>
                                    <div class="col-sm-2 text-center">
                                        <img src="../image/anuncio/100/<%# DataBinder.Eval(Container.DataItem, "foto") %>" class="img-thumbnail mr-3" /><br />
                                        <asp:LinkButton ID="btnExcluir" CssClass="card-link" CommandName="excluir" runat="server" CommandArgument='<%# Eval("id") %>' OnClientClick="if(!confirm('Deseja excluir a foto ?')) return false;">Excluir</asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:Panel ID="pnlFotos" runat="server" Visible="false" CssClass="col-sm-2 text-center">
                                <img src="../image/anuncio/100/imovel.jpg" class="img-thumbnail mr-3" />
                            </asp:Panel>

                        </div>

                        <div class="custom-file">
                            <div class="row">
                                <div class="col-sm-3">
                                    <label class="custom-file-label">Selecione a foto (Opcional)</label>
                                    <asp:FileUpload ID="fuFoto" runat="server" class="custom-file-input" ValidationGroup="anuncio" />
                                    <asp:CustomValidator ID="cvFoto" runat="server" ControlToValidate="fuFoto" ErrorMessage="CustomValidator" ValidationGroup="anuncio"></asp:CustomValidator>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <!--Foto fim-->

                <!--Contato-->
                <div class="card mb-4 shadow-sm">
                    <h2 class="card-header">Contato</h2>
                    <div class="card-body">
                        <div class="form-group row">
                            <div class="col-sm-12 text-right">
                            </div>
                            <div class="col-sm-4">
                                <label>Telefone</label>
                                <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-control" ValidationGroup="anuncio"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvTelefone" runat="server" ErrorMessage="Telefone obrigatório" ControlToValidate="txtTelefone" ValidationGroup="anuncio" Display="Dynamic" CssClass="alert-text"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-4">
                                <label>Celular</label>
                                <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control" ValidationGroup="anuncio"></asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <label>E-mail</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ValidationGroup="anuncio"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="E-mail Errado" ControlToValidate="txtEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="anuncio" CssClass="alert-text"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <!--Contato fim-->

                <!--Comodidade-->
                <div class="card mb-4 shadow-sm">
                    <h2 class="card-header">Comodidades</h2>
                    <div class="card-body">
                        <div class="form-group row">
                            <div class="col-sm-4">
                                <asp:CheckBoxList ID="cblComodidade" runat="server" ValidationGroup="anuncio">
                                </asp:CheckBoxList>

                            </div>
                        </div>
                    </div>
                </div>
                <!--Comodidade fim-->

                <!--Planta-->
                <div class="card mb-4 shadow-sm">
                    <h2 class="card-header">Planta</h2>
                    <div class="card-body">
                        <div class="form-group row">
                            <div class="col-sm-4">
                                <asp:CheckBoxList ID="cblPlanta" runat="server" ValidationGroup="anuncio">
                                </asp:CheckBoxList>

                            </div>
                        </div>
                    </div>
                </div>
                <!--Planta fim-->

                <!--Salvar-->
                <div class="card mb-4 shadow-sm">
                    <div class="card-body text-right">
                        <asp:Button ID="btnExcluir" runat="server" CssClass="btn btn-secondary" OnClick="btnExcluir_Click" Text="Excluir" OnClientClick="if(!confirm('Deseja excluir o anúncio ?')) return false;" />
                        <asp:Button ID="bntSalvar" runat="server" CssClass="btn btn-secondary" OnClick="btnSalvar_Click" Text="Salvar" ValidationGroup="anuncio" />
                    </div>
                </div>
                <!--Salvar fim-->

            </div>
        </div>

    </div>

</asp:Content>

