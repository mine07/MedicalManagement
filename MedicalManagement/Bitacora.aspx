<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="MedicalManagement.Bitacora" EnableEventValidation="false" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <font color="red">Configuración\Bitacora</font>

<table width="100%" border="1">
    <tr><td>

    <table width="100%">
        <tr>
            <td align="left"colspan="6">Fecha&nbsp;:&nbsp;<asp:Calendar ID="FechaGeneracion" runat="server" OnSelectionChanged="OnSelectionChanged"></asp:Calendar>&nbsp;
        </tr>



        <tr>
            <td align="center"colspan="6">
            <asp:GridView ID="Grid_Bitacora" runat="server" AutoGenerateColumns="False" 
         AllowPaging ="False"
         CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" >
    
        <Columns>

            <asp:BoundField DataField="Comercial_Nombre_Empresa" HeaderText="Empresa" 
                SortExpression="Comercial_Nombre_Empresa" />


            <asp:BoundField DataField="Comercial_Nombre_Sucursal" HeaderText="Sucursal" 
                SortExpression="Comercial_Nombre_Sucursal" />


            <asp:BoundField DataField="Nombre_Usuario" HeaderText="Usuario" 
                SortExpression="Nombre_Usuario" />


            <asp:BoundField DataField="Registro_FechaHora_Bitacora" HeaderText="Fecha" 
                SortExpression="Registro_FechaHora_Bitacora" />


            <asp:BoundField DataField="Descripcion_Bitacora" HeaderText="Operación" 
                SortExpression="Descripcion_Bitacora" />


            <asp:BoundField DataField="Registro_Operacion_Btacora" HeaderText="Información" 
                SortExpression="Registro_Operacion_Btacora" />


        </Columns>
    </asp:GridView>
            
            
            
            </td></tr>
    </table>
    </td></tr>

</asp:Content>