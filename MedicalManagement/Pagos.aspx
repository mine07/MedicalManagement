<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pagos.aspx.cs" Inherits="MedicalManagement.Pagos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AjaxFrameworkMode="Enabled" />
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server"  ClientIDMode="Static" ChildrenAsTriggers="true" UpdateMode="Conditional">
    <ContentTemplate>--%>
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
    <!--                                          Scripts                                                          -->

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
            PageSize= "10"  ShowHeader="True">
          <Columns>
              <asp:BoundField DataField = "Fecha" ItemStyle-Width="10%"       HeaderText="Fecha"/>
              <asp:BoundField DataField = "Descripcion" ItemStyle-Width="30%" HeaderText="Descripcion"/>
              <asp:BoundField DataField = "Origen" ItemStyle-Width="10%" HeaderText="Origen"/>
              <asp:BoundField DataField = "Importe" ItemStyle-Width="10%" HeaderText="Importe"/>
              <asp:BoundField DataField = "Pagado" ItemStyle-Width="10%" HeaderText="Pagado"/>
              <asp:BoundField DataField = "Debe" ItemStyle-Width="10%" HeaderText="Debe"/>
              <asp:BoundField DataField = "FPP" ItemStyle-Width="10%" HeaderText="FPP"/>
              <asp:BoundField DataField = "FP" ItemStyle-Width="10%" HeaderText="FP"/>
              <asp:BoundField DataField = "Factura" ItemStyle-Width="20%" HeaderText="FACTURA"/>
              <asp:TemplateField  HeaderText = " ">
                  <ItemTemplate>
                      <asp:LinkButton ID="lnkEdit" runat="server" Text = "Editar" OnClick="Edit" ></asp:LinkButton>
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
    <label  style="width:100%;" class="label label-primary">Pagos a realizar</label>
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
                            <asp:DropDownList runat="server" ID="ddlFichas" DataTextField="_NombreCompleto" DataValueField="Id_FichaIdentificacion" CssClass="form-control"></asp:DropDownList><hr />
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
                            <input type="text" class="form-control" /><hr />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 col-md-4 col-sm-4 col-lg-4 ">
                            <label>FP</label>
                        </div>
                        <div class="col-xs-12 col-md-8 col-sm-8 col-lg-8">
                            <div class="form-group">
                                <div class='input-group date' id='datetimepicker1'>
                                    <input type='text' class="form-control" />
                                    <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                </div>
                            </div>
                            <input type="text" class="form-control" id="txtDate" /><hr />

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
            PageSize= "10"  ShowHeader="false">
          <Columns>
              <asp:BoundField DataField = "Concepto" ItemStyle-Width="25%"/>
              <asp:BoundField DataField = "Cantidad" ItemStyle-Width="30%"/>
              <asp:BoundField DataField = "Total" ItemStyle-Width="30%"/>
              <asp:BoundField DataField = "Descuento" ItemStyle-Width="20%"/>
              <asp:TemplateField  HeaderText = " ">
                  <ItemTemplate>
                      <asp:LinkButton ID="lnkEdit" runat="server" Text = "Edit" OnClick="Edit" ></asp:LinkButton>
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
     <asp:Button ID="btnClean" runat="server" Text="Limpiar"  CssClass="btn-primary" OnClick="btnClean_Click" />
     <asp:Button ID="btnSavePagos" runat="server" Text="Guardar Pago"  CssClass="btn-primary" OnClick="btnSavePagos_Click"/>
     </div>
     </div>
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
                    <input type="number" id="txtPrecioPredef" class="form-control"/>
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


    <asp:Panel ID="pnlAddEdit" runat="server" CssClass="modalPopup">
        
    <div class="modal-header">
    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
    <span aria-hidden="true">&times;</span></button>Agregar Pago
    <h4 class="modal-title" id="myModalBLabel">Agregar Concepto De Pago</h4>
    </div>
    <div class="modal-body container-fluid">
                    <div class="row">
                        <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                            <label>Concepto</label>
                        </div>
                        <div class="col-xs-12 col-md-9 col-sm-9 col-lg-9">
                            <asp:DropDownList ID="ddlConceptos" DataTextField="Descripcion_ConceptoPago"  AutoPostBack="true"
                            DataValueField="Id_ConceptoPago" runat="server" CssClass="form-control" 
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
    <asp:Button ID="btnSave" runat="server" Text="Save"  CssClass="btn-primary" OnClick="btnSave_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="btn-primary" OnClick="CancelAdd" />
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="popup" runat="server" DropShadow="false" PopupControlID="pnlAddEdit" TargetControlID="btnAdd" OkControlID="btnCancel" BackgroundCssClass="modalBackground"  />
    <%--</ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger  ControlID="btnAdd" EventName="Click"/>
            <asp:AsyncPostBackTrigger  ControlID="DropDownList1" EventName="SelectedIndexChanged"/>
        </Triggers>
     </asp:UpdatePanel>--%>
    <script>
    function addConcepto() {
            var descripcion = $("#txtDescripcion").val();
            var nombreCorto = $("#txtNombreCorto").val();
            var estatus = false;
            if ($("#checkEstatus").is(':checked')) {
                estatus = true;
            }
            var oneConcepto = { Id_ConceptoPago: "0", Descripcion_ConceptoPago: descripcion, NombreCorto_ConceptoPago: nombreCorto, Estatus_ConceptoPago: estatus };
            console.log(oneConcepto);
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "GetDates.asmx/InsertarConcepto",
                data: JSON.stringify({ 'oneConcepto': oneConcepto }),
                success: success,
                dataType: "json"
            });
    }




 function success() {
            $('#myModal').modal('hide');
            $(':input', '#myModal')
                .not(':button, :submit, :reset, :hidden')
                .val('');
 }

    </script>
    <script type="text/javascript">
            $(function () {
                $('#datetimepicker1').datetimepicker();
            });
        </script>
    <script type="text/javascript">
        function BlockUI(elementID) {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_beginRequest(function () {
                $("#" + elementID).block({
                    message: '<table align = "center"><tr><td><img src="Images/loading-x.gif"/></td></tr></table>', css: {}, overlayCSS: { backgroundColor: '#000000', opacity: 0.6 }
                });
            });
            prm.add_endRequest(function () {
                $("#" + elementID).unblock();
            });
        }
        $(document).ready(function () {
            BlockUI("<%=pnlAddEdit.ClientID %>");
            $.blockUI.defaults.css = {};
        });
    </script>
    </asp:Content>
