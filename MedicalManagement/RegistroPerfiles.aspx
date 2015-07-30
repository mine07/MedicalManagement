<%@ Page Title="Agregar Perfiles" Language="C#" MasterPageFile="Site.master"  AutoEventWireup="true" CodeBehind="RegistroPerfiles.aspx.cs" Inherits="prototipo.RegistroPerfiles" EnableEventValidation="false"%>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<table width="100%" border="0"><tr><td align="left"><font color="red">Configuración\Perfiles\Agregar</font></td>
<td align="right">
<asp:ImageButton ID="ImageGrabar" runat="Server" ImageUrl="IMG/Grabar.png"  ToolTip = "Grabar Perfil" onclick="btnGuardar_Perfil_Click"></asp:ImageButton>&nbsp;
<asp:ImageButton ID="ImageRegresar" runat="Server" ImageUrl="IMG/Regresar.png"  ToolTip = "Regresar" onclick="btnRegresar_Perfil_Click"></asp:ImageButton>
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
                    <asp:Label ID="Label3" runat="server" Text="Descripción de Perfil :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="Descripcion_Perfil" runat="server" Columns="100"
                    ></asp:TextBox>
            </td>
        </tr>




    </table>
    </td></tr>

</asp:Content>