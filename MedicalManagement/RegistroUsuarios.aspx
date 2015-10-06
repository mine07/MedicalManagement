<%@ Page Title="Agregar Usuarios" Language="C#" MasterPageFile="Site.master"  AutoEventWireup="true" CodeBehind="RegistroUsuarios.aspx.cs" Inherits="prototipo.RegistroUsuarios" EnableEventValidation="false"%>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<table width="100%" border="0"><tr><td align="left"><font color="red">Configuración\Usuarios\Agregar</font></td>
    <td align="right">
        <asp:LinkButton runat="server" ID="Guardar" OnClick="btnGuardar_Usuario_Click" Text='<label class="pull-right label label-success label-button" style="font-size: 16px;" runat="server">Guardar <i class="fa fa-margin-left fa-save"></i></label>'/>
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
<table width="100%" border="1">
    <tr><td>

    <table width="100%">


        <tr>
            <td align="left" colspan="3" bgcolor="#FFBF00">
                    <asp:Label ID="Label4" runat="server" Text="Información Personal :"
                    ></asp:Label>
            </td>
        </tr>

        <tr>
            <td align="left">
                    <asp:Label ID="Label3" runat="server" Text="Nombre Usuario :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="Nombre_Usuario" runat="server" Columns="50"
                    ></asp:TextBox>
            </td>
        </tr>



        <tr>
            <td align="left">
                    <asp:Label ID="Label2" runat="server" Text="Apellido Paterno:"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="Apellido_Paterno_Usuario" runat="server" Columns="50"
                    ></asp:TextBox>
            </td>
        </tr>


        <tr>
            <td align="left">
                    <asp:Label ID="Label5" runat="server" Text="Apellido Materno :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="Apellido_Materno_Usuario" runat="server" Columns="50"
                    ></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td align="left">
                    <asp:Label ID="Label6" runat="server" Text="Cuenta de Usuario :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="Cuenta_Usuario" runat="server" Columns="30"
                    ></asp:TextBox>
            </td>
        </tr>


        <tr>
            <td align="left">
                    <asp:Label ID="Label7" runat="server" Text="Contraseña :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="PWD_Usuario" runat="server" Columns="30"  TextMode="password"
                    ></asp:TextBox>
            </td>
        </tr>



        <tr>
            <td align="left">
                    <asp:Label ID="Label8" runat="server" Text="Correo Electrónico :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
                    <asp:TextBox ID="Correo_Usuario" runat="server" Columns="70"
                    ></asp:TextBox>
            </td>
        </tr>




        <tr>
            <td align="left">
                    <asp:Label ID="Label15" runat="server" Text="Perfil :"
                    ></asp:Label>
            </td>
            <td aling="left" colspan="2">
    <asp:DropDownList ID="Id_Perfil" runat="server">
        </asp:DropDownList>            
            </td>
        </tr>



    </table>
    </td></tr>

</asp:Content>