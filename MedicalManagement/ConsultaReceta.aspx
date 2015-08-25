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

<div class="container-fluid">
    
    <div class="row">
        <asp:TextBox ID="txtBuscar_Receta" runat="server" Columns="40"></asp:TextBox>
        <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar Receta"></asp:ImageButton>
    </div>
    
    <div class="row">            
            <asp:GridView ID="GridViewRecetaPrevia" runat="server" AutoGenerateColumns="false"
            onrowcommand="RowCommand">

            <Columns>
            
                <asp:BoundField DataField="Id_ConsultaRecetaPrevia" HeaderText="Id_ConsultaRecetaPrevia" 
                SortExpression="Id_ConsultaResetaPrevia" />

                <asp:BoundField DataField="Nombre_ConsultaRecetaPrevia" HeaderText="Receta Previa" 
                SortExpression="RecetaPrevia" />

                <asp:ButtonField ButtonType="Button" CommandName="Elegir" HeaderText="Elegir" 
                ShowHeader="True" Text="Elegir" ItemStyle-HorizontalAlign="Center"/>
                        
            </Columns>
            
            </asp:GridView>       
    </div> 
        <div class="row">
            Medicamento
        </div>    
        <div class="row"> 
            <asp:TextBox ID="txtmedicamento" runat="server" Width="800" TextMode="MultiLine" Rows="3"></asp:TextBox>            
        </div>  
           
        
    
    
        <div class="row">
            Dosis
        </div>
        <div class="row"> 
            <asp:TextBox ID="txtdosis" runat="server" Width="800" TextMode="MultiLine" Rows="3"></asp:TextBox>
        </div>       
    
    
        <div class="row">
        
            Notas 
        </div>
        <div class="row"> 
            <asp:TextBox ID="txtnotas" runat="server" Width="800" TextMode="MultiLine" Rows="3"></asp:TextBox>
        </div>       
    
    
    <div class="row">
        
            <asp:LinkButton ID="LinkRecetaPrevia" runat="server" onclick="LinkRecetaPrevia_Click">Agregar de Receta Previa</asp:LinkButton>                    
    </div>
        <div class="row">
            <asp:TextBox ID="Txtnombrerecetaprevia" runat="server" Width="400"></asp:TextBox>
        </div>  
</div>   

</asp:Content>
