<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaProcedimiento.aspx.cs" Inherits="MedicalManagement.ConsultaProcedimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<table width="100%">
        <tr>
            <td align="left"colspan="6">Procedimiento&nbsp;:&nbsp;<asp:TextBox ID="txtBuscar_Procedimiento" runat="server" Columns="85" OnTextChanged="txt_OnTextChanged"  AutoPostBack=true></asp:TextBox>&nbsp;&nbsp;
            <asp:ImageButton ID="ImageRegresar" runat="Server" ImageUrl="IMG/Regresar.png"  ToolTip = "Regresar" onclick="btnRegresar_ConsultasProcedimiento_Click"></asp:ImageButton>
            &nbsp;&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar Perfil"></asp:ImageButton>&nbsp;&nbsp;&nbsp;            
            <asp:ImageButton ID="ImageGrabar" runat="Server" ImageUrl="IMG/Grabar.png"  ToolTip = "Grabar Procedimiento" onclick="btnGuardar_ConsultaProcedimiento_Click"></asp:ImageButton>
            
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
            
            <asp:TemplateField  HeaderText="Elegir">
                <HeaderTemplate>
                    Elegir
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox  ID="CheckBoxelegir" runat="server"   />
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView>
            
            
            
            </td></tr>
    </table>

</asp:Content>
