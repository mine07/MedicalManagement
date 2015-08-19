<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ocupacion.aspx.cs" Inherits="MedicalManagement.Ocupacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<table width="100%">
        <tr>
            <td align="left"colspan="6">Ocupacion&nbsp;:&nbsp;<asp:TextBox ID="txtBuscar_Ocupacion" runat="server" Columns="100" OnTextChanged="txt_OnTextChanged"  AutoPostBack=true></asp:TextBox>&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar Ocupacion"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="AgregarOcupacion" runat="Server" ImageUrl="IMG/agregar.png" OnClick="btnAgregarOcupacion_Click" ToolTip = "Agregar Ocupacion"></asp:ImageButton>
            </td>
        </tr>


        <tr>
            <td align="center"colspan="6">
 <asp:GridView ID="Grid_Ocupacion" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_Empresas_PageIndexChanging" AllowPaging ="False"
        onpageindexchanged="Grid_Empresas_PageIndexChanged" CssClass="mGrid footable" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" >
                    
    
        <Columns>

            <asp:BoundField DataField="Id_Ocupacion" HeaderText="Id.Ocupacion" 
                SortExpression="Id_Ocupacion" />


            <asp:BoundField DataField="Descripcion_Ocupacion" HeaderText="Descripcion Ocupacion" 
                SortExpression="Descripcion_Sexo" />
    
            <asp:BoundField DataField="NombreCorto_Ocupacion" HeaderText="Nombre Corto Ocupacion" 
                SortExpression="NombreCorto_Ocupacion" />

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
