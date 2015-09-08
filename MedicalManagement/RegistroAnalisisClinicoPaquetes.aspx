<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroAnalisisClinicoPaquetes.aspx.cs" Inherits="MedicalManagement.RegistroAnalisisClinicoPaquetes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<table width="100%" border="0"><tr><td align="left"><font color="red">Configuración\AnalisisClinicoPaquetes\Agregar</font></td>
<td align="right">
<asp:ImageButton ID="ImageGrabar" runat="Server" ImageUrl="IMG/Grabar.png"  ToolTip = "Grabar AnalisisClinicoPaquetes" onclick="btnGuardar_AnalisisClinicoPaquetes_Click"></asp:ImageButton>&nbsp;
<asp:ImageButton ID="ImageRegresar" runat="Server" ImageUrl="IMG/Regresar.png"  ToolTip = "Regresar" onclick="btnRegresar_AnalisisClinicoPaquetes_Click"></asp:ImageButton>
</td>
</tr>
<tr>
    <td colspan="2" align ="center" runat="Server" id="Alerta">
    </td>
</tr>
</table>

 

    <table width="100%">
        <tr>
            <td align="left">
                    <asp:Label ID="Label3" runat="server" Text="Descripción de Paquetes de Analisis Clinico :"
                    ></asp:Label>
            </td>
            <td align="left">
                    <asp:TextBox ID="Descripcion_AnalisisClinicoPaquetes" runat="server" Columns="100"
                    ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <asp:GridView ID="Grid_AnalisisClinico" runat="server" AutoGenerateColumns="False" 
                         
                onpageindexchanging ="Grid_AnalisisClinico_PageIndexChanging" 
                AllowPaging="true" pagesize="2"
                onpageindexchanged="Grid_AnalisisClinico_PageIndexChanged" CssClass="mGrid" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                GridLines="None"   >
                    
    
                <Columns>

                    <asp:BoundField DataField="Id_AnalisisClinico" HeaderText="Id.AnalisisClinicos" 
                    SortExpression="Id_AnalisisClinicos" />


                    <asp:BoundField DataField="Descripcion_AnalisisClinico" HeaderText="Descripcion Analisis Clinicos" 
                    SortExpression="Descripcion_AnalisisClinicos" />   
                    
                    <asp:BoundField DataField="Estatus_AnalisisClinicoPaquetes" HeaderText="Estatus_AnalisisClinicoPaquetes" 
                    SortExpression="Estatus_AnalisisClinicoPaquetes" />  
            
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
        </tr>
        <tr>
        <asp:GridView ID="Grid_AnalisisClinicoSeleccionado" runat="server" AutoGenerateColumns="False" > 
            <Columns>       

                <asp:BoundField DataField="Id_AnalisisClinico" HeaderText="Id.AnalisisClinicos" 
                SortExpression="Id_AnalisisClinicos" />

                <asp:BoundField DataField="Descripcion_AnalisisClinico" HeaderText="Descripcion Analisis Clinicos" 
                SortExpression="Descripcion_AnalisisClinicos" /> 

            </Columns>

        </asp:GridView>
        </tr>
        
    </table>
    

</asp:Content>
