<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecetaPrevia.aspx.cs" Inherits="MedicalManagement.RecetaPrevia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

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
                    OnPageIndexChanged="Grid_RecetaPrevia_PageIndexChanged" CssClass="mGrid"
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="None">


                    <Columns>


                        <asp:BoundField DataField="Id_ConsultaRecetaPrevia" HeaderText="Id.ConsultaRecetaPrevia"
                            SortExpression="Id_ConsultaRecetaPrevia" />
                        <asp:BoundField DataField="Descripcion_Diagnostico" HeaderText="Descripcion_Diagnostico"
                            SortExpression="Descripcion_Diagnostico" />
                        <asp:BoundField DataField="Nombre_ConsultaRecetaPrevia" HeaderText="RecetaPrevia"
                            SortExpression="Nombre_ConsultaRecetaPrevia" />


                        <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Editar"
                            ShowHeader="True" Text="Editar" ItemStyle-HorizontalAlign="Center" />

                        <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Eliminar"
                            ShowHeader="True" Text="Eliminar" ItemStyle-HorizontalAlign="Center" />

                    </Columns>
                </asp:GridView>



            </td>
        </tr>
    </table>

</asp:Content>
