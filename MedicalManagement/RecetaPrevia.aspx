<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecetaPrevia.aspx.cs" Inherits="MedicalManagement.RecetaPrevia" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <table width="100%">
        <tr>
            <td align="left" colspan="6">Receta Previa&nbsp;:&nbsp;<asp:TextBox ID="txtBuscar_RecetaPrevia" runat="server" Columns="100" OnTextChanged="txt_OnTextChanged" AutoPostBack="true"></asp:TextBox>&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip="Buscar Receta Previa"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="AgregarRecetaPrevia" runat="Server" ImageUrl="IMG/agregar.png" OnClick="btnAgregarRecetaPrevia_Click" ToolTip="Agregar Receta Previa"></asp:ImageButton>
            </td>
        </tr>


        <tr>
            <td align="center" colspan="6">
                <asp:GridView ID="Grid_RecetaPrevia" runat="server" AutoGenerateColumns="False"
                    OnRowCommand="RowCommand" OnRowDeleting="RowDeleting"
                    OnPageIndexChanging="Grid_RecetaPrevia_PageIndexChanging" AllowPaging="False"
                    OnPageIndexChanged="Grid_RecetaPrevia_PageIndexChanged" CssClass="mGrid footable"
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None">


                    <Columns>
                        <asp:BoundField HeaderText="Id" DataField="Id_ConsultaRecetaPrevia" />
                        <asp:BoundField DataField="Nombre_ConsultaRecetaPrevia" HeaderText="Nombre/Descripcion"
                            SortExpression="Nombre_ConsultaRecetaPrevia" />
                        <asp:BoundField DataField="Descripcion_Diagnostico" HeaderText="Diagnostico"
                            SortExpression="Descripcion_Diagnostico" />
                        <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Editar"
                            ShowHeader="True" Text="Editar" ItemStyle-HorizontalAlign="Center" />
                        <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Eliminar"
                            ShowHeader="True" Text="Eliminar" ItemStyle-HorizontalAlign="Center" />
                    </Columns>
                </asp:GridView>



            </td>
        </tr>
    </table>
    <div class="container-fluid">
        <div class="col-xs-12">
            <div class="input-group">
                <span class="input-group-addon" id="basic-addon1">Buscar: </span>
                <asp:TextBox autocomplete="off" ID="txtSearch" runat="server" CssClass="form-control"></asp:TextBox>
                <%--<a href="RegistroFichaIdentificacion.aspx" class="input-group-addon no-sub">Agregar</a>--%>
            </div>
        </div>

    </div>
    <hr />
    <div class="container-fluid searchContainer  border-top1-bottom5"></div>
    <hr />
    <script>
        $("[id$=txtSearch]").keyup(function (e) {
            var nombre = $("[id$=txtSearch]").val();
            if (nombre !== "") {
                $.ajax({
                    type: "POST",
                    url: "GetDates.asmx/GetRecetaPreviaItems",
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
                    $('#templateRecetaPrevia').jqote(jsonObject, '*')
                ).slideDown();
            } else {
                $('.searchContainer').slideUp();
            }
        }
    </script>
    <script type="text/x-jqote-template" id="templateRecetaPrevia">
    <![CDATA[
       <div class="row">
        <div class="col-xs-12 col-md-3 col-lg-3 col-sm-3">
        <label  class="small-label">Nombre/Descripcion:</label><label  class="small-label"><*= this.Nombre_ConsultaRecetaPrevia*></label>
        </div>
        <div class="col-xs-12 col-md-3 col-lg-3 col-sm-3">
        <label  class="small-label">Diagnostico: </label><label  class="small-label"><*= this.Nombre_ConsultaRecetaPrevia*></label>
        </div>
          <div class="col-xs-12 col-md-2 col-lg-2 col-sm-2">
        <label  class="small-label">Medicamento: </label><label  class="small-label"><*= this.Nombre_ConsultaRecetaPrevia*></label>
        </div>
          <div class="col-xs-12 col-md-2 col-lg-2 col-sm-2">
        <label class="small-label">Dosis: </label><label  class="small-label"><*= this.Nombre_ConsultaRecetaPrevia*></label>
        </div>
          <div class="col-xs-12 col-md-2 col-lg-2 col-sm-2">
        <label  class="small-label">Notas: </label><label  class="small-label"><*= this.Nombre_ConsultaRecetaPrevia *></label>
        </div>
        </div>
        <hr/>
    ]]>
    </script>
</asp:Content>
