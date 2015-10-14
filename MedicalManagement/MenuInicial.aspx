<%@ Page Title="Medical Management" Language="C#" MasterPageFile="Site.master" AutoEventWireup="true"
    CodeBehind="MenuInicial.aspx.cs" Inherits="MedicalManagement.MenuInicial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="alert" class="alert alert-danger alert-dismissible hidden" role="alert">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <strong id="alerta2"></strong>
            </div>

    <table width="100%" border="0">
        <td colspan="2" align="center" runat="Server" id="Alerta"></td>
    </table>
    <span>
        <label class="h3">Menu Inicial </label>
        <label class="h4"><i class="fa fa-calendar-times-o fa-margin-left fa-margin-right"></i>Consultas</label></span>
    <hr />
    <div class="container-fluid border-top1-bottom5 gray-border no-vertical-padding">
        <div class="row hidden">
            <div class="col-xs-12 col-md-12 col-sm-12 col-lg-12">
                <div class="container-fluid">
                    <label class="blue hidden-md hidden-lg hidden-sm">Pacientes</label>
                    <div class="col-xs-12">
                        <div class="input-group">
                            <span class="input-group-addon hidden-xs blue" id="basic-addon1">Pacientes</span>
                            <asp:TextBox ID="txtBuscar_FichaIdentificacion" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                            <a href="RegistroFichaIdentificacion.aspx" class="input-group-addon no-sub">Agregar</a>
                        </div>
                    </div>
                </div>
                <hr />
                <div class="container-fluid searchContainer border-top1-bottom5">
                </div>
                <hr />
            </div>
        </div>


        <div class="row" id="calendarConsulta">
            <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4 left-panel">
                <div class="responsive-calendar contCalendar consCalendar">
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
            <div class="col-xs-12 col-sm-8 col-md-8 col-lg-8 container-fluid" id="consContainer">
            </div>
        </div>
    </div>

    <script>

        //ALERTA
        function llamaralerta2() {
          $("#alerta").text("¡ERROR!, ya existe una cita a esta hora, por favor verifica el horario para continuar.");
        };
        //ALERTA

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
            loadTodayCons();
            $("#calendarAgenda").hide();
            var jsonObject;
            var eventB = {};
            var eventC = {};
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
                    $('.agenCalendar').responsiveCalendar({
                        events: eventB,
                        onDayClick: onDayClick,
                        monthChangeAnimation: false
                    });
                }
            });
            $.ajax({
                type: "POST",
                url: "GetDates.asmx/GetConsulta",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var index = 0;
                    jsonObject = $.parseJSON(data.d);
                    $.each(jsonObject, function () {
                        var number = jsonObject[index].cantidad;
                        eventC[jsonObject[index].date.substring(0, jsonObject[index].date.length - 9)] = { "number": number, "badgeClass": "badge badge-calendar" };
                        index++;
                    });
                    $('.consCalendar').responsiveCalendar({
                        events: eventC,
                        onDayClick: onDayClickB,
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

        function fillAgendaB(data) {
            var jsonObject = $.parseJSON(data.d);
            console.log("Hola");
            $('#consContainer').empty().hide();
            $('#consContainer').fadeIn(200);
            $('#consContainer').append(
                $('#templateCalendarCons').jqote(jsonObject, '*')
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



        function onDayClickB(events) {
            var day = $(this).data("day");
            var month = $(this).data("month");
            var year = $(this).data("year");
            var getItem = { day: day, month: month, year: year };
            $.ajax({
                type: "POST",
                url: "GetDates.asmx/GetConsultaItems",
                data: JSON.stringify({ 'getDate': getItem }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    fillAgendaB(data);
                }
            });
        }

        function loadToday() {
            var dateObj = new Date();
            var month = dateObj.getUTCMonth() + 1; //months from 1-12
            var day = dateObj.getUTCDate();
            var year = dateObj.getUTCFullYear();
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

        function loadTodayCons() {
            var dateObj = new Date();
            var month = dateObj.getUTCMonth() + 1; //months from 1-12
            var day = dateObj.getUTCDate();
            var year = dateObj.getUTCFullYear();
            var getItem = { day: day, month: month, year: year };
            console.log("prueba");
            $.ajax({
                type: "POST",
                url: "GetDates.asmx/GetConsultaItems",
                data: JSON.stringify({ 'getDate': getItem }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    fillAgendaB(data);
                }
            });
        }
    </script>
    <script type="text/x-jqote-template" id="templateCalendar">
     <![CDATA[
        <div class="row border-top1-bottom5">        
            <div class="col-xs-10 col-sm-3 col-md-3 col-lg-3 <*= this._estatus *>">
                <label><*= this.UsuarioDTO.Nombre_FichaIdentificacion + " " + this.UsuarioDTO.ApPaterno_FichaIdentificacion + " " + this.UsuarioDTO.ApMaterno_FichaIdentificacion *>                
            </div>        
        <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                <div class="row">
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                    <label class="small-label"><*= this.InicioCita + " - " + this.FinCita*></label> 
                    </div>
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                    <label class="small-label"><*= "Estado - " + this.EstadoCitas_Agenda + " Prioridad - " + this.Prioridad_Agenda*></label> 
                    </div>
                </div>            
        </div>
        <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
        <label class="small-label"><*= this.Descripcion_Agenda*></label>
        </div>
        <div class="col-xs-12 col-sm-2 col-md-2 col-lg-2 center-text">
            
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
        <div class="col-xs-12 col-sm-1 col-md-2 col-lg-4">
        <a class="label label-secondary form-control" href='<*= "RegistroFichaIdentificacion.aspx?Id_FichaIdentificacion=" + this.Id_FichaIdentificacion*>'>Editar</a>
        <a class="label label-secondary form-control" href='<*= "RegistroAgenda.aspx?Id_FichaIdentificacion=" + this.Id_FichaIdentificacion + "&NombreCompleto=" + this.Nombre_FichaIdentificacion + " " + this.ApPaterno_FichaIdentificacion + " " + this.ApMaterno_FichaIdentificacion *>'>Agendar</a>
        <a class="label label-secondary form-control" href='<*= "ConsultaMenu.aspx?Id_Agenda=0" + "&Id_FichaIdentificacion=" + this.Id_FichaIdentificacion*>'>Menu Consulta</a>        
        </div>
        </div>
        <hr/>
    ]]>
    </script>
    <script type="text/x-jqote-template" id="templateCalendarCons">
    <![CDATA[
        <div class="row container-fluid" style="padding-top:10px;">        
            <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4 <*= this.AgendaDTO._estatus *> row">
         <div class="col-xs-12 text-center">
                <label><*= this.UsuarioDTO.Nombre_FichaIdentificacion + " " + this.UsuarioDTO.ApPaterno_FichaIdentificacion + " " + this.UsuarioDTO.ApMaterno_FichaIdentificacion *>                
        </label>
         </div>           
         <div class="col-xs-12">
                    <label class=""><*= this.AgendaDTO.InicioCita + " - " + this.AgendaDTO.FinCita*></label> 
                    </div>   
            </div>
        <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                <div class="row">                   
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                    <label class="small-label"><*= "Estado - " + this.AgendaDTO.EstadoCitas_Agenda  *></label>
                    <label class="small-label"><*= "Prioridad - " + this.AgendaDTO.Prioridad_Agenda*></label> 
                    </div>
                </div>            
        </div>
        <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
        <label class="small-label"><*= this.AgendaDTO.Descripcion_Agenda*></label>
        </div>        
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-right">
        <a class="label label-secondary form-control" href='<*= "RegistroAgenda.aspx?Id_Agenda=" + this.Id_Agenda + "&Id_FichaIdentificacion=" + this.UsuarioDTO.Id_FichaIdentificacion + "&NombreCompleto=" + this.UsuarioDTO.Nombre_FichaIdentificacion + " " + this.UsuarioDTO.ApPaterno_FichaIdentificacion + " " + this.UsuarioDTO.ApMaterno_FichaIdentificacion *>'>Editar</a>
        <a class="label label-secondary form-control" href='<*= "ConsultaMenu.aspx?Id_Agenda=" + this.AgendaDTO.Id_Agenda + "&Id_FichaIdentificacion=" + this.Id_FichaIdentificacion + "&NombreCompleto=" + this.UsuarioDTO._NombreCompleto *>'>Menu Consulta</a>                
                </div>
        
        </div>
        <hr/>
    ]]>
    </script>
    <style>
        .contCalendar {
            padding: 5px;
        }

            .contCalendar .active {
                padding: 2px;
            }

        .pnd {
            border-left: 5px solid rgb(255, 250, 107);
        }

        .conf {
            border-left: 5px solid rgb(107, 255, 118);
        }

        .canceled {
            border-left: 5px solid rgb(255, 107, 107);
        }
    </style>
</asp:Content>
