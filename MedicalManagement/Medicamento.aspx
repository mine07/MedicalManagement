<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicamento.aspx.cs" Inherits="MedicalManagement.Medicamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table width="100%">
        <tr>
            <td align="left"colspan="6">Medicamento&nbsp;:&nbsp;<asp:TextBox ID="txtBuscar_Medicamento" runat="server" Columns="100" OnTextChanged="txt_OnTextChanged"  AutoPostBack=true></asp:TextBox>&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar Perfil"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="AgregarMedicamento" runat="Server" ImageUrl="IMG/agregar.png" OnClick="btnAgregarMedicamento_Click" ToolTip = "Agregar Medicamento"></asp:ImageButton>
            </td>
        </tr>


        <tr>
            <td align="center"colspan="6">
 <asp:GridView ID="Grid_Medicamento" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_Medicamento_PageIndexChanging" AllowPaging="true" pagesize="15"
        onpageindexchanged="Grid_Medicamento_PageIndexChanged" CssClass="mGrid footable" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" >
                    
    
        <Columns>

            <asp:BoundField DataField="Id_Medicamento" HeaderText="Id.Medicamento" 
                SortExpression="Id_Medicamento" />


            <asp:BoundField DataField="Descripcion_Medicamento" HeaderText="Descripcion Medicamento" 
                SortExpression="Descripcion_Medicamento" />    
            

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
