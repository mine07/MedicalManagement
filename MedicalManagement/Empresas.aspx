<%@ Page Title="Empresas" Language="C#" MasterPageFile="Site.master"  AutoEventWireup="true" CodeBehind="Empresas.aspx.cs" Inherits="MedicalManagement.Empresas" EnableEventValidation="false"%>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <font color="red">Configuración\Empresas</font>

<table width="100%" border="1">
    <tr><td>

    <table width="100%">
        <tr>
            <td align="right"colspan="6">Empresa&nbsp;:&nbsp;<asp:TextBox 
                    ID="txtBuscar_Empresa" runat="server" Columns="100" 
                    OnTextChanged="txt_OnTextChanged"  AutoPostBack=true></asp:TextBox>&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar Empresa"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="AgregarEmpresa" runat="Server" ImageUrl="IMG/agregar.png" OnClick="btnAgregarEmpresa_Click" ToolTip = "Agregar Empresa"></asp:ImageButton>
        </tr>



        <tr>
            <td align="center"colspan="6">
 <asp:GridView ID="Grid_Empresas" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_Empresas_PageIndexChanging" AllowPaging ="False"
        onpageindexchanged="Grid_Empresas_PageIndexChanged" CssClass="mGrid" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" 
                    >
    
        <Columns>

            <asp:BoundField DataField="Id_Empresa" HeaderText="No. Empresa" 
                SortExpression="Id_Empresa" />


            <asp:BoundField DataField="Comercial_Nombre_Empresa" HeaderText="Nombre de Empresa" 
                SortExpression="Comercial_Nombre_Empresa" />


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

</asp:Content>