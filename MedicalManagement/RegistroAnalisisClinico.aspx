<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroAnalisisClinico.aspx.cs" Inherits="MedicalManagement.RegistroAnalisisClinico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table width="100%" border="0"><tr><td align="left"><font color="red">Configuración\AnalisisClinico\Agregar</font></td>
<td align="right">
    <asp:LinkButton runat="server" ID="Guardar" OnClick="btnGuardar_AnalisisClinico_Click" Text='<label class="pull-right label label-success label-button" style="font-size: 16px;" runat="server">Guardar <i class="fa fa-margin-left fa-save"></i></label>'/>
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
