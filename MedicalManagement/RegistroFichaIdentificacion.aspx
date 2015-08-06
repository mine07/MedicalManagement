<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroFichaIdentificacion.aspx.cs" Inherits="MedicalManagement.RegistroFichaIdentificacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table width="100%" border="0">
        <tr>
            <td align="left"><font color="red">Configuración\FichaIdentificacion\Agregar</font></td>
            <td align="right">
                <asp:ImageButton ID="ImageGrabar" runat="Server" ImageUrl="IMG/Grabar.png" ToolTip="Grabar EstadoCivil" OnClick="btnGuardar_FichaIdentificacion_Click"></asp:ImageButton>&nbsp;
        <asp:ImageButton ID="ImageRegresar" runat="Server" ImageUrl="IMG/Regresar.png" ToolTip="Regresar" OnClick="btnRegresar_FichaIdentificacion_Click"></asp:ImageButton>
            </td>
        </tr>

        <tr>
            <td colspan="2" align="center" runat="Server" id="Alerta"></td>
        </tr>
    </table>


    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-12 col-lg-6 col-sm-6 col-md-6">
                <div class="container-fluid">
                    <div class="row">

                        <div class="col-sm-6 col-xs-12 col-lg-6 col-md-6">
                            <label>Clave Identificacion </label>
                        </div>

                        <div class="col-sm-6 col-xs-12 col-lg-6 col-md-6">
                            <asp:TextBox CssClass="form-control" ID="txtClaveIdent" runat="server" Columns="10" ReadOnly="true"
                                BackColor="#CCFFCC"></asp:TextBox>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-sm-6 col-xs-12 col-lg-6 col-md-6">
                            <label>Fecha Identificacion </label>
                        </div>
                        <div class="col-sm-6 col-xs-12 col-lg-6 col-md-6">
                            <input id="txtFechaIdent" type="text" class="datePicker form-control" runat="server" />
                        </div>


                    </div>

                    <div class="row">
                        <div class="col-sm-6 col-xs-12 col-lg-6 col-md-6">
                            <label>Nombre</label>
                        </div>
                        <div class="col-sm-6 col-xs-12 col-lg-6 col-md-6">
                            <asp:TextBox CssClass="form-control" ID="txtNombreIdent" runat="server" Columns="25"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6 col-xs-12 col-lg-6 col-md-6">
                            <label>Apellido Paterno</label>
                        </div>
                        <div class="col-sm-6 col-xs-12 col-lg-6 col-md-6">
                            <asp:TextBox CssClass="form-control" ID="txtApPaIdent" runat="server" Columns="25"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">

                        <div class="col-sm-6 col-xs-12 col-lg-6 col-md-6">
                            <label>Apellido Materno</label>
                        </div>
                        <div class="col-sm-6 col-xs-12 col-lg-6 col-md-6">
                            <asp:TextBox CssClass="form-control" ID="txtApMaIdent" runat="server" Columns="25"></asp:TextBox>

                        </div>
                    </div>
                    <div class="row">

                        <div class="col-sm-6 col-xs-12 col-lg-6 col-md-6">
                            <label>Lugar de Nacimiento</label>
                        </div>
                        <div class="col-sm-6 col-xs-12 col-lg-6 col-md-6">
                            <asp:TextBox CssClass="form-control" ID="txtLugarNaIdent" runat="server" Columns="25"></asp:TextBox>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6 col-xs-12 col-lg-6 col-md-6">
                            <label>Fecha de Nacimiento</label>
                        </div>
                        <div class="col-sm-6 col-xs-12 col-lg-6 col-md-6">
                            <input id="txtFechaNaIdent" type="text" class="datePicker form-control" runat="server" />
                        </div>
                    </div>

                    <div class="row">

                        <div class="col-sm-6 col-xs-12 col-lg-6 col-md-6">
                            <label>Fecha Primera visita</label>
                        </div>
                        <div class="col-sm-6 col-xs-12 col-lg-6 col-md-6">
                            <input id="txtFechaPriIdent" type="text" class="datePicker form-control" runat="server" />
                        </div>
                    </div>


                </div>
            </div>
            <div class="col-xs-12 col-lg-6 col-sm-6 col-md-6">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-xs-12 col-sm-6 col-lg-6 col-md-6">
                            <label>Foto</label>
                            <asp:Label ID="Alerta2" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="col-xs-12 col-sm-6 col-lg-6 col-md-6">
                            <asp:Image ID="Image1" runat="server" Width="80px" Height="90px" align="MIDDLE" />
                        </div>
                    </div>

                    <div class="row">

                        <div class="col-xs-12 col-sm-6 col-lg-6 col-md-6">
                            <label>Cargar Foto</label>
                        </div>
                        <div class="col-xs-12 col-sm-6 col-lg-6 col-md-6">
                            <asp:FileUpload CssClass="btn btn-default file" ID="FileUpload1" runat="server" />
                        </div>
                    </div>

                    <div class="row">

                        <div class="col-xs-12 col-sm-6 col-lg-6 col-md-6">
                            <label>Teléfono Casa</label>
                        </div>
                        <div class="col-xs-12 col-sm-6 col-lg-6 col-md-6">
                            <asp:TextBox CssClass="form-control" ID="txtTelCaIdent" runat="server" Columns="25"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">

                        <div class="col-xs-12 col-sm-6 col-lg-6 col-md-6">
                            <label>Teléfono Oficina</label>
                        </div>
                        <div class="col-xs-12 col-sm-6 col-lg-6 col-md-6">
                            <asp:TextBox CssClass="form-control" ID="txtTelOfiIdent" runat="server" Columns="25"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">

                        <div class="col-xs-12 col-sm-6 col-lg-6 col-md-6">
                            <label>Teléfono Movil</label>
                        </div>
                        <div class="col-xs-12 col-sm-6 col-lg-6 col-md-6">
                            <asp:TextBox CssClass="form-control" ID="txtTelMovIndent" runat="server" Columns="25"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">

                        <div class="col-xs-12 col-sm-6 col-lg-6 col-md-6">
                            <label>Correo electronico</label>
                        </div>
                        <div class="col-xs-12 col-sm-6 col-lg-6 col-md-6">
                            <asp:TextBox CssClass="form-control" ID="txtCorreoIdent" runat="server" Columns="25"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">

                        <div class="col-xs-12 col-sm-6 col-lg-6 col-md-6">
                            <label>Caso Emergencia</label>
                        </div>
                        <div class="col-xs-12 col-sm-6 col-lg-6 col-md-6">
                            <asp:TextBox CssClass="form-control" ID="txtCasoEmeIdent" runat="server" Columns="25"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-xs-12 col-md-6 col-sm-6 col-lg-6">
                        <div class="row">
                            <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4"></div>
                            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">Direccion</div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                <label>Calle</label>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                <asp:TextBox CssClass="form-control" ID="txtCalleIdent" runat="server" Columns="25"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">

                            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                <label>No.Int</label>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                <asp:TextBox CssClass="form-control" ID="txtNuIntIdent" runat="server" Columns="25"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">

                            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                <label>No.Ext</label>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                <asp:TextBox CssClass="form-control" ID="txtNuExtIdent" runat="server" Columns="25"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">

                            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                <label>Colonia</label>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                <asp:TextBox CssClass="form-control" ID="txtColoIdent" runat="server" Columns="25"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">

                            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                <label>Municipio</label>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                <asp:TextBox CssClass="form-control" ID="txtMuniIdent" runat="server" Columns="25"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">

                            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                <label>Pais</label>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                <asp:TextBox CssClass="form-control" ID="txtPaisIdent" runat="server" Columns="25"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">

                            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                <label>Código Postal </label>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                <asp:TextBox CssClass="form-control" ID="txtCoPosIdent" runat="server" Columns="25"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6"></div>
                        </div>
                    </div>
                    <div class="col-xs-12 col-lg-6 col-sm-6 col-md-6">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-xs-12 col-lg-6 col-sm-6 col-md-6">
                                    <label>Empresa</label>
                                </div>

                                <div class="col-xs-12 col-lg-6 col-sm-6 col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlEmpresa" runat="server">
                                    </asp:DropDownList>

                                </div>
                            </div>
                            <div class="row">

                                <div class="col-xs-12 col-lg-6 col-sm-6 col-md-6">
                                    <label>Sucursal</label>
                                </div>
                                <div class="col-xs-12 col-lg-6 col-sm-6 col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlSucursal" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">

                                <div class="col-xs-12 col-lg-6 col-sm-6 col-md-6">
                                    <label>Sexo</label>
                                </div>
                                <div class="col-xs-12 col-lg-6 col-sm-6 col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlSexo" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">

                                <div class="col-xs-12 col-lg-6 col-sm-6 col-md-6">
                                    <label>EdoCivil</label>
                                </div>
                                <div class="col-xs-12 col-lg-6 col-sm-6 col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlEdoCivil" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">

                                <div class="col-xs-12 col-lg-6 col-sm-6 col-md-6">
                                    <label>Ocupacion</label>
                                </div>
                                <div class="col-xs-12 col-lg-6 col-sm-6 col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlOcupacion" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">

                                <div class="col-xs-12 col-lg-6 col-sm-6 col-md-6">
                                    <label>Escolaridad</label>
                                </div>
                                <div class="col-xs-12 col-lg-6 col-sm-6 col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlEscolaridad" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">

                                <div class="col-xs-12 col-lg-6 col-sm-6 col-md-6">
                                    <label>EmpresaConvenio</label>
                                </div>
                                <div class="col-xs-12 col-lg-6 col-sm-6 col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlEmpresaConvenio" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">

                                <div class="col-xs-12 col-lg-6 col-sm-6 col-md-6">
                                    <label>ReferidoPor</label>
                                </div>
                                <div class="col-xs-12 col-lg-6 col-sm-6 col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlReferidoPor" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12 col-lg-6 col-sm-6 col-md-6">
                                    <label>Aseguradora</label>
                                </div>
                                <div class="col-xs-12 col-lg-6 col-sm-6 col-md-6">
                                    <asp:DropDownList CssClass="form-control" ID="ddlAseguradora" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        jQuery('.datePicker').datetimepicker({
            timepicker: false,
            format: 'd-m-Y'
        });


        function ValidNum(e) {
            var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
            return ((tecla > 47 && tecla < 58) || tecla == 08 || tecla == 46);
        }

        var txttel = '<%=txtTelCaIdent.ClientID %>';
        var txtOfi = '<%=txtTelOfiIdent.ClientID %>';
        var txtcel = '<%=txtTelMovIndent.ClientID %>';

        $(function () {


            $("#" + txttel).keypress(function (e) {
                var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
                return ((tecla > 47 && tecla < 58) || tecla == 08 || tecla == 46);


            });

            $("#" + txtOfi).keypress(function (e) {
                var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
                return ((tecla > 47 && tecla < 58) || tecla == 08 || tecla == 46);
            });

            $("#" + txtcel).keypress(function (e) {
                var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
                return ((tecla > 47 && tecla < 58) || tecla == 08 || tecla == 46);
            });
        });

    </script>
    <style>
        .row {
            padding: 5px;
        }
        .file {
            width:100%;
        }
    </style>
</asp:Content>

