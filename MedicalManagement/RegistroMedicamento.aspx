<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroMedicamento.aspx.cs" Inherits="MedicalManagement.RegistroMedicamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<table width="100%" border="0"><tr><td align="left"></td>
<td align="right">
    <asp:LinkButton runat="server" ID="Guardar" OnClick="btnGuardar_Medicamento_Click" Text='<label class="pull-right label label-success label-button" style="font-size: 16px;" runat="server">Guardar <i class="fa fa-margin-left fa-save"></i></label>'/>
</td>
    <td width="9%" align="left">
            <a href='<%= "javascript:history.back(-1);" %>'><label class="pull-right label label-primary label-button" style="font-size: 16px;">Volver<i class="fa fa-arrow-left fa-margin-left"></i></label></a>
    </td>
</tr>
<tr>
    <td colspan="2" align ="center" runat="Server" id="Alerta">
    </td>
</tr>
</table>


    <h3>Agregra Medicamento</h3>
    <hr />
    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                Descripción de Medicamento:
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Descripcion_Medicamento" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Campo Requerido</asp:RequiredFieldValidator>
            </div>
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                <asp:TextBox CssClass="form-control" ID="Descripcion_Medicamento" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                Existencia:
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Existencia" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="([0-9]|)*">Ingrese Valores Enteros</asp:RegularExpressionValidator>
            </div>
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                <asp:TextBox CssClass="form-control" ID="Existencia" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                Precio Costo:
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="PrecioCosto" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="([0-9]|.)*">Ingrese el Costo</asp:RegularExpressionValidator>
            </div>
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                <asp:TextBox CssClass="form-control" ID="PrecioCosto" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                Precio Venta:
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="PrecioVenta" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="([0-9]|.)*">Ingrese el Costo</asp:RegularExpressionValidator>
            </div>
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                <asp:TextBox CssClass="form-control" ID="PrecioVenta" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                Minimo:
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="Minimo" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="([0-9]|)*">Ingrese Valores Enteros</asp:RegularExpressionValidator>
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
