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
                <asp:LinkButton ID = "AgregarRFC" runat="server" OnClick="btnAgregarRFC_Click" ToolTip = "Agregar RFC" Text='<label class="fa-margin-right label pull-right label label-primary"><i class="fa fa-margin-left fa-plus-circle"></i></label>' BackColor="#3333FF"></asp:LinkButton>
                <div class="container-fluid searchContainer searchProc border-top1-bottom5">
                </div>
        </div>                
    </div>
    <hr />



</asp:Content>
