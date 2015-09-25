<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagosOM.aspx.cs" Inherits="MedicalManagement.testUDW" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %> 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"> 


<html xmlns="http://www.w3.org/1999/xhtml"> 
<head runat="server"> 
    <title></title> 
    <style type="text/css"> 
        .modalBackground { 
            background-color:#333333; 
            filter:alpha(opacity=70); 
            opacity:0.7; 
        } 
        .modalPopup { 
            background-color:#FFFFFF; 
            border-width:1px; 
            border-style:solid; 
            border-color:#CCCCCC; 
            padding:1px; 
            width:300px; 
            Height:200px; 
        }    
    </style> 
      <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="https://code.jquery.com/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.9.2.custom.js" type="text/javascript"></script>
    <link href="~/Styles/jquery-ui-1.9.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/bootstrap.js" type="text/javascript"></script>
    <link href="Styles/bootstrap.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="Styles/jquery.datetimepicker.css" />
    <link href="Styles/footable.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
    <script src="Scripts/jquery.datetimepicker.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap-combobox.js" type="text/javascript"></script>
    <script src="Scripts/responsive-calendar.js" type="text/javascript"></script>
    <link href="Styles/responsive-calendar.css" rel="Stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <script src="Scripts/jqota2.js" type="text/javascript"></script>
    <meta charset="UTF-8" />
     <!-- jTable style file -->
    <link href="/Scripts/jtable/themes/metro/blue/jtable.css" rel="stylesheet" type="text/css" />
    <!-- A helper library for JSON serialization -->
    <script type="text/javascript" src="/Scripts/jtable/external/json2.js"></script>
    <!-- Core jTable script file -->
    <script type="text/javascript" src="/Scripts/jtable/jquery.jtable.js"></script>
    <!-- ASP.NET Web Forms extension for jTable -->
    <script type="text/javascript" src="/Scripts/jtable/extensions/jquery.jtable.aspnetpagemethods.js"></script>
    <script type="text/javascript" src="/Scripts/jtable/localization/jquery.jtable.es.js"></script>
    <link href="/Scripts/validationEngine/validationEngine.jquery.css" rel="stylesheet" type="text/css" />
    <!-- Import Javascript files for validation engine (in Head section of HTML) -->
    <script type="text/javascript" src="/Scripts/validationEngine/jquery.validationEngine.js"></script>
    <script type="text/javascript" src="/Scripts/validationEngine/jquery.validationEngine-en.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
</head> 
<body> 
    <form id="form1" runat="server"> 
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
            <label style="font-weight: bold; font-size: x-large; font-family: Helvetica;">Pagos</label>
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
                                PageSize="10" ShowHeader="True" ShowFooter="true">
                                <Columns>
                                    <asp:BoundField DataField="Fecha" ItemStyle-Width="10%" HeaderText="Fecha" />
                                    <asp:BoundField DataField="Descripcion" ItemStyle-Width="30%" HeaderText="Descripcion" />
                                    <asp:BoundField DataField="Origen" ItemStyle-Width="10%" HeaderText="Origen" />
                                    <asp:BoundField DataField="Importe" ItemStyle-Width="10%" HeaderText="Importe" />
                                    <asp:BoundField DataField="Pagado" ItemStyle-Width="10%" HeaderText="Pagado" />
                                    <asp:BoundField DataField="Debe" ItemStyle-Width="10%" HeaderText="Debe" />
                                    <asp:BoundField DataField="FPP" ItemStyle-Width="10%" HeaderText="FPP" />
                                    <asp:BoundField DataField="FP" ItemStyle-Width="10%" HeaderText="FP" />
                                    <asp:BoundField DataField="Factura" ItemStyle-Width="20%" HeaderText="FACTURA" />
                                    <asp:TemplateField HeaderText=" ">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" Text="Editar" OnClick="Edit"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
                                    <asp:DropDownList runat="server" ID="ddlFichas" DataTextField="_NombreCompleto" DataValueField="Id_FichaIdentificacion" CssClass="form-control" OnSelectedIndexChanged="ddlFichas_SelectedIndexChanged"></asp:DropDownList><hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12 col-md-4 col-sm-4 col-lg-4 ">
                                    <label>Descripcion</label>
                                </div>
                                <div class="col-xs-12 col-md-8 col-sm-8 col-lg-8">
                                    <input type="text" class="form-control" /><hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12 col-md-4 col-sm-4 col-lg-4 ">
                                    <label>Origen</label>
                                </div>
                                <div class="col-xs-12 col-md-8 col-sm-8 col-lg-8">
                                    <input type="text" class="form-control" /><hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12 col-md-4 col-sm-4 col-lg-4 ">
                                    <label>Importe</label>
                                </div>
                                <div class="col-xs-12 col-md-8 col-sm-8 col-lg-8">
                                    <input type="text" class="form-control" /><hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12 col-md-4 col-sm-4 col-lg-4 ">
                                    <label>Pagado</label>
                                </div>
                                <div class="col-xs-12 col-md-8 col-sm-8 col-lg-8 ">
                                    <input type="text" class="form-control" /><hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12 col-md-4 col-sm-4 col-lg-4 ">
                                    <label>Debe</label>
                                </div>
                                <div class="col-xs-12 col-md-8 col-sm-8 col-lg-8">
                                    <input type="text" class="form-control" /><hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12 col-md-4 col-sm-4 col-lg-4 ">
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
                                    PageSize="10" ShowHeader="false">
                                    <Columns>
                                        <asp:BoundField DataField="Concepto" ItemStyle-Width="25%" />
                                        <asp:BoundField DataField="Cantidad" ItemStyle-Width="30%" />
                                        <asp:BoundField DataField="Total" ItemStyle-Width="30%" />
                                        <asp:BoundField DataField="Descuento" ItemStyle-Width="20%" />
                                        <asp:TemplateField HeaderText=" ">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" OnClick="Edit"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
                    <asp:Button ID="btnSavePagos" runat="server" Text="Guardar Pago" CssClass="btn-primary" OnClick="btnSavePagos_Click" />
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
                                    <input type="text" id="txtDescripcion" class="form-control" />
                                </div>
                            </div>
                            <hr class="blue-hr" />
                            <div class="row">
                                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                                    <label>Nombre Corto</label>
                                </div>
                                <div class="col-xs-12 col-md-9 col-sm-9 col-lg-9">
                                    <input type="text" id="txtNombreCorto" class="form-control" />
                                </div>
                            </div>
                            <hr class="blue-hr" />
                            <div class="row">
                                <div class="col-xs-12 col-md-9 col-sm-9 col-lg-3">
                                    <label>Precio Unitario</label>
                                </div>
                                <div class="col-xs-12 col-md-9 col-sm-9 col-lg-9">
                                    <input type="number" id="txtPrecioPredef" class="form-control" />
                                </div>
                            </div>
                            <hr class="blue-hr" />
                            <div class="row">
                                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                                    <label>Activado</label>
                                </div>
                                <div class="col-xs-12 col-md-9 col-sm-9 col-lg-9">
                                    <input type="checkbox" id="checkEstatus" checked />
                                </div>
                            </div>
                            <hr class="blue-hr" />
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                            <button type="button" class="btn btn-primary" onclick="addConcepto()">Agregar</button>
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
            <asp:Button ID="btntest" runat="server" Text="aparece?"  CssClass="btn btn-primary" OnClick="btntes" />
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
    </form>
</body>
</html>