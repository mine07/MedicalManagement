<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroRecetaPrevia.aspx.cs" Inherits="MedicalManagement.RegistroRecetaPrevia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<table width="100%" border="0"><tr><td align="left"><font color="red">Configuración\Categoria\Agregar</font></td>
<td align="right">
<asp:ImageButton ID="ImageGrabar" runat="Server" ImageUrl="IMG/Grabar.png"  ToolTip = "Grabar Categoria" onclick="btnGuardar_Categoria_Click"></asp:ImageButton>&nbsp;
<asp:ImageButton ID="ImageRegresar" runat="Server" ImageUrl="IMG/Regresar.png"  ToolTip = "Regresar" onclick="btnRegresar_RecetaPrevia_Click"></asp:ImageButton>
</td>
</tr>
<tr>
    <td colspan="2" align ="center" runat="Server" id="Alerta">
    </td>
</tr>
</table>
<table width="100%" border="1">
        <tr>

    
        
            <td align="left">
                    <asp:Label ID="Label3" runat="server" Text="Nombre de Receta Previa:"
                    ></asp:Label>
            </td>
            <td align="left" colspan="2">
                    <asp:TextBox ID="txtNombre_ConsultaRecetaPrevia" runat="server" Columns="100"
                    ></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td align="left">
                    <asp:Label ID="Label1" runat="server" Text="Medicamento:"
                    ></asp:Label>
            </td>
            <td align="left" colspan="2">
                    <asp:TextBox ID="txtmedicamento_consultareceta" runat="server"  Width="800" TextMode="MultiLine" Rows="3"
                    ></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td align="left">
                    <asp:Label ID="Label2" runat="server" Text="Dosis:"
                    ></asp:Label>
            </td>
            <td align="left" colspan="2">
                    <asp:TextBox ID="txtdosis_consultareceta" runat="server"  Width="800" TextMode="MultiLine" Rows="3"
                    ></asp:TextBox>
            </td>
        </tr>  
         
        <tr>
            <td align="left">
                    <asp:Label ID="Label4" runat="server" Text="Notas:"
                    ></asp:Label>
            </td>
            <td align="left" colspan="2">
                    <asp:TextBox ID="txtnotas_consultareceta" runat="server"  Width="800" TextMode="MultiLine" Rows="3"
                    ></asp:TextBox>
            </td>
        </tr>   

</asp:Content>
