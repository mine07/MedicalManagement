<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TemplateImprimirReceta.aspx.cs" Inherits="MedicalManagement.TemplateImprimirReceta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts\imagen.js">

    <script type="text/javascript" src="Scripts/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="Scripts/imagen.js"></script>


    <table width="100%" border="0">
        <tr>
            <td align="left">
                <h3>Detalles de Usuario </h3>
            </td>
            <td align="right"></td>
            <td width="9%" align="left">
            </td>
        </tr>

        <tr>
            <td colspan="2" align="center" runat="Server" id="Alerta"></td>

        </tr>
    </table>
    <hr />

    <div class="container-fluid">

        <div class="row">
            <div class="col-xs-12 col-lg-6 col-sm-6 col-md-6">
                <div class="container-fluid">
                    <!--<div class="row">
                        <br/><br/><br/>
                        <div class="col-sm-6 col-xs-12 col-lg-6 col-md-6">
                            <label>Clave Identificacion </label>
                        </div>

                        <div class="col-sm-6 col-xs-12 col-lg-6 col-md-6">
                            <asp:TextBox CssClass="form-control" ID="txtClaveIdent" runat="server" Columns="10" ReadOnly="true"
                                BackColor="#CCFFCC"></asp:TextBox>
                        </div>

                    </div>-->
                    <br />
                    <br />
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
                            <label>Especialidad</label>
                        </div>
                        <div class="col-sm-6 col-xs-12 col-lg-6 col-md-6">
                            <asp:TextBox CssClass="form-control" ID="txtEspecialidad" runat="server" Columns="25"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6 col-xs-12 col-lg-6 col-md-6">
                            <label>Cédula Profesional</label>
                        </div>
                        <div class="col-sm-6 col-xs-12 col-lg-6 col-md-6">
                            <asp:TextBox CssClass="form-control" ID="txtCedula" runat="server" Columns="25"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6 col-xs-12 col-lg-6 col-md-6">
                            <label>Nombre de la clinica</label>
                        </div>
                        <div class="col-sm-6 col-xs-12 col-lg-6 col-md-6">
                            <asp:TextBox CssClass="form-control" ID="txtNclinica" runat="server" Columns="25"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xs-12 col-lg-6 col-sm-6 col-md-6">
                <div class="container-fluid">
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-xs-12 col-sm-6 col-lg-6 col-md-6">
                            <label>Logo 1</label>
                            <asp:Label ID="Alerta2" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="col-xs-12 col-sm-6 col-lg-6 col-md-6">
                            <asp:Image ID="Image1" runat="server" Width="80px" Height="90px" align="MIDDLE" CssClass="blah" />
                        </div>
                    </div>

                    <div class="row">

                        <div class="col-xs-12 col-sm-6 col-lg-6 col-md-6">
                            <label>Cargar Foto</label>
                        </div>
                        <div class="col-xs-12 col-sm-6 col-lg-6 col-md-6">
                            <asp:FileUpload CssClass="btn btn-default file" ID="FileUpload1" runat="server" onchange="readURL(this)" />
                        </div>
                    </div>

                    <div class="row">

                        <div class="col-xs-12 col-sm-6 col-lg-6 col-md-6">
                            <label>Teléfono 1</label>
                        </div>
                        <div class="col-xs-12 col-sm-6 col-lg-6 col-md-6">
                            <asp:TextBox CssClass="form-control" ID="txtTelCaIdent1" runat="server" Columns="25"></asp:TextBox>
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
                                <label>Noumero</label>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                <asp:TextBox CssClass="form-control" ID="txtNuIntIdent" runat="server" Columns="25"></asp:TextBox>
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
                </div>
            </div>
        </div>
    </div>

    <style>
        .row {
            padding: 5px;
        }

        .file {
            width: 100%;
        }
    </style>
</asp:Content>
