<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroFichaIdentificacion.aspx.cs" Inherits="MedicalManagement.RegistroFichaIdentificacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table width="100%" border="0"><tr><td align="left"><font color="red">Configuración\FichaIdentificacion\Agregar</font></td>
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

<div class="fichaidentificacion3">
<div class="fichaidentificacion4">

<table   >        

        <tr>
                        
            <td align="left"colspan="1">
               Clave Identificacion 
            </td>
            
            <td align="left"colspan="1">
                <asp:TextBox ID="txtClaveIdent" runat="server" Columns="10" ReadOnly="True" 
                    BackColor="#CCFFCC"></asp:TextBox>              
            </td>
            
        </tr>
         <tr>
                        
            <td align="left"colspan="1">
               
            </td>
            <td align="left"colspan="1" Columns="25">
               
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dia&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mes&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                Año&nbsp;</td>
             
            
            
        </tr>
        <tr>
            
            <td align="left"colspan="1">
               Fecha Identificacion 
            </td>
            
            <td align="left"colspan="2">
                <asp:TextBox ID="txtFechaIdent" runat="server" Columns="6" ReadOnly="True" 
                    BackColor="#CCFFCC"></asp:TextBox>              
            
                <asp:DropDownList ID="DropDownDia" runat="server">
                </asp:DropDownList>
            
                    <asp:DropDownList ID="DropDownMes" runat="server">
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
            
                    <asp:DropDownList ID="DropDownAnio" runat="server">
                    </asp:DropDownList>
            </td>
            
            
        </tr>       

        <tr>
            
            <td align="left"colspan="1">
                Nombre
            </td>
            <td>
                 <asp:TextBox ID="txtNombreIdent" runat="server" Columns="25"></asp:TextBox>
            </td>       
            
        </tr>
        <tr>
            <td align="left"colspan="1">
                Apellido Paterno
            </td>
            <td align="left" colspan="6">
                <asp:TextBox ID="txtApPaIdent" runat="server" Columns="25"></asp:TextBox>
            </td>
        </tr>
        <tr>
            
            <td align="left"colspan="1">
                Apellido Materno
            </td>
            <td align="left"colspan="6">
                <asp:TextBox ID="txtApMaIdent" runat="server" Columns="25"></asp:TextBox>        
            
            </td>
        </tr>
        <tr>
            
            <td align="left"colspan="1">
               Lugar de Nacimiento
            </td>
            <td align="left"colspan="6">
                <asp:TextBox ID="txtLugarNaIdent" runat="server" Columns="25"></asp:TextBox>         
            
            </td>
        </tr>
            
            <tr>
            
            <td align="left"colspan="1">
               
            </td>
            <td align="left"colspan="6">
                        
            
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                Dia&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mes&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 
                Año&nbsp;</td>
        </tr>
        <tr>
            <td align="left"colspan="1">                       
                Fecha de Nacimiento
            </td>
            <td align="left"colspan="6">                 
                <asp:TextBox ID="txtFechaNaIdent" runat="server" Columns="6" ReadOnly="True" 
                    BackColor="#CCFFFF"></asp:TextBox>
                
                <asp:DropDownList ID="DropDownDiaNa" runat="server">
                </asp:DropDownList>
            
                    <asp:DropDownList ID="DropDownMesNa" runat="server">
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
            
                    <asp:DropDownList ID="DropDownAnioNa" runat="server">
                    </asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            
            <td align="left"colspan="1">                       
                Fecha Primera visita
            </td>
            <td align="left"colspan="6"> 
                <asp:TextBox ID="txtFechaPriIdent" runat="server" Columns="6" ReadOnly="True" 
                    BackColor="#CCFFFF"></asp:TextBox>
                <asp:DropDownList ID="DropDownDiaPri" runat="server">
                </asp:DropDownList>
            
                    <asp:DropDownList ID="DropDownMesPri" runat="server">
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
            
                    <asp:DropDownList ID="DropDownAnioPri" runat="server">
                    </asp:DropDownList>
            </td>
        </tr>    
        
</table>
</div>
<div class="fichaidentificacion4">
<table  >
        <tr>
            
            <td align="left"colspan="1">                       
               Foto
                <asp:Label ID="Alerta2" runat="server" Text=""></asp:Label>
            </td>
            <td align="left"colspan="6"> 
                <asp:Image ID="Image1" runat="server" width="80px" Height="90px" align="MIDDLE"  />
                </td>
        </tr>
        
        <tr>
            
            <td align="left"colspan="1">                       
               Cargar Foto
            </td>
            <td align="left"colspan="6"> 
               <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        
       <tr>
            
            <td align="left"colspan="1">                       
                Teléfono Casa
            </td>
            <td align="left"colspan="6"> 
                <asp:TextBox ID="txtTelCaIdent" runat="server" Columns="25"></asp:TextBox>
            </td>
        </tr>
        <tr>
            
            <td align="left"colspan="1">                       
                Ejemplo Tel.
            </td>
            <td align="left"colspan="6"> 
                8115147078
            </td>
        </tr>
        <tr>
            
            <td align="left"colspan="1">                       
                Teléfono Oficina
            </td>
            <td align="left"colspan="6"> 
                <asp:TextBox ID="txtTelOfiIdent" runat="server" Columns="25"></asp:TextBox>
            </td>
        </tr>
        <tr>
            
            <td align="left"colspan="1">                       
                Teléfono Movil
            </td>
            <td align="left"colspan="6"> 
                <asp:TextBox ID="txtTelMovIndent" runat="server" Columns="25"></asp:TextBox>
            </td>
        </tr>
        <tr>
            
            <td align="left"colspan="1">                       
                Correo electronico
            </td>
            <td align="left"colspan="6"> 
                <asp:TextBox ID="txtCorreoIdent" runat="server" Columns="25"></asp:TextBox>
            </td>
        </tr>
        <tr>
            
            <td align="left"colspan="1">                       
                Caso Emergencia
            </td>
            <td align="left"colspan="6"> 
                <asp:TextBox ID="txtCasoEmeIdent" runat="server" Columns="25"></asp:TextBox>
            </td>
        </tr>      
                
    
</table>
    
</div>
</div> 
<div class="fichaidentificacion3"> 
<div class="fichaidentificacion4">
<table  >
        <tr>
        <td></td>
        <td>Direccion</td>
         </tr>
         <tr>
            
            <td align="left"colspan="1">                       
                Calle
            </td>
            <td align="left"colspan="6"> 
                <asp:TextBox ID="txtCalleIdent" runat="server" Columns="25"></asp:TextBox>
            </td>
        </tr>
        <tr>
            
            <td align="left"colspan="1">                       
                No.Int
            </td>
            <td align="left"colspan="6"> 
                <asp:TextBox ID="txtNuIntIdent" runat="server" Columns="25"></asp:TextBox>
            </td>
        </tr>
        <tr>
            
            <td align="left"colspan="1">                       
                No.Ext
            </td>
            <td align="left"colspan="6"> 
                <asp:TextBox ID="txtNuExtIdent" runat="server" Columns="25"></asp:TextBox>
            </td>
        </tr>
        <tr>
            
            <td align="left"colspan="1">                       
                Colonia
            </td>
            <td align="left"colspan="6"> 
                <asp:TextBox ID="txtColoIdent" runat="server" Columns="25"></asp:TextBox>
            </td>
        </tr>
        <tr>
            
            <td align="left"colspan="1">                       
                Municipio
            </td>
            <td align="left"colspan="6"> 
                <asp:TextBox ID="txtMuniIdent" runat="server" Columns="25"></asp:TextBox>
            </td>
        </tr>
        <tr>
            
            <td align="left"colspan="1">                       
                País
            </td>
            <td align="left"colspan="6"> 
                <asp:TextBox ID="txtPaisIdent" runat="server" Columns="25"></asp:TextBox>
            </td>
        </tr>
        <tr>
            
            <td align="left"colspan="1">                       
                Código Postal 
            </td>
            <td align="left"colspan="6"> 
                <asp:TextBox ID="txtCoPosIdent" runat="server" Columns="25"></asp:TextBox>
            </td>
        </tr>
        <tr>
        <td></td>
        </tr>
    
</table>
</div>
<div class="fichaidentificacion4">

<table > 
        <tr>
            <td align="left"colspan="1">                       
                Empresa
             </td>
             
            <td align="left"colspan="6"> 
                <asp:DropDownList ID="ddlEmpresa" runat="server">
                 </asp:DropDownList>    
               
            </td>
        </tr>
        <tr>
            
            <td align="left"colspan="1">                       
                Sucursal
            </td>
            <td align="left"colspan="6"> 
                <asp:DropDownList ID="ddlSucursal" runat="server">
                 </asp:DropDownList> 
            </td>
        </tr>
        <tr>
            
            <td align="left"colspan="1">                       
                Sexo
            </td>
            <td align="left"colspan="6"> 
                <asp:DropDownList ID="ddlSexo" runat="server">
                 </asp:DropDownList> 
            </td>
        </tr>
        <tr>
            
            <td align="left"colspan="1">                       
                EdoCivil
            </td>
            <td align="left"colspan="6"> 
                <asp:DropDownList ID="ddlEdoCivil" runat="server">
                 </asp:DropDownList> 
            </td>
        </tr>
        <tr>
            
            <td align="left"colspan="1">                       
                Ocupacion
            </td>
            <td align="left"colspan="6"> 
               <asp:DropDownList ID="ddlOcupacion" runat="server">
                 </asp:DropDownList> 
            </td>
        </tr>
        <tr>
            
            <td align="left"colspan="1">                       
                Escolaridad
            </td>
            <td align="left"colspan="6"> 
               <asp:DropDownList ID="ddlEscolaridad" runat="server">
                 </asp:DropDownList> 
            </td>
        </tr>
        <tr>
            
            <td align="left"colspan="1">                       
                EmpresaConvenio
            </td>
            <td align="left"colspan="6"> 
                <asp:DropDownList ID="ddlEmpresaConvenio" runat="server">
                 </asp:DropDownList> 
            </td>
        </tr>
        <tr>
            
            <td align="left"colspan="1">                       
                ReferidoPor
            </td>
            <td align="left"colspan="6"> 
                <asp:DropDownList ID="ddlReferidoPor" runat="server">
                 </asp:DropDownList> 
            </td>
        </tr>
        <tr>
            
            <td align="left"colspan="1">                       
                Aseguradora
            </td>
            <td align="left"colspan="6"> 
                <asp:DropDownList ID="ddlAseguradora" runat="server">
                 </asp:DropDownList> 
            </td>
        </tr>

        
</table>
</div>
</div> 


<script type="text/javascript">

    function ValidNum(e) {
        var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
        return ((tecla > 47 && tecla < 58) || tecla == 08 || tecla == 46);
    }

    var txttel = '<%=txtTelCaIdent.ClientID %>';
    var txtOfi = '<%=txtTelOfiIdent.ClientID %>';
    var txtcel = '<%=txtTelMovIndent.ClientID %>';

    $(function () {


        $("#" + txttel).keypress(function (e) {
            var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
            return ((tecla > 47 && tecla < 58) || tecla == 08 || tecla == 46);


        });

        $("#" + txtOfi).keypress(function (e) {
            var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
            return ((tecla > 47 && tecla < 58) || tecla == 08 || tecla == 46);
        });

        $("#" + txtcel).keypress(function (e) {
            var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
            return ((tecla > 47 && tecla < 58) || tecla == 08 || tecla == 46);
        });
    });
   
</script>

</asp:Content>

