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
        <asp:TextBox ID="txtBuscar_AnalisisClinicoPaquetes" runat="server"></asp:TextBox>
        <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChangedPaquetes" ToolTip = "Buscar Paquetes de Analisis Clinicos"></asp:ImageButton>
    </div>

    <div class="row">

    <asp:GridView ID="Grid_AnalisisClinicoPaquetes" runat="server" AutoGenerateColumns="False" 
                          
                onpageindexchanging ="Grid_AnalisisClinicoPaquetes_PageIndexChanging" 
                AllowPaging="true" pagesize="10"
                onpageindexchanged="Grid_AnalisisClinicoPaquetes_PageIndexChanged" CssClass="mGrid" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                GridLines="None"   >
                    
    
                <Columns>

                    <asp:BoundField DataField="Id_AnalisisClinicoPaquetes" HeaderText="Id.AnalisisClinicoPaquetes" 
                    SortExpression="Id_AnalisisClinicoPaquetes" />


                    <asp:BoundField DataField="Descripcion_AnalisisClinicoPaquetes" HeaderText="Descripcion Analisis Clinicos Paquetes" 
                    SortExpression="Descripcion_AnalisisClinicoPaquetes" />    

                    <asp:BoundField DataField="Estatus_ConsultaAnalisisClinicoDetalladoPaquetes" HeaderText="Estatus_ConsultaAnalisisClinicoDetalladoPaquetes" 
                    SortExpression="Estatus_ConsultaAnalisisClinicoDetalladoPaquetes" />  

                                
                    <asp:TemplateField  HeaderText="Elegir">
                        <HeaderTemplate>
                        Elegir
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox  ID="CheckBoxelegirPaquetes" runat="server" OnCheckedChanged ="CheckBoxelegirPaquetes_CheckedChanged" AutoPostBack="true" />
                        </ItemTemplate>
                    </asp:TemplateField>
            
                </Columns>
            </asp:GridView>
        

    </div>

    <div class="row">
        <asp:TextBox ID="txtBuscar_AnalisisClinico" runat="server"></asp:TextBox>
        <asp:ImageButton ID="ImageButton2" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar Analisis Clinicos "></asp:ImageButton>
    </div>

    <div class="row">
        
            <asp:GridView ID="Grid_AnalisisClinico" runat="server" AutoGenerateColumns="False" 
                         
                onpageindexchanging ="Grid_AnalisisClinico_PageIndexChanging" 
                AllowPaging="true" pagesize="10"
                onpageindexchanged="Grid_AnalisisClinico_PageIndexChanged" CssClass="mGrid" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                GridLines="None"   >
                    
    
                <Columns>

                    <asp:BoundField DataField="Id_AnalisisClinico" HeaderText="Id.AnalisisClinicos" 
                    SortExpression="Id_AnalisisClinicos" />


                    <asp:BoundField DataField="Descripcion_AnalisisClinico" HeaderText="Descripcion Analisis Clinicos" 
                    SortExpression="Descripcion_AnalisisClinicos" />    

                    <asp:BoundField DataField="Estatus_ConsultaAnalisisClinicoDetallado" HeaderText="Estatus_ConsultaAnalisisClinicoDetallado" 
                    SortExpression="Estatus_ConsultaAnalisisClinicoDetallado" />  
            
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
        <asp:GridView ID="Grid_AnalisisClinicoSeleccionadoPaquetes" runat="server" AutoGenerateColumns="False" > 
            <Columns>       

                <asp:BoundField DataField="Id_AnalisisClinicoPaquetes" HeaderText="Id.AnalisisClinicos" 
                SortExpression="Id_AnalisisClinicoPaquetes" />

                <asp:BoundField DataField="Descripcion_AnalisisClinicoPaquetes" HeaderText="Descripcion Analisis Clinicos Paquetes" 
                SortExpression="Descripcion_AnalisisClinicoPaquetes" /> 

            </Columns>

        </asp:GridView>
    </div>

    <div class="row">
        <asp:TextBox ID="txtobservacionesanalisisclinico" runat="server" Width="800" TextMode="MultiLine" Rows="3"></asp:TextBox>
    </div>
</div>

</asp:Content>
