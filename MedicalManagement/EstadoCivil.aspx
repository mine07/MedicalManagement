<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstadoCivil.aspx.cs" Inherits="MedicalManagement.EstadoCivil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table width="100%">
        <tr>
            <td align="left"colspan="6">Estado Civil&nbsp;:&nbsp;<asp:TextBox ID="txtBuscar_EstadoCivil" runat="server" Columns="100" OnTextChanged="txt_OnTextChanged"  AutoPostBack=true></asp:TextBox>&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar Perfil"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="AgregarEstadoCivil" runat="Server" ImageUrl="IMG/agregar.png" OnClick="btnAgregarEstadoCivil_Click" ToolTip = "Agregar Estado Civil"></asp:ImageButton>
            </td>
        </tr>


        <tr>
            <td align="center"colspan="6">
 <asp:GridView ID="Grid_EstadoCivil" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_Categoria_PageIndexChanging" AllowPaging ="False"
        onpageindexchanged="Grid_Categoria_PageIndexChanged" CssClass="mGrid footable" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" >
                    
    
        <Columns>

            <asp:BoundField DataField="Id_EdoCivil" HeaderText="Id.EdoCivil" 
                SortExpression="Id_Civil" />


            <asp:BoundField DataField="Descripcion_EdoCivil" HeaderText="Descripcion EdoCivil" 
                SortExpression="Descripcion_EdoCivil" />
    
            <asp:BoundField DataField="NombreCorto_EdoCivil" HeaderText="Nombre Corto EdoCivil" 
                SortExpression="NombreCorto_EdoCivil" />

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
