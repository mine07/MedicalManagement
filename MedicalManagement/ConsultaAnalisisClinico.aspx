<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaAnalisisClinico.aspx.cs" Inherits="MedicalManagement.ConsultaAnalisisClinico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table width="100%" border="0"><tr><td align="left"><font color="red">Operaciones\Consultas\ConsultasAnalisisClinico</font></td>
        <td align="right">   
        <asp:ImageButton ID="ImageGrabar" runat="Server" ImageUrl="IMG/Grabar.png"  ToolTip = "Grabar ConsultaAnalisisClinico" onclick="btnGuardar_ConsultasAnalisisClinico_Click"></asp:ImageButton>&nbsp;     
        <asp:ImageButton ID="ImageRegresar" runat="Server" ImageUrl="IMG/Regresar.png"  ToolTip = "Regresar" onclick="btnRegresar_ConsultasAnalisisClinico_Click"></asp:ImageButton>
        </td>
    </tr>

    <tr>
        <td colspan="2" align ="center" runat="Server" id="Alerta">
        </td>
    </tr>
</table>

<div class="container-fluid">

    <div class="row">
        <asp:TextBox ID="txtBuscar_AnalisisClinico" runat="server"></asp:TextBox>
    </div>

    <div class="row">
        <asp:GridView ID="Grid_AnalisisClinico" runat="server" AutoGenerateColumns="False" 
            onrowcommand="RowCommand"          
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
    </div>

    <div class="row">
        <asp:GridView ID="Grid_AnalisisClinicoSeleccionado" runat="server" AutoGenerateColumns="False" > 
            <Columns>       

                <asp:BoundField DataField="Id_AnalisisClinico" HeaderText="Id.AnalisisClinicos" 
                SortExpression="Id_AnalisisClinicos" />

                <asp:BoundField DataField="Descripcion_AnalisisClinico" HeaderText="Descripcion Analisis Clinicos" 
                SortExpression="Descripcion_AnalisisClinicos" /> 

            </Columns>

        </asp:GridView>
    </div>
    <div class="row">
        <asp:TextBox ID="txtobservacionesanalisisclinico" runat="server" Width="800" TextMode="MultiLine" Rows="3"></asp:TextBox>
    </div>
</div>

</asp:Content>
