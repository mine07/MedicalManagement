<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroAgenda.aspx.cs" Inherits="MedicalManagement.RegistroAgenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%" border="0">
        <tr>
            <td align="left"><font color="red">Configuración\Agenda\Agregar</font></td>
            <td align="right">
                <asp:ImageButton ID="ImageGrabar" runat="Server" ImageUrl="IMG/Grabar.png" ToolTip="Grabar EstadoCivil" OnClick="btnGuardar_FichaIdentificacion_Click"></asp:ImageButton>&nbsp;
        <asp:ImageButton ID="ImageRegresar" runat="Server" ImageUrl="IMG/Regresar.png" ToolTip="Regresar" OnClick="btnRegresar_FichaIdentificacion_Click"></asp:ImageButton>
            </td>
        </tr>

        <tr>
            <td colspan="2" align="center" runat="Server" id="Alerta"></td>
        </tr>
    </table>

    <table>
    </table>
    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                Id.FichaIdentificacion
            </div>
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                <asp:TextBox CssClass="form-control" ID="txtidfichaidentificacion" runat="server" BackColor="#CCFFCC"
                    ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                Nombre Completo
            </div>
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                <asp:TextBox CssClass="form-control" ID="txtnombrecompleto" runat="server" BackColor="#CCFFCC"
                    ReadOnly="True" Width="200px"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                Asunto:
            </div>
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                <asp:TextBox CssClass="form-control" ID="txtasunto" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                Categoria: 
            </div>
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                <asp:DropDownList ID="ddlCategoria" CssClass="form-control" runat="server">
                </asp:DropDownList>
            </div>
        </div>

        <div class="row">

            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                Prioridad
            </div>

            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">

                <asp:RadioButton ID="rbNormal" runat="server" Text="Normal" AutoPostBack="true"
                    OnCheckedChanged="rbNormal_CheckedChanged" />
            </div>
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                <asp:RadioButton ID="rbUrgente" runat="server" Text="Urgente" AutoPostBack="true"
                    OnCheckedChanged="rbUrgente_CheckedChanged" />
            </div>


        </div>


        <div class="row">
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                Dia de Alta en 
            Agenda
            </div>
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                <input id="txtaltaagenda" type="text" class="datePicker form-control" runat="server" />
            </div>

        </div>
        <div class="row">
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">Estado de Cita</div>
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                <asp:DropDownList ID="DropDownEstadoCitas" CssClass="form-control" runat="server">
                    <asp:ListItem>Por confirmar</asp:ListItem>
                    <asp:ListItem>Confirmado</asp:ListItem>
                    <asp:ListItem>Cancelado</asp:ListItem>
                </asp:DropDownList>
            </div>

        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                Comienzo
            </div>

            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                <input id="txtDiaComienzo" type="text" class="datePicker form-control" runat="server" />
                <div class="hidden">
                    <asp:DropDownList ID="DropDownDiaComienzo" runat="server">
                    </asp:DropDownList>

                    <asp:DropDownList ID="DropDownMesComienzo" runat="server">
                        <asp:ListItem>Enero</asp:ListItem>
                        <asp:ListItem>Febrero</asp:ListItem>
                        <asp:ListItem>Marzo</asp:ListItem>
                        <asp:ListItem>Abril</asp:ListItem>
                        <asp:ListItem>Mayo</asp:ListItem>
                        <asp:ListItem>Junio</asp:ListItem>
                        <asp:ListItem>Julio</asp:ListItem>
                        <asp:ListItem>Agosto</asp:ListItem>
                        <asp:ListItem>Septiembre</asp:ListItem>
                        <asp:ListItem>Octubre</asp:ListItem>
                        <asp:ListItem>Noviembre</asp:ListItem>
                        <asp:ListItem>Diciembre</asp:ListItem>
                    </asp:DropDownList>

                    <asp:DropDownList ID="DropDownAnioComienzo" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3 hidden">
                <asp:DropDownList ID="DropDownHoraComienzo" runat="server">
                </asp:DropDownList>

                <asp:DropDownList ID="DropDownMinutoComienzo" runat="server">
                </asp:DropDownList>

                <asp:DropDownList ID="DropDowndiatardeComienzo" runat="server">
                    <asp:ListItem>p.m.</asp:ListItem>
                    <asp:ListItem>a.m.</asp:ListItem>
                </asp:DropDownList>

            </div>
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3" width="300px"></div>
        </div>
        <div class="row">
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                Finalizacion:
            </div>

            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                <input id="txtDiaFinal" type="text" class="datePicker form-control" runat="server" />
                <div class="hidden">
                <asp:DropDownList ID="DropDownDiaFinal" runat="server">
                </asp:DropDownList>

                <asp:DropDownList ID="DropDownMesFinal" runat="server">
                    <asp:ListItem>Enero</asp:ListItem>
                    <asp:ListItem>Febrero</asp:ListItem>
                    <asp:ListItem>Marzo</asp:ListItem>
                    <asp:ListItem>Abril</asp:ListItem>
                    <asp:ListItem>Mayo</asp:ListItem>
                    <asp:ListItem>Junio</asp:ListItem>
                    <asp:ListItem>Julio</asp:ListItem>
                    <asp:ListItem>Agosto</asp:ListItem>
                    <asp:ListItem>Septiembre</asp:ListItem>
                    <asp:ListItem>Octubre</asp:ListItem>
                    <asp:ListItem>Noviembre</asp:ListItem>
                    <asp:ListItem>Diciembre</asp:ListItem>
                </asp:DropDownList>

                <asp:DropDownList ID="DropDownAnioFinal" runat="server">
                </asp:DropDownList>
                    </div>
            </div>
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3 hidden">
                <asp:DropDownList ID="DropDownHoraFinal" runat="server">
                </asp:DropDownList>

                <asp:DropDownList ID="DropDownMinutoFinal" runat="server">
                </asp:DropDownList>

                <asp:DropDownList ID="DropDowndiatardeFinal" runat="server">
                    <asp:ListItem>p.m.</asp:ListItem>
                    <asp:ListItem>a.m.</asp:ListItem>
                </asp:DropDownList>

            </div>
        </div>
        <div class="row">
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                Descripcion
            </div>
            <div class="col-xs-12 col-sm-5 col-md-5 col-lg-5">
                <asp:TextBox CssClass="form-control" ID="txtdescripcionagenda" runat="server" Width="100%" TextMode="multiline"></asp:TextBox>
            </div>
        </div>
    </div>
    <style>
        .row {
            padding: 5px;
        }

        textarea {
            -moz-resize: none;
            -ms-resize: none;
            -o-resize: none;
            resize: none;
        }
    </style>
    <script type="text/javascript">
        jQuery('.datePicker').datetimepicker({
            format: 'd/m/Y H:i'
        });
    </script>
</asp:Content>
