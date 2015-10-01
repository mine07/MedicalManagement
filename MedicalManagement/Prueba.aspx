<%@ Page Language="C#" MasterPageFile="~/Consulta.master" AutoEventWireup="true" CodeBehind="Prueba.aspx.cs" Inherits="MedicalManagement.Prueba" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightSide" runat="server">
    HOLA!
    
<script>
    $(document).ready(function() {
    });

    function toggleSidebar() {
        $("#side-bar").toggleClass("side-nav-hidden");
    }
</script>
<style>
    .side-nav-hidden {
        left:0px;
    }
</style>
    </asp:Content>