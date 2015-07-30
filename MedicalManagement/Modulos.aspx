<%@ Page Title="Modulos" Language="C#" MasterPageFile="Site.master"  AutoEventWireup="true" CodeBehind="Modulos.aspx.cs" Inherits="prototipo.Modulos" EnableEventValidation="false"%>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <font color="red">Configuración\Modulos</font>

<table width="100%" border="1">
    <tr><td>

    <table width="100%">
        <tr>
            <td align="right"colspan="6">Modulos&nbsp;:&nbsp;<asp:TextBox ID="Buscar_Modulos" runat="server" Columns="100" OnTextChanged="txt_OnTextChanged"  AutoPostBack=true></asp:TextBox>&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar Modulo"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="AgregarModulo" runat="Server" ImageUrl="IMG/agregar.png" OnClick="btnAgregarModulo_Click" ToolTip = "Agregar Modulo"></asp:ImageButton>
        </tr>



        <tr>
            <td align="center"colspan="6">
 <asp:GridView ID="Grid_Modulos" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_Modulos_PageIndexChanging" AllowPaging ="False"
        onpageindexchanged="Grid_Modulos_PageIndexChanged" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None">
    
        <Columns>

            <asp:BoundField DataField="Id_Modulo" HeaderText="No. Modulo" 
                SortExpression="Id_Modulo" />


            <asp:BoundField DataField="Identificador_Modulo" HeaderText="Identificador" 
                SortExpression="Identificador_Modulo" />


            <asp:BoundField DataField="Nombre_Modulo" HeaderText="Nombre de Modulo" 
                SortExpression="Nombre_Modulo" />


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