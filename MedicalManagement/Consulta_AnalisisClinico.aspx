<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" ClientIDMode="AutoID" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Consulta_AnalisisClinico.aspx.cs" Inherits="MedicalManagement.Consulta_AnalisisClinico" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager runat="server" />
    <a href='<%= "ConsultaMenu.aspx?Id_Agenda=0&Id_FichaIdentificacion=" + oneUser.Id_FichaIdentificacion %>'>
        <label class="pull-right label label-primary label-button">Volver<i class="fa fa-arrow-left fa-margin-left"></i></label></a>
    <h3>Analisis Clinico</h3>
    <hr />
    <h4 style="margin: 0px; margin-left: 1px;">
        <label class="label label-primary">Paciente: <span runat="server" id="spanName">Nombre</span></label></h4>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid border-top1-bottom5 no-radius no-vertical-padding gray-border">
                <div class="row">
                    <div class="col-xs-12 col-md-5 col-sm-5 col-lg-5 container-fluid left-panel">
                        <div class="row">
                            <div class="col-xs-12">
                                <label class="h5 text-capitalize">Seleccionar  auxiliar de diagnostico a solicitar</label><i class="fa-margin-left fa fa-arrow-down"></i>
                                <hr />
                                <div class="row">
                                    <div class="col-xs-10 col-xs-offset-2">
                                        <label
                                            class="h5 text-capitalize">
                                            Lista de paquetes</label><i class="fa-margin-left fa fa-cubes"></i>
                                        <div class="container-fluid white-container">
                                            <asp:Repeater runat="server" ID="rptPaquete" OnItemCreated="addToUpdatePaquete">
                                                <ItemTemplate>
                                                    <div class="row">
                                                        <div class="col-xs-12">
                                                            <i class="fa-margin-right fa fa-cube"></i>
                                                            <label class="packet-name"><%# Eval("Descripcion_AnalisisClinicoPaquetes")%></label>
                                                            <asp:LinkButton ID="btnAdd" OnClick="addTemporalPaquete" runat="server" Text='<i class="fa  fa-arrow-right icon-button pull-right"></i>' CommandArgument='<%# Eval("Id_AnalisisClinicoPaquetes") %>' />
                                                            <hr />
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                        <hr />
                                    </div>
                                    <div class="col-xs-10 col-xs-offset-2">
                                        <label class="h5 text-capitalize">Lista de auxiliares de diagnostico</label><i class="fa-margin-left fa fa-stethoscope"></i>
                                        <div class="container-fluid white-container">
                                            <asp:Repeater runat="server" ID="rptAuxiliares" OnItemCreated="addToUpdateDiag">
                                                <ItemTemplate>
                                                    <div class="row">
                                                        <div class="col-xs-12">
                                                            <i class="fa-margin-right fa fa-stethoscope"></i>
                                                            <label class="packet-name"><%# Eval("Descripcion_AnalisisClinico")%></label>
                                                            <asp:LinkButton ID="btnAdd" OnClick="addTemporal" runat="server" Text='<i class="fa  fa-arrow-right icon-button pull-right"></i>' CommandArgument='<%# Eval("Id_AnalisisClinico") %>' />
                                                            <hr />
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                        <hr />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12 col-md-7 col-sm-7 col-lg-7 container-fluid padding">
                        <div class="row">
                            <div class="col-xs-12">
                                <label class="h5 text-capitalize">Auxiliares de diagnostico seleccionados hasta el momento</label><i class="fa-margin-left fa fa-stethoscope"></i>
                                <div class="container-fluid gray-container">
                                    <asp:Repeater runat="server" ID="rptSeleccionados" OnItemCreated="addToUpdateRemove">
                                        <ItemTemplate>
                                            <div class="row">
                                                <div class="col-xs-12">
                                                    <i class="fa-margin-right fa fa-stethoscope"></i>
                                                    <label class="packet-name"><%# Eval("Descripcion_AnalisisClinico")%></label>
                                                    <asp:LinkButton ID="btnAdd" runat="server" Text='<i class="fa fa-remove remove-icon pull-right"></i>' OnClick="removeSelected" CommandArgument='<%# Eval("Id_AnalisisClinico") %>' />
                                                    <hr />
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <h5>
                                    <label data-toggle="modal" data-target="#myModal" class="label label-success label-button">Guardar Nuevo Paquete<i class="fa fa-save fa-margin-left"></i></label></h5>
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-10 col-xs-offset-2">
                                <label class="h5 text-capitalize">Otros</label>
                                <input class="form-control" type="text" />
                                <hr />
                            </div>
                            <div class="col-xs-10 col-xs-offset-2">
                                <label class="h5 text-capitalize">Notas al laboratorio</label>
                                <input class="form-control" type="text" />
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 text-right text-uppercase no-user-select" style="font-size: 16px;">
                                <label class="label lbl-hvr-icn label-button label-default">Imprimir<i class="fa fa-print fa-margin-left"></i></label>
                                <label class="label lbl-hvr-icn label-button label-success">Guardar<i class="fa fa-save fa-margin-left"></i></label>
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
                    <h4 class="modal-title" id="myModalLabel">Guardar Paquete</h4>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-xs-12 col-sm-4">
                                <label>Nombre Paquete</label>
                            </div>
                            <div class="col-xs-12 col-sm-8">
                                <input type="text" class="form-control" runat="server" id="txtNombre" />
                                <hr />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-success">Guardar<i class="fa fa-save"></i></button>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12 text-right text-uppercase">
            <hr />
            <label class="fade-hover"><span id="time"></span></label>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            setInterval(function () { interval() }, 1000);
        });

        function interval() {
            var currentdate = new Date();
            var datetime = "Fecha Actual : " + currentdate.getDate() + "/"
                            + (currentdate.getMonth() + 1) + "/"
                            + currentdate.getFullYear() + " - "
                            + currentdate.getHours() + ":"
                            + currentdate.getMinutes() + ":"
                            + currentdate.getSeconds();
            $("#time").text(datetime);
        }
    </script>
</asp:Content>
