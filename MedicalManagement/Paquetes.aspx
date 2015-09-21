<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Paquetes.aspx.cs" Inherits="MedicalManagement.Paquetes" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid border-top1-bottom5 no-radius no-vertical-padding gray-border">
        <div class="row">
            <div class="col-xs-12 col-md-4 col-lg-4 col-sm-4 left-panel">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-xs-12">
                            <label class="h5">Lista de Paquetes<i class="fa fa-cubes fa-margin-left"></i></label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-1x fa-search"></i></span>
                                <asp:DropDownList runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlChanged" ID="ddlPaquetes" CssClass="form-control combobox" DataTextField="Descripcion_AnalisisClinicoPaquetes" DataValueField="Id_AnalisisClinicoPaquetes" />
                            </div>
                        </div>
                        <div class="col-xs-12">
                            <hr />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-10 col-xs-offset-2">
                            <label class="h6">Agregar Auxiliar</label>
                            <asp:DropDownList runat="server" ID="ddlAnalisis" CssClass="form-control combobox" DataTextField="Descripcion_AnalisisClinico" DataValueField="Id_AnalisisClinico" />
                        </div>
                        <div class="col-xs-10 col-xs-offset-2 padding">
                            <asp:LinkButton runat="server" ID="btnAdd" OnClick="addAnalisis" Text='<label class=" pull-right label label-button label-success" runat="server">Agregar<i class="fa fa-arrow-right"></i></label>'/> 
                            <hr />
                        </div>
                    </div>
                    <div class="row">
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
                                    <asp:LinkButton runat="server" OnClick="insertPacket" Text='<label class=" pull-right label label-button label-success" runat="server">Crear<i class="fa fa-plus"></i></label>'  />
                                    <hr />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xs-12 col-md-8 col-lg-8 col-sm-8 container-fluid padding">
                <div class="row">
                    <div class="col-xs-12">
                        
                        <asp:LinkButton runat="server" OnClick="deletePacket" Text='<label class="label label-danger pull-right label-button pull-right" style="font-size: 16px;">Eliminar<i class="fa fa-scissors"></i></label>'/>
                        <hr />
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <h3>Analis Clinicos<i class="fa fa-stethoscope fa-margin-left fa-margin-right"></i>-<label runat="server" id="lblPaqueteNombre"></label></h3>
                        <hr />
                    </div>
                </div>
                <asp:Repeater runat="server" ID="rptItems">
                    <ItemTemplate>
                        <div class="col-xs-12 col-md-4 col-sm-6 col-lg-3 container-fluid " style="padding: 10px;">
                            <div class="row">
                                <div class="col-xs-12">
                                    <asp:LinkButton runat="server" Text='<i class="fa fa-close remove-icon pull-right"></i>' CommandArgument='<%# Eval("Id_AnalisisClinicoPaquetesdatos")%>' OnClick="deleteItem"/>
                                    <hr />
                                    <label class="h5"><i class="fa fa-stethoscope fa-margin-right"></i><%# Eval("oneAnalisis.Descripcion_AnalisisClinico") %></label>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $(".combobox").combobox();
        });

    </script>
</asp:Content>
