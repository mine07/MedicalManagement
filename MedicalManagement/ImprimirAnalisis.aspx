<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImprimirAnalisis.aspx.cs" Inherits="MedicalManagement.ImprimirAnalisis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <h3>Imprimir Analisis Clinico</h3>
            <hr />
            <div class="container-fluid border-top1-bottom5 no-radius no-vertical-padding gray-border">
                <div class="loading hidden">
                    <div><i class="fa fa-3x fa-spinner fa-spin"></i></div>
                </div>
                <div class="row">
                    <div class="col-xs-12 col-md-8 col-lg-8 col-sm-8 container-fluid padding">
                        <!--<div class="row">
                            <div class="col-xs-12">

                                <asp:LinkButton runat="server" Text='<label class="label label-danger pull-right label-button pull-right" style="font-size: 16px;">Eliminar<i class="fa fa-scissors"></i></label>' />
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <h3>Analis Clinicos<i class="fa fa-stethoscope fa-margin-left fa-margin-right"></i>-<label runat="server" id="lblPaqueteNombre"></label></h3>
                                <hr />
                            </div>
                        </div>-->
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="row">
                            </div>
                                <asp:Panel id ="pnlImprimir" runat ="server">
                                    <table width ="100%" border ="0">
                         <tr>
                             <td>
                                 Nombre:
                                 <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                             </td>
                             <td>
                                 Fecha: 
                                 <asp:Label ID="Label3" runat="server" Text= "" ></asp:Label>
                           
                             </td>
                         
                         </tr> 
                         </table>

                                <div class="gray-container" style="max-height: 450px;"">
                                <asp:Repeater runat="server" ID="rptItems">
                                    <ItemTemplate>
                                            <div class="row">
                                                <div class="col-xs-12">
                                                    <hr />
                                                    <label class="h5"><i class="fa fa-stethoscope fa-margin-right"></i><%# Eval("oneAnalisis.Descripcion_AnalisisClinico") %></label>
                                                </div>
                                            </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                    </div>
                                    </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


    <asp:LinkButton ID="btnPrint" runat="server" Text='<h4><label class="label label-success pull-right label-button">Imprimir<i class="fa fa-margin-left fa-print"></i></label></h4>' OnClientClick = "return PrintPanel();" />  

    <script type = "text/javascript">
        function PrintPanel() {

            var panel = document.getElementById("<%=pnlImprimir.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            //printWindow.document.write('Nombre: ');
            //printWindow.document.write('Fecha:');
            //printWindow.document.write('</head><body >');
            //printWindow.document.write(panel2.innerHTML);
            printWindow.document.write(panel.innerHTML);
            //printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
                printWindow.window.close();
            }, 500);
            return false;  
        }
        function Fecha() {
            var f = new Date();
            document.write(f.getDate() + "/" + (f.getMonth() + 1) + "/" + f.getFullYear());
            return f;
        }
    </script>

</asp:Content>
