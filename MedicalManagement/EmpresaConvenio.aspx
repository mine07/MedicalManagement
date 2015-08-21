<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmpresaConvenio.aspx.cs" Inherits="MedicalManagement.EmpresaConvenio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<table width="100%">
        <tr>
            <td align="left"colspan="6">EmpresaConvenio&nbsp;:&nbsp;<asp:TextBox ID="txtBuscar_EmpresaConvenio" runat="server" Columns="100" OnTextChanged="txt_OnTextChanged"  AutoPostBack=true></asp:TextBox>&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar Perfil"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="AgregarEmpresaConvenio" runat="Server" ImageUrl="IMG/agregar.png" OnClick="btnAgregarEmpresaConvenio_Click" ToolTip = "Agregar Empresa Convenio"></asp:ImageButton>
            </td>
        </tr>


        <tr>
            <td align="center"colspan="6">
 <asp:GridView ID="Grid_EmpresaConvenio" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_Empresas_PageIndexChanging" AllowPaging ="False"
        onpageindexchanged="Grid_Empresas_PageIndexChanged" CssClass="mGrid footable" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" >
                    
    
        <Columns>

            <asp:BoundField DataField="Id_EmpresaConvenio" HeaderText="Id.EmpresaConvenio" 
                SortExpression="Id_EmpresaConvenio" />


            <asp:BoundField DataField="RazonSocial_EmpresaConvenio" HeaderText="Razon Social Empresa Convenio" 
                SortExpression="RazonSocial_EmpresaConvenio" />
    
            <asp:BoundField DataField="NombreCorto_EmpresaConvenio" HeaderText="Nombre Corto Empresa Convenio" 
                SortExpression="NombreCorto_EmpresaConvenio" />

            <asp:BoundField DataField="RFC_EmpresaConvenio" HeaderText="RFC Empresa Convenio" 
                SortExpression="RFC_EmpresaConvenio" />

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
