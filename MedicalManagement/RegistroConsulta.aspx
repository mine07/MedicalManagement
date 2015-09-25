<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroConsulta.aspx.cs" Inherits="MedicalManagement.RegistroConsulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table width="100%" border="0">

        <tr>
            <td align="left"><font color="red">Configuración\Consulta\Agregar</font></td>
            <td align="right">
                <asp:ImageButton ID="ImageGrabar" runat="Server" ImageUrl="IMG/Grabar.png" ToolTip="Grabar EstadoCivil" OnClick="btnGuardar_Consulta_Click"></asp:ImageButton>&nbsp;
        <asp:ImageButton ID="ImageRegresar" runat="Server" ImageUrl="IMG/Regresar.png" ToolTip="Regresar" OnClick="btnRegresar_Consulta_Click"></asp:ImageButton>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td></td>
        </tr>

        <tr>
            <td>Fecha
            </td>
        </tr>
        <tr class="hidden">
            <td></td>
            <td>
                <asp:LinkButton ID="LinkDiagnostico" runat="server" OnClick="LinkDiagnostico_Click"
                    Visible="False">Diagnostico</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="LinkProcedimiento" runat="server" OnClick="LinkProcedimiento_Click"
                    Visible="False">Procedimiento</asp:LinkButton>
            </td>
        </tr>


    </table>
    <div class="container-fluid border-top1-bottom10">
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
                <label>Diagnostico</label>
            </div>
            <div class="col-xs-12 col-md-10 col-lg-10 col-sm-10">
                <asp:TextBox CssClass="form-control" runat="server" ID="txtSearch" placeholder="Buscar Diagnostico..." autocomplete="off"></asp:TextBox>
                <hr />
                <div class="container-fluid searchContainer border-top1-bottom5">
                </div>
            </div>

        </div>

        <div class="row">
            <div class="col-xs-12 col-md-2 col-lg-2 col-sm-2">
                <label>Analisis</label>
            </div>
            <div class="col-xs-12 col-md-10 col-lg-10 col-sm-10">
                <asp:TextBox ID="txtanalisis" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>

            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-xs-12 col-md-2 col-lg-2 col-sm-2">
                <label>Plan</label>
                <div class="padding">
                    <label class="pull-right label label-button label-success" data-toggle="modal" data-target="#myModal">Nueva Cita<i class="fa fa-plus fa-margin-left"></i></label>
                </div>
            </div>
            <div class="col-xs-12 col-md-10 col-lg-10 col-sm-10">
                <asp:TextBox ID="txtplan" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>

            </div>
        </div>
        <hr />
    </div>

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
                                Asunto:
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
                        <div class="row">
                            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">Estado de Cita</div>
                            <div class="col-xs-12 col-sm-9 col-md-9 col-lg-9">
                                <asp:DropDownList ID="DropDownEstadoCitas" CssClass="form-control" runat="server">
                                    <asp:ListItem>Por confirmar</asp:ListItem>
                                    <asp:ListItem>Confirmado</asp:ListItem>
                                    <asp:ListItem>Cancelado</asp:ListItem>
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
                    <asp:LinkButton runat="server" OnClick="btnSave" Text='<label class="pull-right label label-button label-success">Nueva Cita<i class="fa fa-plus fa-margin-left"></i></label>'/>
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
                $('.searchContainer').slideUp().empty();
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
                $('.searchContainer').slideUp().empty();
            }
        }

        function appendData(data) {
            var jsonObject = $.parseJSON(data.d);
            if (jsonObject[0] != null) {
                $('.searchContainer').empty();
                $('.searchContainer').append(
                    $('#template').jqote(jsonObject, '*')
                ).slideDown();
            } else {
                $('.searchContainer').slideUp();
            }
        }
        $(document).mouseup(function (e) {
            var container = $(".searchContainer");
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
            if ($('.searchContainer').children().length !== 0) {
                $('.searchContainer').slideDown();
            }
        });

        function upText(x) {
            var val = $(x).closest('.row').find('h5');
            $("[id$=txtSearch]").val(val.html());
        }
        jQuery('.datePicker').datetimepicker({
            format: 'd/m/Y H:i'
        });

    </script>
    <script type="text/x-jqote-template" id="template">
    <![CDATA[        
        <div class="row row-hover" onclick="upText(this);">
        <div class="col-xs-12 col-md-12 col-sm-12 col-lg-12">        
        <h5><*= this.Descripcion_Diagnostico*></h5>
        <hr />
        </div>       
        </div>
    ]]>
    </script>
    <style>
        .row {
            padding: 5px;
        }

        .searchContainer {
            max-height: 300px;
            overflow-x: auto;
            position: absolute;
            width: 100%;
        }
    </style>
</asp:Content>
