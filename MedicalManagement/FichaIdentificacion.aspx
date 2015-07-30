<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FichaIdentificacion.aspx.cs" Inherits="MedicalManagement.FichaIdentificacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<table width="100%">
        <tr>
            <td align="left"colspan="6">FichaIdentificacion&nbsp;:&nbsp;<asp:TextBox ID="txtBuscar_FichaIdentificacion" runat="server" Columns="100" OnTextChanged="txt_OnTextChanged"  AutoPostBack=true></asp:TextBox>&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar Perfil"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="AgregarFichaIdentiificacion" runat="Server" ImageUrl="IMG/agregar.png" OnClick="btnAgregarFichaIdentificacion_Click" ToolTip = "Agregar Ficha Identificacion"></asp:ImageButton>
            </td>
        </tr>


        <tr>
            <td align="center"colspan="6">
 <asp:GridView ID="Grid_FichaIdentificacion" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_FichaIdentificacion_PageIndexChanging" AllowPaging ="False"
        onpageindexchanged="Grid_FichaIdentificacion_PageIndexChanged" CssClass="mGrid" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" >
                    
    
        <Columns>

            <asp:BoundField DataField="Id_FichaIdentificacion" HeaderText="Id.FichaIdentificacion" 
                SortExpression="Id_FichaIdentificacion" />


            <asp:BoundField DataField="NombreCompleto" HeaderText="NombreCompleto" 
                SortExpression="NombreCompleto" />
    
            

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
