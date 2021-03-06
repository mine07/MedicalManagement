﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pagos.aspx.cs" Inherits="MedicalManagement.testUDW"   MasterPageFile="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %> 


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
                <a href="#" onClick="history.back();" __designer:mapid="696"><label class="pull-right label label-primary label-button" __designer:mapid="697">Volver<i class="fa fa-arrow-left fa-margin-left" __designer:mapid="698"></i></label></a><div class="hidden"></div>
                <h3>Pagos</h3>
            </div>
            <hr />

    <asp:ScriptManager ID="ScriptManager1" runat="server"> 
    </asp:ScriptManager> 
    <div> 
        <asp:UpdatePanel ID="udpOutterUpdatePanel" runat="server" ChildrenAsTriggers="True" ClientIDMode="Static"> 
             <ContentTemplate> 
                 <ajaxToolkit:ModalPopupExtender runat="server" 
                        ID="mpeThePopup" 
                        TargetControlID="btnAdd" 
                        PopupControlID="pnlModalPopUpPanel" 
                        BackgroundCssClass="modalBackground"                        
                        DropShadow="true" CancelControlID="btnCancelModalPopup"/>
            <%--<label style="font-weight: bold; font-size: x-large; font-family: Helvetica;">Pagos</label>--%>
            <div class="container-fluid border-top1-bottom5">
                     <div class="row">
                         <div class="col-xs-12 col-sm-12 col-lg-2 col-md-2">
                             <div class="row">
                                 <div class="col-xs-12 col-sm-4 col-lg-12 col-md-12 text-right">
                                     <div class="dropdown">
                                    <button class="btn btn-default dropdown-toggle form-control" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                                        <span id="ddl">Filtro...</span>
                                        <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu" aria-labelledby="dropdownMenu1">
                                        <li class="text"><a href="#">Por Cobrar y Cobrado</a></li>
                                        <li class="text"><a href="#">Por Cobrar</a></li>
                                        <li class="text"><a href="#">Cobrado</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <hr class="hidden-sm" />
                        <div class="row">
                            <div class="col-xs-12 col-sm-4 col-lg-12 col-md-12 text-center">
                                <label>Entre</label>
                            </div>
                            <div class="col-xs-6 col-sm-6 col-lg-6 col-md-6">
                                <input class="datetimepicker form-control" type="text" />
                            </div>
                            <div class="col-xs-6 col-sm-6 col-lg-6 col-md-6">
                            </div>
                        </div>
                        <hr class="hidden-sm" />
                        <div class="row">
                            <div class="col-xs-12 col-sm-4 col-lg-12 col-md-12 text-center">
                                <label>Conceptos de Pago</label>
                            </div>
                            <div class="col-xs-12 col-sm-12 col-lg-12 col-md-12 text-right">
                                <a class="label label-secondary form-control" href='#' data-toggle="modal" data-target="#myModal">Agregar</a>
                            </div>
                        </div>
                        <hr />
                    </div>
                    <div class="col-xs-12 col-sm-12 col-lg-10 col-md-10 hidden-xs">
                        <div id="gridPagos">
                            <asp:GridView ID="gvHistPagos" runat="server"
                                AutoGenerateColumns="False"
                                GridLines="None"
                                AllowPaging="true"
                                CssClass="mGrid"
                                PagerStyle-CssClass="pgr"
                                AlternatingRowStyle-CssClass="alt"
                                ShowHeader="True" ShowFooter="true">
                                <Columns>
                                    <asp:BoundField DataField="FechaAlta_Pagos" ItemStyle-Width="10%" HeaderText="Fecha" />
                                    <asp:BoundField DataField="Descripcion_Pagos" ItemStyle-Width="30%" HeaderText="Descripcion" />
                                    <asp:BoundField DataField="Origen_Pagos" ItemStyle-Width="10%" HeaderText="Origen" />
                                    <asp:BoundField DataField="Importe_Pagos" ItemStyle-Width="10%" HeaderText="Importe" />
                                    <asp:BoundField DataField="Pagado_Pagos" ItemStyle-Width="10%" HeaderText="Pagado" />
                                    <asp:BoundField DataField="Debe_Pagos" ItemStyle-Width="10%" HeaderText="Debe" />
                                    <asp:BoundField DataField="FechaParaPagar_Pagos" ItemStyle-Width="10%" HeaderText="FPP" />
                                    <asp:BoundField DataField="FechaPagado_Pagos" ItemStyle-Width="10%" HeaderText="FP" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <hr class="blue-hr" />
                <div class="row">
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center" style="width: 100%">
                        <label style="width: 100%;" class="label label-primary">Pagos a realizar</label>
                    </div>
                </div>
                <hr class="blue-hr" />
                <div class="row">

                    <div class="col-xs-12 col-md-6 col-sm-12 col-lg-6">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                                    <label>Usuario</label>
                                </div>
                                <div class="col-xs-12 col-md-8 col-sm-8 col-lg-8">
                                    <asp:DropDownList runat="server" ID="ddlFichas" DataTextField="_NombreCompleto" DataValueField="Id_FichaIdentificacion" CssClass="form-control" OnSelectedIndexChanged="ddlFichas_SelectedIndexChanged" EnableTheming="True"></asp:DropDownList><hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12 col-md-4 col-sm-4 col-lg-4 ">
                                    <label>Descripcion</label>
                                </div>
                                <div class="col-xs-12 col-md-8 col-sm-8 col-lg-8">
                                    <input type="text" class="form-control" name="txtDescripcionPago" /><hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12 col-md-4 col-sm-4 col-lg-4 ">
                                    <label>Origen</label>
                                </div>
                                <div class="col-xs-12 col-md-8 col-sm-8 col-lg-8">
                                    <input type="text" class="form-control" name="txtOrigenPago" /><hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12 col-md-4 col-sm-4 col-lg-4 ">
                                    <label>Importe</label>
                                </div>
                                <div class="col-xs-12 col-md-8 col-sm-8 col-lg-8">
                                    <input type="text" class="form-control" name="txtOrigenPago" /><hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12 col-md-4 col-sm-4 col-lg-4 ">
                                    <label>Pagado</label>
                                </div>
                                <div class="col-xs-12 col-md-8 col-sm-8 col-lg-8 ">
                                    <input type="text" class="form-control" name="txtPagado" /><hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12 col-md-4 col-sm-4 col-lg-4 ">
                                    <label>Debe</label>
                                </div>
                                <div class="col-xs-12 col-md-8 col-sm-8 col-lg-8">
                                    <input type="text" class="form-control" name="txtDebePagos" /><hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12 col-md-4 col-sm-4 col-lg-4 ">
                                    <ajaxToolkit:calendarextender id="CalendarExtender1" runat="server" enabled="True"
                                        format="dd-MM-yyyy" targetcontrolid="txtFPP" />
                                    <ajaxToolkit:calendarextender id="CalendarExtender2" runat="server" enabled="True"
                                        format="dd-MM-yyyy" targetcontrolid="txtDate" />
                                    <label>FPP</label>
                                </div>
                                <div class="col-xs-12 col-md-8 col-sm-8 col-lg-8">
                                    <asp:TextBox ID="txtFPP" runat="server" Width="290px" Height="34px" />
                                    <hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12 col-md-4 col-sm-4 col-lg-4 ">
                                    <label>FP</label>
                                </div>
                                <div class="col-xs-12 col-md-8 col-sm-8 col-lg-8">
                                    <asp:TextBox ID="txtDate" runat="server" Width="290px" Height="34px" />
                                    <hr />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-xs-12 col-md-6 col-lg-6 col-sm-12">
                        <div class="border-top1-bottom5">
                            <asp:Button ID="btnAdd" runat="server" Text="Agregar Pago" CssClass="btn-primary" Height="31px" Width="103px" OnClick="Add" data-toggle="modal" data-target="#myModalB" />
                            <hr class="blue-hr" />
                            <div id="initialDiv" class="conceptContainer container-fluid">
                                <div class="row hidden-xs hidden-sm">
                                    <div class="col-xs-12 col-md-3 col-sm-6 col-lg-3">Concepto</div>
                                    <div class="col-xs-12 col-md-3 col-sm-6 col-lg-3">Cantidad</div>
                                    <div class="col-xs-12 col-md-3 col-sm-6 col-lg-3">Pago</div>
                                    <div class="col-xs-12 col-md-3 col-sm-6 col-lg-3">Descuento</div>
                                </div>
                                <hr />
                                <asp:GridView ID="gvConceptos" runat="server"
                                    AutoGenerateColumns="False"
                                    GridLines="None"
                                    AllowPaging="true"
                                    CssClass="mGrid"
                                    PagerStyle-CssClass="pgr"
                                    AlternatingRowStyle-CssClass="alt"
                                    ShowHeader="false">
                                    <Columns>
                                        <asp:BoundField DataField="Concepto" ItemStyle-Width="25%" />
                                        <asp:BoundField DataField="Cantidad" ItemStyle-Width="25%" />
                                        <asp:BoundField DataField="Total" ItemStyle-Width="30%" />
                                        <asp:BoundField DataField="Descuento" ItemStyle-Width="30%" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row"></div>
                <hr class="blue-hr" />
                <div class="col-xs-12 text-right">
                    <asp:Button ID="btnClean" runat="server" Text="Limpiar" CssClass="btn-primary" OnClick="btnClean_Click" />
                    <asp:Button ID="btnSavePagos" runat="server" Text="Guardar Pago" CssClass="btn-primary" OnClick="btnSavePagos_Click"/>
                </div>
            </div>
            <%--Modal para agregar nuevos conceptos de pago--%>
            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" id="myModalLabel">Agregar Concepto De Pago</h4>
                        </div>
                        <div class="modal-body container-fluid">
                            <div class="row">
                                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                                    <label>Descripcion</label>
                                </div>
                                <div class="col-xs-12 col-md-9 col-sm-9 col-lg-9">
                                    <asp:TextBox runat="server" type="text" id="txtDescripcion" class="form-control" />
                                </div>
                            </div>
                            <hr class="blue-hr" />
                            <div class="row">
                                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                                    <label>Nombre Corto</label>
                                </div>
                                <div class="col-xs-12 col-md-9 col-sm-9 col-lg-9">
                                    <asp:TextBox runat="server" type="text" id="txtNombreCorto" class="form-control" />
                                </div>
                            </div>
                            <hr class="blue-hr" />
                            <div class="row">
                                <div class="col-xs-12 col-md-9 col-sm-9 col-lg-3">
                                    <label>Precio Unitario</label>
                                </div>
                                <div class="col-xs-12 col-md-9 col-sm-9 col-lg-9">
                                     <asp:TextBox runat="server" type="number" id="txtPrecioPredef" class="form-control" />
                                </div>
                            </div>
                            <hr class="blue-hr" />
                            <div class="row">
                                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                                    <label>Activado</label>
                                </div>
                                <div class="col-xs-12 col-md-9 col-sm-9 col-lg-9">
                                     <asp:CheckBox runat="server" type="checkbox" id="checkEstatus" />
                                </div>
                            </div>
                            <hr class="blue-hr" />
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                            <asp:LinkButton OnClick="addConcepto" ID="LinkButton7" runat="server"><label class="btn btn-default">Aceptar</label></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>

                 <asp:Panel ID="pnlModalPopUpPanel" runat="server" CssClass="modalPopup" style="display:none" > 
               <%--     <asp:UpdatePanel ID="udpInnerUpdatePanel" runat="Server"  ChildrenAsTriggers="True" ClientIDMode="Static">  
                        <ContentTemplate>--%>
                            <div class="modal-header">Agregar Pago
                                <h4 class="modal-title" id="myModalBLabel">Agregar Concepto De Pago</h4>
                            </div>
                            <div class="modal-body container-fluid">
                                <div class="row">
                                    <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                                        <label>Concepto</label>
                                    </div>
                                    <div class="col-xs-12 col-md-9 col-sm-9 col-lg-9">
                                        <asp:DropDownList ID="ddlConceptos" DataTextField="Descripcion_ConceptoPago"
                                        DataValueField="Id_ConceptoPago" runat="server" CssClass="form-control" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlConceptos_Selected" EnableViewState="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                    <hr class="blue-hr" />
                    <div class="row">
                        <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                            <label>Cantidad</label>
                        </div>
                        <div class="col-xs-12 col-md-9 col-sm-9 col-lg-9">
                            <asp:TextBox ID="txtCantidad" runat="server"  TextMode="Number" CssClass="form-control"/>
                        </div>
                    </div>
                    <hr class="blue-hr" />
                    <div class="row">
                        <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                            <label>Precio</label>
                        </div>
                        <div class="col-xs-12 col-md-9 col-sm-9 col-lg-9">
                            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"/>
                        </div>
                    </div>
                    <hr class="blue-hr" />
                    <div class="row">
                        <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                            <label>Descuento</label>
                        </div>
                        <div class="col-xs-12 col-md-9 col-sm-9 col-lg-9">
                            <asp:TextBox ID="txtDescuento" runat="server"  TextMode="Number" CssClass="form-control"/>
                        </div>
                    </div>
                    <hr class="blue-hr" />
                </div>
            <asp:Button ID="btntest" runat="server" Text="Agregar"  CssClass="btn btn-primary" OnClick="btntes" />
            <asp:Button ID="btnCancelModalPopup" runat="server" Text="Cancel"  CssClass="btn btn-primary" /> 
                     <%--   </ContentTemplate>       
                    </asp:UpdatePanel>--%> 
                 </asp:Panel> 
            </ContentTemplate>
                   <Triggers>
                       <asp:AsyncPostBackTrigger ControlID="btntest" EventName="Click" />
                       <asp:asyncpostbacktrigger controlid="ddlConceptos" eventname="SelectedIndexChanged" />
                   </Triggers> 
        </asp:UpdatePanel>
    </div>

</asp:Content>