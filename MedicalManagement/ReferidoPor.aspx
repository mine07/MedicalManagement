<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReferidoPor.aspx.cs" Inherits="MedicalManagement.ReferidoPor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <table width="100%">
        <tr>
            <td align="left"colspan="6">Referido Por&nbsp;:&nbsp;<asp:TextBox ID="txtBuscar_ReferidoPor" runat="server" Columns="100" OnTextChanged="txt_OnTextChanged"  AutoPostBack=true></asp:TextBox>&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar Referido Por"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="AgregarReferidoPor" runat="Server" ImageUrl="IMG/agregar.png" OnClick="btnAgregarReferidoPor_Click" ToolTip = "Agregar Referido Por"></asp:ImageButton>
            </td>
        </tr>


        <tr>
            <td align="center"colspan="6">
 <asp:GridView ID="Grid_ReferidoPor" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_Empresas_PageIndexChanging" AllowPaging ="False"
        onpageindexchanged="Grid_Empresas_PageIndexChanged" CssClass="mGrid" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" >
                    
    
        <Columns>

            <asp:BoundField DataField="Id_ReferidoPor" HeaderText="Id.ReferidoPor" 
                SortExpression="Id_ReferidoPor" />


            <asp:BoundField DataField="Descripcion_ReferidoPor" HeaderText="Descripcion ReferidoPor" 
                SortExpression="Descripcion_ReferidoPor" />
    
            <asp:BoundField DataField="NombreCorto_ReferidoPor" HeaderText="Nombre Referido Por" 
                SortExpression="NombreCorto_Referido Por" />

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
