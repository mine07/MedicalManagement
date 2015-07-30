<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgendaElegirFicha.aspx.cs" Inherits="MedicalManagement.AgendaElegirFicha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table width="100%">
        <tr>
            <td align="left"colspan="6">Ficha de Identificacion&nbsp;:&nbsp;<asp:TextBox ID="txtBuscar_FichaIdentificacion" runat="server" Columns="90" OnTextChanged="txt_OnTextChanged"  AutoPostBack=true></asp:TextBox>&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar Perfil"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="ImageRegresar" runat="Server" ImageUrl="IMG/Regresar.png"  ToolTip = "Regresar" onclick="btnRegresar_FichaIdentificacion_Click"></asp:ImageButton>
            </td>
        </tr>

        
        <tr>
            <td align="center">              
                    Favor de elegir algun usuario para asignar cita.
                               
            </td>                    
        </tr>
        <tr>

            <td align="center"colspan="6">
            <asp:GridView ID="Grid_FichaIdentificacion" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_FichaIdentificacion_PageIndexChanging" AllowPaging ="False"
        onpageindexchanged="Grid_FichaIdentificacion_PageIndexChanged" CssClass="mGrid" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" >
                    
    
        <Columns>
            
            

            <asp:BoundField DataField="Id_FichaIdentificacion" HeaderText="Id.FichaIdentificacion" 
                SortExpression="Id_FichaIdentificacion" />

            <asp:BoundField DataField="NombreCompleto" HeaderText="NombreCompleto" 
                SortExpression="NombreCompleto" />

          
            <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Elegir" 
                ShowHeader="True" Text="Elegir" ItemStyle-HorizontalAlign="Center"/>

            
             
        </Columns>
    </asp:GridView>
            
 
            
            
            </td></tr>
</table>

</asp:Content>
