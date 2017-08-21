<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="mEmpresa.aspx.cs" Inherits="App_ifac.mEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainBody" runat="server">
    <div class="right_col" role="main">
	    <div class="">	
            <div class="page-title">
                <div class="title_left">
                <h3>Registro de Empresas</h3>
                </div>

                <div class="title_right">
                <div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search">
                    <div class="input-group">
                        <asp:TextBox ID="txtBuscar" class="form-control" runat="server" placeholder="Buscar..."></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="btnBuscar" runat="server" class="btn btn-round btn-info" Text="Vamos!"  OnClick="btnBuscar_Click" />
                        </span>
                    </div>
                </div>
                </div>
            </div>
            <div class="clearfix"></div>

            <div class="row">
                <div class="col-md-12 col-xs-12">
                        <div class="x_panel">
                                <div class="x_title">
                                    <h2><small>Ingrese los datos de la empresa</small></h2>
                                    <ul class="nav navbar-right panel_toolbox">
                                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                        </li>
                                    </ul>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="x_content">
                                <br />
                                    <div class="form-horizontal form-label-left input_mask">

                                        <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                                            <asp:TextBox ID="txtRuc" class="form-control has-feedback-right" runat="server" placeholder="Ruc"></asp:TextBox>
                                        <span class="fa fa-barcode form-control-feedback right" aria-hidden="true"></span>
                                        </div>

                                        <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                                            <asp:TextBox ID="txtRazonSocial" class="form-control" runat="server" placeholder="Raz&oacute;n Social"></asp:TextBox>
                                        <span class="fa fa-bank form-control-feedback right" aria-hidden="true"></span>
                                        </div>

                                        <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                                            <asp:TextBox ID="txtDireccionFiscal" class="form-control" runat="server" placeholder="Direcci&oacute;n Fiscal"></asp:TextBox>
                                        <span class="fa fa-map-marker form-control-feedback right" aria-hidden="true"></span>
                                        </div>

                                        <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                                            <asp:TextBox ID="txtTelefono" class="form-control" runat="server" placeholder="Tel&eacute;fono"></asp:TextBox>
                                        <span class="fa fa-phone form-control-feedback right" aria-hidden="true"></span>
                                        </div>
					  
					                    <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                                            <asp:TextBox ID="txtEmail" class="form-control" runat="server" placeholder="Email"></asp:TextBox>
                                        <span class="fa fa-envelope form-control-feedback right" aria-hidden="true"></span>
                                        </div>
					  
					                    <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                                            <asp:TextBox ID="txtPaginaWeb" class="form-control" runat="server" placeholder="P&aacute;gina Web"></asp:TextBox>
                                        <span class="fa fa-globe form-control-feedback right" aria-hidden="true"></span>
                                        </div>
					  
					                    <div class="form-group">
						                <div class="col-md-6 col-sm-6 col-xs-12">
                                            <label>
                                                <%--Activo: <asp:CheckBox ID="chkActivo" runat="server" class="js-switch" Checked="true"/>--%>
                                                Activo: <input id="chkActivo" runat="server" type="checkbox" class="js-switch" checked/>
                                            </label>                                            
						                </div>
						                <div class="col-md-6 col-sm-6 col-xs-12">
							                <label>
							                    Emisor Elect&oacute;nico: <input id="chkElectronico" runat="server" type="checkbox" class="js-switch" />
							                </label>
						                </div>
					                    </div>
					  
					                    <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                                            <asp:TextBox ID="txtUsuarioSunat" class="form-control" runat="server" placeholder="Usuario Sunat"></asp:TextBox>
                                        <span class="fa fa-user form-control-feedback right" aria-hidden="true"></span>
                                        </div>
					  
					                    <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                                            <asp:TextBox ID="txtClaveSunat" class="form-control" runat="server" type="password" placeholder="Cl&aacute;ve Sunat"></asp:TextBox>
                                        <span class="fa fa-key form-control-feedback right" aria-hidden="true"></span>
                                        </div>
					  
					                    <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                                            <asp:FileUpload ID="fluCargarFirma" runat="server" class="form-control" placeholder="Cargar Firma Digital"/>
						                <span class="fa fa-search-plus form-control-feedback right" aria-hidden="true"></span>
					                    </div>
					  
					                    <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                                            <asp:TextBox ID="txtEmailEnvio" class="form-control" runat="server" placeholder="Email de ev&iacute;o"></asp:TextBox>
						                <span class="fa fa-envelope form-control-feedback right" aria-hidden="true"></span>
					                    </div>
					  
					                    <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                                            <asp:TextBox ID="txtClaveEmail" class="form-control" runat="server" type="password" placeholder="Cl&aacute;ve Email"></asp:TextBox>
						                <span class="fa fa-key form-control-feedback right" aria-hidden="true"></span>
					                    </div>
					  
					                    <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                                            <asp:TextBox ID="txtSmtpEmail" class="form-control" runat="server" placeholder="SMTP Email"></asp:TextBox>
                                        <span class="fa fa-paper-plane form-control-feedback right" aria-hidden="true"></span>
                                        </div>					  
					                    
                                        <div class="form-group">
                                            <div class="col-md-2 col-sm-2 col-xs-12 form-group has-feedback">
                                                <asp:TextBox ID="txtPuertoEmail" class="form-control" runat="server" placeholder="Puerto Email"></asp:TextBox>
						                    <span class="fa fa-plug form-control-feedback right" aria-hidden="true"></span>
					                        </div>

                                            <div class="col-md-2 col-sm-2 col-xs-12">
							                    <label>
							                        SSL: <input id="chkSSL" runat="server" type="checkbox" class="js-switch" />
							                    </label>				                				
					                        </div>
                                            <div class="col-md-2 col-sm-2 col-xs-12">
                                                <div class="radio">
                                                <label>
                                                    <input id="rbtPruebas" runat="server" type="radio" class="flat" name="iCheck"/> Pruebas
                                                </label>
                                                </div>
                                            </div>
                                            <div class="col-md-2 col-sm-2 col-xs-12">
                                                <div class="radio">
                                                <label>
                                                    <input id="rbtHomologacion" runat="server" type="radio" class="flat" name="iCheck"/> Homologaci&oacute;n
                                                </label>
                                                </div>
                                            </div>
                                            <div class="col-md-2 col-sm-2 col-xs-12">
                                                <div class="radio">
                                                <label>
                                                    <input id="rbtProduccion" runat="server" type="radio" class="flat" name="iCheck"/> Producci&oacute;n
                                                </label>
                                                </div>
                                            </div>
                                        </div>

					                    <div class="form-group">
					                        <div class="col-md-4 col-sm-4 col-xs-12 form-group has-feedback">
						                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Depart:</label>
                                            <div class="col-md-9 col-sm-9 col-xs-12">
                                                <asp:DropDownList ID="cboDepartamento" runat="server" class="select2_single form-control"></asp:DropDownList>
                                            </div>
					                        </div>
					  
					                        <div class="col-md-4 col-sm-4 col-xs-12 form-group has-feedback">
						                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Provincia:</label>
                                            <div class="col-md-9 col-sm-9 col-xs-12">
                                                <asp:DropDownList ID="cboProvincia" runat="server" class="select2_single form-control"></asp:DropDownList>
                                            </div>
					                        </div>
					  
					                        <div class="col-md-4 col-sm-4 col-xs-12 form-group has-feedback">
						                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Distrito:</label>
                                            <div class="col-md-9 col-sm-9 col-xs-12">
                                                <asp:DropDownList ID="cboDistrito" runat="server" class="select2_single form-control"></asp:DropDownList>
                                            </div>
					                        </div> 
					  
					                        <div class="form-group">
						                    <div class="col-md-4 col-sm-4 col-xs-12">
							                    <label>
							                        Es Corporativo: <input id="chkCorporativo" runat="server" type="checkbox" class="js-switch" />
							                    </label>
						                    </div>
						                    <div class="col-md-4 col-sm-4 col-xs-12">
							                    <label>
							                        Agente de Percepci&oacute;n: <input id="chkAgentePercepcion" runat="server" type="checkbox" class="js-switch" />
							                    </label>
						                    </div>
						                    <div class="col-md-4 col-sm-4 col-xs-12">
							                    <label>
							                        Buen Contribuyente: <input id="chkBuenContribuyente" runat="server" type="checkbox" class="js-switch" />
							                    </label>
						                    </div>						
					                        </div>
					  
					                        <div class="form-group">						
						                    <div class="col-md-6 col-sm-6 col-xs-12">
							                    <label>
							                        Agente de Retenci&oacute;n: <input id="chkAgenteRetencion" runat="server" type="checkbox" class="js-switch" />
							                    </label>
						                    </div>
						                    <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                                                <asp:FileUpload ID="fluCargaLogo" runat="server" class="form-control" placeholder="Carga del Logo"/>
							                    <span class="fa fa-search-plus form-control-feedback right" aria-hidden="true"></span>
						                    </div>
					                        </div>
                      
                                            <div class="form-group">
						
                                            </div>
					                        <div class="form-group">
						                        <div class="col-md-12 col-sm-12 col-xs-12 form-group has-feedback">
							                    <div class="thumbnail">
							                        <div class="image view view-first">
								                    <img style="width: 100%" src="images/media.jpg" alt="image" />                            
							                        </div>
							                    </div>
						                        </div>
					                        </div>
                                            <div class="ln_solid"></div>
                                            <div class="form-group">
                                                <div class="col-md-9 col-sm-9 col-xs-12 col-md-offset-3">
                                                    <asp:Button ID="btnCancelar" runat="server" class="btn btn-danger" Text="CANCELAR" />
                                                    <asp:Button ID="btnActualizar" runat="server" class="btn btn-warning" Text="ACTUALIZAR" OnClick="btnActualizar_Click" />
                                                    <asp:Button ID="btnGrabar" runat="server" class="btn btn-success" Text="GRABAR" OnClick="btnGrabar_Click" />
                                                </div>
                                            </div>
                                    </div>
                                </div>
                        </div>           
                </div>
            <div class="clearfix"></div>			
                <div class="row">			
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_panel">
                            <div class="x_title">
                                <h2>Empresas Registradas</h2>
                                <ul class="nav navbar-right panel_toolbox">
                                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                    </li>
                                </ul>
                                <div class="clearfix"></div>
                            </div>
                            <div class="x_content">
                                <asp:GridView ID="grvEmpresas" runat="server" class="table table-striped table-bordered"></asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
	</div>
    </div>
</asp:Content>
