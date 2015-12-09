<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EspecialistasInfo.aspx.cs" Inherits="MedicalManagement.EspecialistasInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id_Especialista" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="Id_Especialista" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id_Especialista" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
        <asp:BoundField DataField="Apellido_Paterno_Especialista" SortExpression="Apellido_Paterno_Especialista" />
        <asp:BoundField DataField="Apellido_Materno_Especialista" SortExpression="Apellido_Materno_Especialista" />
        <asp:BoundField DataField="Cedula_Profecional" HeaderText="No. Cedula" SortExpression="Cedula_Profecional" />
        <asp:BoundField DataField="Celular" HeaderText="Celular" SortExpression="Celular" />
    </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MedicalmanagemenConnectionString %>" DeleteCommand="DELETE FROM [Table_Catalogo_Especialista] WHERE [Id_Especialista] = @Id_Especialista" InsertCommand="INSERT INTO [Table_Catalogo_Especialista] ([Nombre], [Apellido_Paterno_Especialista], [Apellido_Materno_Especialista], [Cedula_Profecional], [Nombre_Clinica], [Direccion_Calle], [Direccion_No], [Direccion_Colonia], [Telefono], [Celular], [Correo_Electronico], [Texto_Libre], [Logo]) VALUES (@Nombre, @Apellido_Paterno_Especialista, @Apellido_Materno_Especialista, @Cedula_Profecional, @Nombre_Clinica, @Direccion_Calle, @Direccion_No, @Direccion_Colonia, @Telefono, @Celular, @Correo_Electronico, @Texto_Libre, @Logo)" SelectCommand="SELECT * FROM [Table_Catalogo_Especialista]" UpdateCommand="UPDATE [Table_Catalogo_Especialista] SET [Nombre] = @Nombre, [Apellido_Paterno_Especialista] = @Apellido_Paterno_Especialista, [Apellido_Materno_Especialista] = @Apellido_Materno_Especialista, [Cedula_Profecional] = @Cedula_Profecional, [Nombre_Clinica] = @Nombre_Clinica, [Direccion_Calle] = @Direccion_Calle, [Direccion_No] = @Direccion_No, [Direccion_Colonia] = @Direccion_Colonia, [Telefono] = @Telefono, [Celular] = @Celular, [Correo_Electronico] = @Correo_Electronico, [Texto_Libre] = @Texto_Libre, [Logo] = @Logo WHERE [Id_Especialista] = @Id_Especialista">
    <DeleteParameters>
        <asp:Parameter Name="Id_Especialista" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="Nombre" Type="String" />
        <asp:Parameter Name="Apellido_Paterno_Especialista" Type="String" />
        <asp:Parameter Name="Apellido_Materno_Especialista" Type="String" />
        <asp:Parameter Name="Cedula_Profecional" Type="String" />
        <asp:Parameter Name="Nombre_Clinica" Type="String" />
        <asp:Parameter Name="Direccion_Calle" Type="String" />
        <asp:Parameter Name="Direccion_No" Type="Int32" />
        <asp:Parameter Name="Direccion_Colonia" Type="String" />
        <asp:Parameter Name="Telefono" Type="Int32" />
        <asp:Parameter Name="Celular" Type="Int32" />
        <asp:Parameter Name="Correo_Electronico" Type="String" />
        <asp:Parameter Name="Texto_Libre" Type="String" />
        <asp:Parameter Name="Logo" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="Nombre" Type="String" />
        <asp:Parameter Name="Apellido_Paterno_Especialista" Type="String" />
        <asp:Parameter Name="Apellido_Materno_Especialista" Type="String" />
        <asp:Parameter Name="Cedula_Profecional" Type="String" />
        <asp:Parameter Name="Nombre_Clinica" Type="String" />
        <asp:Parameter Name="Direccion_Calle" Type="String" />
        <asp:Parameter Name="Direccion_No" Type="Int32" />
        <asp:Parameter Name="Direccion_Colonia" Type="String" />
        <asp:Parameter Name="Telefono" Type="Int32" />
        <asp:Parameter Name="Celular" Type="Int32" />
        <asp:Parameter Name="Correo_Electronico" Type="String" />
        <asp:Parameter Name="Texto_Libre" Type="String" />
        <asp:Parameter Name="Logo" Type="String" />
        <asp:Parameter Name="Id_Especialista" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="Id_Especialista" DataSourceID="SqlDataSource1" DefaultMode="Insert" Height="50px" OnPageIndexChanging="DetailsView1_PageIndexChanging" Width="384px">
        <Fields>
            <asp:BoundField DataField="Id_Especialista" HeaderText="Id_Especialista" InsertVisible="False" ReadOnly="True" SortExpression="Id_Especialista" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="Apellido_Paterno_Especialista" HeaderText="Apellido Paterno" SortExpression="Apellido_Paterno_Especialista" />
            <asp:BoundField DataField="Apellido_Materno_Especialista" HeaderText="Apellido Materno" SortExpression="Apellido_Materno_Especialista" />
            <asp:BoundField DataField="Cedula_Profecional" HeaderText="Cedula Profecional" SortExpression="Cedula_Profecional" />
            <asp:BoundField DataField="Nombre_Clinica" HeaderText="Nombre de la Clinica" SortExpression="Nombre_Clinica" />
            <asp:BoundField DataField="Direccion_Calle" HeaderText="Calle" SortExpression="Direccion_Calle" />
            <asp:BoundField DataField="Direccion_No" HeaderText="No" SortExpression="Direccion_No" />
            <asp:BoundField DataField="Direccion_Colonia" HeaderText="Colonia" SortExpression="Direccion_Colonia" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
            <asp:BoundField DataField="Celular" HeaderText="Celular" SortExpression="Celular" />
            <asp:BoundField DataField="Correo_Electronico" HeaderText="Correo Electronico" SortExpression="Correo_Electronico" />
            <asp:BoundField DataField="Texto_Libre" HeaderText="Texto Libre" SortExpression="Texto_Libre" />
            <asp:BoundField DataField="Logo" HeaderText="Logo" SortExpression="Logo" />
            <asp:CommandField ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>
</asp:Content>
