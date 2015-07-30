<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Aseguradora.aspx.cs" Inherits="MedicalManagement.Aseguradora" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table width="100%">
        <tr>
            <td align="left"colspan="6">Aseguradora&nbsp;:&nbsp;<asp:TextBox ID="txtBuscar_Aseguradora" runat="server" Columns="100" OnTextChanged="txt_OnTextChanged"  AutoPostBack=true></asp:TextBox>&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar Perfil"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="AgregarAseguradora" runat="Server" ImageUrl="IMG/agregar.png" OnClick="btnAgregarAseguradora_Click" ToolTip = "Agregar Aseguradora"></asp:ImageButton>
            </td>
        </tr>


        <tr>
            <td align="center"colspan="6">
 <asp:GridView ID="Grid_Aseguradora" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_Empresas_PageIndexChanging" AllowPaging ="False"
        onpageindexchanged="Grid_Empresas_PageIndexChanged" CssClass="mGrid" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" >
                    
    
        <Columns>

            <asp:BoundField DataField="Id_Aseguradora" HeaderText="Id.Aseguradora" 
                SortExpression="Id_Aseguradora" />


            <asp:BoundField DataField="RazonSocial_Aseguradora" HeaderText="Razon Social Aseguradora" 
                SortExpression="RazonSocial_Aseguradora" />
    
            <asp:BoundField DataField="NombreCorto_Aseguradora" HeaderText="Nombre Corto Aseguradora" 
                SortExpression="NombreCorto_Aseguradora" />

            <asp:BoundField DataField="RFC_Aseguradora" HeaderText="RFC Aseguradora" 
                SortExpression="RFC_Aseguradora" />

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
