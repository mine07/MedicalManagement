<%@ Page Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Modulo.aspx.cs" Inherits="MedicalManagement.Modulo" %>

<asp:Content runat="Server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager runat="server"/>
    <asp:UpdatePanel runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnNew"/>
        </Triggers>
        <ContentTemplate>
            <div class="container-fluid no-vertical-padding border-top1-bottom5 gray-border no-radius">
                <div class="row">
                    <div class="col-xs-12 col-md-4 col-sm-4 col-lg-4 left-panel container-fluid">
                        <div class="loading hidden">
                            <div><i class="fa fa-3x fa-spinner fa-spin"></i></div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <label>Nuevo Modulo <i class="fa fa-plus fa-margin-left"></i></label>
                                <hr />
                            </div>
                            <div class="col-xs-10 col-xs-offset-2">
                                <label>Nombre</label>
                                <input type="text" class="form-control" runat="server" id="txtNombre" />
                            </div>
                            <div class="col-xs-10 col-xs-offset-2">
                                <label>Direccion</label>
                                <input type="text" class="form-control" runat="server" id="txtDireccion" />
                            </div>
                            <div class="col-xs-10 col-xs-offset-2 padding">
                                <asp:LinkButton ID="btnNew" runat="server" OnClick="Create" Text='<label class="pull-right label label-button label-success">Guardar<i class="fa fa-save fa-margin-left"></i></label>' />
                                <hr />
                            </div>
                            <div runat="server" id="divHidden" visible="false">
                                <div class="col-xs-12">
                                    <asp:HiddenField runat="server" ID="txtId" />
                                    <label>Editar Modulo <i class="fa fa-pencil-square fa-margin-left"></i></label>
                                    <hr />
                                </div>
                                <div class="col-xs-10 col-xs-offset-2">
                                    <label>Nombre</label>
                                    <input type="text" class="form-control" runat="server" id="txtNombreEdit" />
                                </div>
                                <div class="col-xs-10 col-xs-offset-2">
                                    <label>Direccion</label>
                                    <input type="text" class="form-control" runat="server" id="txtDireccionEdit" />
                                </div>
                                <div class="col-xs-10 col-xs-offset-2 padding">
                                    <asp:LinkButton OnClick="saveEdit" runat="Server" Text='<label class="pull-right label label-button label-success">Guardar<i class="fa fa-save fa-margin-left"></i></label>' />
                                    <hr />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12 col-md-8 col-sm-8 col-lg-8 padding container-fluid">
                        <div class="row">
                            <div class="col-xs-12">
                                <h3>Modulos</h3>
                                <hr />
                            </div>
                            <div class="col-xs-12">
                                <div class="gray-container" style="max-height: 400px;">
                                    <asp:Repeater ID="rptModulos" runat="Server">
                                        <ItemTemplate>
                                            <div>
                                                <asp:LinkButton OnClick="edit" runat="server" Text='<i class="fa fa-pencil-square add-icon fa-margin-right"></i>' CommandArgument='<%# Eval("Id_Modulo") %>' />
                                                <label class="packet-name"><%# Eval("Nombre_Modulo") + " - " + Eval("Programa_Modulo") %></label>
                                                <asp:LinkButton OnClick="delete" runat="server" Text='<i class="pull-right fa fa-remove add-icon fa-margin-right"></i>' CommandArgument='<%# Eval("Id_Modulo") %>' />
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
            $(".label-success").click(function () {
                $(".loading").removeClass("hidden");
            });
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            $(".loading").addClass("hidden");
            $(".label-success").click(function () {
                $(".loading").removeClass("hidden");
            });
        });
    </script>
</asp:Content>
