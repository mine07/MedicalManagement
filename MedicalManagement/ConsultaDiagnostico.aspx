﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaDiagnostico.aspx.cs" Inherits="MedicalManagement.ConsultaDiagnostico" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table width="100%">
        <tr>
            <td align="left"colspan="6">Diagnostico&nbsp;:&nbsp;<asp:TextBox ID="txtBuscar_Diagnostico" runat="server" Columns="85" OnTextChanged="txt_OnTextChanged"  AutoPostBack=true></asp:TextBox>&nbsp;&nbsp;
            <asp:ImageButton ID="ImageRegresar" runat="Server" ImageUrl="IMG/Regresar.png"  ToolTip = "Regresar" onclick="btnRegresar_ConsultasDiagnostico_Click"></asp:ImageButton>
            &nbsp;&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar Perfil"></asp:ImageButton>&nbsp;&nbsp;&nbsp;            
            <asp:ImageButton ID="ImageGrabar" runat="Server" ImageUrl="IMG/Grabar.png"  ToolTip = "Grabar Diagnostico" onclick="btnGuardar_ConsultaDiagnostico_Click"></asp:ImageButton>
            
            </td>
        </tr>

</table>

<div class="container-fluid">

    <div class="row">
            
    <asp:GridView ID="Grid_Diagnostico" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_Diagnostico_PageIndexChanging" AllowPaging="true" pagesize="15"
        onpageindexchanged="Grid_Diagnostico_PageIndexChanged" CssClass="mGrid" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" >
                    
    
        <Columns>

            <asp:BoundField DataField="Id_Diagnostico" HeaderText="Id.Diagnostico" 
                SortExpression="Id_Diagnostico" />


            <asp:BoundField DataField="Descripcion_Diagnostico" HeaderText="Descripcion Diagnostico" 
                SortExpression="Descripcion_Diagnostico" />    
            
            <asp:TemplateField  HeaderText="Elegir">
                <HeaderTemplate>
                    Elegir
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox  ID="CheckBoxelegir" runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView>
            
            
    </div>            
            
    
</div>

</asp:Content>
