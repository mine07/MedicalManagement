<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaMenu.aspx.cs" Inherits="MedicalManagement.ConsultaMenu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-12 col-md-4 col-sm-4 col-lg-4">
                <div>
                    <font color="blue"><strong>
        Paciente:</strong><asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
        </font>

                </div>
                <div>
                    <p>_____</p>
                </div>
                <div>

                    <asp:GridView ID="GridViewFecha" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Id_Consulta" HeaderText="Id.Consulta"
                                SortExpression="Id_Consulta" />

                            <asp:BoundField DataField="Fecha_Consulta" HeaderText="Fecha de Consultas"
                                SortExpression="Fecha_Consulta" />
                        </Columns>

                    </asp:GridView>
                </div>
                <div>
                    <asp:Button ID="btnantecedentes" runat="server" Text="antecedentes"
                        OnClick="btnantecedentes_Click" />

                </div>
                <div>
                    <asp:TextBox ID="txtantecedentes" runat="server" Width="120" TextMode="MultiLine" Rows="6"></asp:TextBox>
                </div>
                <div>
                </div>
                <div>
                    <asp:LinkButton ID="LinkNotaClinica" runat="server"
                        OnClick="LinkNotaClinica_Click">Nota Clinica</asp:LinkButton>
                </div>

                <div>
                    <asp:LinkButton ID="LinkReceta" runat="server" OnClick="LinkReceta_Click"
                        Visible="False">Receta Medica</asp:LinkButton>
                </div>
                <div>
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


                <div>
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
                <div>
                    <asp:TextBox ID="txtnotasrelevantes" runat="server" Width="120" TextMode="MultiLine" Rows="6"></asp:TextBox>
                </div>
                <div>
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
            <div class="col-xs-12 col-md-8 col-sm-8 col-lg-8">
                <div class="row">
                    <div class="col-xs-12 text-center">
                        <label class="label label-primary">Historial</label>
                        <hr class="blue-hr" />
                    </div>
                </div>
                <asp:Repeater runat="server" ID="rptAnteriores">
                    <ItemTemplate>
                        <div class="container-fluid border-top1-bottom5">
                        <div class="row">
                            <div class="col-xs-12 col-md-12 col-sm-12 col-lg-12">
                                <div class="col-xs-6 col-md-3 col-sm-3 col-lg-3 text-right">
                                    <label>Fecha Consulta</label>
                                </div>
                                <div class="col-xs-6 col-md-9 col-sm-9 col-lg-9">
                                    <%# Eval("Fecha_Consulta") %>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-6 col-md-3 col-sm-3 col-lg-3 text-right">
                                <label>Subjetivo</label>
                            </div>
                            <div class="col-xs-6 col-md-9 col-sm-9 col-lg-9">
                                <%# Eval("Subjetivo_Consulta") %>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-6 col-md-3 col-sm-3 col-lg-3 text-right">
                                <label>Objetivo</label>
                            </div>
                            <div class="col-xs-6 col-md-9 col-sm-9 col-lg-9">
                                <%# Eval("Objetivo_Consulta") %>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-6 col-md-3 col-sm-3 col-lg-3 text-right">
                                <label>Diagonisto</label>
                            </div>
                            <div class="col-xs-6 col-md-9 col-sm-9 col-lg-9">
                                <%# Eval("Diagnostico_Consulta") %>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-6 col-md-3 col-sm-3 col-lg-3 text-right">
                                <label>Analis</label>
                            </div>
                            <div class="col-xs-6 col-md-9 col-sm-9 col-lg-9">
                                <%# Eval("Analisis_Consulta") %>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-6 col-md-3 col-sm-3 col-lg-3 text-right">
                                <label>Plan</label>
                            </div>
                            <div class="col-xs-6 col-md-9 col-sm-9 col-lg-9">
                                <%# Eval("Plan_Consulta") %>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-6 col-md-3 col-sm-3 col-lg-3 text-right">
                                <label>Medicamento</label>
                            </div>
                            <div class="col-xs-6 col-md-9 col-sm-9 col-lg-9">
                                <%# Eval("Medicamento_ConsultaReceta") %>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-6 col-md-3 col-sm-3 col-lg-3 text-right">
                                <label>Cantidad</label>
                            </div>
                            <div class="col-xs-6 col-md-9 col-sm-9 col-lg-9">
                                <%# Eval("Cantidad_ConsultaReceta") %>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-6 col-md-3 col-sm-3 col-lg-3 text-right">
                                <label>Observaciones</label>
                            </div>
                            <div class="col-xs-6 col-md-9 col-sm-9 col-lg-9">
                                <%# Eval("Observaciones_ConsultaDiagnostico") %>
                            </div>
                        </div>
                            
                            </div>
                        <hr />
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>
        <div class="row">
            <div id="consultasanteriores" runat="server">
            </div>
        </div>
    </div>
</asp:Content>
