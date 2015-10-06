<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroRecetaPrevia.aspx.cs" Inherits="MedicalManagement.RegistroRecetaPrevia" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <table width="100%" border="0">
        <tr>
            <td align="left"><font color="red">Configuración\Categoria\Agregar</font></td>
            <td align="right">
                <asp:LinkButton runat="server" ID="Guardar" OnClick="btnGuardar_Categoria_Click" Text='<label class="pull-right label label-success label-button" style="font-size: 16px;" runat="server">Guardar <i class="fa fa-margin-left fa-save"></i></label>'/>              
            </td>
            <td width="9%" align="left">
                <a href='<%= "javascript:history.back(-1);" %>'><label class="pull-right label label-primary label-button" style="font-size: 16px;">Volver<i class="fa fa-arrow-left fa-margin-left"></i></label></a>
                </td>
        </tr>
        <tr>
            <td colspan="2" align="center" runat="Server" id="Alerta"></td>
        </tr>
    </table>

    <div class="container-fluid border-top1-bottom10">
        <div class="row">
            <div class="col-xs-12 col-md-3 col-sm-3 col-lg-3">
                <label>Nombre de Receta Previa</label>
            </div>
            <div class="col-xs-12 col-md-9 col-sm-9 col-lg-9">
                <asp:TextBox ID="txtNombre_ConsultaRecetaPrevia" runat="server" CssClass="form-control" TextMode="multiline"></asp:TextBox>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-xs-12 col-md-3 col-sm-3 col-lg-3">
                <label>Diagnostico/Enfermedad</label>
            </div>
            <div class="col-xs-12 col-md-9 col-sm-9 col-lg-9">
                <asp:TextBox ID="txtDiagnostico" runat="server" CssClass="form-control"  placeholder="Buscar Diagnostico..."></asp:TextBox>
                <hr />
                <div class="container-fluid searchContainer border-top1-bottom5">
                </div>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-xs-12 col-md-3 col-sm-3 col-lg-3">
                <label>Medicamento</label>
            </div>
            <div class="col-xs-12 col-md-9 col-sm-9 col-lg-9">
                <asp:TextBox ID="txtmedicamento_consultareceta" runat="server" CssClass="form-control" TextMode="multiline"></asp:TextBox>
            </div>
        </div>
        <hr />

        <div class="row">
            <div class="col-xs-12 col-md-3 col-sm-3 col-lg-3">
                <label>Dosis</label>
            </div>
            <div class="col-xs-12 col-md-9 col-sm-9 col-lg-9">
                <asp:TextBox ID="txtdosis_consultareceta" runat="server" CssClass="form-control" TextMode="multiline"></asp:TextBox>
            </div>
        </div>
        <hr />

        <div class="row">
            <div class="col-xs-12 col-md-3 col-sm-3 col-lg-3">
                <label>Notas</label>
            </div>
            <div class="col-xs-12 col-md-9 col-sm-9 col-lg-9">
                <asp:TextBox ID="txtnotas_consultareceta" runat="server" CssClass="form-control" TextMode="multiline"></asp:TextBox>
            </div>
        </div>
        <hr />
    </div>
    <style>
        textarea {
            -moz-resize: none;
            -ms-resize: none;
            -o-resize: none;
            resize: none;
        }

        .searchContainer {
            max-height: 300px;
            overflow-x: auto;
            position: absolute;
            width: 100%;
        }
    </style>
    <script>$('[id$=txtDiagnostico]').bind('input keyup', function () {
    var $this = $(this);
    var delay; // 2 seconds delay after last input
    var value = $('[id$=txtDiagnostico]').val();
    clearTimeout($this.data('timer'));
    if (value === " ") {
        $('.searchContainer').slideUp().empty();
    }
    if (value.substr(value.length - 1) !== " ") {
        delay = 500;
    } else {
        delay = 1;
    }
    $this.data('timer', setTimeout(function () {
        $this.removeData('timer');

        diagSearch(value);
    }, delay));
});

        function diagSearch(x) {
            var nombre = x;
            if (nombre !== "") {
                $.ajax({
                    type: "POST",
                    url: "GetDates.asmx/GetDiagnosticoItems",
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
        }

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
        $(document).mouseup(function (e) {
            var container = $(".searchContainer");
            var containerB = $("[id$=txtDiagnostico]");
           
            if (!container.is(e.target) // if the target of the click isn't the container...
                && container.has(e.target).length === 0 && !containerB.is(e.target)) // ... nor a descendant of the container
            {
                container.slideUp();
            }
            var containerC = $("h5");
            if (containerC.is(e.target))
            {
                container.slideUp();
            }
        });

        $("[id$=txtDiagnostico]").focus(function () {
            if ($('.searchContainer').children().length !== 0) {
                $('.searchContainer').slideDown();
            }
        });

        function upText(x) {
            var val = $(x).closest('.row').find('h5');
            $("[id$=txtDiagnostico]").val(val.html());
        }

    </script>
    <script type="text/x-jqote-template" id="template">
    <![CDATA[        
        <div class="row row-hover" onclick="upText(this);">
        <div class="col-xs-12 col-md-12 col-sm-12 col-lg-12">        
        <h5><*= this.Descripcion_Diagnostico*></h5>
        <hr />
        </div>       
        </div>
    ]]>
    </script>
</asp:Content>
