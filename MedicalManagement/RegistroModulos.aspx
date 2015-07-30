<%@ Page Title="Agregar Modulos" Language="C#" MasterPageFile="Site.master"  AutoEventWireup="true" CodeBehind="RegistroModulos.aspx.cs" Inherits="prototipo.RegistroModulos" EnableEventValidation="false"%>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<table width="100%" border="0"><tr><td align="left"><font color="red">Configuración\Modulos\Agregar</font></td>
<td align="right">
<asp:ImageButton ID="ImageGrabar" runat="Server" ImageUrl="IMG/Grabar.png"  ToolTip = "Grabar Modulo" onclick="btnGuardar_Modulo_Click"></asp:ImageButton>&nbsp;
<asp:ImageButton ID="ImageRegresar" runat="Server" ImageUrl="IMG/Regresar.png"  ToolTip = "Regresar" onclick="btnRegresar_Modulo_Click"></asp:ImageButton>
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
                    <asp:Label ID="Label4" runat="server" Text="Identificador Modulo :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="Identificador_Modulo" runat="server" Columns="50"
                    ></asp:TextBox>
            </td>
        </tr>


        <tr>
            <td align="left">
                    <asp:Label ID="Label3" runat="server" Text="Nombre Modulo :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="Nombre_Modulo" runat="server" Columns="100"
                    ></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td align="left">
                    <asp:Label ID="Label1" runat="server" Text="Programa :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="Programa_Modulo" runat="server" Columns="100"
                    ></asp:TextBox>
            </td>
        </tr>


        <tr>
            <td align="left">
                    <asp:Label ID="Label2" runat="server" Text="Depende :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="Depende_Id_Modulo" runat="server" Columns="50"
                    ></asp:TextBox>
            </td>
        </tr>




    </table>
    </td></tr>

</asp:Content>