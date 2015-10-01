<%@ Page Title="Usuarios" Language="C#" MasterPageFile="Site.master"  AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="prototipo.Usuarios" EnableEventValidation="false"%>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h3>Usuarios</h3>
    <hr />
<table width="100%">
    <tr><td>

    <table width="100%">
        <tr>
            <td align="left"colspan="6">Usuario&nbsp;:&nbsp;<asp:TextBox ID="Buscar_Usuario" runat="server" Columns="100" OnTextChanged="txt_OnTextChanged"  AutoPostBack=true></asp:TextBox>&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar Usuario"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="AgregarUsuario" runat="Server" ImageUrl="IMG/agregar.png" OnClick="btnAgregarUsuario_Click" ToolTip = "Agregar Usuario"></asp:ImageButton>
        </tr>



        <tr>
            <td align="center"colspan="6">
 <asp:GridView ID="Grid_Usuarios" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_Usuarios_PageIndexChanging" AllowPaging ="False"
        onpageindexchanged="Grid_Usuarios_PageIndexChanged" CssClass="table table-hover table-responsive" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" >
    
        <Columns>

            <asp:BoundField DataField="Id_Usuario" HeaderText="No. Usuario" 
                SortExpression="Id_Usuario" />

            <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre" 
                SortExpression="NombreCompleto" />


            <asp:BoundField DataField="Descripcion_Perfil" HeaderText="Perfil" 
                SortExpression="Descripcion_Perfil" />


            <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Editar" 
                ShowHeader="True" Text="Editar"  ItemStyle-HorizontalAlign="Center" />

            <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Eliminar" 
                ShowHeader="True" Text="Eliminar" ItemStyle-HorizontalAlign="Center"
                />
            <asp:ButtonField ButtonType="Button" CommandName="Update" HeaderText="Empresas-Sucursales-Territorios" 
                ShowHeader="True" Text="Empresas-Sucursales-Territorios" ItemStyle-HorizontalAlign="Center"
                />
               
        </Columns>
    </asp:GridView>
            
            
            
            </td></tr>
    </table>
    </td></tr>
    </table>
</asp:Content>