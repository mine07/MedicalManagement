<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaReceta.aspx.cs" Inherits="MedicalManagement.ConsultaReceta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table width="100%" border="0"><tr><td align="left"><font color="red">Operaciones\Consultas\ConsultasRecetas</font></td>
        <td align="right">   
        <asp:ImageButton ID="ImageGrabar" runat="Server" ImageUrl="IMG/Grabar.png"  ToolTip = "Grabar ConsultaReceta" onclick="btnGuardar_ConsultasRecetas_Click"></asp:ImageButton>&nbsp;     
        <asp:ImageButton ID="ImageRegresar" runat="Server" ImageUrl="IMG/Regresar.png"  ToolTip = "Regresar" onclick="btnRegresar_ConsultasRecetas_Click"></asp:ImageButton>
        </td>
    </tr>

    <tr>
        <td colspan="2" align ="center" runat="Server" id="Alerta">
        </td>
    </tr>
</table>
<table>
    <tr>
        <td>
            Id_Consulta
        </td>
        <td>
        </td>
    
    </tr>
    <tr>
        <td>
            Medicamento_Consulta
        </td>
        <td> 
            <asp:TextBox ID="txtmedicamento" runat="server" Width="800" TextMode="MultiLine" Rows="3"></asp:TextBox>            
        </td>       
    
    </tr>
     <tr>
        <td>
            Cantidad_ConsultaReceta
        </td>
        <td> 
            <asp:TextBox ID="txtcantidad" runat="server" Width="800" TextMode="MultiLine" Rows="3"></asp:TextBox>
        </td>       
    
    </tr>
     <tr>
        <td>
            Cada_ConsultaReceta 
        </td>
        <td> 
            <asp:TextBox ID="txtcadacuando" runat="server" Width="800" TextMode="MultiLine" Rows="3"></asp:TextBox>
        </td>       
    
    </tr>


</table>

</asp:Content>
