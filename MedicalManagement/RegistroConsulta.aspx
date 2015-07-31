<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroConsulta.aspx.cs" Inherits="MedicalManagement.RegistroConsulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table width="100%" border="0">

    <tr><td align="left"><font color="red">Configuración\Consulta\Agregar</font></td>
        <td align="right">
        <asp:ImageButton ID="ImageGrabar" runat="Server" ImageUrl="IMG/Grabar.png"  ToolTip = "Grabar EstadoCivil" onclick="btnGuardar_Consulta_Click"></asp:ImageButton>&nbsp;
        <asp:ImageButton ID="ImageRegresar" runat="Server" ImageUrl="IMG/Regresar.png"  ToolTip = "Regresar" onclick="btnRegresar_Consulta_Click"></asp:ImageButton>
        </td>
    </tr>
</table>
<table>
    <tr>
        <td>
        </td>
    </tr>
    
    <tr>
        <td>
            Fecha
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtfechaconsulta" runat="server" BackColor="#CCFFCC" 
                ReadOnly="True" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Nombre
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtnombre" runat="server" Width="350" BackColor="#CCFFCC" 
                ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Subjetivo
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtsubjetivo" runat="server" Width="600" TextMode="MultiLine" Rows="3"  ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Objetivo
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtobjetivo" runat="server" Width="800" TextMode="MultiLine" Rows="3"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Diagnostico
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtdiagnostico" runat="server" Width="800" TextMode="MultiLine" Rows="3"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Analisis
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtanalisis" runat="server" Width="800" TextMode="MultiLine" Rows="3"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Plan
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtplan" runat="server" Width="800" TextMode="MultiLine" Rows="3"></asp:TextBox>
        </td>
    </tr>
    
    
</table>

              
</asp:Content>
