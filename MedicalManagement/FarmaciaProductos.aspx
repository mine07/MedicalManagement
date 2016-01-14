<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FarmaciaProductos.aspx.cs" Inherits="MedicalManagement.FarmaciaProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <h3>Productos Farmacia</h3>
    <hr />
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

    <triggers>      
                <div class="col-xs-12 col-md-8 col-lg-8 col-sm-8"> 
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtBuscar_Medicamento" Columns="100" OnTextChanged="txt_OnTextChanged" placeholder="Buscar..." autocomplete="off" onfocus="ponerAlfinal(this);"></asp:TextBox>&nbsp;     
                    <%--<asp:TextBox CssClass="form-control" runat="server" ID="txtBuscar_Diagnostico2" Columns="100" OnTextChanged="txt_OnTextChanged" placeholder="Buscar..." autocomplete="off" onfocus="ponerAlfinal(this);"></asp:TextBox>&nbsp;     
                    <asp:ImageButton ID="ImageRegresar" runat="Server" ImageUrl="IMG/Regresar.png"  ToolTip = "Regresar" onclick="btnRegresar_ConsultasDiagnostico_Click"></asp:ImageButton>--%>
                    <asp:LinkButton runat="server" OnClick="btnGuardar_Producto" ToolTip = "Agregar Diagnostico" Text='<label class="fa-margin-right label pull-right label label-primary"><i class="fa fa-margin-left fa-plus-circle"></i></label>' BackColor="#3333FF"></asp:LinkButton>
                    <asp:LinkButton ID = "Buscar" runat="server" OnClick ="txt_OnTextChanged" ToolTip = "Buscar Perfil" Text='<label class="fa-margin-right label pull-right label-success label-button"><i class="fa fa-margin-left fa-search"></i></label>'></asp:LinkButton>                                                                                          
                    <hr />   
                </div>
            </triggers>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" 
        DataKeyNames="Id_Productos" DataSourceID="SqlDataSource1" ForeColor="#333333" 
        GridLines="None" Width="1016px" AllowPaging="True" CssClass="table table-hover" 
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="Id_Productos" HeaderText="Id_Productos" InsertVisible="False" ReadOnly="True" SortExpression="Id_Productos" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
            <asp:BoundField DataField="PrecioCompra" HeaderText="PrecioCompra" SortExpression="PrecioCompra" />
            <asp:BoundField DataField="Existencias" HeaderText="Existencias" SortExpression="Existencias" />
            <asp:BoundField DataField="PrecioVenta" HeaderText="PrecioVenta" SortExpression="PrecioVenta" />
            <asp:BoundField DataField="Minimo" HeaderText="Minimo" SortExpression="Minimo" />
            <asp:CheckBoxField DataField="Activo" HeaderText="Activo" SortExpression="Activo" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
        DeleteCommand="DELETE FROM [Tabla_Catalogo_ProductosFarmacia] WHERE [Id_Productos] = @Id_Productos" 
        InsertCommand="INSERT INTO [Tabla_Catalogo_ProductosFarmacia] ([Nombre], [Descripcion], [PrecioCompra], [Existencias], [PrecioVenta], [Minimo], [Activo]) VALUES (@Nombre, @Descripcion, @PrecioCompra, @Existencias, @PrecioVenta, @Minimo, @Activo)" 
        SelectCommand="SELECT * FROM [Tabla_Catalogo_ProductosFarmacia] WHERE ([Descripcion] LIKE '%' + @Descripcion + '%')"
        UpdateCommand="UPDATE [Tabla_Catalogo_ProductosFarmacia] SET [Nombre] = @Nombre, [Descripcion] = @Descripcion, [PrecioCompra] = @PrecioCompra, [Existencias] = @Existencias, [PrecioVenta] = @PrecioVenta, [Minimo] = @Minimo, [Activo] = @Activo WHERE [Id_Productos] = @Id_Productos">
        
        <DeleteParameters>
            <asp:Parameter Name="Id_Productos" Type="Int32" />
        </DeleteParameters>

        <InsertParameters>
            <asp:Parameter Name="Nombre" Type="String" />
            <asp:Parameter Name="Descripcion" Type="String" />
            <asp:Parameter Name="PrecioCompra" Type="Decimal" />
            <asp:Parameter Name="Existencias" Type="Int32" />
            <asp:Parameter Name="PrecioVenta" Type="Decimal" />
            <asp:Parameter Name="Minimo" Type="Int32" />
            <asp:Parameter Name="Activo" Type="Boolean" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="txtBuscar_Medicamento" DefaultValue=" " Name="Descripcion" PropertyName="Text" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Nombre" Type="String" />
            <asp:Parameter Name="Descripcion" Type="String" />
            <asp:Parameter Name="PrecioCompra" Type="Decimal" />
            <asp:Parameter Name="Existencias" Type="Int32" />
            <asp:Parameter Name="PrecioVenta" Type="Decimal" />
            <asp:Parameter Name="Minimo" Type="Int32" />
            <asp:Parameter Name="Activo" Type="Boolean" />
            <asp:Parameter Name="Id_Productos" Type="Int32" />
        </UpdateParameters>
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

          function ponerAlfinal(campo) {
              with (campo) {
                  selectionStart = selectionEnd = value.length;
                  focus();
              }

          }
    </script>
</asp:Content>