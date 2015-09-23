<%@ Page Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="PermisosPorPerfil.aspx.cs" Inherits="MedicalManagement.PermisosPorPerfil" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid border-top1-bottom5 gray-border no-radius no-vertical-padding">
                <div class="loading hidden">
                    <div><i class="fa fa-3x fa-spinner fa-spin"></i></div>
                </div>
                <div class="row">
                    <div class="col-xs-4 container-fluid left-panel">
                        <div class="row">
                            <div class="col-xs-12">
                                <label>Perfil</label>
                                <asp:DropDownList OnSelectedIndexChanged="loadPermisos" AutoPostBack="true" runat="Server" ID="ddlPerfil" CssClass="form-control combobox does-postback" DataTextField="Descripcion_Perfil" DataValueField="Id_Perfil" />
                                <hr />
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-8 padding container-fluid">
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="row">
                                    <div class="col-xs-12">
                                        <label>Permisos - <span runat="server" class="text-uppercase" id="spanNombre"></span></label>
                                        <hr />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="gray-container" style="max-height: 400px;">
                                    <asp:Repeater ID="rptPermiso" runat="Server">
                                        <ItemTemplate>
                                            <div class='<%# hasPermision(Convert.ToBoolean(Eval("Estatus_Permiso"))) %>'>
                                                <asp:LinkButton runat="server" Text='<i class="fa fa-lock add-icon fa-margin-right"></i>' OnClick="OnClickGreen" CommandArgument='<%# Eval("Id_Permiso") %>' />
                                                <label class="packet-name label label-danger"><%# Eval("oneModulo.Nombre_Modulo") + " - " + Eval("oneModulo.Programa_Modulo") %></label>
                                                <label class="pull-right packet-name"><%# Eval("Estatus_Permiso") %></label>
                                                <hr />
                                            </div>
                                            <div class='<%# hasPermision(!Convert.ToBoolean(Eval("Estatus_Permiso"))) %>'>
                                                <asp:LinkButton runat="server" Text='<i class="fa fa-unlock add-icon fa-margin-right"></i>' OnClick="OnClick" CommandArgument='<%# Eval("Id_Permiso") %>' />
                                                <label class="packet-name label label-success"><%# Eval("oneModulo.Nombre_Modulo") + " - " + Eval("oneModulo.Programa_Modulo") %></label>
                                                <label class="pull-right packet-name"><%# Eval("Estatus_Permiso") %></label>
                                                <hr />
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>
        $(document).ready(function () {
            $(".combobox").combobox();
            $(".does-postback").change(function () {
                $(".loading").removeClass("hidden");
            });
            $(".add-icon").click(function () {
                $(".loading").removeClass("hidden");
            });
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            $(".loading").addClass("hidden");
            $(document).ready(function () {
                $('.combobox').combobox();
                $(".does-postback").change(function () {
                    $(".loading").removeClass("hidden");
                });
                $(".add-icon").click(function () {
                    $(".loading").removeClass("hidden");
                });
            });
        });
    </script>
</asp:Content>
