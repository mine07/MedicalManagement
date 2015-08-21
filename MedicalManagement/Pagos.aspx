﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pagos.aspx.cs" Inherits="MedicalManagement.Pagos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- jTable style file -->
    <link href="/Scripts/jtable/themes/metro/blue/jtable.css" rel="stylesheet" type="text/css" />

    <!-- A helper library for JSON serialization -->
    <script type="text/javascript" src="/Scripts/jtable/external/json2.js"></script>
    <!-- Core jTable script file -->
    <script type="text/javascript" src="/Scripts/jtable/jquery.jtable.js"></script>
    <!-- ASP.NET Web Forms extension for jTable -->
    <script type="text/javascript" src="/Scripts/jtable/extensions/jquery.jtable.aspnetpagemethods.js"></script>
    <script type="text/javascript" src="/Scripts/jtable/localization/jquery.jtable.es.js"></script>
    <link href="/Scripts/validationEngine/validationEngine.jquery.css" rel="stylesheet" type="text/css" />
 
<!-- Import Javascript files for validation engine (in Head section of HTML) -->
<script type="text/javascript" src="/Scripts/validationEngine/jquery.validationEngine.js"></script>
<script type="text/javascript" src="/Scripts/validationEngine/jquery.validationEngine-en.js"></script>
    <div class="container-fluid border-top1-bottom5">
        <div class="row">
            <div class="col-xs-12 col-sm-2 col-lg-2 col-md-2">
                <div class="row">
                    <div class="col-xs-12 col-sm-12 col-lg-12 col-md-12 text-right">
                        <div class="dropdown">
                            <button class="btn btn-default dropdown-toggle form-control" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                                <span id="ddl">Filtro...</span>
                                <span class="caret"></span>
                            </button>
                            <ul class="dropdown-menu" aria-labelledby="dropdownMenu1">
                                <li class="text"><a href="#">Por Cobrar y Cobrado</a></li>
                                <li class="text"><a href="#">Por Cobrar</a></li>
                                <li class="text"><a href="#">Cobrado</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-xs-12 col-sm-12 col-lg-12 col-md-12 text-center">
                        <label>Entre</label>
                    </div>
                    <div class="col-xs-6 col-sm-6 col-lg-6 col-md-6">
                        <input class="datetimepicker form-control" type="text" />
                    </div>
                    <div class="col-xs-6 col-sm-6 col-lg-6 col-md-6">
                        <input class="datetimepicker form-control" type="text" />
                    </div>
                </div>
            </div>
            <div class="col-xs-12 col-sm-10 col-lg-10 col-md-10 hidden-xs">
                <div id="gridPagos"></div>
            </div>

        </div>
    </div>
    <script>
        $("li.text").click(function () {
            $("#ddl").text($(this).text());
        });

        jQuery('.datetimepicker').datetimepicker({
            timepicker: false,
            format: 'Y/m/d'
        });

        $(document).ready(function () {

            //Prepare jtable plugin
            $('#gridPagos').jtable({
                title: 'Pagos',
                paging: true, //Enables paging
                pageSize: 10, //Actually this is not needed since default value is 10.
                sorting: true, //Enables sorting
                defaultSorting: 'Id_Pagos desc', //Optional. Default sorting on first load.
                actions: {
                    listAction: 'Pagos.aspx/GetPagosItems',
                    createAction: 'Pagos.aspx/Create',
                    updateAction: 'Pagos.aspx/Update'
                    //deleteAction: '/PagingAndSorting.aspx/DeleteStudent'
                },
                fields: {
                    Id_Pagos: {
                        key: true,
                        create: false,
                        edit: false,
                        list: false
                    },
                    Id_FichaIdentificacion: {
                        title: 'Nombre',
                        width: '10%',
                        display: function (data) {
                            return data.record.oneUsuario.Nombre_FichaIdentificacion + data.record.oneUsuario.ApPaterno_FichaIdentificacion;
                        },
                        options: 'Pagos.aspx/GetFichasPagos'

                    },
                    FechaAlta_Pagos: {
                        title: 'Fecha Alta',
                        width: '10%',
                        type: 'date'
                    },
                    Descripcion_Pagos: {
                        title: 'Descripcion',
                        width: '15%'
                    },
                    Origen_Pagos: {
                        title: 'Origen',
                        width: '10%'
                    },
                    Importe_Pagos: {
                        title: 'Importe',
                        width: '10%'
                    },
                    Pagado_Pagos: {
                        title: 'Pagado',
                        width: '10%'
                    },
                    Debe_Pagos: {
                        title: 'Debe',
                        width: '10%'
                    },
                    FechaParaPagar_Pagos: {
                        title: 'FPP',
                        width: '10%',
                        type: 'date'
                    },
                    FechaPagado_Pagos: {
                        title: 'FP',
                        width: '10%',
                        type: 'date'
                    }
                },
                formCreated: function (event, data) {
                    $(data.form).addClass("custom_horizontal_form_field");
                data.form.find('input[name="Id_FichaIdentificacion"]').addClass('validate[required]');
                data.form.find('input[name="Importe_Pagos"]').addClass('validate[required,custom[number]]');
                data.form.validationEngine();
            },
            //Validate form when it is being submitted
            formSubmitting: function (event, data) {
                return data.form.validationEngine('validate');
            },
            //Dispose validation logic when form is closed
            formClosed: function (event, data) {
                data.form.validationEngine('hide');
                data.form.validationEngine('detach');
            }
        });
        //Load student list from server
        $('#gridPagos').jtable('load');
        });

    </script>
    <style>
        .ui-state-hover, .ui-state-focus, .ui-state-focus {
            background-color: transparent !important;
            border: 0 !important;
        }

        .custom_horizontal_form_field .jtable-input-field-container {
            width: 400px !important;
        }

        .ui-widget-content {
            background-color: white;
            padding: 0;
        }

        .custom_horizontal_form_field .jtable-input-field-container .jtable-input-label {
            width: 150px !important;
            float: left !important;
        }
    </style>
</asp:Content>
