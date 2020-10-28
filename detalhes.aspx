<%@ Page Language="C#" MasterPageFile="~/mestre.Master" AutoEventWireup="true" CodeBehind="detalhes.aspx.cs" Inherits="quartoesuite.detalhes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- breadcrumb -->
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="default.aspx" title="Home">Home</a></li>
            <li class="breadcrumb-item active" aria-current="page" title="Imóvel">Imóvel</li>
        </ol>
    </nav>
    <!-- breadcrumb fim-->

    <div class="container-fluid">

        <div class="row">
            <div class="col-sm-12">
                <h1>
                   <asp:Literal ID="ltlImovel" runat="server"></asp:Literal> <asp:Literal ID="ltlSubImovel" runat="server"></asp:Literal>
                </h1>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-7">

                    <div class="row">
                            <div class="col-sm-12">                               

                                <!-- carousel -->
                                <div id="carouselExampleControls" class="carousel slide mb-4 shadow-sm" data-ride="carousel">
                                    <asp:Panel ID="pnlFoto" runat="server" CssClass="carousel-inner" Visible="false"> 
                                        <asp:Repeater ID="rpFotos" runat="server" OnItemDataBound="OnItemDataBound">
                                            <ItemTemplate> 
                                                <div class="carousel-caption">
                                                   <small class="alert alert-secondary"><%# DataBinder.Eval(Container.DataItem, "situacao") %></small>
                                                </div>
                                                <div class="carousel-item <asp:Literal ID="ltlActive" runat="server"></asp:Literal>">
                                                    <asp:Image ID="ibtnImgAnuncio" CssClass="d-block w-100 rounded border" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "foto") %>' runat="server" ToolTip='<%# DataBinder.Eval(Container.DataItem, "titulo") %>' AlternateText='<%# DataBinder.Eval(Container.DataItem, "titulo") %>' />
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>                                    
                                    </asp:Panel>
                                    <asp:Panel ID="pnlSemFoto" runat="server" CssClass="carousel-inner" Visible="false">
                                        <div class="carousel-item active">
                                            <asp:Image ID="ibtnImgAnuncio" CssClass="d-block w-100 rounded border" ImageUrl="../image/anuncio/400/imovel.jpg" runat="server" ToolTip='Sem Foto' AlternateText='Sem Foto' />
                                        </div>
                                    </asp:Panel>                                    

                                    <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
                                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                        <span class="sr-only">Previous</span>
                                    </a>
                                    <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next">
                                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                        <span class="sr-only">Next</span>
                                    </a>
                                </div>

                            </div>
                        </div>

                <!--Localização-->
                <asp:Panel ID="pnlLocalizacao" runat="server" CssClass="card mb-4 shadow-sm">
                    <h2 class="card-header">Localização</h2>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-sm-12">
                                <h3>Endereço</h3>
                                <p>
                                   <asp:Literal ID="ltlEndereco" runat="server"></asp:Literal>,
                                   <asp:Literal ID="ltlNumero" runat="server"></asp:Literal>
                                   <asp:Literal ID="ltlComplemento" runat="server"></asp:Literal>
                                </p>
                            </div>
                            </div>
                        <div class="row">
                            <div class="col-sm-3">
                                <h3>Bairro</h3>
                                <p>
                                   <asp:Literal ID="ltlBairro" runat="server"></asp:Literal>
                                </p>
                            </div>
                            <div class="col-sm-3">
                                <h3>Cidade</h3>
                                <p>
                                   <asp:Literal ID="ltlCidade" runat="server"></asp:Literal>
                                </p>
                            </div>
                            <div class="col-sm-3">
                                <h3>Estado</h3>
                                <p>
                                   <asp:Literal ID="ltlEstado" runat="server"></asp:Literal>
                                </p>
                            </div>
                            <div class="col-sm-3">
                                <h3>CEP</h3>
                                <p>
                                   <asp:Literal ID="ltlCep" runat="server"></asp:Literal>
                                </p>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

                <!--Caracteritica-->
                <asp:Panel ID="pnlCaracteristica" runat="server" CssClass="card mb-4 shadow-sm">
                    <h2 class="card-header">Características</h2>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-sm-2">
                                <h3>Área Útil</h3>
                                <p>
                                   <asp:Literal ID="ltlAreaUtil" runat="server"></asp:Literal>
                                </p>
                            </div>
                            <div class="col-sm-2">
                                <h3>Área Total</h3>
                                <p>
                                   <asp:Literal ID="ltlAreaTotal" runat="server"></asp:Literal>
                                </p>
                            </div>
                            <div class="col-sm-2">
                                <h3>Pé Direito</h3>
                                <p>
                                   <asp:Literal ID="ltlPeDireito" runat="server"></asp:Literal>
                                </p>
                            </div>
                            <div class="col-sm-2">
                                <h3>Andar</h3>
                                <p>
                                   <asp:Literal ID="ltlAndar" runat="server"></asp:Literal>
                                </p>
                            </div>
                            <div class="col-sm-2">
                                <h3>Quartos</h3>
                                <p>
                                   <asp:Literal ID="ltlQuartos" runat="server"></asp:Literal>
                                </p>
                            </div>
                            <div class="col-sm-2">
                                <h3>Suítes</h3>
                                <p>
                                   <asp:Literal ID="ltlSuites" runat="server"></asp:Literal>
                                </p>
                            </div>
                            <div class="col-sm-2">
                                <h3>Banheiros</h3>
                                <p>
                                   <asp:Literal ID="ltlBanheiros" runat="server"></asp:Literal>
                                </p>
                            </div>
                            <div class="col-sm-2">
                                <h3>Vagas</h3>
                                <p>
                                   <asp:Literal ID="ltlVagas" runat="server"></asp:Literal>
                                </p>
                            </div>

                        </div>

                    </div>
                </asp:Panel>

                <!--Descrição-->
                <asp:Panel ID="pnlDescricao" runat="server" CssClass="card mb-4 shadow-sm" Visible="false">
                    <h2 class="card-header">Descrição</h2>
                    <div class="card-body">
                        <p class="card-text">
                            <asp:Literal ID="ltlDescricao" runat="server"></asp:Literal>
                        </p>
                    </div>
                </asp:Panel>

                <!--Comodidade-->
                <asp:Panel ID="pnlComodidade" runat="server" CssClass="card mb-4" Visible="false">
                    <h2 class="card-header">Comodidades</h2>
                    <div class="card-body">
                        <div class="row">
                            <asp:Repeater ID="rpComodidade" runat="server">
                                <ItemTemplate>
                                    <div class="col-sm-4">
                                        <p class="card-text">
                                            <asp:Image ID="imgTick" ImageUrl="../image/tick.png" runat="server" />
                                            <asp:Literal ID="ltlComodidade" Text='<%# DataBinder.Eval(Container.DataItem, "comodidade") %>' runat="server"></asp:Literal>
                                        </p>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </asp:Panel>

                <!--Planta-->
                <asp:Panel ID="pnlPlanta" runat="server" CssClass="card mb-4 shadow-sm" Visible="false">
                    <h2 class="card-header">Planta</h2>
                    <div class="card-body">
                        <div class="row">
                            <asp:Repeater ID="rpPlanta" runat="server">
                                <ItemTemplate>
                                    <div class="col-sm-4">
                                        <p class="card-text">
                                            <asp:Image ID="imgTick" ImageUrl="../image/tick.png" runat="server" />
                                            <asp:Literal ID="ltlPlanta" Text='<%# DataBinder.Eval(Container.DataItem, "planta") %>' runat="server"></asp:Literal>
                                        </p>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </asp:Panel>


            </div>
            <div class="col-sm-5">

                <!--Valor-->
                <asp:Panel ID="pnlValor" runat="server" CssClass="card mb-4 shadow-sm">
                    <h2 class="card-header"><asp:Literal ID="ltlEdificacao" runat="server"></asp:Literal> / <asp:Literal ID="ltlContrato" runat="server"></asp:Literal></h2>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-sm-4">
                               <h3>Valor</h3>
                               <p><asp:Literal ID="ltlValor" runat="server"></asp:Literal></p>
                            </div>                            
                            <div class="col-sm-4">
                               <h3>Valor Condomínio</h3>
                               <p><asp:Literal ID="ltlValorCondominio" runat="server"></asp:Literal></p>
                            </div>                            
                            <div class="col-sm-4">
                               <h3>Valor Iptu</h3>
                               <p><asp:Literal ID="ltlValorIptu" runat="server"></asp:Literal></p>
                            </div>
                         </div>
                    </div>
                </asp:Panel>

                <!--Anunciante-->
                <asp:Panel ID="pnlAnunciante" runat="server" CssClass="card mb-4 shadow-sm">
                    <h2 class="card-header"><asp:Literal ID="ltlNivel" runat="server"></asp:Literal></h2>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Image ID="imgLogo" runat="server" class="img-thumbnail mr-3" Width="100" />
                            </div>
                            <div class="col-md-10">
                               <div class="row">  
                                  <div class="col-md-6">
                                     <h3>Empresa</h3> 
                                     <p>
                                        <asp:Literal ID="ltlEmpresa" runat="server"></asp:Literal>
                                     </p>
                                  </div>
                                  <div class="col-md-6">
                                     <h3>Nome</h3>
                                     <p>
                                        <asp:Literal ID="ltlNome" runat="server"></asp:Literal>
                                     </p>
                                   </div>
                                  <div class="col-md-6">
                                      <h3>Creci</h3>
                                      <p>
                                         <asp:Literal ID="ltlCreci" runat="server"></asp:Literal>
                                      </p>
                                   </div>   
                                   <div class="col-md-6">
                                      <h3>Código Anúncio</h3>
                                      <p>
                                         <asp:Literal ID="ltlCodigoAnuncio" runat="server"></asp:Literal>
                                      </p>
                                   </div>  
                               </div>
                            </div>
                        </div>
                    </div>                    
                </asp:Panel>

                <!--Contato-->
                <asp:Panel ID="pnlContato" runat="server" CssClass="card mb-4 shadow-sm">
                    <h2 class="card-header">Contato</h2>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-6">
                                <h3>Telefone</h3>
                                <p>
                                   <asp:Literal ID="ltlTelefone" runat="server"></asp:Literal>
                                </p>
                            </div>
                            <div class="col-md-6">
                                <h3>Celular</h3>
                                <p>
                                   <asp:Literal ID="ltlCelular" runat="server"></asp:Literal>
                                </p>
                            </div>
                            <div class="col-md-12">
                                <h3>E-mail</h3>
                                <p>
                                    <asp:Literal ID="ltlEmail" runat="server"></asp:Literal>
                                </p>
                            </div>
                            <div class="col-md-12">
                                <h3>Site</h3>
                                <p>
                                    <asp:Literal ID="ltlSite" runat="server"></asp:Literal>
                                </p>
                            </div>

                          </div>
                        </div>
                    
                </asp:Panel>                

            </div>
        </div>
    </div>



</asp:Content>
