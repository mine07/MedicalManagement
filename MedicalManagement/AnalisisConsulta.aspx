<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnalisisConsulta.aspx.cs" Inherits="MedicalManagement.AnalisisConsulta1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:ScriptManager runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div>
                <a href="#" onClick="history.back();" __designer:mapid="696"><label class="pull-right label label-primary label-button" __designer:mapid="697">Volver<i class="fa fa-arrow-left fa-margin-left" __designer:mapid="698"></i></label></a><div class="hidden"></div>
                <h3>Analisis Clinico</h3>
            </div>
            <hr />
            <div class="container-fluid border-top1-bottom5 no-radius no-vertical-padding gray-border">
                <div class="loading hidden">
                    <div><i class="fa fa-3x fa-spinner fa-spin"></i></div>
                </div>
                <div class="row">
                    <div class="col-xs-12 col-md-4 col-lg-4 col-sm-4 left-panel">
                        <div class="container-fluid">
                             <div class="row">
                                 <hr class="blue-hr" />
                                 <div class=" text-center">
                                     <label class="label-primary label">
                                         <i class="fa fa-user fa-margin-right"></i>
                                         <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label></label>
                                 </div>
                                 <hr class="blue-hr" />
                                  </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <label class="h5">Lista de Paquetes<i class="fa fa-cubes fa-margin-left"></i></label>
                                    <div class="input-group">
                                        <span class="input-group-addon"><i class="fa fa-1x fa-search"></i></span>
                                        <asp:DropDownList runat="server" ID="ddlPaquetes" CssClass="form-control combobox" DataTextField="Descripcion_AnalisisClinicoPaquetes" DataValueField="Id_AnalisisClinicoPaquetes" OnSelectedIndexChanged="ddlChanged"     />
                                    </div>
                                    <h4>
                                    <label class="label label-success pull-right label-button" data-toggle="modal" data-target="#modalRecPrevia">Ver Paquete<i class="fa fa-search"></i></label><h4></h4>
                                </h4>
                                        </div>
                                <div class="col-xs-12">
                                    <hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-10 col-xs-offset-2">
                                    <label class="h6">Agregar Auxiliar</label>
                                    <!--<asp:DropDownList runat="server" ID="ddlAnalisis" CssClass="form-control combobox" DataTextField="Descripcion_AnalisisClinico" DataValueField="Id_AnalisisClinico" />-->
                                    <div >
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtSearch" placeholder="Buscar Analsis Clinico..." autocomplete="off"></asp:TextBox>
                                        <hr />
                                        <div class="container-fluid searchContainer searchProc border-top1-bottom5">
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-10 col-xs-offset-2 padding">
                                    <asp:LinkButton runat="server" ID="btnAdd" OnClick="saveTo" Text='<label class=" pull-right label label-button label-success" runat="server">Agregar<i class="fa fa-arrow-right"></i></label>' />
                                    <hr />
                                </div>
                            </div>
                            <!--<div class="row">
                                <div class="col-xs-12 container-fluid">
                                    <div class="row">
                                        <div class="col-xs-12">
                                            <label class="h5 icon-add">Nuevo Paquete<i class="fa fa-plus fa-margin-left"></i></label>
                                            <hr />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-10 col-xs-offset-2">
                                            <label class="h6">Nombre</label>
                                            <input type="text" runat="server" class="form-control" id="txtNombre" />
                                        </div>
                                        <div class="col-xs-10 col-xs-offset-2 padding">
                                            <asp:LinkButton runat="server" OnClick="insertPacket" Text='<label class=" pull-right label label-button label-success">Crear<i class="fa fa-plus"></i></label>' />
                                            <hr />
                                        </div>
                                    </div>
                                </div>
                            </div>-->
                        </div>
                    </div>
                    <div class="col-xs-12 col-md-8 col-lg-8 col-sm-8 container-fluid padding">
                        <!--<div class="row">
                            <div class="col-xs-12">

                                <asp:LinkButton runat="server" Text='<label class="label label-danger pull-right label-button pull-right" style="font-size: 16px;">Eliminar<i class="fa fa-scissors"></i></label>' />
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <h3>Analis Clinicos<i class="fa fa-stethoscope fa-margin-left fa-margin-right"></i>-<label runat="server" id="lblPaqueteNombre"></label></h3>
                                <hr />
                            </div>
                        </div>-->
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="row">
                                <div class="col-xs-12">
                                    <label class="label label-success pull-right label-button pull-right" style="font-size: 16px;" data-toggle="modal" data-target="#myModal">Guardar Paquete<i class="fa fa-save"></i></label>
                                    <hr />
                                </div>
                            </div>
                                <asp:Panel id ="pnlImprimir" runat ="server">
                                <div class="gray-container" style="max-height: 450px;"">
                                <asp:Repeater runat="server" ID="rptItems">
                                    <ItemTemplate>
                                        <div class="col-xs-12 col-md-5 col-lg-5 col-sm-5  border-right3-bottom3" style="background-color: white;">
                                            <div class="row">
                                                <div class="col-xs-12">
                                                    <asp:LinkButton runat="server" Text='<i class="fa fa-close remove-icon pull-right"></i>' CommandArgument='<%# Eval("Id_Temporal_AnalisisClinico")%>' OnClick="deleteItem" />
                                                    <hr />
                                                    <label class="h5"><i class="fa fa-stethoscope fa-margin-right"></i><%# Eval("oneAnalisis.Descripcion_AnalisisClinico") %></label>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                    </div>
                                    </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

<a  href='<%= "ImprimirAnalisis.aspx??Id_Paciente="+ Id_FichaIdentificacion +"&NombreCompleto="+ NombreCompleto+"&IdConsulta="+ Id_Consulta%>'><h4><label class="label label-success pull-right label-button">Vista Previa<i class="fa fa-margin-left fa-eye"></i></label></h4></a>

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

     <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Guardar Paquete</h4>
                </div>
                <div class="modal-body contaienr-fluid">
                    <div class="row">
                        <div class="col-xs-12">
                            <label>Nombre</label>
                            <input type="text" class="form-control" runat="server" id="txtNombrePaquete" />
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
                    <asp:LinkButton OnClick="saveToPaquete" ID="LinkButton1" runat="server" Text='<h4><label class="label label-success pull-right label-button">Guardar<i class="fa fa-save"></i></label></h4>' />
                </div>
            </div>
        </div>
    </div>


    <div class="modal fade" id="modalAgregar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Ageregar Analisis Clinico: <span class="label label-primary AnaliNombre"></span></h4>
                </div>
                 <div class="modal-body contaienr-fluid">
                    <div class="container-fluid">
                        <!--<span class="MediNombre"></span>-->
                        Este Analisis Clinico no existe, desea agregarlo al catalogo.
                    </div>
                </div>
                <div class="modal-footer">
                        <label class="label label-danger label-button" data-dismiss="modal">Cerrar</label>
                    <asp:LinkButton OnClick="InsertarMedicamento" ID="LinkButton3" runat="server" Text='<h4><label class="label label-success pull-right label-button">Agregar<i class="fa fa-check"></i></label></h4>' />
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalerror" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Error: <span class="label label-primary ProcNombre"></span></h4>
                </div>
                 <div class="modal-body contaienr-fluid">
                    <div class="container-fluid">
                        <!---->
                       Debe ingresar un <span class="Mensaje"></span>.
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton data-dismiss="modal" ID="LinkButton4" runat="server"  Text='<h4><label class="label label-success pull-right label-button">Aceptar<i class="fa fa-check"></i></label></h4>' />
                </div>
            </div>
        </div>
    </div>
    <script>

        $(document).ready(function () {
            $('.combobox').combobox();
            $("[id$=ddlPaquetes]").change();
            $("[id$=ddlTemplate]").change();
        });

        $("[id$=ddlPaquetes]").change(function () {
            var x = $("[id$=ddlPaquetes]").val();
            $.ajax({
                type: "POST",
                url: "GetDates.asmx/loadPaquete",
                data: "{'Id_AnalisisClinicoPaquetes':'" + x + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    appendTemplateP(data);
                }
            });
        });
        function appendTemplateP(data) {
            var jsonObject = $.parseJSON(data.d);
            var Descripcion_AnalisisClinicoPaquete = jsonObject[0].Descripcion_AnalisisClinicoPaquete;
            $(".recetaNombre").text(Descripcion_AnalisisClinicoPaquete);
            $('#Template-Container').empty().append($('#templateTemplate').jqote(jsonObject, '*'));
        }



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
                    url: "GetDates.asmx/GetAnalisisItems",
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
            var MedicamentoNom = $('[id$=txtSearch]').val();
            $(".AnaliNombre").text(MedicamentoNom);
            $('#modalAgregar').modal('show')
        }

        function ValidarTexBox() {
            $(".Mensaje").text("Analisis Clinico");
            $('#modalerror').modal('show')
        }
    </script>

    <script type="text/x-jqote-template" id="templateTemplate">
        <![CDATA[
        <div class="col-xs-12 col-md-5 col-lg-5 col-sm-5  border-right3-bottom3">
                                    <div class="row">
                                        <div class="col-xs-12">
                                            <label class="h5">Analisis</label>
                                            <label><*= this.Tem_Medicamento*></label>
                                        </div>
                                       
                                    </div>
                                </div>
        ]]>
    </script>

    <script type="text/x-jqote-template" id="template">
    <![CDATA[        
        <div class="row row-hover" onclick="upText(this);">
        <div class="col-xs-12 col-md-12 col-sm-12 col-lg-12">        
        <h5 uid="<*= this.Id_AnalisisClinico *>"><*= this.Descripcion_AnalisisClinico*></h5>
        <hr />
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
    </style>
</asp:Content>

