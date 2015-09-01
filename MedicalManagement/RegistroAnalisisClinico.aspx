<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroAnalisisClinico.aspx.cs" Inherits="MedicalManagement.RegistroAnalisisClinico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table width="100%" border="0"><tr><td align="left"><font color="red">Configuración\AnalisisClinico\Agregar</font></td>
<td align="right">
<asp:ImageButton ID="ImageGrabar" runat="Server" ImageUrl="IMG/Grabar.png"  ToolTip = "Grabar Sexo" onclick="btnGuardar_AnalisisClinico_Click"></asp:ImageButton>&nbsp;
<asp:ImageButton ID="ImageRegresar" runat="Server" ImageUrl="IMG/Regresar.png"  ToolTip = "Regresar" onclick="btnRegresar_AnalisisClinico_Click"></asp:ImageButton>
</td>
</tr>
<tr>
    <td colspan="2" align ="center" runat="Server" id="Alerta">
    </td>
</tr>
</table>

 

    <table width="100%">
        <tr>
            <td align="left">
                    <asp:Label ID="Label3" runat="server" Text="Descripción de Analisis Clinico :"
                    ></asp:Label>
            </td>
            <td align="left" colspan="2">
                    <asp:TextBox ID="Descripcion_AnalisisClinico" runat="server" Columns="100"
                    ></asp:TextBox>
            </td>
        </tr>
        
    </table>
    

</asp:Content>
