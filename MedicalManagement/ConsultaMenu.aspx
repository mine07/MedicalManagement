<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaMenu.aspx.cs" Inherits="MedicalManagement.ConsultaMenu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <font color="blue"><strong>
        Paciente:</strong><asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>

        </font>
        
    </div>
    <div>
        <p>_____</p>
    </div>    
    <div>
    
                <asp:GridView ID="GridViewFecha" runat="server" AutoGenerateColumns="false">
                    <Columns>
            
                        <asp:BoundField DataField="Id_Consulta" HeaderText="Id.Consulta" 
                        SortExpression="Id_Consulta" />

                        <asp:BoundField DataField="Fecha_Consulta" HeaderText="Fecha de Consultas" 
                        SortExpression="Fecha_Consulta" />
                    </Columns>

                </asp:GridView>
     </div>      
        <div>
                <asp:Button ID="btnantecedentes" runat="server" Text="antecedentes" 
                    onclick="btnantecedentes_Click" />

        </div>   
        <div>
            <asp:TextBox ID="txtantecedentes" runat="server" Width="120" TextMode="MultiLine" Rows="6"  ></asp:TextBox>
        </div>   
        <div>
        
        </div>
        <div>
            <asp:LinkButton ID="LinkNotaClinica" runat="server" 
            onclick="LinkNotaClinica_Click">Nota Clinica</asp:LinkButton>
        </div>
    
        <div>
            <asp:LinkButton ID="LinkReceta" runat="server" onclick="LinkReceta_Click" 
                Visible="False">Receta Medica</asp:LinkButton>
        </div>
        <div>
    
        </div>
           



        <div>
                <asp:GridView ID="GridViewDiagnosticosActivos" runat="server" 
                    AutoGenerateColumns="False" >
                    

                <Columns>
            
                    <asp:BoundField DataField="Id_Diagnostico" HeaderText="Id.Diagnostico" 
                     SortExpression="Id_Diagnostico" />

                     <asp:BoundField DataField="Descripcion_Diagnostico" HeaderText="Activo              " 
                     SortExpression="Descripcion_Diagnostico" />                     

                     <asp:BoundField DataField="Estatus_ConsultaDiagnostico" HeaderText="Estatus.ConsultaDiagnostico" 
                     SortExpression="Estatus_ConsultaDiagnostico" />

                     <asp:BoundField DataField="Fecha_ConsultaDiagnostico" HeaderText="Fecha" 
                     SortExpression="Fecha_Diagnostico" />

                    

                     <asp:TemplateField  HeaderText="Elegir">
                     <HeaderTemplate>
                     Elegir
                     </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox  ID="CheckBoxelegir" runat="server" OnCheckedChanged="CheckBoxactivo_CheckedChanged" AutoPostBack="true"  />
                        </ItemTemplate>
                     </asp:TemplateField>

                </Columns>
                </asp:GridView>
          </div>  
        
   
          <div>
                    <asp:GridView ID="GridViewDiagnosticosInactivos" runat="server" AutoGenerateColumns="False">
                    <Columns>
            
                    <asp:BoundField DataField="Id_Diagnostico" HeaderText="Id.Diagnostico" 
                     SortExpression="Id_Diagnostico" />

                     <asp:BoundField DataField="Descripcion_Diagnostico" HeaderText="Inactivo            " 
                     SortExpression="Descripcion_Diagnostico" />                     

                     <asp:BoundField DataField="Estatus_ConsultaDiagnostico" HeaderText="Estatus.ConsultaDiagnostico" 
                     SortExpression="Estatus_ConsultaDiagnostico" />

                     <asp:BoundField DataField="Fecha_ConsultaDiagnostico" HeaderText="Fecha" 
                     SortExpression="Fecha_Diagnostico0" />

                     <asp:TemplateField  HeaderText="Elegir">
                     <HeaderTemplate>
                     Elegir
                     </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox  ID="CheckBoxelegir" runat="server" OnCheckedChanged="CheckBoxinactivo_CheckedChanged" AutoPostBack="true"   />
                        </ItemTemplate>
                     </asp:TemplateField>

                    </Columns>

                    </asp:GridView>
        </div>  
        <div>
                <asp:TextBox ID="txtnotasrelevantes" runat="server" Width="120" TextMode="MultiLine" Rows="6"  ></asp:TextBox>
        </div>
        <div>
                <asp:GridView ID="GridViewProcedimientos" runat="server" AutoGenerateColumns="false">
                    <Columns>
            
                        <asp:BoundField DataField="Id_Procedimiento" HeaderText="Id.Procedimiento" 
                        SortExpression="Id_Procedimiento" />

                        <asp:BoundField DataField="Descripcion_Procedimiento" HeaderText="Procedimiento" 
                        SortExpression="Descripcion_Procedimiento" />

                        <asp:BoundField DataField="Fecha_ConsultaProcedimiento" HeaderText="Fecha Procedimientos" 
                        SortExpression="Fecha_ConsultaProcedimiento" />
                    </Columns>

                </asp:GridView>
        </div>
               
      
        <div>
<p>_____
    </p>
<p><strong><font color="blue">Historial</font></strong></p>
<p>_____</p>
        </div>
        <div id="consultasanteriores" runat="server"  >
    
        </div> 

</asp:Content>
