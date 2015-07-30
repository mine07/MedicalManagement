<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Escolaridad.aspx.cs" Inherits="MedicalManagement.Escolaridad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <table width="100%">
        <tr>
            <td align="left"colspan="6">Escolaridad&nbsp;:&nbsp;<asp:TextBox ID="txtBuscar_Escolaridad" runat="server" Columns="100" OnTextChanged="txt_OnTextChanged"  AutoPostBack=true></asp:TextBox>&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar Perfil"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="AgregarEscolaridad" runat="Server" ImageUrl="IMG/agregar.png" OnClick="btnAgregarEscolaridad_Click" ToolTip = "Agregar Escolaridad"></asp:ImageButton>
            </td>
        </tr>


        <tr>
            <td align="center"colspan="6">
 <asp:GridView ID="Grid_Escolaridad" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_Empresas_PageIndexChanging" AllowPaging ="False"
        onpageindexchanged="Grid_Empresas_PageIndexChanged" CssClass="mGrid" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" >
                    
    
        <Columns>

            <asp:BoundField DataField="Id_Escolaridad" HeaderText="Id.Escolaridad" 
                SortExpression="Id_Escolaridad" />


            <asp:BoundField DataField="Descripcion_Escolaridad" HeaderText="Descripcion Escolaridad" 
                SortExpression="Descripcion_Escolaridad" />
    
            <asp:BoundField DataField="NombreCorto_Escolaridad" HeaderText="Nombre Corto Escolaridad" 
                SortExpression="NombreCorto_Escolaridad" />

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
