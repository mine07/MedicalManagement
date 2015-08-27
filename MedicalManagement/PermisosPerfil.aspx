<%@ Page Title="PermisosPerfil" Language="C#" MasterPageFile="Site.master"  AutoEventWireup="true" CodeBehind="PermisosPerfil.aspx.cs" Inherits="prototipo.PermisosPerfil" EnableEventValidation="false"%>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<font color="red">Configuración\Permisos</font>

<table width="100%" >
    <tr><td>
    </td></tr>
    </table>

    <table width="100%">
        <tr>
            <td align="left"colspan="6">Perfil&nbsp;:&nbsp;            
            <asp:DropDownList ID="ddl_Id_Perfil" runat="server"                        
            onselectedindexchanged="cmbPerfil_SelectedIndexChanged" AutoPostBack=true>
        </asp:DropDownList>            
            </td>
        </tr>

        <tr>
            <td align="center"colspan="6">
 <asp:GridView ID="Grid_Permisos" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="cmbPerfil_SelectedIndexChanged" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_Permisos_PageIndexChanging"
        onpageindexchanged="Grid_Permisos_PageIndexChanged" CssClass="mGrid" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" >
    
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
    
        <Columns>

            <asp:BoundField DataField="Id_Modulo" HeaderText="No. Modulo" 
                SortExpression="Id_Empresa" />

            <asp:BoundField DataField="Nombre_Modulo" HeaderText="Modulo" 
                SortExpression="Nombre_Modulo" />
                
                <asp:BoundField DataField="Estatus_Permiso" HeaderText="Estatus_Permiso" 
                SortExpression="Estatus_Permiso" />
                           

            <asp:TemplateField  HeaderText="Elegir">
                <HeaderTemplate>
                    Elegir
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox  ID="CheckBoxelegir" runat="server"   />
                </ItemTemplate>
            </asp:TemplateField>
                
                
            

            

        </Columns>


    </asp:GridView>

    <asp:Button ID="btnelegir" runat="server" Text="Enviar" onclick="btnelegir_Click" />

            </td></tr>
    </table>
    

</asp:Content>