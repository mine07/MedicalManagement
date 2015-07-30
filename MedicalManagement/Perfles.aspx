<%@ Page Title="Perfiles" Language="C#" MasterPageFile="Site.master"  AutoEventWireup="true" CodeBehind="Perfles.aspx.cs" Inherits="prototipo.Perfiles" EnableEventValidation="false"%>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <font color="red">Configuración\Perfiles</font>

<table width="100%" border="1">
    <tr><td>

    <table width="100%">
        <tr>
            <td align="left"colspan="6">Perfil&nbsp;:&nbsp;<asp:TextBox ID="Buscar_Perfil" runat="server" Columns="100" OnTextChanged="txt_OnTextChanged"  AutoPostBack=true></asp:TextBox>&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar Perfil"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="AgregarPerfil" runat="Server" ImageUrl="IMG/agregar.png" OnClick="btnAgregarPerfil_Click" ToolTip = "Agregar Perfil"></asp:ImageButton>
        </tr>



        <tr>
            <td align="center"colspan="6">
 <asp:GridView ID="Grid_Perfiles" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_Perfiles_PageIndexChanging" AllowPaging ="False"
        onpageindexchanged="Grid_Perfiles_PageIndexChanged" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" >
    
        <Columns>

            <asp:BoundField DataField="Id_Perfil" HeaderText="No. Perfil" 
                SortExpression="Id_Perfil" />


            <asp:BoundField DataField="Descripcion_Perfil" HeaderText="Nombre de Perfil" 
                SortExpression="Descripcion_Perfil" />


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