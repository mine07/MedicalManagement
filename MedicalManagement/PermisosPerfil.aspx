<%@ Page Title="PermisosPerfil" Language="C#" MasterPageFile="Site.master"  AutoEventWireup="true" CodeBehind="PermisosPerfil.aspx.cs" Inherits="prototipo.PermisosPerfil" EnableEventValidation="false"%>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <font color="red">Configuración\Permisos</font>

<table width="100%" border="1">
    <tr><td>

    <table width="100%">
        <tr>
            <td align="left"colspan="6">Perfil&nbsp;:&nbsp;            
            <asp:DropDownList ID="Id_Perfil" runat="server"                        
            onselectedindexchanged="cmbPerfil_SelectedIndexChanged" AutoPostBack=true>
        </asp:DropDownList>            
            </td>
        </tr>

        <tr>
            <td align="center"colspan="6">
 <asp:GridView ID="Grid_Permisos" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_Permisos_PageIndexChanging" AllowPaging ="False"
        onpageindexchanged="Grid_Permisos_PageIndexChanged" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" >
    
        <Columns>

            <asp:BoundField DataField="Id_Modulo" HeaderText="No. Modulo" 
                SortExpression="Id_Empresa" />

            <asp:BoundField DataField="Nombre_Modulo" HeaderText="Modulo" 
                SortExpression="Nombre_Modulo" />

        </Columns>
    </asp:GridView>
            
            
            
            </td></tr>
    </table>
    </td></tr>

</asp:Content>