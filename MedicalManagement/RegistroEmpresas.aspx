<%@ Page Title="Agregar Empresas" Language="C#" MasterPageFile="Site.master"  AutoEventWireup="true" CodeBehind="RegistroEmpresas.aspx.cs" Inherits="prototipo.RegistroEmpresas" EnableEventValidation="false"%>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<table width="100%" border="0"><tr><td align="left"><font color="red">Configuración\Empresas\Agregar</font></td>
<td align="right">
<asp:ImageButton ID="ImageGrabar" runat="Server" ImageUrl="IMG/Grabar.png"  ToolTip = "Grabar Empresa" onclick="btnGuardar_Empresa_Click"></asp:ImageButton>&nbsp;
<asp:ImageButton ID="ImageRegresar" runat="Server" ImageUrl="IMG/Regresar.png"  ToolTip = "Regresar" onclick="btnRegresar_Empresa_Click"></asp:ImageButton>
</td>
</tr>
<tr>
    <td colspan="2" align ="center" runat="Server" id="Alerta">
    </td>
</tr>
</table>


    <table width="100%" border="1">
        <tr>
            <td align="left">
                    <asp:Label ID="Label3" runat="server" Text="Nombre Comercial de Empresa :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="txtComercial_Nombre_Empresa" runat="server" Columns="100"
                    ></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td align="left" colspan="3" bgcolor="#FFBF00">
                    <asp:Label ID="Label4" runat="server" Text="Información Fiscal :"
                    ></asp:Label>
            </td>
        </tr>


        <tr>
            <td align="left">
                    <asp:Label ID="Label1" runat="server" Text="Nombre de Empresa :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="txtFiscal_Nombre_Empresa" runat="server" Columns="100"
                    ></asp:TextBox>
            </td>
        </tr>


        <tr>
            <td align="left">
                    <asp:Label ID="Label2" runat="server" Text="Calle :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="txtFiscal_Direccion_Calle_Empresa" runat="server" Columns="100"
                    ></asp:TextBox>
            </td>
        </tr>


        <tr>
            <td align="left">
                    <asp:Label ID="Label5" runat="server" Text="Número Localidad Interior :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="txtFiscal_Direccion_NoInt_Empresa" runat="server" Columns="20"
                    ></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td align="left">
                    <asp:Label ID="Label6" runat="server" Text="Número Localidad Exterior :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="txtFiscal_Direccion_NoExt_Empresa" runat="server" Columns="20"
                    ></asp:TextBox>
            </td>
        </tr>


        <tr>
            <td align="left">
                    <asp:Label ID="Label7" runat="server" Text="Colonia :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="txtFiscal_Direccion_Colonia_Empresa" runat="server" Columns="100"
                    ></asp:TextBox>
            </td>
        </tr>



        <tr>
            <td align="left">
                    <asp:Label ID="Label8" runat="server" Text="Ciudad :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="txtFiscal_Direccion_Ciudad_Empresa" runat="server" Columns="100"
                    ></asp:TextBox>
            </td>
        </tr>


        <tr>
            <td align="left">
                    <asp:Label ID="Label9" runat="server" Text="Municipio :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="txtFiscal_Direccion_Municipio_Empresa" runat="server" Columns="100"
                    ></asp:TextBox>
            </td>
        </tr>


        <tr>
            <td align="left">
                    <asp:Label ID="Label10" runat="server" Text="CP :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="txtFiscal_Direccion_CP_Empresa" runat="server" Columns="20"
                    ></asp:TextBox>
            </td>
        </tr>



        <tr>
            <td align="left">
                    <asp:Label ID="Label11" runat="server" Text="Estado :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="txtFiscal_Direccion_Estado_Empresa" runat="server" Columns="100"
                    ></asp:TextBox>
            </td>
        </tr>



        <tr>
            <td align="left">
                    <asp:Label ID="Label12" runat="server" Text="Pais :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="txtFiscal_Direccion_Pais_Empresa" runat="server" Columns="100"
                    ></asp:TextBox>
            </td>
        </tr>


        <tr>
            <td align="left">
                    <asp:Label ID="Label13" runat="server" Text="Regimen :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="txtFiscal_General_Regimen_Empresa" runat="server" Columns="100"
                    ></asp:TextBox>
            </td>
        </tr>


        <tr>
            <td align="left" colspan="3" bgcolor="#FFBF00">
                    <asp:Label ID="Label15" runat="server" Text="Información General :"
                    ></asp:Label>
            </td>
        </tr>


        <tr>
            <td align="left">
                    <asp:Label ID="Label14" runat="server" Text="URL :"
                    ></asp:Label>
            </td>
            <td align="left" colspan="2">
                    <asp:TextBox ID="txtGeneral_URL_Empresa" runat="server" Columns="100"
                    ></asp:TextBox>
            </td>
        </tr>
        </table>


    

</asp:Content>