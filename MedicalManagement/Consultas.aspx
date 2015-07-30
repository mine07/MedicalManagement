<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="MedicalManagement.Consultas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<table width="100%">
        <tr>
            <td align="left"colspan="6">Consulta&nbsp;:&nbsp;<asp:TextBox ID="txtBuscar_FichaIdentificacion" runat="server" Columns="100" OnTextChanged="txt_OnTextChanged"  AutoPostBack=true></asp:TextBox> &nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar Perfil"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="AgregarAgenda" runat="Server" ImageUrl="IMG/agregar.png" OnClick="btnAgregarAgenda_Click" ToolTip = "Agregar Agenda"></asp:ImageButton>                
            </td>
        </tr>

        <tr>
            <td>
                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="OnSelectionChanged"></asp:Calendar>
            </td>
        </tr>
        <tr>                
            <td>
               
                 <asp:RadioButton ID="rdbtodos" runat="server" Text="Todos" AutoPostBack="true" 
                    oncheckedchanged="rdbtodos_CheckedChanged" Checked="True" />
            
                 &nbsp;&nbsp;
            
                 <asp:RadioButton ID="rdbnormal" runat="server" Text="Normal" AutoPostBack="true" 
                    oncheckedchanged="rdbnormal_CheckedChanged" />
               
                 &nbsp;&nbsp;
               
                 <asp:RadioButton ID="rdburgente" runat="server" Text="Urgente" AutoPostBack="true"
                    oncheckedchanged="rdburgente_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td align="center"colspan="6">
            <asp:GridView ID="Grid_Agenda" runat="server" AutoGenerateColumns="False" 
        onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
        onpageindexchanging ="Grid_Agenda_PageIndexChanging" AllowPaging ="False"
        onpageindexchanged="Grid_Agenda_PageIndexChanged" CssClass="mGrid" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" >
                    
    
        <Columns>
            
            <asp:BoundField DataField="Id_Agenda" HeaderText="Id.Agenda" 
                SortExpression="Id_Agenda" />

            <asp:BoundField DataField="Id_FichaIdentificacion" HeaderText="Id.FichaIdentificacion" 
                SortExpression="Id_FichaIdentificacion" />

            <asp:BoundField DataField="NombreCompleto" HeaderText="NombreCompleto" 
                SortExpression="NombreCompleto" />

           <asp:BoundField DataField="Fecha_Agenda" HeaderText="Fecha_Agenda" 
                SortExpression="Fecha_Agenda" />

            <asp:BoundField DataField="Inicio_Agenda" HeaderText="Inicio_Agenda" 
                SortExpression="Inicio_Agenda" />

            <asp:BoundField DataField="Fin_Agenda" HeaderText="Fin_Agenda" 
                SortExpression="Fin_Agenda" />

            <asp:BoundField DataField="EstadoCitas_Agenda" HeaderText="EstadoCitas_Agenda" 
                SortExpression="EstadoCitas_Agenda" />

            <asp:ButtonField ButtonType="Button" CommandName="ConsultaMenu" HeaderText="Consulta Menu" 
                ShowHeader="True" Text="Consulta Menu" ItemStyle-HorizontalAlign="Center"/>
            

            <asp:ButtonField ButtonType="Button" CommandName="HistorialConsultas" HeaderText="Historial" 
                ShowHeader="True" Text="Historial" ItemStyle-HorizontalAlign="Center"/>
            
                
        </Columns>
    </asp:GridView>
            
 
            
            
            </td></tr>
</table>

</asp:Content>
