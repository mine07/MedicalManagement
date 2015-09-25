<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ConsultaReceta.aspx.cs" Inherits="MedicalManagement.ConsultaReceta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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

            <div class="row">
                Dosis
            </div>
            <div class="row">
                <asp:TextBox ID="txtdosis" runat="server" Width="800" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </div>
            <div class="row">
                Notas 
            </div>
            <div class="row">
                <asp:TextBox ID="txtnotas" runat="server" Width="800" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </div>


            <div class="row">

                <asp:LinkButton ID="LinkRecetaPrevia" runat="server" OnClick="LinkRecetaPrevia_Click">Agregar de Receta Previa</asp:LinkButton>
            </div>
            <div class="row">
                <asp:TextBox ID="Txtnombrerecetaprevia" runat="server" Width="400"></asp:TextBox>
            </div>
        </div>
    </div>
    <asp:UpdatePanel runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" />
            <asp:AsyncPostBackTrigger ControlID="rptTemporal" />
        </Triggers>
        <ContentTemplate>
            <a href='<%= "ConsultaMenu.aspx?Id_Agenda="+ Id_Agenda +"&Id_FichaIdentificacion=" + Id_FichaIdentificacion %>'><label class="pull-right label label-primary label-button">Volver<i class="fa fa-arrow-left fa-margin-left"></i></label></a>
            <h3>Receta</h3>
            <hr />
            <div class="container-fluid border-top1-bottom5 no-radius no-vertical-padding gray-border">
                <div class="row">
                    <div class="col-xs-12 col-md-4 col-lg-4 col-sm-4 left-panel">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-xs-12">
                                    <label>Receta Previa</label>
                                    <div class="input-group">
                                        <span class="input-group-addon"><i class="fa fa-1x fa-search"></i></span>
                                        <asp:DropDownList runat="server" ID="ddlTemplate" CssClass="form-control combobox" DataTextField="Tem_Nombre" DataValueField="Id_Template" />
                                    </div>
                                    <h4>
                                        <label class="label label-success pull-right label-button" data-toggle="modal" data-target="#modalRecPrevia">Ver Receta<i class="fa fa-search"></i></label></h4>
                                </div>
                                <div class="col-xs-12">
                                    <hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <label>Medicamento</label>
                                    <div class="input-group">
                                        <span class="input-group-addon"><i class="fa fa-1x fa-search"></i></span>
                                        <asp:DropDownList runat="server" ID="ddlMedicamento" CssClass="form-control combobox" DataTextField="Descripcion_Medicamento" DataValueField="Id_Medicamento" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
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
                            </div>
                            <div class="row" style="padding-top: 5px;">
                                <div class="col-xs-12">
                                    <asp:LinkButton OnClick="saveTo" ID="btnSave" runat="server" Text='<h4><label class="label label-success pull-right label-button">Agregar<i class="fa fa-arrow-circle-right"></i></label></h4>' />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12 col-md-8 col-lg-8 col-sm-8">
                        <div class="container-fluid padding" id="Medicine-Container">
                            <div class="row">
                                <div class="col-xs-12">
                                    <label class="label label-success pull-right label-button pull-right" style="font-size: 16px;" data-toggle="modal" data-target="#myModal">Guardar Como Receta Previa<i class="fa fa-save"></i></label>
                                    <hr />
                                </div>
                            </div>
                            <div class="gray-container" style="max-height: 450px;">
                                <asp:Repeater runat="server" ID="rptTemporal">
                                    <ItemTemplate>
                                        <div class="col-xs-12 col-md-5 col-lg-5 col-sm-5  border-right3-bottom3" style="background-color: white;">
                                            <div class="row">
                                                <div class="col-xs-12">
                                                    <asp:LinkButton ID="btnRemove" runat="server" Text='<i class="fa fa-remove fa-1x pull-right remove-icon"></i>' OnClick="RemoveTemporal" CommandArgument='<%# Eval("Id_Temporal_Receta") %>' />
                                                    <hr />
                                                    <label class="h5">Medicamento</label>
                                                    <label><%# Eval("Tem_Medicamento") %></label>
                                                </div>
                                                <div class="col-xs-12">
                                                    <label class="h5">Dosis</label>
                                                    <label><%# Eval("Tem_Dosis") %></label>
                                                </div>
                                                <div class="col-xs-12">
                                                    <label class="h5">Notas</label>
                                                    <label><%# Eval("Tem_Notas") %></label>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <hr />
                            <label class="pull-right label label-success label-button" style="font-size: 16px;">Guardar<i class="fa fa-margin-left fa-save"></i></label>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
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
                    <div class="row">
                        <div class="col-xs-12">
                            <label>Diagnostico</label>
                            <asp:TextBox CssClass="form-control" runat="server" ID="txtSearch" placeholder="Buscar Diagnostico..." autocomplete="off"></asp:TextBox>
                            <hr />
                            <div class="container-fluid searchContainer border-top1-bottom5">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <h4>
                        <label class="label label-danger label-button" data-dismiss="modal">Cerrar</label></h4>
                    <asp:LinkButton OnClick="saveToTemplate" ID="LinkButton1" runat="server" Text='<h4><label class="label label-success pull-right label-button">Guardar<i class="fa fa-save"></i></label></h4>' />
                </div>
            </div>
        </div>
    </div>
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
    <script>
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
                    url: "GetDates.asmx/GetDiagnosticoItems",
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
                $('.searchContainer').show();
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


    </script>
    <script type="text/x-jqote-template" id="template">
    <![CDATA[        
        <div class="row row-hover" onclick="upText(this);">
        <div class="col-xs-12 col-md-12 col-sm-12 col-lg-12">        
        <h5 uid="<*= this.Id_Diagnostico *>"><*= this.Descripcion_Diagnostico*></h5>
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
    </style>
</asp:Content>
