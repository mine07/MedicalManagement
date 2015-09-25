<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FichaIdentificacion.aspx.cs" Inherits="MedicalManagement.FichaIdentificacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <table width="100%" class="footable footableB hidden">
        <tr>
            <td align="left" colspan="6">
                <div style="vertical-align: middle;" class="row">
                    FichaIdentificacion&nbsp;:&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip="Buscar Perfil"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="AgregarFichaIdentiificacion" runat="Server" ImageUrl="IMG/agregar.png" OnClick="btnAgregarFichaIdentificacion_Click" ToolTip="Agregar Ficha Identificacion"></asp:ImageButton>
                </div>
            </td>
        </tr>
    </table>
    <div class="container-fluid">
        <div class="col-xs-12">
            <div class="input-group">
                <span class="input-group-addon" id="basic-addon1">Buscar: </span>
                <asp:TextBox ID="txtBuscar_FichaIdentificacion" runat="server" CssClass="form-control" autocomplete="off"></asp:TextBox>
                <a href="RegistroFichaIdentificacion.aspx" class="input-group-addon no-sub">Agregar</a>
            </div>
        </div>
    </div>
    <hr />
    <div class="container-fluid  searchContainer border-top1-bottom5">
    </div>
    <hr />
    <asp:GridView ID="Grid_FichaIdentificacion" runat="server" AutoGenerateColumns="False"
        OnRowCommand="RowCommand" OnRowDeleting="RowDeleting"
        OnPageIndexChanging="Grid_FichaIdentificacion_PageIndexChanging" AllowPaging="False"
        OnPageIndexChanged="Grid_FichaIdentificacion_PageIndexChanged" CssClass="table table-hover"
        PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None">
        <Columns>
            <asp:BoundField DataField="Id_FichaIdentificacion" HeaderText="Id.FichaIdentificacion" ControlStyle-CssClass="expand"
                SortExpression="Id_FichaIdentificacion" />
            <asp:BoundField DataField="NombreCompleto" HeaderText="NombreCompleto"
                SortExpression="NombreCompleto" />
            <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Editar" ItemStyle-Width="10%"
                ShowHeader="True" Text="Editar" ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="btn btn-primary" />
            <asp:ButtonField ButtonType="Button" ItemStyle-Width="10%" CommandName="Delete" HeaderText="Eliminar"
                ShowHeader="True" Text="Eliminar" ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="btn btn-primary" />
        </Columns>
    </asp:GridView>
    <script>
        $("[id$=txtBuscar_FichaIdentificacion]").keyup(function (e) {
            var nombre = $("[id$=txtBuscar_FichaIdentificacion]").val();
            if (nombre !== "") {
                $.ajax({
                    type: "POST",
                    url: "GetDates.asmx/GetFichas",
                    data: "{'search':'" + nombre + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        appendData(data);
                    }
                });
            } else {
                $('.searchContainer').slideUp().empty();
            }
        });

        function appendData(data) {
            var jsonObject = $.parseJSON(data.d);
            if (jsonObject[0] != null) {
                $('.searchContainer').empty();
                $('.searchContainer').append(
                    $('#template').jqote(jsonObject, '*')
                ).slideDown();
            } else {
                $('.searchContainer').slideUp();
            }
        }
    </script>
    <script type="text/x-jqote-template" id="template">
    <![CDATA[
        <div class="row">        
            <div class="col-xs-10 col-sm-4 col-md-3 col-lg-3">
                <label><*= this.Id_FichaIdentificacion + " - " + this.Nombre_FichaIdentificacion + " " + this.ApPaterno_FichaIdentificacion + " " + this.ApMaterno_FichaIdentificacion *>                
            </div>        
        <div class="col-xs-12 col-sm-4 col-md-3 col-lg-3">
        <label class="small-label"><*= this.Direccion_Calle_FichaIdentificacion + ", " + this.Direccion_Colonia_FichaIdentificacion + ", " + this.Direccion_Municipio_FichaIdentificacion + ", " + this.Direccion_Pais_FichaIdentificacion *>                
        </div>
        <div class="col-xs-12 col-sm-3 col-md-2 col-lg2">
        <label class="small-label"><*= "Casa - " + this.TelefonoCasa_FichaIdentificacion*></label>
        <label class="small-label"><*= "Movil - " + this.TelefonoMovil_FichaIdentificacion*></label>
        </div>
        <div class="col-xs-12 col-sm-1 col-md-2 col-lg-2">
        <a class="label label-secondary form-control" href='<*= "RegistroFichaIdentificacion.aspx?Id_FichaIdentificacion=" + this.Id_FichaIdentificacion*>'>Editar</a>
        <a class="label label-secondary form-control" href='<*= "RegistroAgenda.aspx?Id_FichaIdentificacion=" + this.Id_FichaIdentificacion + "&NombreCompleto=" + this.Nombre_FichaIdentificacion + " " + this.ApPaterno_FichaIdentificacion + " " + this.ApMaterno_FichaIdentificacion *>'>Agendar</a>
        
        </div>
        </div>
        <hr/>
    ]]>
    </script>
</asp:Content>
