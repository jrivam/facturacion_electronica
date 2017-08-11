<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="mSerieDocumento.aspx.cs" Inherits="App_ifac.mSerieDocumentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainBody" runat="server">
    <div class="right_col" role="main">
	    <div class="">	
            <div class="page-title">
                <div class="title_left">
                <h3>Registro de la Serie de los Documentos de Venta</h3>
                </div>

                <div class="title_right">
                <div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search">
                    <div class="input-group">
                        <asp:TextBox ID="txtBuscar" class="form-control" runat="server" placeholder="Buscar..."></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="btnBuscar" runat="server" class="btn btn-round btn-info" Text="Vamos!" />
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
                                    <h2><small>Ingrese los documentos y serie a usar</small></h2>
                                    <ul class="nav navbar-right panel_toolbox">
                                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                        </li>
                                    </ul>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="x_content">
                                <br />
                                    <div class="form-horizontal form-label-left input_mask">
                                        <div class="col-md-8 col-sm-8 col-xs-12 form-group has-feedback">
						                    <label class="control-label col-md-2 col-sm-2 col-xs-12">Documento:</label>
                                            <div class="col-md-10 col-sm-10 col-xs-12">
                                                <asp:DropDownList ID="cboDocumento" runat="server" class="select2_single form-control"></asp:DropDownList>
                                            </div>
					                    </div>
                                        <div class="col-md-2 col-sm-2 col-xs-12 form-group has-feedback">
                                            <asp:TextBox ID="txtSerie" class="form-control has-feedback-right" runat="server" placeholder="001, 002, ..."></asp:TextBox>
                                        <span class="fa fa-book form-control-feedback right" aria-hidden="true"></span>
                                        </div>

                                        <div class="col-md-2 col-sm-2 col-xs-12 form-group has-feedback">
                                            <asp:TextBox ID="txtNumeroActual" class="form-control" runat="server" placeholder="00000257"></asp:TextBox>
                                        <span class="fa fa-tachometer form-control-feedback right" aria-hidden="true"></span>
                                        </div>                                     
					  
					                    <div class="form-group">
						                    <div class="col-md-6 col-sm-6 col-xs-12">
                                                <label>
                                                    <%--Activo: <asp:CheckBox ID="chkActivo" runat="server" class="js-switch" Checked="true"/>--%>
                                                    Activo: <input id="chkActivo" type="checkbox" class="js-switch" checked/>                                                    
                                                </label>                                            
						                    </div>
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <label>
                                                    <%--Activo: <asp:CheckBox ID="chkActivo" runat="server" class="js-switch" Checked="true"/>--%>
                                                    Electr&oacute;nico: <input id="chkElectronico" type="checkbox" class="js-switch"/>
                                                </label>                                            
						                    </div>
					                    </div>
                                        <div class="form-group"></div>
                                        <div class="ln_solid"></div>
                                        <div class="form-group">
                                                <div class="col-md-9 col-sm-9 col-xs-12 col-md-offset-3">
                                                    <asp:Button ID="btnCancelar" runat="server" class="btn btn-danger" Text="CANCELAR" />
                                                    <asp:Button ID="btnActualizar" runat="server" class="btn btn-warning" Text="ACTUALIZAR" />
                                                    <asp:Button ID="btnGrabar" runat="server" class="btn btn-success" Text="GRABAR" />
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
                                <h2>Serie de Documentos Registrados</h2>
                                <ul class="nav navbar-right panel_toolbox">
                                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                    </li>
                                </ul>
                                <div class="clearfix"></div>
                            </div>
                            <div class="x_content">
                                <asp:GridView ID="grvSerieDocumentos" runat="server" class="table table-striped table-bordered"></asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
	</div>
    </div>
</asp:Content>
