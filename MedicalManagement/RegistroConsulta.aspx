<%@ Page Title="" Language="C#" MasterPageFile="~/Consulta.Master" AutoEventWireup="true" CodeBehind="RegistroConsulta.aspx.cs" Inherits="MedicalManagement.RegistroConsulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <div>
        <a href='<%= "ConsultaMenu.aspx?Id_Agenda=" + Id_Agenda + "&Id_FichaIdentificacion=" + oneUser.Id_FichaIdentificacion %>'>
            <label class="pull-right label label-primary label-button">Volver<i class="fa fa-arrow-left fa-margin-left"></i></label></a>
        <h3>Nota Clinica</h3>
    </div>
    <hr />
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightSide" runat="server">
                <div class="row">
                    <div class="col-xs-12 col-md-2 col-lg-2 col-sm-2">
                        <label>Fecha</label>
                    </div>
                    <div class="col-xs-12 col-md-10 col-lg-10 col-sm-10">
                        <asp:TextBox ID="txtfechaconsulta" runat="server" BackColor="#CCFFCC"
                            ReadOnly="True" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-xs-12 col-md-2 col-lg-2 col-sm-2">
                        <label>Nombre</label>
                    </div>
                    <div class="col-xs-12 col-md-10 col-lg-10 col-sm-10">
                        <asp:TextBox ID="txtnombre" runat="server" BackColor="#CCFFCC"
                            ReadOnly="True" CssClass="form-control"></asp:TextBox>

                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-xs-12 col-md-2 col-lg-2 col-sm-2">
                        <label>Subjetivo</label>
                    </div>
                    <div class="col-xs-12 col-md-10 col-lg-10 col-sm-10">
                        <asp:TextBox ID="txtsubjetivo" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>

                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-xs-12 col-md-2 col-lg-2 col-sm-2">
                        <label>Objetivo</label>
                    </div>
                    <div class="col-xs-12 col-md-10 col-lg-10 col-sm-10">
                        <asp:TextBox ID="txtobjetivo" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>

                    </div>
                </div>
                <hr />


                <div class="row">
                    <div class="col-xs-12 col-md-2 col-lg-2 col-sm-2">
                        <label>Analisis</label>
                    </div>
                    <div class="col-xs-12 col-md-10 col-lg-10 col-sm-10">
                        <asp:TextBox ID="txtanalisis" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        <hr />
                    </div>
                    <div class="col-xs-12 col-sm-2 col-sm-offset-2">
                        <label>Diagnostico</label>
                    </div>
                    <div class="col-xs-12 col-md-8 col-lg-8 col-sm-8">
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtSearch" placeholder="Buscar Diagnostico..." autocomplete="off"></asp:TextBox>
                        <hr />
                        <div class="container-fluid searchContainer searchDiag border-top1-bottom5">
                        </div>
                    </div>
                    <div class="col-xs-12 col-md-10 col-lg-10 col-sm-10 col-sm-offset-2">
                        <asp:LinkButton runat="server" Text='<label class="label label-button label-success pull-right">Agregar Diagnostico<i class="fa fa-plus fa-margin-left"></i></label>' OnClick="addDiagnostico"></asp:LinkButton>
                    </div>
                    <div class="col-xs-12 col-md-8 col-lg-8 col-sm-8 col-sm-offset-4">
                        <div class="gray-container">
                            <asp:Repeater runat="server" ID="rptDiag">
                                <ItemTemplate>
                                    <div class="row">
                                        <div class="col-xs-12">
                                            <asp:LinkButton runat="server" Text='<i class="fa fa-margin-left fa-remove remove-icon pull-right"></i>' CommandArgument='<%# Eval("Id_ConsultaDiagnostico") %>' OnClick="deleteDiag" />
                                            <label class="packet-name"><%# Eval("oneDiag.Descripcion_Diagnostico")%></label>
                                            <hr />
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-xs-12 col-md-2 col-lg-2 col-sm-2">
                        <label>Plan</label>
                        <div class="padding">
                        </div>
                    </div>
                    <div class="col-xs-12 col-md-10 col-lg-10 col-sm-10">
                        <asp:TextBox ID="txtplan" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        <hr />
                    </div>
                    <div class="col-xs-12 col-sm-2 col-sm-offset-2">
                        <label>Procedimiento</label>
                    </div>
                    <div class="col-xs-12 col-md-8 col-lg-8 col-sm-8">
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtProc" placeholder="Buscar Procedimiento..." autocomplete="off"></asp:TextBox>
                        <hr />
                        <div class="container-fluid searchContainer searchProc border-top1-bottom5">
                        </div>
                    </div>
                    <div class="col-xs-12 col-md-10 col-lg-10 col-sm-10 col-sm-offset-2">
                        <asp:LinkButton runat="server" Text='<label class="label label-button label-success pull-right">Agregar Procedimiento<i class="fa fa-plus fa-margin-left"></i></label>' OnClick="addProcedimiento"></asp:LinkButton>
                    </div>
                    <div class="col-xs-12 col-md-8 col-lg-8 col-sm-8 col-sm-offset-4">
                        <div class="gray-container">
                            <asp:Repeater runat="server" ID="rptProc1">
                                <ItemTemplate>
                                    <div class="row">
                                        <div class="col-xs-12">
                                            <asp:LinkButton runat="server" Text='<i class="fa fa-margin-left fa-remove remove-icon pull-right"></i>' CommandArgument='<%# Eval("Id_ConsultaProcedimiento") %>' OnClick="deleteProc" />
                                            <label class="packet-name"><%# Eval("onePro.Descripcion_Procedimiento")%></label>
                                            <hr />
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>

                </div>
                <hr />
                <div class="row">
                    <div class="col-xs-12">
                        <label class="pull-right label label-button label-success" data-toggle="modal" data-target="#myModal">Nueva Cita<i class="fa fa-plus fa-margin-left"></i></label>
                        <asp:LinkButton runat="server" OnClick="btnGuardar_Consulta_Click" Text='<label class="fa-margin-right label pull-right label-success label-button">Guardar<i class="fa fa-margin-left fa-save"></i></label>'></asp:LinkButton>
                    </div>
                </div>
            <hr />
    
    <a  href='<%= "ImprimirNotaClinica.aspx?Id_Agenda="+ Id_Agenda +"&Id_FichaIdentificacion=" + Id_FichaIdentificacion%>'><h4><label class="label label-success pull-right label-button">Vista Previa<i class="fa fa-margin-left fa-eye"></i></label></h4></a>
                                                                                                        
    <div class="modal fade no-radius" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Nueva Cita</h4>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row hidden">
                            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                                Id.FichaIdentificacion
                            </div>
                            <div class="col-xs-12 col-sm-9 col-md-9 col-lg-9">
                                <asp:TextBox CssClass="form-control hidden" ID="txtidfichaidentificacion" runat="server" BackColor="#CCFFCC"
                                    ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                                Nombre Completo
                            </div>
                            <div class="col-xs-12 col-sm-9 col-md-9 col-lg-9">
                                <asp:TextBox CssClass="form-control" ID="txtnombrecompleto" runat="server" BackColor="#CCFFCC" ReadOnly="True" Width="200px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                                Asunto
                            </div>
                            <div class="col-xs-12 col-sm-9 col-md-9 col-lg-9">
                                <asp:TextBox CssClass="form-control" ID="txtasunto" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                                Categoria: 
                            </div>
                            <div class="col-xs-12 col-sm-9 col-md-9 col-lg-9">
                                <asp:DropDownList ID="ddlCategoria" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                                Prioridad
                            </div>

                            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                                <asp:RadioButton ID="rbNormal" runat="server" Text="Normal" GroupName="rdio" />
                            </div>
                            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                                <asp:RadioButton ID="rbUrgente" runat="server" Text="Urgente" GroupName="rdio" />
                            </div>


                        </div>


                        <div class="row">
                            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                                Dia de Alta en 
            Agenda
                            </div>
                            <div class="col-xs-12 col-sm-9 col-md-9 col-lg-9">
                                <input id="txtaltaagenda" type="text" class="datePicker form-control" disabled runat="server" />
                            </div>

                        </div>
                        <div class="row hidden">
                            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">Estado de Cita</div>
                            <div class="col-xs-12 col-sm-9 col-md-9 col-lg-9">
                                <asp:DropDownList ID="DropDownEstadoCitas" CssClass="form-control" runat="server" Enabled="false">
                                    <asp:ListItem>Por confirmar</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                                Comienzo
                            </div>

                            <div class="col-xs-12 col-sm-9 col-md-9 col-lg-9">
                                <input id="txtDiaComienzo" type="text" class="datePicker form-control" runat="server" />
                                <div class="hidden">
                                    <asp:DropDownList ID="DropDownDiaComienzo" runat="server">
                                    </asp:DropDownList>

                                    <asp:DropDownList ID="DropDownMesComienzo" runat="server">
                                        <asp:ListItem>Enero</asp:ListItem>
                                        <asp:ListItem>Febrero</asp:ListItem>
                                        <asp:ListItem>Marzo</asp:ListItem>
                                        <asp:ListItem>Abril</asp:ListItem>
                                        <asp:ListItem>Mayo</asp:ListItem>
                                        <asp:ListItem>Junio</asp:ListItem>
                                        <asp:ListItem>Julio</asp:ListItem>
                                        <asp:ListItem>Agosto</asp:ListItem>
                                        <asp:ListItem>Septiembre</asp:ListItem>
                                        <asp:ListItem>Octubre</asp:ListItem>
                                        <asp:ListItem>Noviembre</asp:ListItem>
                                        <asp:ListItem>Diciembre</asp:ListItem>
                                    </asp:DropDownList>

                                    <asp:DropDownList ID="DropDownAnioComienzo" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3 hidden">
                                <asp:DropDownList ID="DropDownHoraComienzo" runat="server">
                                </asp:DropDownList>

                                <asp:DropDownList ID="DropDownMinutoComienzo" runat="server">
                                </asp:DropDownList>

                                <asp:DropDownList ID="DropDowndiatardeComienzo" runat="server">
                                    <asp:ListItem>p.m.</asp:ListItem>
                                    <asp:ListItem>a.m.</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3" width="300px"></div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                                Finalizacion:
                            </div>

                            <div class="col-xs-12 col-sm-9 col-md-9 col-lg-9">
                                <input id="txtDiaFinal" type="text" class="datePicker form-control" runat="server" />
                                <div class="hidden">
                                    <asp:DropDownList ID="DropDownDiaFinal" runat="server">
                                    </asp:DropDownList>

                                    <asp:DropDownList ID="DropDownMesFinal" runat="server">
                                        <asp:ListItem>Enero</asp:ListItem>
                                        <asp:ListItem>Febrero</asp:ListItem>
                                        <asp:ListItem>Marzo</asp:ListItem>
                                        <asp:ListItem>Abril</asp:ListItem>
                                        <asp:ListItem>Mayo</asp:ListItem>
                                        <asp:ListItem>Junio</asp:ListItem>
                                        <asp:ListItem>Julio</asp:ListItem>
                                        <asp:ListItem>Agosto</asp:ListItem>
                                        <asp:ListItem>Septiembre</asp:ListItem>
                                        <asp:ListItem>Octubre</asp:ListItem>
                                        <asp:ListItem>Noviembre</asp:ListItem>
                                        <asp:ListItem>Diciembre</asp:ListItem>
                                    </asp:DropDownList>

                                    <asp:DropDownList ID="DropDownAnioFinal" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3 hidden">
                                <asp:DropDownList ID="DropDownHoraFinal" runat="server">
                                </asp:DropDownList>

                                <asp:DropDownList ID="DropDownMinutoFinal" runat="server">
                                </asp:DropDownList>

                                <asp:DropDownList ID="DropDowndiatardeFinal" runat="server">
                                    <asp:ListItem>p.m.</asp:ListItem>
                                    <asp:ListItem>a.m.</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                                Descripcion
                            </div>
                            <div class="col-xs-12 col-sm-9 col-md-9 col-lg-9">
                                <asp:TextBox CssClass="form-control" ID="txtdescripcionagenda" runat="server" Width="100%" TextMode="multiline"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <label class="label label-danger" data-dismiss="modal">Cancelar<i class="fa fa-remove fa-margin-left"></i></label>
                    <asp:LinkButton runat="server" OnClick="btnSave" Text='<label class="pull-right label label-button label-success">Nueva Cita<i class="fa fa-plus fa-margin-left"></i></label>' />
                </div>
            </div>
        </div>
    </div>
    <script>
        $('[id$=txtSearch]').bind('input keyup', function () {
            var $this = $(this);
            var delay; // 2 seconds delay after last input
            var value = $('[id$=txtSearch]').val();
            clearTimeout($this.data('timer'));
            if (value === " ") {
                $('.searchDiag').slideUp().empty();
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
                    url: "GetDates.asmx/GetDiagnosticoItems",
                    data: "{'search':'" + nombre + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        appendData(data);
                    }
                });
            } else {
                $('.searchDiag').slideUp().empty();
            }
        }

        function appendData(data) {
            var jsonObject = $.parseJSON(data.d);
            if (jsonObject[0] != null) {
                $('.searchDiag').empty();
                $('.searchDiag').append(
                    $('#templateD').jqote(jsonObject, '*')
                ).slideDown();
            } else {
                $('.searchDiag').slideUp();
            }
        }
        $(document).mouseup(function (e) {
            var container = $(".searchDiag");
            var containerB = $("[id$=txtSearch]");
            if (!container.is(e.target) // if the target of the click isn't the container...
                && container.has(e.target).length === 0 && !containerB.is(e.target)) // ... nor a descendant of the container
            {
                container.slideUp();
            }
            var containerC = $("h5");
            if (containerC.is(e.target)) {
                container.slideUp();
            }
        });

        $("[id$=txtSearch]").focus(function () {
            if ($('.searchDiag').children().length !== 0) {
                $('.searchDiag').slideDown();
            }
        });

        function upText(x) {
            var val = $(x).closest('.row').find('h5');
            $("[id$=txtSearch]").val(val.html());
        }
        jQuery('.datePicker').datetimepicker({
            format: 'd/m/Y H:i'
        });

        function removeDiagnostico(Id) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "GetDates.asmx/RemoveActive",
                data: JSON.stringify({ 'Id_Diagnostico': Id }),
                success: success,
                error: error,
                dataType: "json"
            });
        }

        function AddDiagnostico(Id) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "GetDates.asmx/RemoveInActive",
                data: JSON.stringify({ 'Id_Diagnostico': Id }),
                success: success,
                error: error,
                dataType: "json"
            });
        }

         /////////////////////////////////////////////
        //////////// PROCEDIMIENTO //////////////////
       /////////////////////////////////////////////

        $('[id$=txtProc]').bind('input keyup', function () {
            var $this = $(this);
            var delay; // 2 seconds delay after last input
            var valueP = $('[id$=txtProc]').val();
            clearTimeout($this.data('timer'));
            if (valueP === " ") {
                $('.searchProc').slideUp().empty();
            }
            if (valueP.substr(valueP.length - 1) !== " ") {
                delay = 500;
            } else {
                delay = 1;
            }
            $this.data('timer', setTimeout(function () {
                $this.removedata('timer');

                procSearch(valueP);
            }, delay));
        });

        function procSearch(x) {
            var nombreP = x;
            if (nombreP !== "") {
                $.ajax({
                    type: "POST",
                    url: "GetDates.asmx/GetProcedimientoItems",
                    data: "{'search':'" + nombreP + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        appendData2(data);
                    }
                });
            } else {
                $('.searchProc').slideUp().empty();
            }
        }

        function appendData2(data) {
            var jsonObject = $.parseJSON(data.d);
            if (jsonObject[0] != null) {
                $('.searchProc').empty();
                $('.searchProc').append(
                    $('#templateP').jqote(jsonObject, '*')
                ).slideDown();
            } else {
                $('.searchProc').slideUp();
            }
        }
        $(document).mouseup(function (e) {
            var containerP = $(".searchProc");
            var containerBP = $("[id$=txtProc]");
            if (!containerP.is(e.target) // if the target of the click isn't the container...
                && containerP.has(e.target).length === 0 && !containerBP.is(e.target)) // ... nor a descendant of the container
            {
                containerP.slideUp();
            }
            var containerCP = $("h5");
            if (containerCP.is(e.target)) {
                containerP.slideUp();
            }
        });

        $("[id$=txtProc]").focus(function () {
            if ($('.searchProc').children().length !== 0) {
                $('.searchProc').slideDown();
            }
        });

        function upText1(x) {
            var valP = $(x).closest('.row').find('h5');
            $("[id$=txtProc]").valP(valP.html());
        }
        jQuery('.datePicker').datetimepicker({
            format: 'd/m/Y H:i'
        });

        function removeProcedimiento(Id) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "GetDates.asmx/RemoveActiveP",
                data: JSON.stringify({ 'Id_Procedimiento': Id }),
                success: success,
                error: error,
                dataType: "json"
            });
        }

        function AddProcedimiento(Id) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "GetDates.asmx/RemoveInActiveP",
                data: JSON.stringify({ 'Id_Procedimiento': Id }),
                success: success,
                error: error,
                dataType: "json"
            });
        }

        function success() {
            location.reload();
        }

        function error() {
            alert("A ocurrido un error, favor de volver a intentarlo.");
            location.reload();
        }

    </script>
    <script type="text/x-jqote-template" id="templateD">
    <![CDATA[        
        <div class="row row-hover" onclick="upText(this);">
        <div class="col-xs-12 col-md-12 col-sm-12 col-lg-12">        
        <h5><*= this.Descripcion_Diagnostico*></h5>
        <hr />
        </div>       
        </div>
    ]]>
    </script>

    <script type="text/x-jqote-template" id="templateP">
    <![CDATA[        
        <div class="row row-hover" onclick="upText1(this);">
        <div class="col-xs-12 col-md-12 col-sm-12 col-lg-12">        
       <h5><*= this.Descripcion_Procedimiento*></h5>
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
            width: 100%;
        }

        .modal-body .row {
            margin: 5px 0;
            padding: 5px;
            border-bottom: 1px solid #c8c8c8;
        }

        .ui-accordion-header {
            border-color: #c8c8c8 !important;
        }

        .padding {
            margin: 5px 0;
        }
    </style>
</asp:Content>
