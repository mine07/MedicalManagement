﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroOcupacion.aspx.cs" Inherits="MedicalManagement.RegistroOcupacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



<table width="100%" border="0"><tr><td align="left"><font color="red">Configuración\Ocupacion\Agregar</font></td>
<td align="right">
<asp:ImageButton ID="ImageGrabar" runat="Server" ImageUrl="IMG/Grabar.png"  ToolTip = "Grabar Ocupacion" onclick="btnGuardar_Ocupacion_Click"></asp:ImageButton>&nbsp;
<asp:ImageButton ID="ImageRegresar" runat="Server" ImageUrl="IMG/Regresar.png"  ToolTip = "Regresar" onclick="btnRegresar_Ocupacion_Click"></asp:ImageButton>
</td>
</tr>
<tr>
    <td colspan="2" align ="center" runat="Server" id="Alerta">
    </td>
</tr>
</table>
<table width="100%" border="1">
    <tr><td>

    <table width="100%">
        <tr>
            <td align="left">
                    <asp:Label ID="Label3" runat="server" Text="Descripción de Ocupacion :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="Descripcion_Ocupacion" runat="server" Columns="100"
                    ></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td align="left">
                    <asp:Label ID="Label1" runat="server" Text="Nombre corto Ocupacion:"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="txtNombreCorto_Ocupacion" runat="server" Columns="20"
                    ></asp:TextBox>
            </td>
        </tr>




    </table>
    </td></tr>

</asp:Content>
