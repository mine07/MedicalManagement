<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Procedimiento.aspx.cs" Inherits="MedicalManagement.Procedimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <triggers>
                <div class="col-xs-12 col-md-8 col-lg-8 col-sm-8">            
                    Procedimiento&nbsp;:&nbsp; 
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtBuscar_Procedimiento" Columns="100" OnTextChanged="txt_OnTextChanged" placeholder="Buscar..." autocomplete="off" onfocus="ponerAlfinal(this);"></asp:TextBox>&nbsp;     
                    <!--<asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip = "Buscar Perfil"></asp:ImageButton>&nbsp;
                    <asp:ImageButton ID="AgregarProcedimiento" runat="Server" ImageUrl="IMG/agregar.png" OnClick="btnAgregarProcedimiento_Click" ToolTip = "Agregar Procedimiento"></asp:ImageButton>-->
                    <asp:LinkButton runat="server" OnClick="btnAgregarProcedimiento_Click" ToolTip = "Agregar Diagnostico" Text='<label class="fa-margin-right label pull-right label label-primary"><i class="fa fa-margin-left fa-plus-circle"></i></label>' BackColor="#3333FF"></asp:LinkButton>
                    <asp:LinkButton ID = "Buscar" runat="server" OnClick ="txt_OnTextChanged" ToolTip = "Buscar Perfil" Text='<label class="fa-margin-right label pull-right label-success label-button"><i class="fa fa-margin-left fa-search"></i></label>'></asp:LinkButton> 
                    <hr />  
                </div>
            </triggers>
    
            <table id="Tabla" width="100%">
                <tr>
                    <td align="center"colspan="6">
                        <asp:GridView ID="Grid_Procedimiento" runat="server" AutoGenerateColumns="False"      
                            onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
                            onpageindexchanging ="Grid_Procedimiento_PageIndexChanging" AllowPaging="True" pagesize="25"
                            onpageindexchanged="Grid_Procedimiento_PageIndexChanged" CssClass="mGrid" 
                            PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" CellPadding="4" ForeColor="#333333" >
                            <AlternatingRowStyle CssClass="alt" BackColor="White"></AlternatingRowStyle>
                    
   
                            <Columns>
                                <asp:BoundField DataField="Id_Procedimiento" HeaderText="Id.Procedimiento" 
                                    SortExpression="Id_Procedimiento" />

                                <asp:BoundField DataField="Descripcion_Procedimiento" HeaderText="Descripcion Procedimiento" 
                                    SortExpression="Descripcion_Procedimiento" /> 
                                  
                                <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Editar" 
                                    ShowHeader="True" Text="Editar" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:ButtonField>

                                <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Eliminar" 
                                    ShowHeader="True" Text="Eliminar" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:ButtonField>

                            </Columns>

        
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerSettings FirstPageText="&amp;nbsp;Primero&amp;nbsp;" LastPageText="&amp;nbsp;Ultimo&amp;nbsp;" Mode="NextPreviousFirstLast" NextPageText="&amp;nbsp;Siguiente&amp;nbsp;" PreviousPageText="&amp;nbsp;Anterior&amp;nbsp;" />

                            <PagerStyle CssClass="pgr" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />

                        </asp:GridView>
           
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.quicksearch.js" type="text/javascript"></script> 
    <script type="text/javascript">
          
          $(document).keyup(function (event) {
              Actualizar()

          });

          function Actualizar() {
              var boton = document.getElementById('<%=Buscar.ClientID%>');
              boton.click();
              return;
          }

          function ponerAlfinal(campo) {
              with (campo) {
                  selectionStart = selectionEnd = value.length;
                  focus();
              }

          }
    </script>
</asp:Content>
