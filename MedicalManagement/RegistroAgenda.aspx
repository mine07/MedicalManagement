<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroAgenda.aspx.cs" Inherits="MedicalManagement.RegistroAgenda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

            
<table width="100%" border="0"><tr><td align="left"><font color="red">Configuración\Agenda\Agregar</font></td>
        <td align="right">
        <asp:ImageButton ID="ImageGrabar" runat="Server" ImageUrl="IMG/Grabar.png"  ToolTip = "Grabar EstadoCivil" onclick="btnGuardar_FichaIdentificacion_Click"></asp:ImageButton>&nbsp;
        <asp:ImageButton ID="ImageRegresar" runat="Server" ImageUrl="IMG/Regresar.png"  ToolTip = "Regresar" onclick="btnRegresar_FichaIdentificacion_Click"></asp:ImageButton>
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
        Id.FichaIdentificacion
        </td>
        <td>
            <asp:TextBox ID="txtidfichaidentificacion" runat="server" BackColor="#CCFFCC" 
                ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
        Nombre Completo
        </td>
        <td>
            <asp:TextBox ID="txtnombrecompleto" runat="server"  BackColor="#CCFFCC" 
                ReadOnly="True" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
        Asunto:
        </td>
        <td>
             <asp:TextBox ID="txtasunto" runat="server"></asp:TextBox>
        </td>
    </tr>
    
    <tr>
        <td>
        Categoria: 
        </td>
        <td>
    <asp:DropDownList ID="ddlCategoria" runat="server">
    </asp:DropDownList>
        </td>
    </tr>
   
    <tr>
         
        <td>
         Prioridad
        </td>
        
        <td>                       
        
            <asp:RadioButton ID="rbNormal" runat="server" Text="Normal" AutoPostBack="true"
                oncheckedchanged="rbNormal_CheckedChanged" />
        </td>
        <td>
            <asp:RadioButton ID="rbUrgente" runat="server" Text="Urgente" AutoPostBack="true"
                oncheckedchanged="rbUrgente_CheckedChanged" />
        </td>
        
        
    </tr>
    
    
    <tr>
        <td>
        Dia de Alta en 
            Agenda
        </td>
        <td>
            <asp:TextBox ID="txtaltaagenda" runat="server" ReadOnly="True" 
                BackColor="#CCFFCC"></asp:TextBox>
        </td>
        
    </tr>
    <tr>
        <td>
        
            Estado de Cita</td>
        <td>
            <asp:DropDownList ID="DropDownEstadoCitas" runat="server">
                <asp:ListItem>Por confirmar</asp:ListItem>
                <asp:ListItem>Confirmado</asp:ListItem>
                <asp:ListItem>Cancelado</asp:ListItem>
            </asp:DropDownList>
        </td>
        
    </tr>
    <tr>
        <td>
        </td>        
        <td>
        Dia Mes Año 
        </td>
        <td>
        Hora Minuto DiaTarde
        </td>
    </tr>
    <tr>        
        <td>
        
    Comienzo
        </td>
        
                <td>
                <asp:DropDownList ID="DropDownDiaComienzo" runat="server">
                </asp:DropDownList>
            
                <asp:DropDownList ID="DropDownMesComienzo" runat="server">
                    <asp:ListItem>Enero</asp:ListItem>
                    <asp:ListItem>Febrero</asp:ListItem>
                    <asp:ListItem>Marzo</asp:ListItem>
                    <asp:ListItem>Abril</asp:ListItem>
                    <asp:ListItem>Mayo</asp:ListItem>
                    <asp:ListItem>Junio</asp:ListItem>
                    <asp:ListItem>Julio</asp:ListItem>
                    <asp:ListItem>Agosto</asp:ListItem>
                    <asp:ListItem>Septiembre</asp:ListItem>
                    <asp:ListItem>Octubre</asp:ListItem>
                    <asp:ListItem>Noviembre</asp:ListItem>
                    <asp:ListItem>Diciembre</asp:ListItem>
                </asp:DropDownList>
            
                <asp:DropDownList ID="DropDownAnioComienzo" runat="server">
                </asp:DropDownList>
        </td>
        <td>
                <asp:DropDownList ID="DropDownHoraComienzo" runat="server">
                </asp:DropDownList>
            
                <asp:DropDownList ID="DropDownMinutoComienzo" runat="server">
                </asp:DropDownList>
            
                <asp:DropDownList ID="DropDowndiatardeComienzo" runat="server">
                    <asp:ListItem>p.m.</asp:ListItem>
                    <asp:ListItem>a.m.</asp:ListItem>
                </asp:DropDownList>
        
        </td>
        <td width="300px"></td>
    </tr>
    <tr>
        <td>
    Finalizacion:
        </td>
        
                <td>
                <asp:DropDownList ID="DropDownDiaFinal" runat="server">
                </asp:DropDownList>
            
                <asp:DropDownList ID="DropDownMesFinal" runat="server">
                    <asp:ListItem>Enero</asp:ListItem>
                    <asp:ListItem>Febrero</asp:ListItem>
                    <asp:ListItem>Marzo</asp:ListItem>
                    <asp:ListItem>Abril</asp:ListItem>
                    <asp:ListItem>Mayo</asp:ListItem>
                    <asp:ListItem>Junio</asp:ListItem>
                    <asp:ListItem>Julio</asp:ListItem>
                    <asp:ListItem>Agosto</asp:ListItem>
                    <asp:ListItem>Septiembre</asp:ListItem>
                    <asp:ListItem>Octubre</asp:ListItem>
                    <asp:ListItem>Noviembre</asp:ListItem>
                    <asp:ListItem>Diciembre</asp:ListItem>
                </asp:DropDownList>
            
                <asp:DropDownList ID="DropDownAnioFinal" runat="server">
                </asp:DropDownList>
        </td>
        <td>
                <asp:DropDownList ID="DropDownHoraFinal" runat="server">
                </asp:DropDownList>
            
                <asp:DropDownList ID="DropDownMinutoFinal" runat="server">
                </asp:DropDownList>
            
                <asp:DropDownList ID="DropDowndiatardeFinal" runat="server">
                    <asp:ListItem>p.m.</asp:ListItem>
                    <asp:ListItem>a.m.</asp:ListItem>
                </asp:DropDownList>
        
        </td>
    </tr>
    <tr>
        <td>
        Descripcion
        </td>
        <td colspan="3">
            <asp:TextBox ID="txtdescripcionagenda" runat="server" Width="100%"></asp:TextBox>
        </td>
    </tr>
</table>
    
</asp:Content>
