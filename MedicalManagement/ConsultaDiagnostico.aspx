<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaDiagnostico.aspx.cs" Inherits="MedicalManagement.ConsultaDiagnostico" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table width="100%">
        <tr>
            <td align="left"colspan="6">Diagnostico&nbsp;:&nbsp;<asp:TextBox ID="txtBuscar_Diagnostico" runat="server" Columns="85" OnTextChanged="txt_OnTextChanged"  AutoPostBack=true></asp:TextBox>&nbsp;&nbsp;
            <!--<asp:ImageButton ID="ImageRegresar" runat="Server" ImageUrl="IMG/Regresar.png"  ToolTip = "Regresar" onclick="btnRegresar_ConsultasDiagnostico_Click"></asp:ImageButton>-->
            &nbsp;&nbsp;
          
            <asp:LinkButton runat="server" OnClick="btnGuardar_ConsultaDiagnostico_Click" ToolTip = "Agregar Diagnostico" Text='<label class="fa-margin-right label pull-right label label-primary"><i class="fa fa-margin-left fa-plus-circle"></i></label>' BackColor="#3333FF"></asp:LinkButton>
            <asp:LinkButton runat="server" OnClick="txt_OnTextChanged" ToolTip = "Buscar Perfil" Text='<label class="fa-margin-right label pull-right label-success label-button"><i class="fa fa-margin-left fa-search"></i></label>'></asp:LinkButton>                                                                                          
            
            </td>
        </tr>

</table>

<div class="container-fluid">

    <div class="row">
            
    <asp:GridView ID="Grid_Diagnostico" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_Diagnostico_PageIndexChanging" AllowPaging="True" pagesize="15"
        onpageindexchanged="Grid_Diagnostico_PageIndexChanged" CssClass="mGrid" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" CellPadding="4" ForeColor="#333333" >
                    
    
<AlternatingRowStyle CssClass="alt" BackColor="White"></AlternatingRowStyle>
                    
    
        <Columns>

            <asp:BoundField DataField="Id_Diagnostico" HeaderText="Id.Diagnostico" 
                SortExpression="Id_Diagnostico" />


            <asp:BoundField DataField="Descripcion_Diagnostico" HeaderText="Descripcion Diagnostico" 
                SortExpression="Descripcion_Diagnostico" />    
            
          
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

<PagerStyle CssClass="pgr" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
            
            
    </div>            
            
    
</div>

</asp:Content>
