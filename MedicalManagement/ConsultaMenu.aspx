<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaMenu.aspx.cs" Inherits="MedicalManagement.ConsultaMenu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
    <div class="container-fluid gray-border border-top1-bottom5 no-vertical-padding">
        <div class="row">
            <div class="col-xs-12 col-md-4 col-sm-4 col-lg-4 left-panel">
                <hr class="blue-hr" />
                <div class=" text-center">
                    <label class="label-primary label">Paciente:<asp:Label ID="lblNombre" runat="server" Text=""></asp:Label></label>
                </div>
                <hr class="blue-hr" />
                <div class="hidden">
                    <asp:GridView ID="GridViewFecha" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Id_Consulta" HeaderText="Id.Consulta"
                                SortExpression="Id_Consulta" />
                            <asp:BoundField DataField="Fecha_Consulta" HeaderText="Fecha de Consultas"
                                SortExpression="Fecha_Consulta" />
                        </Columns>

                    </asp:GridView>
                </div>
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-xs-12 col-md-12 col-lg-12 col-sm-12">
                            <h5>Antecedentes</h5>
                            <asp:TextBox placeholder="Sin Antecedentes..." ID="txtantecedentes" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                        <br />
                        <div class="col-xs-12 col-md-12 col-lg-12 col-sm-12">
                            <h5>Notas Relevantes</h5>
                            <asp:TextBox placeholder="Sin Notas Relevantes..." ID="txtnotasrelevantes" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                        <div class="col-xs-12 col-md-12 col-lg-12 text-right h5">
                            <asp:Button ID="btnantecedentes" runat="server" Text="Guardar"
                                OnClick="btnantecedentes_Click" CssClass="btn btn-primary" />
                        </div>

                    </div>
                </div>
                <hr />
                <div>
                </div>
                <div class="hidden">
                    <div>
                        <asp:LinkButton ID="LinkNotaClinica" runat="server" CssClass="label label-secondary"
                            OnClick="LinkNotaClinica_Click">Nota Clinica</asp:LinkButton>
                    </div>

                    <div>
                        <asp:LinkButton ID="LinkReceta" runat="server" OnClick="LinkReceta_Click" CssClass="label label-secondary"
                            Visible="False">Receta Medica</asp:LinkButton>
                    </div>
                    <div>
                    </div>
                </div>
                <div>
                    <h5>Diagnosticos Activos</h5>
                    <div class="white-container">

                        <asp:Repeater ID="rptActivos" runat="server">
                            <ItemTemplate>
                                <hr />
                                <i onclick="removeDiagnostico(<%#Eval("Id_ConsultaDiagnostico") %>)" class="fa fa-remove fa-1x pull-right remove-icon"></i>
                                <label class="small-label"><%# Eval("Descripcion_Diagnostico") %></label>
                                <label class="small-label"><%# Eval("Fecha_ConsultaDiagnostico") %></label>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <hr />
                <div>
                    <h5>Diagnosticos Inactivas</h5>
                    <div class="white-container">
                        <asp:Repeater ID="rptInactivos" runat="server">
                            <ItemTemplate>
                                <hr />
                                <i onclick="AddDiagnostico(<%#Eval("Id_ConsultaDiagnostico") %>)" class="fa fa-check fa-1x pull-right remove-icon"></i>
                                <label class="small-label"><%# Eval("Descripcion_Diagnostico") %></label>
                                <label class="small-label"><%# Eval("Fecha_ConsultaDiagnostico") %></label>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <hr />
                <div>
                    <h5>Procedimientos</h5>
                    <asp:Repeater ID="rptProcedimientos" runat="server">
                        <ItemTemplate>
                            <div class="border-top1-bottom5">
                                <label class="small-label"><%# Eval("Descripcion_Procedimiento") %></label>
                                <label class="small-label"><%# Eval("Fecha_ConsultaProcedimiento") %></label>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <hr />
                <div>
                    <h5>Auxiliar Clinico<a href='<%= "Consulta_AnalisisClinico.aspx?Id_Paciente="+ Id_FichaIdentificacion %>'><label class="icon-add pull-right  label label-success">Pedir<i class="fa fa-stethoscope fa-margin-left"></i></label></a></h5>
                    <hr />
                </div>
                <div>
                    <h5>Archivos Adjuntos</h5>
                    <div class="container-fluid white-container">
                        <asp:Repeater runat="server" ID="rptFiles">
                            <ItemTemplate>
                                <div class="row">
                                    <div class="col-xs-12">
                                        <a href='<%# Eval("Download") %>' target="_blank" class="label-button" download>
                                            <i class="fa-margin-right fa fa-file"></i>
                                            <label class="packet-name"><%# Eval("Nombre")%></label>
                                        </a>
                                        <hr />
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <asp:FileUpload ID="fleUpload" runat="server" CssClass="form-control padding" />
                    <asp:LinkButton OnClick="upload" runat="server" Text='<label class="label pull-right label-success padding">Subir<i class="fa-margin-left fa fa-upload"></i></label>' />
                    <hr />
                </div>
                <div class="hidden">
                    <asp:GridView ID="GridViewDiagnosticosActivos" runat="server"
                        AutoGenerateColumns="False">
                        <Columns>

                            <asp:BoundField DataField="Id_Diagnostico" HeaderText="Id.Diagnostico"
                                SortExpression="Id_Diagnostico" />

                            <asp:BoundField DataField="Descripcion_Diagnostico" HeaderText="Activo              "
                                SortExpression="Descripcion_Diagnostico" />

                            <asp:BoundField DataField="Estatus_ConsultaDiagnostico" HeaderText="Estatus.ConsultaDiagnostico"
                                SortExpression="Estatus_ConsultaDiagnostico" />

                            <asp:BoundField DataField="Fecha_ConsultaDiagnostico" HeaderText="Fecha"
                                SortExpression="Fecha_Diagnostico" />



                            <asp:TemplateField HeaderText="Elegir">
                                <HeaderTemplate>
                                    Elegir
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBoxelegir" runat="server" OnCheckedChanged="CheckBoxactivo_CheckedChanged" AutoPostBack="true" />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>


                <div class="hidden">
                    <asp:GridView ID="GridViewDiagnosticosInactivos" runat="server" AutoGenerateColumns="False">
                        <Columns>

                            <asp:BoundField DataField="Id_Diagnostico" HeaderText="Id.Diagnostico"
                                SortExpression="Id_Diagnostico" />

                            <asp:BoundField DataField="Descripcion_Diagnostico" HeaderText="Inactivo            "
                                SortExpression="Descripcion_Diagnostico" />

                            <asp:BoundField DataField="Estatus_ConsultaDiagnostico" HeaderText="Estatus.ConsultaDiagnostico"
                                SortExpression="Estatus_ConsultaDiagnostico" />

                            <asp:BoundField DataField="Fecha_ConsultaDiagnostico" HeaderText="Fecha"
                                SortExpression="Fecha_Diagnostico0" />

                            <asp:TemplateField HeaderText="Elegir">
                                <HeaderTemplate>
                                    Elegir
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBoxelegir" runat="server" OnCheckedChanged="CheckBoxinactivo_CheckedChanged" AutoPostBack="true" />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>

                    </asp:GridView>
                </div>

                <div class="hidden">
                    <asp:GridView ID="GridViewProcedimientos" runat="server" AutoGenerateColumns="false">
                        <Columns>

                            <asp:BoundField DataField="Id_Procedimiento" HeaderText="Id.Procedimiento"
                                SortExpression="Id_Procedimiento" />

                            <asp:BoundField DataField="Descripcion_Procedimiento" HeaderText="Procedimiento"
                                SortExpression="Descripcion_Procedimiento" />

                            <asp:BoundField DataField="Fecha_ConsultaProcedimiento" HeaderText="Fecha Procedimientos"
                                SortExpression="Fecha_ConsultaProcedimiento" />
                        </Columns>

                    </asp:GridView>
                </div>
            </div>
            <div class="col-xs-12 col-md-8 col-sm-8 col-lg-8 padding">
                <div class="row">
                    <div class="col-xs-12 text-center">
                        <hr class="blue-hr" />
                        <label class="label label-primary">Actual</label>
                        <div class="text-right pull-right">
                            <a class="label label-secondary form-control" href='<%= "PagosIndividuales.aspx?Id_Usuario=" + Request.QueryString["Id_FichaIdentificacion"] %>'>Pagos</a>
                        </div>
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
                                            <label class="hidden-xs"><%# porConsultar(Eval("Subjetivo_Consulta")) + " - "%></label>
                                            <label><%# testbind(Eval("Fecha_Consulta"))%></label>
                                        </span>
                                    </h4>
                                    <hr class="blue-hr" />
                                    <div class="container-fluid no-vertical-padding">
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <h5>Objetivo</h5>
                                                    </div>
                                                    <div class="col-xs-12">
                                                        <label class="packet-name"><%#  testbind(Eval("Objetivo_Consulta")) %></label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <h5>Analisis</h5>
                                                    </div>
                                                    <div class="col-xs-12">
                                                        <label class="packet-name"><%#  testbind(Eval("Analisis_Consulta")) %></label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <h5>Plan</h5>
                                                    </div>
                                                    <div class="col-xs-12">
                                                        <label class="packet-name"><%#  testbind(Eval("Plan_Consulta")) %></label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <h5>Observaciones</h5>
                                                    </div>
                                                    <div class="col-xs-12">
                                                        <label class="packet-name"><%#  testbind(Eval("Observaciones_ConsultaDiagnostico")) %></label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <a class="label label-secondary form-control" href='<%# "RegistroConsulta.aspx?Id_Agenda=" + Eval("Id_Agenda") + "&Id_FichaIdentificacion=" + Eval("Id_FichaIdentificacion") + "&NombreCompleto=" + lblNombre.Text %>'>Nota Clinica</a>
                                                        <a class="label label-secondary form-control" href='<%# "ConsultaReceta.aspx?Id_Agenda=" + Eval("Id_Agenda") + "&Id_FichaIdentificacion=" + Eval("Id_FichaIdentificacion") + "&NombreCompleto" + lblNombre.Text + "&Id_Consulta=" + Eval("Id_Consulta") %>'>Receta Medica</a>
                                                        <a class="label label-secondary form-control hidden" href='<%# "ConsultaAnalisisClinico.aspx?Id_Agenda=" + Eval("Id_Agenda") + "&Id_FichaIdentificacion=" + Eval("Id_FichaIdentificacion") + "&NombreCompleto" + lblNombre.Text + "&Id_Consulta=" + Eval("Id_Consulta") %>'>Analisis Clinico</a>
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
                        <div class="col-xs-12 text-center">
                            <label class="label label-primary">Historial</label>
                            <hr class="blue-hr" />

                            <div id="accordion">
                                <asp:Repeater runat="server" ID="rptAnteriores">
                                    <ItemTemplate>
                                        <h4>
                                            <span class="label label-primary">
                                                <label class="hidden-xs"><%# porConsultar(Eval("Subjetivo_Consulta")) + " - "%></label>
                                                <label><%# testbind(Eval("Fecha_Consulta"))%></label>
                                            </span>
                                        </h4>
                                        <div class="border-top1-bottom5 gray-border container-fluid text-left">
                                            <div class="container-fluid no-vertical-padding">
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <div class="row">
                                                            <div class="col-xs-12">
                                                                <h5>Objetivo</h5>
                                                            </div>
                                                            <div class="col-xs-12">
                                                                <label class="packet-name"><%#  testbind(Eval("Objetivo_Consulta")) %></label>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-xs-12">
                                                                <h5>Analisis</h5>
                                                            </div>
                                                            <div class="col-xs-12">
                                                                <label class="packet-name"><%#  testbind(Eval("Analisis_Consulta")) %></label>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-xs-12">
                                                                <h5>Plan</h5>
                                                            </div>
                                                            <div class="col-xs-12">
                                                                <label class="packet-name"><%#  testbind(Eval("Plan_Consulta")) %></label>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-xs-12">
                                                                <h5>Observaciones</h5>
                                                            </div>
                                                            <div class="col-xs-12">
                                                                <label class="packet-name"><%#  testbind(Eval("Observaciones_ConsultaDiagnostico")) %></label>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-xs-12">
                                                                <a class="label label-secondary form-control" href='<%# "RegistroConsulta.aspx?Id_Agenda=" + Eval("Id_Agenda") + "&Id_FichaIdentificacion=" + Eval("Id_FichaIdentificacion") + "&NombreCompleto=" + lblNombre.Text %>'>Nota Clinica</a>
                                                                <a class="label label-secondary form-control" href='<%# "ConsultaReceta.aspx?Id_Agenda=" + Eval("Id_Agenda") + "&Id_FichaIdentificacion=" + Eval("Id_FichaIdentificacion") + "&NombreCompleto" + lblNombre.Text + "&Id_Consulta=" + Eval("Id_Consulta") %>'>Receta Medica</a>
                                                                <a class="label label-secondary form-control hidden" href='<%# "ConsultaAnalisisClinico.aspx?Id_Agenda=" + Eval("Id_Agenda") + "&Id_FichaIdentificacion=" + Eval("Id_FichaIdentificacion") + "&NombreCompleto" + lblNombre.Text + "&Id_Consulta=" + Eval("Id_Consulta") %>'>Analisis Clinico</a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-xs-12">
                                                        <div class="row">
                                                            <div class="col-xs-6">
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

                                                            <div class="col-xs-6">
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
    </div>

    <script>
        $("#accordion").accordion({
            collapsible: true,
            heightStyle: "content"
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

        $(document).ready(function () {
            $(".combobox").combobox();
        });

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
    </style>
</asp:Content>
