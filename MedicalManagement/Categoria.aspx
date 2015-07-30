<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categoria.aspx.cs" Inherits="MedicalManagement.Categoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<table width="100%">
        <tr>
            <td align="left"colspan="6">Categoria&nbsp;:&nbsp;<asp:TextBox ID="txtBuscar_Categoria" runat="server" Columns="100" OnTextChanged="txt_OnTextChanged"  AutoPostBack=true></asp:TextBox>&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar Categoria"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="AgregarCategoria" runat="Server" ImageUrl="IMG/agregar.png" OnClick="btnAgregarCategoria_Click" ToolTip = "Agregar Categoria"></asp:ImageButton>
            </td>
        </tr>


        <tr>
            <td align="center"colspan="6">
 <asp:GridView ID="Grid_Categoria" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_Categoria_PageIndexChanging" AllowPaging ="False"
        onpageindexchanged="Grid_Categoria_PageIndexChanged" CssClass="mGrid" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" >
                    
    
        <Columns>

            <asp:BoundField DataField="Id_Categoria" HeaderText="Id.Categoria" 
                SortExpression="Id_Categoria" />


            <asp:BoundField DataField="Descripcion_Categoria" HeaderText="Descripcion Categoria" 
                SortExpression="Descripcion_Categoria" />
    
            <asp:BoundField DataField="NombreCorto_Categoria" HeaderText="Nombre Categoria" 
                SortExpression="NombreCorto_Categoria" />

            <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Editar" 
                ShowHeader="True" Text="Editar" ItemStyle-HorizontalAlign="Center"/>

            <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Eliminar" 
                ShowHeader="True" Text="Eliminar" ItemStyle-HorizontalAlign="Center"
                />
        </Columns>
    </asp:GridView>
            
            
            
            </td></tr>
    </table>

</asp:Content>
