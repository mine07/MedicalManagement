<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="MedicalManagement.AgregarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%" border="0">
        <tr>
            <td align="left"><font color="red">Configuración\Procedimiento\Agregar</font></td>
            <td align="right">
                <asp:LinkButton runat="server" ID="LinkButton1" OnClick="btnGuardar_Sexo_Click" Text='<label class="pull-right label label-success label-button" style="font-size: 16px;" runat="server">Guardar <i class="fa fa-margin-left fa-save"></i></label>' />
            </td>
            <td width="9%" align="left">
                <a href='<%= "javascript:history.back(-1);" %>'>
                    <label class="pull-right label label-primary label-button" style="font-size: 16px;">Volver<i class="fa fa-arrow-left fa-margin-left"></i></label></a>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" runat="Server" id="Td1"></td>
        </tr>
    </table>


<h3>Agregar Productos</h3>
    <hr />
    <br />

    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                Nombre :
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NombreProducto" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Campo Requerido</asp:RequiredFieldValidator>
            </div>
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                <asp:TextBox CssClass="form-control" ID="NombreProducto" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                Descripcion :
            <asp:RequiredFieldValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Descripcion" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Campo Requerido</asp:RequiredFieldValidator>
            </div>
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                <asp:TextBox CssClass="form-control" ID="Descripcion" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                Precio Compra :
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="PrecioCompra" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="([0-9]|.)*">Ingrese el Costo</asp:RegularExpressionValidator>
            </div>
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                <asp:TextBox CssClass="form-control" ID="PrecioCompra" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                Existencias :
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="Existencias" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="([0-9]|)*">Ingrese Valores Enteros</asp:RegularExpressionValidator>
            </div>
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                <asp:TextBox CssClass="form-control" ID="Existencias" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                Precio Venta :
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="PrecioVenta" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="([0-9]|.)*">Ingrese el Costo</asp:RegularExpressionValidator>
            </div>
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                <asp:TextBox CssClass="form-control" ID="PrecioVenta" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                Minimo :
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Minimo" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="([0-9]|)*">Ingrese Valores Enteros</asp:RegularExpressionValidator>
            </div>
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                <asp:TextBox CssClass="form-control" ID="Minimo" runat="server"></asp:TextBox>
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
</asp:Content>
