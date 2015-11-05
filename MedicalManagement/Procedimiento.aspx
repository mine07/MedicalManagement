<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Procedimiento.aspx.cs" Inherits="MedicalManagement.Procedimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table width="100%">
        <tr>
            <td align="left"colspan="6">Procedimiento&nbsp;:&nbsp;<asp:TextBox ID="txtBuscar_Procedimiento" runat="server" Columns="100" OnTextChanged="txt_OnTextChanged"  AutoPostBack=true></asp:TextBox>&nbsp;
            
                <!--<asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar Perfil"></asp:ImageButton>&nbsp;
                <asp:ImageButton ID="AgregarProcedimiento" runat="Server" ImageUrl="IMG/agregar.png" OnClick="btnAgregarProcedimiento_Click" ToolTip = "Agregar Procedimiento"></asp:ImageButton>-->
                <asp:LinkButton runat="server" OnClick="btnAgregarProcedimiento_Click" Text='<label class="fa-margin-right label pull-right label label-primary"><i class="fa fa-margin-left fa-plus-circle"></i></label>' BackColor="#3333FF"></asp:LinkButton>
               <asp:LinkButton runat="server" OnClick="txt_OnTextChanged" Text='<label class="fa-margin-right label pull-right label-success label-button"><i class="fa fa-margin-left fa-search"></i></label>'></asp:LinkButton>                                                                                          
            </td>
        </tr>

        <tr>
            <td align="center"colspan="6">
 <asp:GridView ID="Grid_Procedimiento" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_Procedimiento_PageIndexChanging" AllowPaging="True" pagesize="15"
        onpageindexchanged="Grid_Procedimiento_PageIndexChanged" CssClass="mGrid" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" CellPadding="4" ForeColor="#333333" >
                    
   

<AlternatingRowStyle CssClass="alt" BackColor="White"></AlternatingRowStyle>
                    
    
        <Columns>

            <asp:BoundField DataField="Id_Procedimiento" HeaderText="Id.Procedimiento" 
                SortExpression="Id_Procedimiento" />


            <asp:BoundField DataField="Descripcion_Procedimiento" HeaderText="Descripcion Procedimiento" 
                SortExpression="Descripcion_Procedimiento" />    
            

            <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Editar" 
                ShowHeader="True" Text="Editar" ItemStyle-HorizontalAlign="Center">

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:ButtonField>

            <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Eliminar" 
                ShowHeader="True" Text="Eliminar" ItemStyle-HorizontalAlign="Center"
                >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:ButtonField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerSettings FirstPageText="&amp;nbsp;Primero&amp;nbsp;" LastPageText="&amp;nbsp;Ultimo&amp;nbsp;" Mode="NextPreviousFirstLast" NextPageText="&amp;nbsp;Siguiente&amp;nbsp;" PreviousPageText="&amp;nbsp;Anterior&amp;nbsp;" />

<PagerStyle CssClass="pgr" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
            
            
            
            </td></tr>
    </table>
</asp:Content>
