<%@ Page Title="Sucursales" Language="C#" MasterPageFile="Site.master"  AutoEventWireup="true" CodeBehind="Sucursales.aspx.cs" Inherits="prototipo.Sucursales" EnableEventValidation="false"%>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h3>Sucursales</h3>
    <hr />
<table width="100%">
    <tr><td>

    <table width="100%">
        <tr>
            <td align="left"colspan="6">Empresa&nbsp;:&nbsp;            
            <asp:DropDownList ID="Id_Empresa" runat="server"                        
            onselectedindexchanged="cmbEmpresa_SelectedIndexChanged" AutoPostBack=true>
        </asp:DropDownList>            
            </td>
        </tr>
        <tr>
            <td align="left"colspan="6">Sucursal&nbsp;:&nbsp;<asp:TextBox ID="Buscar_Sucursal" runat="server" Columns="100" OnTextChanged="txt_OnTextChanged"  AutoPostBack=true></asp:TextBox>&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar Sucursal"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="AgregarSucursal" runat="Server" ImageUrl="IMG/agregar.png" OnClick="btnAgregarSucursal_Click" ToolTip = "Agregar Sucursal"></asp:ImageButton>
        </tr>



        <tr>
            <td align="center"colspan="6">
 <asp:GridView ID="Grid_Sucursales" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_Sucursales_PageIndexChanging" AllowPaging ="False"
        onpageindexchanged="Grid_Sucursales_PageIndexChanged" CssClass="table table-hover table-responsive" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" >
    
        <Columns>

            <asp:BoundField DataField="Id_Empresa" HeaderText="No. Empresa" 
                SortExpression="Id_Empresa" />

            <asp:BoundField DataField="Id_Sucursal" HeaderText="No. Sucursal" 
                SortExpression="Id_Sucursal" />


            <asp:BoundField DataField="Comercial_Nombre_Sucursal" HeaderText="Nombre de Sucursal" 
                SortExpression="Comercial_Nombre_Sucursal" />


            <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Editar" 
                ShowHeader="True" Text="Editar" ItemStyle-HorizontalAlign="Center"/>
            <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Eliminar" 
                ShowHeader="True" Text="Eliminar" ItemStyle-HorizontalAlign="Center"
                />
        </Columns>
    </asp:GridView>
            
            
            
            </td></tr>
    </table>
    </td></tr>
    </table>
</asp:Content>