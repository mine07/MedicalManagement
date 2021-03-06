﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CalendarPrueba.aspx.cs" Inherits="MedicalManagement.Styles.CalendarPrueba" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Responsive calendar - START -->
    <div class="row hidden">
        <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
            <div class="responsive-calendar  contCalendar">
                <div class="controls">
                    <span class="pull-left" data-go="prev">
                        <div class="btn btn-Primary label-primary label">Prev</div>
                    </span>
                    <h4><span data-head-year></span>-<span data-head-month></span></h4>
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
    <div class="row hidden">
        <div class="container">
            <h2>Collapse</h2>
            <div class="panel-group" id="accordion">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">Collapsible Group 1</a>
                        </h4>
                    </div>
                    <div id="collapse1" class="panel-collapse collapse in">
                        <div class="panel-body">
                            Lorem ipsum dolor sit amet, consectetur adipisicing elit,
        sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
        quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapse2">Collapsible Group 2</a>
                        </h4>
                    </div>
                    <div id="collapse2" class="panel-collapse collapse">
                        <div class="panel-body">
                            Lorem ipsum dolor sit amet, consectetur adipisicing elit,
        sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
        quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapse3">Collapsible Group 3</a>
                        </h4>
                    </div>
                    <div id="collapse3" class="panel-collapse collapse">
                        <div class="panel-body">
                            Lorem ipsum dolor sit amet, consectetur adipisicing elit,
        sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
        quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <asp:TextBox CssClass="form-control" runat="server" ID="txtSearch"></asp:TextBox>
    </div>
    <hr />
    <div class="container-fluid  searchContainer border-top1-bottom5">
    </div>
    <!-- Responsive calendar - END -->
    <script>



        $(document).ready(function () {
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
            $('#rowsContainer').fadeOut(400);
            $('#rowsContainer').empty();
            $('#rowsContainer').delay(300).fadeIn(000);
            $('#rowsContainer').append(
                $('#template').jqote(jsonObject, '*')
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
        $('[id$=txtSearch]').bind('input keyup', function () {
            var $this = $(this);
            var delay; // 2 seconds delay after last input
            var value = $('[id$=txtSearch]').val();
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
            var containerB = $("[id$=txtSearch]");
            if (!container.is(e.target) // if the target of the click isn't the container...
                && container.has(e.target).length === 0 && !containerB.is(e.target)) // ... nor a descendant of the container
            {
                container.slideUp();
            }
        });

        $("[id$=txtSearch]").focus(function () {
            if ($('.searchContainer').children().length !== 0) {
                $('.searchContainer').slideDown();
            }
        });

        function upText(x) {
            var val = $(x).closest('.row').find('h4');
            $("[id$=txtSearch]").val(val.html());
        }

    </script>
    <script type="text/x-jqote-template" id="template">
    <![CDATA[        
        <div class="row row-hover" onclick="upText(this);">
        <div class="col-xs-12 col-md-12 col-sm-12 col-lg-12">        
        <h4><*= this.Descripcion_Diagnostico*></h4>
        <hr />
        </div>       
        </div>
    ]]>
    </script>
    <style>
      
    </style>
</asp:Content>
