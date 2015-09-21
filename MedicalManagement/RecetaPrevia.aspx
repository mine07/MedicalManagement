<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="RecetaPrevia.aspx.cs" Inherits="MedicalManagement.RecetaPrevia" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="hidden">
        <table width="100%">
            <tr>
                <td align="left" colspan="6">Receta Previa&nbsp;:&nbsp;<asp:TextBox ID="txtBuscar_RecetaPrevia" runat="server" Columns="100" OnTextChanged="txt_OnTextChanged" AutoPostBack="true"></asp:TextBox>&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip="Buscar Receta Previa"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="AgregarRecetaPrevia" runat="Server" ImageUrl="IMG/agregar.png" OnClick="btnAgregarRecetaPrevia_Click" ToolTip="Agregar Receta Previa"></asp:ImageButton>
                </td>
            </tr>


            <tr>
                <td align="center" colspan="6">
                    <asp:GridView ID="Grid_RecetaPrevia" runat="server" AutoGenerateColumns="False"
                        OnRowCommand="RowCommand" OnRowDeleting="RowDeleting"
                        OnPageIndexChanging="Grid_RecetaPrevia_PageIndexChanging" AllowPaging="False"
                        OnPageIndexChanged="Grid_RecetaPrevia_PageIndexChanged" CssClass="mGrid footable"
                        PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None">


                        <Columns>
                            <asp:BoundField HeaderText="Id" DataField="Id_ConsultaRecetaPrevia" />
                            <asp:BoundField DataField="Nombre_ConsultaRecetaPrevia" HeaderText="Nombre/Descripcion"
                                SortExpression="Nombre_ConsultaRecetaPrevia" />
                            <asp:BoundField DataField="Descripcion_Diagnostico" HeaderText="Diagnostico"
                                SortExpression="Descripcion_Diagnostico" />
                            <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Editar"
                                ShowHeader="True" Text="Editar" ItemStyle-HorizontalAlign="Center" />
                            <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Eliminar"
                                ShowHeader="True" Text="Eliminar" ItemStyle-HorizontalAlign="Center" />
                        </Columns>
                    </asp:GridView>



                </td>
            </tr>
        </table>
        <div class="container-fluid">
            <div class="col-xs-12">
                <div class="input-group">
                    <span class="input-group-addon" id="basic-addon1">Buscar: </span>
                    <asp:TextBox autocomplete="off" ID="txtSearchB" runat="server" CssClass="form-control"></asp:TextBox>
                    <%--<a href="RegistroFichaIdentificacion.aspx" class="input-group-addon no-sub">Agregar</a>--%>
                </div>
            </div>

        </div>
        <hr />
        <div class="container-fluid searchContainer  border-top1-bottom5"></div>
        <hr />
    </div>
    <asp:UpdatePanel runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" />
            <asp:AsyncPostBackTrigger ControlID="rptTemporal" />
        </Triggers>
        <ContentTemplate>
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
                                    <asp:LinkButton OnClick="addToList" OnClientClick="refresh" ID="btnSave" runat="server" Text='<h4><label class="label label-success pull-right label-button">Agregar<i class="fa fa-arrow-circle-right"></i></label></h4>' />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12 col-md-8 col-lg-8 col-sm-8">
                        <div class="container-fluid padding" id="Medicine-Container">
                            <div class="row">
                                <div class="col-xs-12">
                                    <asp:LinkButton OnClick="saveToTemplate" ID="LinkButton1" runat="server" Text='<label style="font-size:16px;" class="label label-success pull-right label-button">Guardar<i class="fa fa-save"></i></label>' />
                                    <hr />
                                </div>
                            </div>
                            <asp:Repeater runat="server" ID="rptTemporal">
                                <ItemTemplate>
                                    <div class="col-xs-12 col-md-5 col-lg-5 col-sm-5  border-right3-bottom3">
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <label class="h5">Medicamento</label>
                                                <label><%# Eval("Tem_Medicamento") %></label>
                                                <asp:LinkButton ID="btnRemove" runat="server" Text='<i class="fa fa-remove fa-1x pull-right remove-icon"></i>' CommandArgument='<%# Eval("Id_Receta_Template") %>' OnClick="RemoveTemporal" />
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
                            <div class="row" runat="server" visible="false" id="cancelRow">
                                <div class="col-xs-12">
                                    <asp:LinkButton OnClick="cancelEdit" ID="LinkButton3" runat="server" Text='<label style="font-size:16px;" class="label label-danger pull-right label-button">Cancelar<i class="fa fa-close"></i></label>' />
                                    <hr />
                                </div>
                            </div>
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
                </div>
                <div class="modal-footer">
                    <h4>
                        <label class="label label-danger label-button" data-dismiss="modal">Cerrar</label></h4>

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
                    <asp:LinkButton OnClick="editCurrent" ID="LinkButton2" runat="server" Text='<h4><label class="label label-success pull-right label-button">Editar<i class="fa fa-check"></i></label></h4>' />
                </div>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $('.combobox').combobox();
            $("[id$=ddlTemplate]").change();
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
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

        function refresh() {
            $("[id$=txtDos]").change();
            $("[id$=txtNotas]").change();
            $("[id$=txtDos]").change();
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
