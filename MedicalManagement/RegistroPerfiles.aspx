<%@ Page Title="Agregar Perfiles" Language="C#" MasterPageFile="Site.master"  AutoEventWireup="true" CodeBehind="RegistroPerfiles.aspx.cs" Inherits="prototipo.RegistroPerfiles" EnableEventValidation="false"%>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<table width="100%" border="0"><tr><td align="left"><font color="red">Configuración\Perfiles\Agregar</font></td>
<td align="right">
    <asp:LinkButton runat="server" ID="Guardar" OnClick="btnGuardar_Perfil_Click" Text='<label class="pull-right label label-success label-button" style="font-size: 16px;" runat="server">Guardar <i class="fa fa-margin-left fa-save"></i></label>'/>
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