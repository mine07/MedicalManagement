<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnalisisClinico.aspx.cs" Inherits="MedicalManagement.AnalisisClinico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table width="100%">
        <tr>
            <td align="left"colspan="6">Analisis Clinico&nbsp;:&nbsp;<asp:TextBox ID="txtBuscar_AnalisisClinico" runat="server" Columns="100" OnTextChanged="txt_OnTextChanged"  AutoPostBack=true></asp:TextBox>&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar AnalisisClinico"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="AgregarSexo" runat="Server" ImageUrl="IMG/agregar.png" OnClick="btnAgregarSexo_Click" ToolTip = "Agregar AnalisisClinico"></asp:ImageButton>
            </td>
        </tr>


        <tr>
            <td align="center"colspan="6">
 <asp:GridView ID="Grid_AnalisisClinico" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_AnalisisClinico_PageIndexChanging" AllowPaging="true" pagesize="15"
        onpageindexchanged="Grid_AnalisisClinico_PageIndexChanged" CssClass="mGrid" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" >
                    
    
        <Columns>

            <asp:BoundField DataField="Id_AnalisisClinico" HeaderText="Id.AnalisisClinico" 
                SortExpression="Id_AnalisisClinico" />


            <asp:BoundField DataField="Descripcion_AnalisisClinico" HeaderText="Descripcion Analisis Clinico" 
                SortExpression="Descripcion_AnalisisClinico" />    
            

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
