<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaAnalisisClinico.aspx.cs" Inherits="MedicalManagement.ConsultaAnalisisClinico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <asp:TextBox ID="txtBuscar_AnalisisClinico" runat="server"></asp:TextBox>

    <asp:GridView ID="Grid_AnalisisClinico" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_AnalisisClinico_PageIndexChanging" 
        AllowPaging="true" pagesize="15"
        onpageindexchanged="Grid_AnalisisClinico_PageIndexChanged" CssClass="mGrid" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
        GridLines="None"  >
                    
    
        <Columns>

            <asp:BoundField DataField="Id_AnalisisClinico" HeaderText="Id.AnalisisClinicos" 
                SortExpression="Id_AnalisisClinicos" />


            <asp:BoundField DataField="Descripcion_AnalisisClinico" HeaderText="Descripcion Analisis Clinicos" 
                SortExpression="Descripcion_AnalisisClinicos" />    
            
            <asp:TemplateField  HeaderText="Elegir">
                <HeaderTemplate>
                    Elegir
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox  ID="CheckBoxelegir" runat="server" OnCheckedChanged ="CheckBoxelegir_CheckedChanged" AutoPostBack="true" />
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView>


    <asp:TextBox ID="TextBox1" runat="server" Width="800" TextMode="MultiLine" Rows="3"></asp:TextBox>

    
    <asp:GridView ID="Grid_AnalisisClinicoSeleccionado" runat="server">
    </asp:GridView>

</asp:Content>
