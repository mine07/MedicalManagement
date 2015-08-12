<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agenda.aspx.cs" Inherits="MedicalManagement.Agenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table width="100%" class="">
        <tr>
            <td align="left" colspan="6">Agenda&nbsp;:&nbsp;<asp:TextBox ID="txtBuscar_FichaIdentificacion" runat="server" Columns="100" OnTextChanged="txt_OnTextChanged" AutoPostBack="true"></asp:TextBox>
                &nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip="Buscar Perfil"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="AgregarAgenda" runat="Server" ImageUrl="IMG/agregar.png" OnClick="btnAgregarAgenda_Click" ToolTip="Agregar Agenda"></asp:ImageButton>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="OnSelectionChanged"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td>

                <asp:RadioButton ID="rdbtodos" runat="server" Text="Todos" AutoPostBack="true"
                    OnCheckedChanged="rdbtodos_CheckedChanged" Checked="True" />

                &nbsp;&nbsp;
            
                 <asp:RadioButton ID="rdbnormal" runat="server" Text="Normal" AutoPostBack="true"
                     OnCheckedChanged="rdbnormal_CheckedChanged" />
                &nbsp;&nbsp;
                 <asp:RadioButton ID="rdburgente" runat="server" Text="Urgente" AutoPostBack="true"
                     OnCheckedChanged="rdburgente_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>Seleccionar mes:&nbsp;              
                <asp:DropDownList ID="ddlmes" runat="server">
                    <asp:ListItem>Enero</asp:ListItem>
                    <asp:ListItem>Febrero</asp:ListItem>
                    <asp:ListItem>Marzo</asp:ListItem>
                    <asp:ListItem>Abril</asp:ListItem>
                    <asp:ListItem>Mayo</asp:ListItem>
                    <asp:ListItem>Junio</asp:ListItem>
                    <asp:ListItem>Julio</asp:ListItem>
                    <asp:ListItem>Agosto</asp:ListItem>
                    <asp:ListItem>Septiembre</asp:ListItem>
                    <asp:ListItem>Octubre</asp:ListItem>
                    <asp:ListItem>Noviembre</asp:ListItem>
                    <asp:ListItem>Diciembre</asp:ListItem>
                </asp:DropDownList>

                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
                <asp:Button ID="btncitasmes" runat="server"
                    Text="Ver Todas las Citas del Mes seleccionado" OnClick="btncitasmes_Click" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="6">
                <asp:GridView ID="Grid_Agenda" runat="server" AutoGenerateColumns="False"
                    OnRowCommand="RowCommand" OnRowDeleting="RowDeleting" OnRowDataBound="RowDataBound"
                    OnPageIndexChanging="Grid_Agenda_PageIndexChanging" AllowPaging="False"
                    OnPageIndexChanged="Grid_Agenda_PageIndexChanged" CssClass="mGrid"
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                    GridLines="None">


                    <Columns>

                        <asp:BoundField DataField="Id_Agenda" HeaderText="Id.Agenda"
                            SortExpression="Id_Agenda" />

                        <asp:BoundField DataField="Id_FichaIdentificacion" HeaderText="Id.FichaIdentificacion"
                            SortExpression="Id_FichaIdentificacion" />

                        <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre Completo"
                            SortExpression="NombreCompleto" />

                        <asp:BoundField DataField="Fecha_Agenda" HeaderText="Fecha Agenda"
                            SortExpression="Fecha_Agenda" />

                        <asp:BoundField DataField="Inicio_Agenda" HeaderText="Inicio Agenda"
                            SortExpression="Inicio_Agenda" />

                        <asp:BoundField DataField="Fin_Agenda" HeaderText="Fin Agenda"
                            SortExpression="Fin_Agenda" />

                        <asp:BoundField DataField="EstadoCitas_Agenda" HeaderText="EstadoCitas Agenda"
                            SortExpression="EstadoCitas_Agenda" />

                        <asp:BoundField DataField="Id_Categoria" HeaderText="Id Categoria"
                            SortExpression="Id_Categoria" />

                        <asp:BoundField DataField="Descripcion_Categoria" HeaderText="Descripcion Categoria"
                            SortExpression="Descripcion_Categoria" />

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
                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"></asp:TextBox>
                <%--<a href="RegistroFichaIdentificacion.aspx" class="input-group-addon no-sub">Agregar</a>--%>
            </div>
        </div>
    </div>
    <hr />
    <div class="container-fluid searchContainer  border-top1-bottom5"></div>
    <hr />
    <div class="row" id="calendarAgenda">
        <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
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
        <div class="col-xs-12 col-sm-8 col-md-8 col-lg-8 container-fluid" id="rowsContainer">
        </div>
    </div>
    <script>
        $("[id$=txtSearch]").keyup(function (e) {
            var nombre = $("[id$=txtSearch]").val();
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
            loadToday();
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


        function onDayClick(events) {
            var day = $(this).data("day");
            var month = $(this).data("month");
            var year = $(this).data("year");
            var getItem = { day: day, month: month, year: year };
            console.log(getItem);
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
            <a class="btn btn-primary" href='<*= "RegistroAgenda.aspx?Id_Agenda=" + this.Id_Agenda + "&Id_FichaIdentificacion=" + this.UsuarioDTO.Id_FichaIdentificacion + "&NombreCompleto=" + this.UsuarioDTO.Nombre_FichaIdentificacion + " " + this.UsuarioDTO.ApPaterno_FichaIdentificacion + " " + this.UsuarioDTO.ApMaterno_FichaIdentificacion *>'>Editar</a>
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
