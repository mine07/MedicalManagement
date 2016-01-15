<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="MedicalManagement.Ventas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <%--<a href="#" onClick="history.back();" __designer:mapid="696"><label class="pull-right label label-primary label-button" __designer:mapid="697">Volver<i class="fa fa-arrow-left fa-margin-left" __designer:mapid="698"></i></label></a>--%>
        <h2>Farmacia</h2>
    </div>
    <asp:ScriptManager runat="server" />
    <div class="hidden">
        <table width="100%" border="0">
            <tr>
                <td align="left"><font color="red">Operaciones\Consultas\ConsultasRecetas</font></td>
                <td align="right">
                    <asp:ImageButton ID="ImageGrabar" runat="Server" ImageUrl="IMG/Grabar.png" ToolTip="Grabar ConsultaReceta" OnClick="btnGuardar_ConsultasRecetas_Click"></asp:ImageButton>&nbsp;     
        <asp:ImageButton ID="ImageRegresar" runat="Server" ImageUrl="IMG/Regresar.png" ToolTip="Regresar" OnClick="btnRegresar_ConsultasRecetas_Click"></asp:ImageButton>
                </td>
            </tr>

            <tr>
                <td colspan="2" align="center" runat="Server" id="Alerta"></td>
            </tr>
        </table>

        <div class="container-fluid">
            <div class="row">
            </div>

            <div class="row">
                <asp:TextBox ID="txtBuscar_Receta" runat="server" Columns="40"></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip="Buscar Receta"></asp:ImageButton>
            </div>
            <div class="row">
                <asp:GridView ID="GridViewRecetaPrevia" runat="server" AutoGenerateColumns="false"
                    OnRowCommand="RowCommand">

                    <Columns>

                        <asp:BoundField DataField="Id_ConsultaRecetaPrevia" HeaderText="Id_ConsultaRecetaPrevia"
                            SortExpression="Id_ConsultaResetaPrevia" />

                        <asp:BoundField DataField="Nombre_ConsultaRecetaPrevia" HeaderText="Receta Previa"
                            SortExpression="RecetaPrevia" />

                        <asp:ButtonField ButtonType="Button" CommandName="Elegir" HeaderText="Elegir"
                            ShowHeader="True" Text="Elegir" ItemStyle-HorizontalAlign="Center" />

                    </Columns>

                </asp:GridView>
            </div>

            <div class="row">
                Medicamento
            </div>
            <div class="row">
                <asp:TextBox ID="txtmedicamento" runat="server" Width="800" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </div>

            <%--            <div class="row">
                Dosis
            </div>
            <div class="row">
                <asp:TextBox ID="txtdosis" runat="server" Width="800" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </div>--%>
            <%--<div class="row">
                Notas 
            </div>
            <div class="row">
                <asp:TextBox ID="txtnotas" runat="server" Width="800" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </div>--%>
            <div class="row">
                <asp:LinkButton ID="LinkRecetaPrevia" runat="server" OnClick="LinkRecetaPrevia_Click">Agregar de Receta Previa</asp:LinkButton>
            </div>
            <div class="row">
                <asp:TextBox ID="Txtnombrerecetaprevia" runat="server" Width="400"></asp:TextBox>
            </div>
        </div>
    </div>


    <triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" />
            <asp:AsyncPostBackTrigger ControlID="rptTemporal" />
        </triggers>
    <contenttemplate>

            
            <div class="container-fluid border-top1-bottom5 no-radius no-vertical-padding gray-border">
                <div class="row">
                    <div class="col-xs-12 col-md-4 col-lg-4 col-sm-4 left-panel">
                        
                <%--<hr class="blue-hr" />
                <div class=" text-center">      
                <label class="label-primary label">  
                    <i class="fa fa-user fa-margin-right"></i>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </label>
                </div> --%> 
                <hr class="blue-hr" />
                        <div class="container-fluid">
                            <div class="row">
                                <%--<div class="col-xs-12">
                                    <label>Receta Previa</label>
                                    <div class="input-group">
                                        <span class="input-group-addon"><i class="fa fa-1x fa-search"></i></span>
                                        <asp:DropDownList runat="server" ID="ddlTemplate" CssClass="form-control combobox" DataTextField="Tem_Nombre" DataValueField="Id_Template" />
                                    </div>
                                    <h4>
                                        <label class="label label-success pull-right label-button" data-toggle="modal" data-target="#modalRecPrevia">Ver Receta<i class="fa fa-search"></i></label><h4></h4>
                                        <h4></h4>
                                        <h4></h4>
                                        <h4></h4>
                                        <h4></h4>
                                        <h4></h4>
                                    </h4>
                                </div>--%>
                                <%--<div class="col-xs-12">
                                    <hr />
                                </div>--%>
                               
                            </div>
                            <div class ="row">
                                <div class ="col-xs-12">
                                   <h4>No. Ticket <asp:Label ID="lblTicket" runat="server" Text=""></asp:Label></h4> 
                                </div>
                                
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-xs-12">

                                    <div >
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtSearch" placeholder="Buscar Medicamento..." autocomplete="off" Width ="100%"></asp:TextBox>
                                        <div class="container-fluid searchContainer searchProc border-top1-bottom5">
                                        </div>
                                    </div>
                                </div>
                            </div>
    
                            <div class="row" style="padding-top: 5px;">
                                <div class="col-xs-12">
                                    
                                    <asp:LinkButton OnClick="saveTo" ID="btnSave" runat="server" Text='<h4><label class="label label-success pull-right label-button">Agregar<i class="fa fa-arrow-circle-right"></i></label></h4>' ></asp:LinkButton>
                                    <%--<asp:LinkButton OnClick="btnPrint" ID="LinkButton4" runat="server" Text='<h4><label class="label label-success pull-right label-button">Imprimir<i class="fa fa-arrow-circle-right"></i></label></h4>' ></asp:LinkButton>--%>

                                </div>
                            </div>


                            <hr />
                                
                                     <div class="row">
                                <div class="col-xs-12">
                                        <label>Consulta</label>
                                        <asp:DropDownList runat="Server" CssClass="combobox form-control" ID="ddlConsulta" DataTextField="_NombreConsulta" DataValueField="Id_ConceptoPago"  />
                                    </div>
                                         </div>
                                     
                            
                            <%--<div class="row">
                                <div class="col-xs-12">
                                    <label>Dosis</label>
                                    <input type="text" class="form-control" id="txtDos" runat="server" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <label>Notas</label>
                                    <input type="text" class="form-control" id="txtNot" runat="server" />
                                </div>
                            </div>--%>
                            <div class="row" style="padding-top: 5px;">
                                <div class="col-xs-12">
                                    
                                    <asp:LinkButton OnClick="saveToConsulta" ID="btnSaveConsulta" runat="server" Text='<h4><label class="label label-success pull-right label-button">Agregar<i class="fa fa-arrow-circle-right"></i></label></h4>' ></asp:LinkButton>
                                    <%--<asp:LinkButton OnClick="btnPrint" ID="LinkButton4" runat="server" Text='<h4><label class="label label-success pull-right label-button">Imprimir<i class="fa fa-arrow-circle-right"></i></label></h4>' ></asp:LinkButton>--%>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12 col-md-8 col-lg-8 col-sm-8">
                        <div class="container-fluid padding" id="Medicine-Container">
                            <div class="row">
                                <%--<div class="col-xs-12">
                                    <label class="label label-success pull-right label-button pull-right" style="font-size: 16px;" data-toggle="modal" data-target="#myModal">Guardar Como Receta Previa<i class="fa fa-save"></i></label>
                                    <hr />
                                </div>--%>
                            </div>
                            
                            <div class="gray-container" style="max-height: 450px;">
                                
                                <table width="100%" border="0">
                                            <tr>
                                                <th><label class="h5">Medicamento</label></th>
                                                <th><label class="h5">Costo</label></th> 
                                                
                                            </tr>
                                    
                                    
                                <asp:Repeater runat="server" ID="rptTemporal">
                                    
                                    <ItemTemplate>
                                        
                                            <tr>
                                                <th>
                                                    
                                                    <label><%# Eval("NombreMedicamento") %></label>
                                                </th>
                                                <th>
                                                    
                                                    <label><%# Eval("Costo") %></label>
                                                    
                                                    <asp:LinkButton ID="btnRemove" runat="server" Text='<i class="fa fa-remove fa-1x pull-right remove-icon"></i>' OnClick="RemoveTemporal" CommandArgument='<%# Eval("Id_Ticket") %>' />
                                                
                                                </th>
                                                <%--<th>
                                                    <%# String.Format("{0:f2}",DataBinder.Eval(Container.DataItem, "costo"))%>
                                                    </th>--%>
                                            
                                            </tr>                                                    
                                         
                                                                                        
                                    </ItemTemplate>
                                </asp:Repeater>
                                    
                                    <tr>
                                        <hr>
                                                <th>
                                                    <hr>
                                                    <label class="h5">Total</label>

                                                </th>
                                                <th> <hr>
                                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                                   
                                                </th> 
                                                
                                            </tr>
                                    </table>
                            </div>
                            <hr />               
                        </div>
                    </div>
                </div>
            </div>
        </contenttemplate>


    <%--<a  href='<%= "ImprimirReceta.aspx?Id_Agenda="+ Id_Agenda +"&Id_FichaIdentificacion=" + Id_FichaIdentificacion%>'><h4><label class="label label-success pull-right label-button">Pagar<i class="fa fa-margin-left fa-eye"></i></label></h4></a>--%>
    <%--<asp:LinkButton OnClick="saveToTickets" ID="LinkButton5" runat="server" Text='<h4><label class="label label-success pull-right label-button">Pagar<i class="fa fa-arrow-circle-right"></i></label></h4>' ></asp:LinkButton>--%>
    <table width="100%">
        <tr>
            <td style="width: 50%"></td>
        </tr>
    </table>  
    <br />
        
        <asp:LinkButton OnClick="pagar" ID="LinkButton7" runat="server" Text='<h4><label class="label label-success pull-right label-button">Pagar<i class="fa fa-arrow-circle-right"></i></label></h4>'></asp:LinkButton>
    

    <%-- <a  href='<%= "ImprimirReceta.aspx?Id_Agenda="+ Id_Agenda +"&Id_FichaIdentificacion=" + Id_FichaIdentificacion%>'><h4><label class="label label-success pull-right label-button">Facturar<i class="fa fa-margin-left fa-eye"></i></label></h4></a>--%>
    <%--<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Guardar Receta Previa</h4>
                </div>
                <div class="modal-body contaienr-fluid">
                    <div class="row">
                        <div class="col-xs-12">
                            <label>Nombre</label>
                            <input type="text" class="form-control" runat="server" id="txtNombre" />
                        </div>
                    </div>
                    <!--<div class="row">
                        <div class="col-xs-12">
                            <label>Diagnostico</label>
                            <asp:TextBox CssClass="form-control" runat="server" ID="txtSearch2" placeholder="Buscar Diagnostico..." autocomplete="off"></asp:TextBox>
                            <hr />
                            <div class="container-fluid searchContainer border-top1-bottom5">
                            </div>
                        </div>
                    </div>-->
                </div>
                <div class="modal-footer">
                    <h4>
                        <label class="label label-danger label-button" data-dismiss="modal">Cerrar</label></h4>
                    <asp:LinkButton OnClick="saveToTemplate" ID="LinkButton1" runat="server" Text='<h4><label class="label label-success pull-right label-button">Guardar<i class="fa fa-save"></i></label></h4>' />
                </div>
            </div>
        </div>
    </div>--%>

    <div class="modal fade" id="modalRecPrevia" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Receta: <span class="label label-primary recetaNombre"></span></h4>
                </div>
                <div class="modal-body contaienr-fluid">
                    <div class="container-fluid" id="Template-Container">
                        <asp:Repeater runat="server" ID="rptTemplate">
                            <ItemTemplate>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="modal-footer">
                    <h4>
                        <label class="label label-danger label-button" data-dismiss="modal">Cerrar</label></h4>
                    <asp:LinkButton OnClick="saveToUse" ID="LinkButton2" runat="server" Text='<h4><label class="label label-success pull-right label-button">Usar<i class="fa fa-check"></i></label></h4>' />
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalAgregar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">El Medicamento: <span class="label label-primary MediNombre">no existe.</span></h4>
                </div>
                <div class="modal-body contaienr-fluid">
                    <div class="container-fluid">
                        <!--<span class="MediNombre"></span>-->
                        Este medicamento no se encuentra registrado dentro del catalogo de medicamentos.
                    </div>
                </div>
                <div class="modal-footer">
                    
                    <asp:LinkButton data-dismiss="modal" ID="LinkButton3" runat="server" Text='<h4><label class="label label-success pull-right label-button">Aceptar<i class="fa fa-check"></i></label></h4>' />
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalExistencia" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">El Medicamento: <span class="label label-primary MediNombre"></span></h4>
                </div>
                <div class="modal-body contaienr-fluid">
                    <div class="container-fluid">
                        <!--<span class="MediNombre"></span>-->
                        Se encuentra Agotado.
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton data-dismiss="modal" ID="LinkButton1" runat="server" Text='<h4><label class="label label-success pull-right label-button">Aceptar<i class="fa fa-check"></i></label></h4>' />
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalerror" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Error: <span class="label label-primary"></span></h4>
                </div>
                <div class="modal-body contaienr-fluid">
                    <div class="container-fluid">
                        <!---->
                        Debe ingresar un <span class="Mensaje"></span>.
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton data-dismiss="modal" ID="LinkButton4" runat="server" Text='<h4><label class="label label-success pull-right label-button">Aceptar<i class="fa fa-check"></i></label></h4>' />
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalDetalles" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Total:<span class="label label-primary"></span></h4>
                </div>
                <div class="modal-body contaienr-fluid">
                    <div class="container-fluid">
                        <!---->

                        Total:
                        <asp:TextBox ID="TextBox3" Enabled="false" runat="server" Text="0.00"  Width="100%" CssClass="form-control"></asp:TextBox>
                        Pago con:
                        <asp:TextBox ID="TextBox1" runat="server" Width="100%" Text="0.00" OnTextChanged="cambio" CssClass="form-control"></asp:TextBox>
                        Su cambio:
                        <asp:TextBox ID="TextBox2" Enabled="false" runat="server" Text="0.00" Width="100%" CssClass="form-control"></asp:TextBox>
                        <br />
                        <hr />


                    </div>
                </div>
                <div class="modal-footer">
                    <label class="checkbox-inline label label-success label-button">
                        Facturar &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
                        <asp:Checkbox id="CheckboxFacturar" runat="server"/>
                    </label>

                    <asp:LinkButton ID="Buscar" runat="server" OnClick="cambio" ToolTip="Calcular" Text=""></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton6" runat="server" OnClick="saveToTickets" Text='<h4><label class="label label-success pull-right label-button">Aceptar<i class="fa fa-check"></i></label></h4>' />
                </div>
            </div>
        </div>
    </div>

    <script>


        function AlertaGuardar() {
            $("#alert1").removeClass("hidden");
            $("#alerta3").text("Guardado");
        }

        $(document).ready(function () {
            $('.combobox').combobox();
            $("[id$=ddlTemplate]").change();
        });
        $('[id$=txtSearch]').bind('input keyup', function () {
            var $this = $(this);
            var delay; // 2 seconds delay after last input
            var value = $('[id$=txtSearch]').val();
            clearTimeout($this.data('timer'));
            if (value === " ") {
                $('.searchContainer').hide().empty();
            }
            if (value.substr(value.length - 1) !== " ") {
                delay = 500;
            } else {
                delay = 1;
            }
            $this.data('timer', setTimeout(function () {
                $this.removeData('timer');
                diagSearch(value);
            }, delay));
        });

        function diagSearch(x) {
            var nombre = x;
            if (nombre !== "") {
                $.ajax({
                    type: "POST",
                    url: "GetDates.asmx/GetMedicamentoFarmacia",
                    data: "{'search':'" + nombre + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        appendData(data);
                    }
                });
            } else {
                $('.searchContainer').hide().empty();
            }
        }

        function appendData(data) {
            var jsonObject = $.parseJSON(data.d);
            if (jsonObject[0] != null) {
                $('.searchContainer').empty();
                $('.searchContainer').append(
                    $('#template').jqote(jsonObject, '*')
                ).show();
                $('.searchContainer').append(
                    $('#template2').jqote(jsonObject, '*')
                ).show();
            } else {
                $('.searchContainer').hide();
            }
        }
        $(document).mouseup(function (e) {
            var container = $(".searchContainer");
            var containerB = $("[id$=txtSearch]");
            if (!container.is(e.target) // if the target of the click isn't the container...
                && container.has(e.target).length === 0 && !containerB.is(e.target)) // ... nor a descendant of the container
            {
                container.hide();
            }
            var containerC = $("h5");
            if (containerC.is(e.target)) {
                container.hide();
            }
        });

        $("[id$=txtSearch]").focus(function () {
            if ($('.searchContainer').children().length !== 0) {
                $('.s   ').show();
            }
        });

        function upText(x) {
            var val = $(x).closest('.row').find('h5');
            $("[id$=txtSearch]").val(val.html());
        }

        $("[id$=ddlTemplate]").change(function () {
            var x = $("[id$=ddlTemplate]").val();
            $.ajax({
                type: "POST",
                url: "GetDates.asmx/loadTemplate",
                data: "{'Id_Template':'" + x + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    appendTemplate(data);
                }
            });
        });
        function appendTemplate(data) {
            var jsonObject = $.parseJSON(data.d);
            var Tem_Nombre = jsonObject[0].Tem_Nombre;
            $(".recetaNombre").text(Tem_Nombre);
            $('#Template-Container').empty().append($('#templateTemplate').jqote(jsonObject, '*'));
        }
        function EjecutarModal() {
            //var MedicamentoNom = $('[id$=txtSearch]').val();
            //$(".MediNombre").text(MedicamentoNom);
            //$('#modalAgregar').modal('show')n

            $("#alert").removeClass("hidden");
            $("#alerta2").text("¡ERROR!, No exixte el Medicamento ");
        }

        function ValidarMEDI() {
            //$(".Mensaje").text("Medicamento");
            //$('#modalerror').modal('show')
            $("#alert").removeClass("hidden");
            $("#alerta2").text("¡ERROR!, Ingrese un Medicamento.");
        }

        //function ValidarExistencia() {
        //    var MedicamentoNom = $('[id$=txtSearch]').val();
        //    $(".MediNombre").text(MedicamentoNom);
        //    $('#modalExistencia').modal('show')
        //}

        function ValidarExistencia() {

            $("#alert").removeClass("hidden");
            $("#alerta2").text("¡ERROR!, El medicamento se enceuntra agotado.");
        }

        function ValidarTexBox() {
            $("#alert").removeClass("hidden");
            $("#alerta2").text("¡ERROR!, Ingrese un Medicamento.");
        }
        function EjecutarModalDetalles() {
            $(".Mensaje").text("Medicamento");
            $('#modalDetalles').modal('show')
        }
        $(document).keyup(function (tecla) {
            if (tecla.keyCode == 13) {
                //alert('Tecla X presionada');
                Actualizar();
            }
        });

        function Actualizar() {
            var boton = document.getElementById('<%=Buscar.ClientID%>');
            boton.click();
            return;
        }
        function sumar() {
            var a, b, r;    // Se declara la variable
            a = document.getElementById('TextBox1').value;  //captura del contenido del TextBox
            b = document.getElementById('TextBox3').value;
            r = parseFloat(a) + parseFloat(b);           // Convierte en Float y sumar
            document.getElementById('TextBox2').value = r; // El resultado en TextBox resultado
        }

        ///////////////////////////////////////////////////////////////////////
        /////////////////// BUSCAR CONSULTA //////////////////////////////////
    </script>

    <script type="text/x-jqote-template" id="template">
    <![CDATA[        
        <div class="row row-hover" onclick="upText(this);">
        <div class="col-xs-12 col-md-12 col-sm-12 col-lg-12">        
        <h5 uid="<*= this.Id_Productos *>"><*= this.Descripcion*></h5>
        <hr />
        </div>       
        </div>
    ]]>
    </script>

    <script type="text/x-jqote-template" id="templateTemplate">
        <![CDATA[
        <div class="col-xs-12 col-md-5 col-lg-5 col-sm-5  border-right3-bottom3">
                                    <div class="row">
                                        <div class="col-xs-12">
                                            <label class="h5">Medicamento</label>
                                            <label><*= this.Tem_Medicamento*></label>
                                        </div>
                                        <div class="col-xs-12">
                                            <label class="h5">Dosis</label>
                                            <label><*= this.Tem_Dosis*></label>
                                        </div>
                                        <div class="col-xs-12">
                                            <label class="h5">Notas</label>
                                            <label><*= this.Tem_Notas *></label>
                                        </div>
                                    </div>
                                </div>
        ]]>
    </script>
    <style>
        .searchContainer {
            max-height: 300px;
            overflow-x: auto;
            position: absolute;
            width: 90%;
        }

        $('input[type="checkbox"].style1').checkbox({
	buttonStyleChecked: 'btn-success',
    checkedClass: 'icon-check',
    uncheckedClass: 'icon-check-empty'
});
    </style>
</asp:Content>

