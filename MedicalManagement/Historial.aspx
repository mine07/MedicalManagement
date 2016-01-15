<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Historial.aspx.cs" Inherits="MedicalManagement.Historial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Historial de Ventas</h3>
    <hr />
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

    <triggers>      
                <div class="col-xs-12 col-md-8 col-lg-8 col-sm-8"> 
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtBuscar_Medicamento" Columns="100" OnTextChanged="txt_OnTextChanged" placeholder="Buscar Ticket..." autocomplete="off" onfocus="ponerAlfinal(this);"></asp:TextBox>&nbsp;     
                    <%--<asp:TextBox CssClass="form-control" runat="server" ID="txtBuscar_Diagnostico2" Columns="100" OnTextChanged="txt_OnTextChanged" placeholder="Buscar..." autocomplete="off" onfocus="ponerAlfinal(this);"></asp:TextBox>&nbsp;     
                    <asp:ImageButton ID="ImageRegresar" runat="Server" ImageUrl="IMG/Regresar.png"  ToolTip = "Regresar" onclick="btnRegresar_ConsultasDiagnostico_Click"></asp:ImageButton>--%>
                    <%--<asp:LinkButton runat="server" OnClick="btnGuardar_Producto" ToolTip = "Agregar Diagnostico" Text='<label class="fa-margin-right label pull-right label label-primary"><i class="fa fa-margin-left fa-plus-circle"></i></label>' BackColor="#3333FF"></asp:LinkButton>--%>
                    <asp:LinkButton ID = "Buscar" runat="server" OnClick ="txt_OnTextChanged" ToolTip = "Buscar Perfil" Text='<label class="fa-margin-right label pull-right label-success label-button"><i class="fa fa-margin-left fa-search"></i></label>'></asp:LinkButton>                                                                                          
                    <hr />   
                </div>
            </triggers>
 <table width="100%">
     <tr>
            <th align="center"colspan="6">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" 
        DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="30" CssClass="table table-hover" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                <AlternatingRowStyle CssClass="alt" BackColor="White"></AlternatingRowStyle>
        <Columns>
            <%--<asp:BoundField DataField="Id_Ticket" HeaderText="Id_Ticket" InsertVisible="False" ReadOnly="True" SortExpression="Id_Ticket" />--%>
            <asp:BoundField DataField="No_Tiket" HeaderText="No Tiket" SortExpression="No_Tiket" ItemStyle-Width="10%"/>
           <%-- <asp:BoundField DataField="Id_Medicamento" HeaderText="Id_Medicamento" SortExpression="Id_Medicamento" />--%>
            <asp:BoundField DataField="NombreMedicamento" HeaderText="Descripcion" SortExpression="NombreMedicamento" ItemStyle-Width="25%" />
            <asp:BoundField DataField="RazonSocial" HeaderText="RazonSocial" SortExpression="RazonSocial" ItemStyle-Width="25%"/>
            <asp:BoundField DataField="Costo" HeaderText="Costo" SortExpression="Costo" ItemStyle-Width="10%" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" ItemStyle-Width="30%" />
            <%--<asp:CheckBoxField DataField="Activo" HeaderText="Activo" SortExpression="Activo" />--%>
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
            </th>
                </tr>
                <tr >
                    <th style ="width:10%"></th>
                    <th style ="width:25%"></th>
                    <th style ="width:25%">Total:</th>
                    <th style ="width:10%">$<asp:Label ID="Label1" runat="server" Text=""></asp:Label></th>
                    <th style ="width:30%" ></th>
                </tr>
            </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
        SelectCommand="SELECT [No_Tiket], [NombreMedicamento], [RazonSocial], [Costo], [Fecha] FROM [Tabla_Catalogo_Ticket] WHERE ([No_Tiket] = @No_Tiket)">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtBuscar_Medicamento" DefaultValue="" Name="No_Tiket" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</ContentTemplate>
    </asp:UpdatePanel>

    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.quicksearch.js" type="text/javascript"></script> 
    <script type="text/javascript">

        // $(document).keyup(function (event) {
        // Actualizar();
        // });

        $(document).keyup(function (tecla) {
            if (tecla.keyCode == 32 || tecla.keyCode == 8 || tecla.keyCode == 13) {
                //alert('Tecla X presionada');
                Actualizar();
            }
        });

        function Actualizar() {
            var boton = document.getElementById('<%=Buscar.ClientID%>');
            boton.click();
            return;
        }

        function Total() {
            $("#alert").removeClass("hidden");
            $("#alerta2").text("¡ERROR!, Ingrese un Medicamento.");
        }

        function ponerAlfinal(campo) {
            with (campo) {
                selectionStart = selectionEnd = value.length;
                focus();
            }

        }
    </script>

</asp:Content>
