<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agenda.aspx.cs" Inherits="MedicalManagement.Agenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table width="100%">
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
    <script>
        jQuery('.datePicker').datetimepicker();
    </script>
</asp:Content>
