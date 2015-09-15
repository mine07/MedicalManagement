<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ConsultaReceta.aspx.cs" Inherits="MedicalManagement.ConsultaReceta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="">
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

    <hr style="border-color: black;" />
    <asp:UpdatePanel runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" />
            <asp:AsyncPostBackTrigger ControlID="rptTemporal" />
        </Triggers>
        <ContentTemplate>
            <div class="container-fluid border-top1-bottom5">
                <div class="row">
                    <div class="col-xs-12 col-md-4 col-lg-4 col-sm-4">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><i class="fa fa-1x fa-search"></i></span>
                                        <asp:DropDownList runat="server" ID="ddlTemplate" CssClass="form-control combobox" DataTextField="Descripcion_Medicamento" DataValueField="Id_Medicamento" />
                                    </div>
                                    <hr />
                                </div>
                                <div class="col-xs-12">
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
                                    <asp:LinkButton OnClick="saveTo" ID="btnSave" runat="server" Text='<h4><label class="label label-success pull-right label-button">Agregar<i class="fa fa-arrow-circle-right" style="padding-left: 10px;"></i></label></h4>' />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12 col-md-8 col-lg-8 col-sm-8">
                        <div class="container-fluid" id="Medicine-Container">
                            <asp:Repeater runat="server" ID="rptTemporal">
                                <ItemTemplate>
                                    <div class="col-xs-12 col-md-5 col-lg-5 col-sm-5  border-right3-bottom3">
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <label class="h5">Medicamento</label>
                                                <label><%# Eval("Tem_Medicamento") %></label>
                                                <asp:LinkButton ID="btnRemove" runat="server" Text='<i class="fa fa-remove fa-1x pull-right remove-icon"></i>' OnClick="RemoveTemporal" CommandArgument='<%# Eval("Id_Temporal_Receta") %>' />
                                            </div>
                                            <div class="col-xs-12">
                                                <label  class="h5">Dosis</label>
                                                <label><%# Eval("Tem_Dosis") %></label>
                                            </div>
                                            <div class="col-xs-12">
                                                <label  class="h5">Notas</label>
                                                <label><%# Eval("Tem_Notas") %></label>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>
        $(document).ready(function () {
            $('.combobox').combobox();
        });
    </script>
</asp:Content>
