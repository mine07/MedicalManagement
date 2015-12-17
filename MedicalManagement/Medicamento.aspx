<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicamento.aspx.cs" Inherits="MedicalManagement.Medicamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Medicamento</h3>
    <hr />
     <asp:ScriptManager runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <triggers>
                <div class="col-xs-12 col-md-8 col-lg-8 col-sm-8">            
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtBuscar_Medicamento" Columns="100" OnTextChanged="txt_OnTextChanged" placeholder="Buscar..." autocomplete="off" onfocus="ponerAlfinal(this);"></asp:TextBox>&nbsp;     
                    <asp:LinkButton ID = "AgregarMedicamento" runat="server" OnClick="btnAgregarMedicamento_Click" ToolTip = "Agregar Medicamento" Text='<label class="fa-margin-right label pull-right label label-primary"><i class="fa fa-margin-left fa-plus-circle"></i></label>' BackColor="#3333FF"></asp:LinkButton>
                    <asp:LinkButton ID = "ImageButton1" runat="server" OnClick ="txt_OnTextChanged" ToolTip = "Buscar" Text='<label class="fa-margin-right label pull-right label-success label-button"><i class="fa fa-margin-left fa-search"></i></label>'></asp:LinkButton> 
                    <hr />  
                </div>
            </triggers>

<table id="Tabla" width="100%">

        <tr>
            <td align="center"colspan="6">
                <asp:GridView ID="Grid_Medicamento" runat="server" AutoGenerateColumns="False" 
                    onrowcommand="RowCommand" onrowdeleting="RowDeleting"          
                    onpageindexchanging ="Grid_Medicamento_PageIndexChanging" AllowPaging="true" pagesize="25"
                    onpageindexchanged="Grid_Medicamento_PageIndexChanged" CssClass="table table-hover" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None" CellPadding="4" ForeColor="#333333" >
                    <AlternatingRowStyle CssClass="alt" BackColor="White"></AlternatingRowStyle>
                    

        <Columns>

            <asp:BoundField DataField="Id_Medicamento" HeaderText="Id" 
                SortExpression="Id_Medicamento" ItemStyle-Width="5%"/>


            <asp:BoundField DataField="Descripcion_Medicamento" HeaderText="Descripcion Medicamento" 
                SortExpression="Descripcion_Medicamento" ItemStyle-Width="45%"/> 
               
            <asp:BoundField DataField="Existencia" HeaderText="Exixtencia" 
                SortExpression="Existencia" ItemStyle-Width="10%"/> 

            <asp:BoundField DataField="PrecioCosto" HeaderText="Precio Costo" 
                SortExpression="PrecioCosto" ItemStyle-Width="10%"/> 

            <asp:BoundField DataField="PrecioVenta" HeaderText="Precio Venta" 
                SortExpression="PrecioVenta" ItemStyle-Width="10%"/> 

            <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Editar" 
                ShowHeader="True" Text="Editar" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"/>

            <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Eliminar" 
                 ShowHeader="True" Text="Eliminar" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"/>
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
          
          // $(document).keyup(function (event) {
           // Actualizar();
       // });

        $(document).keyup(function (tecla) {
            if (tecla.keyCode == 32||tecla.keyCode==8||tecla.keyCode==13) {
                //alert('Tecla X presionada');
                Actualizar();
            }
        });

          function Actualizar() {
              var boton = document.getElementById('<%=ImageButton1.ClientID%>');
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
