<%@ Page Title="" Language="C#" MasterPageFile="~/Consulta.Master" AutoEventWireup="true" CodeBehind="ConsultaMenu.aspx.cs" Inherits="MedicalManagement.ConsultaMenu" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Header" runat="server">
    <h3>Menu Consulta</h3>
    <hr />
    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-12 col-sm-4">
                <asp:DropDownList AutoPostBack="true" runat="server" ID="ddlFichas" OnSelectedIndexChanged="changePaciente" CssClass="col-sm-4 form-control combobox" DataTextField="_NombreCompleto" DataValueField="Id_FichaIdentificacion" />
            </div>
        </div>
    </div>
    <hr />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightSide" runat="server">
        <div class="row">
            <div class="col-xs-12 col-md-12 col-sm-12 col-lg-12 padding">
                <div class="row">
                    <div class="col-xs-12">
                        <hr class="blue-hr" />
                        <label class="label label-primary">Actual</label>
                        <hr class="blue-hr" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <asp:Repeater runat="server" ID="rptActual">
                            <ItemTemplate>
                                <div class="border-top1-bottom5 gray-border container-fluid">
                                    <h4>
                                        <span class="label label-primary">
                                            <label><%# testbind(Eval("Fecha_Consulta"))%></label>
                                        </span>
                                    </h4>
                                    <hr class="blue-hr" />
                                    <div class="container-fluid no-vertical-padding">
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <div class="row col-xs-12 col-md-6">
                                                    <div class="col-xs-12">
                                                        <h5>Subjetivo</h5>
                                                    </div>
                                                    <div class="col-xs-12">
                                                        <label class="packet-name"><%#  testbind(Eval("Subjetivo_Consulta")) %></label>
                                                    </div>
                                                </div>
                                                <div class="row col-xs-12 col-md-6">
                                                    <div class="col-xs-12">
                                                        <h5>Objetivo</h5>
                                                    </div>
                                                    <div class="col-xs-12">
                                                        <label class="packet-name"><%#  testbind(Eval("Objetivo_Consulta")) %></label>
                                                    </div>
                                                </div>
                                                <div class="row col-xs-12 col-md-6">
                                                    <div class="col-xs-12">
                                                        <h5>Analisis</h5>
                                                    </div>
                                                    <div class="col-xs-12">
                                                        <label class="packet-name"><%#  testbind(Eval("Analisis_Consulta")) %></label>
                                                    </div>
                                                </div>
                                                <div class="row col-xs-12 col-md-6">
                                                    <div class="col-xs-12">
                                                        <h5>Plan</h5>
                                                    </div>
                                                    <div class="col-xs-12">
                                                        <label class="packet-name"><%#  testbind(Eval("Plan_Consulta")) %></label>
                                                    </div>
                                                </div>
                                                <div class="row col-xs-12 col-md-6">
                                                    <div class="col-xs-12">
                                                        <h5>Observaciones</h5>
                                                    </div>
                                                    <div class="col-xs-12">
                                                        <label class="packet-name"><%#  testbind(Eval("Observaciones_ConsultaDiagnostico")) %></label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-xs-12">
                                                <div class="row">
                                                    <div class="col-xs-12 col-sm-6">
                                                        <h4>Diagnosticos</h4>
                                                        <hr />
                                                        <div class="col-xs-12 gray-container">
                                                            <asp:Repeater runat="server" ID="rptDiag" DataSource='<%# Eval("lDiagnosticos")%>'>
                                                                <ItemTemplate>
                                                                    <div class="row">
                                                                        <div class="col-xs-12">
                                                                            <label class="small-label"><%# Eval("oneDiag.Descripcion_Diagnostico")%></label>
                                                                            <hr />
                                                                        </div>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </div>
                                                    </div>
                                                    <div class="col-xs-12 col-sm-6">
                                                        <h4>Medicamentos y Dosis</h4>
                                                        <hr />
                                                        <div class="col-xs-12 gray-container">
                                                            <asp:Repeater runat="server" ID="Repeater1" DataSource='<%# Eval("lRecetas")%>'>
                                                                <ItemTemplate>
                                                                    <div class="row">
                                                                        <div class="col-xs-12">
                                                                            <h5><%# Eval("Tem_Medicamento")%></h5>
                                                                            <h5><%# Eval("Tem_Dosis")%></h5>
                                                                            <h5><%# Eval("Tem_Notas")%></h5>
                                                                            <hr />
                                                                        </div>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-xs-12 text-right padding">
                                                        <a class="label label-secondary form-control" href='<%# "RegistroConsulta.aspx?Id_Agenda=" + Eval("Id_Agenda") + "&Id_FichaIdentificacion=" + Eval("Id_FichaIdentificacion") + "&NombreCompleto=" + NombreCompleto %>'>Nota Clinica</a>
                                                        <a class="label label-secondary form-control" href='<%# "ConsultaReceta.aspx?Id_Agenda=" + Eval("Id_Agenda") + "&Id_FichaIdentificacion=" + Eval("Id_FichaIdentificacion") + "&NombreCompleto" + NombreCompleto + "&Id_Consulta=" + Eval("Id_Consulta") %>'>Receta Medica</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                    <hr class="blue-hr" />
                </div>
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-xs-12">
                            <label class="label label-primary">Historial</label>
                            <hr class="blue-hr" />
                            <div id="accordion">
                                <asp:Repeater runat="server" ID="rptAnteriores">
                                    <ItemTemplate>
                                        <h4>
                                            <span class="label label-primary">
                                                <label><%# testbind(Eval("Fecha_Consulta"))%></label>
                                            </span>
                                        </h4>
                                        <div class="container-fluid no-vertical-padding">
                                            <div class="row">
                                                <div class="col-xs-12">
                                                    <div class="row col-xs-12 col-md-6">
                                                        <div class="col-xs-12">
                                                            <h5>Subjetivo</h5>
                                                        </div>
                                                        <div class="col-xs-12">
                                                            <label class="packet-name"><%#  testbind(Eval("Subjetivo_Consulta")) %></label>
                                                        </div>
                                                    </div>
                                                    <div class="row col-xs-12 col-md-6">
                                                        <div class="col-xs-12">
                                                            <h5>Objetivo</h5>
                                                        </div>
                                                        <div class="col-xs-12">
                                                            <label class="packet-name"><%#  testbind(Eval("Objetivo_Consulta")) %></label>
                                                        </div>
                                                    </div>
                                                    <div class="row col-xs-12 col-md-6">
                                                        <div class="col-xs-12">
                                                            <h5>Analisis</h5>
                                                        </div>
                                                        <div class="col-xs-12">
                                                            <label class="packet-name"><%#  testbind(Eval("Analisis_Consulta")) %></label>
                                                        </div>
                                                    </div>
                                                    <div class="row col-xs-12 col-md-6">
                                                        <div class="col-xs-12">
                                                            <h5>Plan</h5>
                                                        </div>
                                                        <div class="col-xs-12">
                                                            <label class="packet-name"><%#  testbind(Eval("Plan_Consulta")) %></label>
                                                        </div>
                                                    </div>
                                                    <div class="row col-xs-12 col-md-6">
                                                        <div class="col-xs-12">
                                                            <h5>Observaciones</h5>
                                                        </div>
                                                        <div class="col-xs-12">
                                                            <label class="packet-name"><%#  testbind(Eval("Observaciones_ConsultaDiagnostico")) %></label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xs-12">
                                                    <div class="row">
                                                        <div class="col-xs-12 col-sm-6">
                                                            <h4>Diagnosticos</h4>
                                                            <hr />
                                                            <div class="col-xs-12 gray-container">
                                                                <asp:Repeater runat="server" ID="rptDiag" DataSource='<%# Eval("lDiagnosticos")%>'>
                                                                    <ItemTemplate>
                                                                        <div class="row">
                                                                            <div class="col-xs-12">
                                                                                <label class="small-label"><%# Eval("oneDiag.Descripcion_Diagnostico")%></label>
                                                                                <hr />
                                                                            </div>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </div>
                                                        </div>
                                                        <div class="col-xs-12 col-sm-6">
                                                            <h4>Medicamentos y Dosis</h4>
                                                            <hr />
                                                            <div class="col-xs-12 gray-container">
                                                                <asp:Repeater runat="server" ID="Repeater1" DataSource='<%# Eval("lRecetas")%>'>
                                                                    <ItemTemplate>
                                                                        <div class="row">
                                                                            <div class="col-xs-12">
                                                                                <h5><%# Eval("Tem_Medicamento")%></h5>
                                                                                <h5><%# Eval("Tem_Dosis")%></h5>
                                                                                <h5><%# Eval("Tem_Notas")%></h5>
                                                                                <hr />
                                                                            </div>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-xs-12 text-right padding">
                                                            <a class="label label-secondary form-control" href='<%# "RegistroConsulta.aspx?Id_Agenda=" + Eval("Id_Agenda") + "&Id_FichaIdentificacion=" + Eval("Id_FichaIdentificacion") + "&NombreCompleto=" + NombreCompleto %>'>Nota Clinica</a>
                                                        <a class="label label-secondary form-control" href='<%# "ConsultaReceta.aspx?Id_Agenda=" + Eval("Id_Agenda") + "&Id_FichaIdentificacion=" + Eval("Id_FichaIdentificacion") + "&NombreCompleto" + NombreCompleto + "&Id_Consulta=" + Eval("Id_Consulta") %>'>Receta Medica</a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row hidden">
            <div id="consultasanteriores" runat="server">
            </div>
        </div>
    <script>
        $("#accordion").accordion({
            collapsible: true,
            heightStyle: "content",
            active:false
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

        function success() {
            location.reload();
        }

        function error() {
            alert("A ocurrido un error, favor de volver a intentarlo.");
            location.reload();
        }
    </script>
    <style>
        textarea {
            resize: none;
            margin-bottom: 5px;
        }

        .padding {
            margin: 5px 0;
        }
    </style>
</asp:Content>
