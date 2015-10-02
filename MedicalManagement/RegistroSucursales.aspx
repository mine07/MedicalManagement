<%@ Page Title="Agregar Sucursales" Language="C#" MasterPageFile="Site.master"  AutoEventWireup="true" CodeBehind="RegistroSucursales.aspx.cs" Inherits="prototipo.RegistroSucursales" EnableEventValidation="false"%>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<table width="100%" border="0"><tr><td align="left"><font color="red">Configuración\Sucursales\Agregar</font></td>
<td align="right">
<!--<asp:ImageButton ID="ImageGrabar" runat="Server" ImageUrl="IMG/Grabar.png"  ToolTip = "Grabar Sucursal" onclick="btnGuardar_Sucursal_Click"></asp:ImageButton>&nbsp;
<asp:ImageButton ID="ImageRegresar" runat="Server" ImageUrl="IMG/Regresar.png"  ToolTip = "Regresar" onclick="btnRegresar_Sucursal_Click"></asp:ImageButton>-->

    <asp:LinkButton runat="server" ID="Guardar" OnClick="btnGuardar_Sucursal_Click" Text='<label class="pull-right label label-success label-button" style="font-size: 16px;" runat="server">Guardar <i class="fa fa-margin-left fa-save"></i></label>'/>
    <a href='<%= "javascript:history.back(-1);" %>'><label class="pull-right label label-primary label-button" style="font-size: 16px;">Volver<i class="fa fa-arrow-left fa-margin-left"></i></label></a><br><br>

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
                    <asp:Label ID="Label3" runat="server" Text="Nombre Comercial de Sucursal :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="Comercial_Nombre_Sucursal" runat="server" Columns="100"
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
                    <asp:Label ID="Label2" runat="server" Text="Calle :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="Fiscal_Direccion_Calle_Sucursal" runat="server" Columns="100"
                    ></asp:TextBox>
            </td>
        </tr>


        <tr>
            <td align="left">
                    <asp:Label ID="Label5" runat="server" Text="Número Localidad Interior :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="Fiscal_Direccion_NoInt_Sucursal" runat="server" Columns="20"
                    ></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td align="left">
                    <asp:Label ID="Label6" runat="server" Text="Número Localidad Exterior :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="Fiscal_Direccion_NoExt_Sucursal" runat="server" Columns="20"
                    ></asp:TextBox>
            </td>
        </tr>


        <tr>
            <td align="left">
                    <asp:Label ID="Label7" runat="server" Text="Colonia :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="Fiscal_Direccion_Colonia_Sucursal" runat="server" Columns="100"
                    ></asp:TextBox>
            </td>
        </tr>



        <tr>
            <td align="left">
                    <asp:Label ID="Label8" runat="server" Text="Ciudad :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="Fiscal_Direccion_Ciudad_Sucursal" runat="server" Columns="100"
                    ></asp:TextBox>
            </td>
        </tr>


        <tr>
            <td align="left">
                    <asp:Label ID="Label9" runat="server" Text="Municipio :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="Fiscal_Direccion_Municipio_Sucursal" runat="server" Columns="100"
                    ></asp:TextBox>
            </td>
        </tr>


        <tr>
            <td align="left">
                    <asp:Label ID="Label10" runat="server" Text="CP :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="Fiscal_Direccion_CP_Sucursal" runat="server" Columns="20"
                    ></asp:TextBox>
            </td>
        </tr>



        <tr>
            <td align="left">
                    <asp:Label ID="Label11" runat="server" Text="Estado :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="Fiscal_Direccion_Estado_Sucursal" runat="server" Columns="100"
                    ></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td align="left">
                    <asp:Label ID="Label12" runat="server" Text="Pais :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="Fiscal_Direccion_Pais_Sucursal" runat="server" Columns="100"
                    ></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td align="left">
                    <asp:Label ID="Label1" runat="server" Text="Serie Factura :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="Fiscal_Facturas_Serie_Sucursal" runat="server" Columns="50"
                    ></asp:TextBox>
            </td>
        </tr>


        <tr>
            <td align="left">
                    <asp:Label ID="Label13" runat="server" Text="Serie Nota de Credito :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="Fiscal_NCredito_Serie_Sucursal" runat="server" Columns="50"
                    ></asp:TextBox>
            </td>
        </tr>


        <tr>
            <td align="left">
                    <asp:Label ID="Label14" runat="server" Text="Serie Nota de Cargo :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="Fiscal_NCargo_Serie_Sucursal" runat="server" Columns="50"
                    ></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td align="left" colspan="3" bgcolor="#FFBF00">
                    <asp:Label ID="Label16" runat="server" Text="Información General :"
                    ></asp:Label>
            </td>
        </tr>


        <tr>
            <td align="left">
                    <asp:Label ID="Label15" runat="server" Text="Empresa :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
    <asp:DropDownList ID="Id_Empresa" runat="server">
        </asp:DropDownList>            
            </td>
        </tr>



    </table>
    </td></tr>

</asp:Content>