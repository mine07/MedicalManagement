<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Facturar.aspx.cs" Inherits="MedicalManagement.Facturar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Facturaciòn</h2>
    </div>
    <div class="row">
        <div class="col-xs-12 col-md-8 col-lg-8 col-sm-">
            <asp:TextBox CssClass="form-control" runat="server" ID="txtSearch" placeholder="Buscar RFC..." autocomplete="off" Width="100%"></asp:TextBox>
            <asp:LinkButton ID="AgregarRFC" runat="server" OnClick="btnAgregarRFC_Click" ToolTip="Agregar RFC" Text='<label class="fa-margin-right label pull-right label label-primary"><i class="fa fa-margin-left fa-plus-circle"></i></label>' BackColor="#3333FF"></asp:LinkButton>
            <div class="container-fluid searchContainer searchProc border-top1-bottom5">
            </div>
        </div>
    </div>
    <hr />

    <div>
        <table width="100%" border="1">
            <tr>
                <td colspan="2" align="right">
                    <table border="1">
                        <tr>
                            <th class="h1">Serie</th>
                            <td class="h1">FDXA</td>
                        </tr>
                        <tr>
                            <th class="h1">Folio</th>
                            <td class="h1">000001</td>
                        </tr>
                        <tr>
                            <th class="h1">Fecha</th>
                            <td class="h1">2013-12-22T10:28:15</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="50%">
                    <tab
                        le width="100%" border="1">
                        <tr>
                            <th colspan="2" class="h1">Emisor</th>
                        </tr>
                        <tr>
                            <th>RFC</th>
                            <td>FJC780315E91</td>
                        </tr>
                        <tr>
                            <th>Nombre</th>
                            <td>FABRICA DE JABON LA CORONA SA DE CV</td>
                        </tr>
                        <tr>
                            <th colspan="2" class="h2">Domicilio</th>
                        </tr>
                        <tr>
                            <td colspan="2">CARLOS B. ZETINA # 80 - </td>
                        </tr>
                        <tr>
                            <td colspan="2">PARQUE INDUSTRIAL XALOSTOC</td>
                        </tr>
                        <tr>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td colspan="2">ECATEPEC DE MORELOS CODIGO POSTAL 55348</td>
                        </tr>
                        <tr>
                            <td colspan="2">MEXICO</td>
                        </tr>
                        <tr>
                            <td colspan="2">MEXICO</td>
                        </tr>
                    </tab>
                </td>
                <td width="50%">
                    <table width="100%" border="1">
                        <tr>
                            <th colspan="2" class="h1">Receptor</th>
                        </tr>
                        <tr>
                            <th>RFC</th>
                            <td>XAXX010101000</td>
                        </tr>
                        <tr>
                            <th>Nombre</th>
                            <td>FABRICA DE JABON LA CORONA,S.A.C.V</td>
                        </tr>
                        <tr>
                            <th colspan="2" class="h2">Domicilio</th>
                        </tr>
                        <tr>
                            <td colspan="2">CARLOS B. ZETINA # 80 - </td>
                        </tr>
                        <tr>
                            <td colspan="2">FRACC.INDUSTRIAL XALOSTOC</td>
                        </tr>
                        <tr>
                            <td colspan="2">ECATEPEC DE MORELOS</td>
                        </tr>
                        <tr>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td colspan="2">ECATEPEC CODIGO POSTAL 55340</td>
                        </tr>
                        <tr>
                            <td colspan="2">ESTADO DE MEXICO</td>
                        </tr>
                        <tr>
                            <td colspan="2">MEXICO</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <table width="100%" border="1">
                    <tr>
                        <th>Cantidad</th>
                        <th>Descripcion</th>
                        <th>Precio</th>
                        <th>Importe</th>
                    </tr>
                    <tr>
                        <td align="center">1</td>
                        <td>VARIOS</td>
                        <td align="right">1</td>
                        <td align="right">1.00</td>
                    </tr>
                    <tr>
                        <td colspan="2" align="right">IVA</td>
                        <td align="right">0.16</td>
                        <td>16.00 %</td>
                    </tr>
                </table>
            </tr>
        </table>
        <hr>
        <table width="100%" border="1">
            <tr>
                <th>Numero de serie del Certificado</th>
            </tr>
            <tr>
                <td>00001100000200000154</td>
            </tr>
            <tr>
                <th>Sello Digital</th>
            </tr>
            <tr>
                <td><small><small>E0q9sxQ6IfmhONw+BuQPdyoYsMKZ7tqOSYObCg5vCU6IidFNgPnXSswHv34w9ZnWAbMiL687T+B3LvIsj+XYGjR70gtfkSD7buBGlVpgSildMgreVBydMLI/+SjbVlSiR21SYB52HWOcsc4A/43lIVhWcE5cpvIAgGVosjMvy58=</small></small></td>
            </tr>
        </table>
        <center>
        Este documento es una impresion de un comprobante fiscal digital por Internet
        </center>
    </div>

    <script>
        $('[id$=txtSearch]').bind('input keyup', function () {
            var $this = $(this);
            var delay; // 2 seconds delay after last input
            var value = $('[id$=txtSearch]').val();
            clearTimeout($this.data('timer'));
            if (value === " ") {
                $('.searchContainer').hide().empty();
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
                    url: "GetDates.asmx/GetClienteMorales",
                    data: "{'search':'" + nombre + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        appendData(data);
                    }
                });
            } else {
                $('.searchContainer').hide().empty();
            }
        }

        function appendData(data) {
            var jsonObject = $.parseJSON(data.d);
            if (jsonObject[0] != null) {
                $('.searchContainer').empty();
                $('.searchContainer').append(
                    $('#template').jqote(jsonObject, '*')
                ).show();
                $('.searchContainer').append(
                    $('#template2').jqote(jsonObject, '*')
                ).show();
            } else {
                $('.searchContainer').hide();
            }
        }
        $(document).mouseup(function (e) {
            var container = $(".searchContainer");
            var containerB = $("[id$=txtSearch]");
            if (!container.is(e.target) // if the target of the click isn't the container...
                && container.has(e.target).length === 0 && !containerB.is(e.target)) // ... nor a descendant of the container
            {
                container.hide();
            }
            var containerC = $("h5");
            if (containerC.is(e.target)) {
                container.hide();
            }
        });

        $("[id$=txtSearch]").focus(function () {
            if ($('.searchContainer').children().length !== 0) {
                $('.s   ').show();
            }
        });

        function upText(x) {
            var val = $(x).closest('.row').find('h5');
            $("[id$=txtSearch]").val(val.html());
        }

        $("[id$=ddlTemplate]").change(function () {
            var x = $("[id$=ddlTemplate]").val();
            $.ajax({
                type: "POST",
                url: "GetDates.asmx/loadTemplate",
                data: "{'Id_Template':'" + x + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    appendTemplate(data);
                }
            });
        });
        function appendTemplate(data) {
            var jsonObject = $.parseJSON(data.d);
            var Tem_Nombre = jsonObject[0].Tem_Nombre;
            $(".recetaNombre").text(Tem_Nombre);
            $('#Template-Container').empty().append($('#templateTemplate').jqote(jsonObject, '*'));
        }
    </script>

    <script type="text/x-jqote-template" id="template">
    <![CDATA[        
        <div class="row row-hover" onclick="upText(this);">
        <div class="col-xs-12 col-md-12 col-sm-12 col-lg-12">        
        <h5 uid="<*= this.Id_Clientes *>"><*= this.Nombre*></h5>
        <hr />
        </div>       
        </div>
    ]]>
    </script>
</asp:Content>
