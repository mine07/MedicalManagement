<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgendaElegirFicha.aspx.cs" Inherits="MedicalManagement.AgendaElegirFicha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table width="100%" class="footable footableB">
        <tr>
            <td align="left" colspan="6">Ficha de Identificacion&nbsp;:&nbsp;<asp:TextBox ID="txtBuscar_FichaIdentificacion" runat="server" Width="70%" OnTextChanged="txt_OnTextChanged" AutoPostBack="true"></asp:TextBox>&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="IMG/buscarf.jpg" OnClick="txt_OnTextChanged" ToolTip="Buscar Perfil"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="ImageRegresar" runat="Server" ImageUrl="IMG/Regresar.png" ToolTip="Regresar" OnClick="btnRegresar_FichaIdentificacion_Click"></asp:ImageButton>
            </td>
        </tr>
        <tr>
            <td style="text-align:center;"><label class="label label-primary">Favor de elegir algun usuario para asignar cita.</label>
            </td>
        </tr>
    </table>

    <asp:GridView ID="Grid_FichaIdentificacion" runat="server" AutoGenerateColumns="False"
        OnRowCommand="RowCommand" OnRowDeleting="RowDeleting"
        OnPageIndexChanging="Grid_FichaIdentificacion_PageIndexChanging" AllowPaging="False"
        OnPageIndexChanged="Grid_FichaIdentificacion_PageIndexChanged" CssClass="mGrid footable"
        PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None">


        <Columns>



            <asp:BoundField DataField="Id_FichaIdentificacion" HeaderText="Id.FichaIdentificacion"
                SortExpression="Id_FichaIdentificacion" />

            <asp:BoundField DataField="NombreCompleto" HeaderText="NombreCompleto"
                SortExpression="NombreCompleto" />


            <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Elegir"
                ShowHeader="True" Text="Elegir" ControlStyle-CssClass="btn btn-primary" ItemStyle-HorizontalAlign="Center" />



        </Columns>
    </asp:GridView>



</asp:Content>
