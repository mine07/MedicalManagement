<%@ Page Title="Usuario - Empresa - Sucursal" Language="C#" MasterPageFile="Site.master"  AutoEventWireup="true" CodeBehind="RegistroUsuarioEmpresaSucursal.aspx.cs" Inherits="prototipo.RegistroUsuarioEmpresaSucursal" EnableEventValidation="false"%>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<table width="100%" border="0"><tr><td align="left"><font color="red">Configuración\Usuarios\Empresa Sucursal</font></td>
<td align="right">
<asp:ImageButton ID="ImageRegresar" runat="Server" ImageUrl="IMG/Regresar.png"  ToolTip = "Regresar" onclick="btnRegresar_UsuarioEmpresaSucursal_Click"></asp:ImageButton>
</td>
</tr>
</table>
<table width="100%" border="1">
    <tr><td>

    <table width="100%">


        <tr>
            <td align="left"colspan="6">Usuario&nbsp;:&nbsp;<asp:TextBox ID="NombreCompletoR" ReadOnly runat="server" Columns="100"></asp:TextBox></td>
        </tr>



        <tr>
            <td align="center"colspan="6">
        <asp:GridView ID="Grid_UsuariosEmpresaSucursal" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting" OnRowEditing="Grid_UsuariosEmpresaSucursal_RowEditing"        
        onpageindexchanging ="Grid_UsuariosEmpresaSucursal_PageIndexChanging" AllowPaging ="False"
        onpageindexchanged="Grid_UsuariosEmpresaSucursal_PageIndexChanged" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None">
    
        <Columns>

            <asp:BoundField DataField="Id_Empresa" HeaderText="No. Empresa" 
                SortExpression="Id_Empresa" />


            <asp:BoundField DataField="Id_Sucursal" HeaderText="No. Sucursal" 
                SortExpression="Id_Sucursal" /> 


            <asp:BoundField DataField="Id_Territorio" HeaderText="No. Territorio" 
                SortExpression="Id_Territorio" /> 


            <asp:BoundField DataField="Comercial_Nombre_Empresa" HeaderText="Empresa" 
                SortExpression="Comercial_Nombre_Empresa" />


            <asp:BoundField DataField="Comercial_Nombre_Sucursal" HeaderText="Sucursal" 
                SortExpression="Comercial_Nombre_Sucursal" />


            <asp:BoundField DataField="Nombre_Territorio" HeaderText="Territorio" 
                SortExpression="Nombre_Territorio" />

            <asp:CheckBoxField DataField="Activo" HeaderText="Activo" SortExpression="Activo" ItemStyle-HorizontalAlign="Center"
            />
             
            <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Permiso" 
                ShowHeader="True" Text="Activar" ItemStyle-HorizontalAlign="Center"/>

        </Columns>
    </asp:GridView>
            
            
            
            </td></tr>


    </table>
    </td></tr>

</asp:Content>