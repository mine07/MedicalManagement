<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Procedimiento.aspx.cs" Inherits="MedicalManagement.Procedimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table width="100%">
        <tr>
            <td align="left"colspan="6">Procedimiento&nbsp;:&nbsp;<asp:TextBox ID="txtBuscar_Procedimiento" runat="server" Columns="100" OnTextChanged="txt_OnTextChanged"  AutoPostBack=true></asp:TextBox>&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar Perfil"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="AgregarProcedimiento" runat="Server" ImageUrl="IMG/agregar.png" OnClick="btnAgregarProcedimiento_Click" ToolTip = "Agregar Procedimiento"></asp:ImageButton>
            </td>
        </tr>


        <tr>
            <td align="center"colspan="6">
 <asp:GridView ID="Grid_Procedimiento" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_Procedimiento_PageIndexChanging" AllowPaging="true" pagesize="15"
        onpageindexchanged="Grid_Procedimiento_PageIndexChanged" CssClass="mGrid" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" >
                    
    
        <Columns>

            <asp:BoundField DataField="Id_Procedimiento" HeaderText="Id.Procedimiento" 
                SortExpression="Id_Procedimiento" />


            <asp:BoundField DataField="Descripcion_Procedimiento" HeaderText="Descripcion Procedimiento" 
                SortExpression="Descripcion_Procedimiento" />    
            

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
