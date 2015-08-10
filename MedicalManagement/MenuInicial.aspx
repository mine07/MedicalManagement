﻿<%@ Page Title="Medical Management" Language="C#" MasterPageFile="Site.master" AutoEventWireup="true"
    CodeBehind="MenuInicial.aspx.cs" Inherits="MedicalManagement.MenuInicial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table width="100%" border="0">
        <td colspan="2" align="center" runat="Server" id="Alerta"></td>
    </table>
    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-12 col-md-12 col-sm-12 col-lg-12">
                <div class="container-fluid">
                    <label class="blue hidden-md hidden-lg hidden-sm">Pacientes</label>
                    <div class="col-xs-12">
                        <div class="input-group">
                            <span class="input-group-addon hidden-xs blue" id="basic-addon1">Pacientes</span>
                            <asp:TextBox ID="txtBuscar_FichaIdentificacion" runat="server" CssClass="form-control"></asp:TextBox>
                            <a href="RegistroFichaIdentificacion.aspx" class="input-group-addon no-sub">Agregar</a>
                        </div>
                    </div>
                </div>
                <hr class="blue-hr" />
                <div class="container-fluid searchContainer border-top1-bottom5">
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-6 text-right">
                    <label id="lblAgenda" class="label label-primary center text-uppercase">agenda</label>
            </div>
            <div class="col-xs-6 text-left">
                    <label id="lblConsulta" class="label label-primary center text-uppercase">Consulta</label>
            </div>
            
        </div>
        <hr class="blue-hr" />
        <div class="row" id="calendarAgenda">
            <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                <div class="responsive-calendar  contCalendar">
                    <div class="controls">
                        <span class="pull-left" data-go="prev">
                            <div class="btn btn-Primary label-primary label">Prev</div>
                        </span>
                        <h4>Agenda <span data-head-year></span>-<span data-head-month></span></h4>
                        <span class="pull-right" data-go="next">
                            <div class="btn btn-Primary label-primary label">Sig</div>
                        </span>
                    </div>
                    <hr />
                    <div class="day-headers">
                        <div class="day header">Lun</div>
                        <div class="day header">Mar</div>
                        <div class="day header">Mie</div>
                        <div class="day header">Jue</div>
                        <div class="day header">Vie</div>
                        <div class="day header">Sab</div>
                        <div class="day header">Dom</div>
                    </div>
                    <div class="days" data-group="days">
                        <!-- the place where days will be generated -->
                    </div>
                </div>
            </div>
            <div class="col-xs-12 col-sm-8 col-md-8 col-lg-8" id="rowsContainer">
            </div>
        </div>
        
         <div class="row" id="calendarConsulta">
            <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                <div class="responsive-calendar  contCalendar">
                    <div class="controls">
                        <span class="pull-left" data-go="prev">
                            <div class="btn btn-Primary label-primary label">Prev</div>
                        </span>
                        <h4>Consulta <span data-head-year></span>-<span data-head-month></span></h4>
                        <span class="pull-right" data-go="next">
                            <div class="btn btn-Primary label-primary label">Sig</div>
                        </span>
                    </div>
                    <hr />
                    <div class="day-headers">
                        <div class="day header">Lun</div>
                        <div class="day header">Mar</div>
                        <div class="day header">Mie</div>
                        <div class="day header">Jue</div>
                        <div class="day header">Vie</div>
                        <div class="day header">Sab</div>
                        <div class="day header">Dom</div>
                    </div>
                    <div class="days" data-group="days">
                        <!-- the place where days will be generated -->
                    </div>
                </div>
            </div>
            <div class="col-xs-12 col-sm-8 col-md-8 col-lg-8">
            </div>
        </div>
    </div>
    <script>

        $("#lblAgenda").click(function () {
            $("#calendarAgenda").slideDown();
            $("#calendarConsulta").slideUp();
        });
        $("#lblConsulta").click(function () {
            $("#calendarAgenda").slideUp();
            $("#calendarConsulta").slideDown();
        });
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
        $("[id$=txtBuscar_FichaIdentificacion]").blur(function () {

            $('.searchContainer').slideUp();
        });

        $("[id$=txtBuscar_FichaIdentificacion]").focus(function () {
            if ($('.searchContainer').children().length !== 0) {
                $('.searchContainer').slideDown();
            }
        });
        function appendData(data) {
            var jsonObject = $.parseJSON(data.d);
            if (jsonObject[0] != null) {
                $('.searchContainer').empty();
                $('.searchContainer').append(
                    $('#templateFichas').jqote(jsonObject, '*')
                ).slideDown();
            } else {
                $('.searchContainer').slideUp();
            }
        }

        $(document).ready(function () {
            $("#calendarAgenda").hide();
            $("#calendarConsulta").hide();
            var jsonObject;
            var eventB = {};
            $.ajax({
                type: "POST",
                url: "GetDates.asmx/GetAgenda",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var index = 0;
                    jsonObject = $.parseJSON(data.d);
                    $.each(jsonObject, function () {
                        var number = jsonObject[index].cantidad;
                        eventB[jsonObject[index].date.substring(0, jsonObject[index].date.length - 9)] = { "number": number, "badgeClass": "badge badge-calendar" };
                        index++;
                    });
                    $('.responsive-calendar').responsiveCalendar({
                        events: eventB,
                        onDayClick: onDayClick,
                        monthChangeAnimation: false
                    });
                }
            });

        });

        function fillAgenda(data) {
            var jsonObject = $.parseJSON(data.d);
            console.log(jsonObject);
            $('#rowsContainer').empty().hide();
            $('#rowsContainer').fadeIn(200);
            $('#rowsContainer').append(
                $('#templateCalendar').jqote(jsonObject, '*')
            );

        }

        function addLeadingZero(num) {
            if (num < 10) {
                return "0" + num;
            } else {
                return "" + num;
            }
        }


        function onDayClick(events) {
            var day = $(this).data("day");
            var month = $(this).data("month");
            var year = $(this).data("year");
            var getItem = { day: day, month: month, year: year };
            $.ajax({
                type: "POST",
                url: "GetDates.asmx/GetAgendaItems",
                data: JSON.stringify({ 'getDate': getItem }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    fillAgenda(data);
                }
            });
        }
    </script>
    <script type="text/x-jqote-template" id="templateCalendar">
    <![CDATA[
        <div class="row border-top1-bottom5">        
            <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                <label><*= this.UsuarioDTO.Nombre_FichaIdentificacion + " " + this.UsuarioDTO.ApPaterno_FichaIdentificacion + " " + this.UsuarioDTO.ApMaterno_FichaIdentificacion *>                
            </div>        
        <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                <div class="row">
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                    <label class="small-label"><*= this.InicioCita + " - " + this.FinCita*></label> 
                    </div>
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                    <label class="small-label"><*= "Estado - " + this.EstadoCitas_Agenda*></label> 
                    </div>
                </div>            
        </div>
        <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4 center-text">
            <a class="btn btn-primary" href='<*= "RegistroAgenda.aspx?Id_Agenda=" + this.Id_Agenda + "&Id_FichaIdentificacion=" + this.UsuarioDTO.Id_FichaIdentificacion + "&NombreCompleto=" + this.UsuarioDTO.Nombre_FichaIdentificacion + " " + this.UsuarioDTO.ApPaterno_FichaIdentificacion + " " + this.UsuarioDTO.ApMaterno_FichaIdentificacion *>'>Editar</a>
        </div>
        </div>
        <hr/>
    ]]>
    </script>
    <script type="text/x-jqote-template" id="templateFichas">
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
        <a class="btn btn-primary" href='<*= "RegistroFichaIdentificacion.aspx?Id_FichaIdentificacion=" + this.Id_FichaIdentificacion*>'>Editar</a>
        <a class="btn btn-primary" href='<*= "RegistroAgenda.aspx?Id_FichaIdentificacion=" + this.Id_FichaIdentificacion + "&NombreCompleto=" + this.Nombre_FichaIdentificacion + " " + this.ApPaterno_FichaIdentificacion + " " + this.ApMaterno_FichaIdentificacion *>'>Agendar</a>
        
        </div>
        </div>
        <hr/>
    ]]>
    </script>
    <style>
        .badge-calendar {
            background: WHITE;
            color: #1d86c8;
            border-radius: 0px;
            font-size: 9px;
            border-bottom-left-radius: 4px;
            padding: 3px 5px;
        }

        .contCalendar {
            padding: 5px;
        }

            .contCalendar .active {
                padding: 2px;
            }
    </style>
</asp:Content>
