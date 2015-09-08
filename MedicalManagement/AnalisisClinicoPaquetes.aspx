<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnalisisClinicoPaquetes.aspx.cs" Inherits="MedicalManagement.AnalisisClinicoPaquetes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table width="100%">
        <tr>
            <td align="left"colspan="6">Paquete de Analisis Clinico&nbsp;:&nbsp;<asp:TextBox ID="txtBuscar_AnalisisClinicoPaquetes" runat="server" Columns="100" OnTextChanged="txt_OnTextChanged"  AutoPostBack=true></asp:TextBox>&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar AnalisisClinico"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="AgregarSexo" runat="Server" ImageUrl="IMG/agregar.png" OnClick="btnAgregarAnalisisClinicoPaquetes_Click" ToolTip = "Agregar Paquete de AnalisisClinico"></asp:ImageButton>
            </td>
        </tr>


        <tr>
            <td align="center"colspan="6">
 <asp:GridView ID="Grid_AnalisisClinicoPaquetes" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_AnalisisClinicoPaquetes_PageIndexChanging" AllowPaging="true" pagesize="10"
        onpageindexchanged="Grid_AnalisisClinicoPaquetes_PageIndexChanged" CssClass="mGrid" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" >
                    
    
        <Columns>

            <asp:BoundField DataField="Id_AnalisisClinicoPaquetes" HeaderText="Id.AnalisisClinicoPaquetes" 
                SortExpression="Id_AnalisisClinicoPaquetes" />


            <asp:BoundField DataField="Descripcion_AnalisisClinicoPaquetes" HeaderText="Descripcion Analisis Clinico Paquetes" 
                SortExpression="Descripcion_AnalisisClinicoPaquetes" />    
            
            <asp:ButtonField ButtonType="Button" CommandName="Mostrar" HeaderText="Analisis Incluidos" 
                ShowHeader="True" Text="Analisis Incluidos" ItemStyle-HorizontalAlign="Center"/>

            <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Editar" 
                ShowHeader="True" Text="Editar" ItemStyle-HorizontalAlign="Center"/>

            <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Eliminar" 
                ShowHeader="True" Text="Eliminar" ItemStyle-HorizontalAlign="Center"
                />
        </Columns>
    </asp:GridView>
            
            
            
            </td></tr>
            <tr>
                <td>
                    <asp:GridView ID="Grid_AnalisisClinicoIncluidos" runat="server" AutoGenerateColumns="False" 
                 
        onpageindexchanging ="Grid_AnalisisClinicoIncluidos_PageIndexChanging" AllowPaging="true" pagesize="10"
        onpageindexchanged="Grid_AnalisisClinicoIncluidos_PageIndexChanged" CssClass="mGrid" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" >
                    
    
        <Columns>

            <asp:BoundField DataField="Id_AnalisisClinico" HeaderText="Id.AnalisisClinico" 
                SortExpression="Id_AnalisisClinico" />


            <asp:BoundField DataField="Descripcion_AnalisisClinico" HeaderText="Descripcion Analisis Clinico" 
                SortExpression="Descripcion_AnalisisClinico" />    
            
            
                
        </Columns>
    </asp:GridView>

                </td>
            </tr>
    </table>

</asp:Content>
