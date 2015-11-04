<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImprimirNotaClinica.aspx.cs" Inherits="MedicalManagement.ImprimirNotaClinica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <a href="#" onClick="history.back();" __designer:mapid="696">
            <label class="pull-right label label-primary label-button" __designer:mapid="697">
                Volver
                <i class="fa fa-arrow-left fa-margin-left" __designer:mapid="698"></i>
            </label>
        </a>
        <h2>Imprimir Nota Clinica</h2>
    </div>

<asp:ScriptManager runat="server" />  
    <asp:UpdatePanel runat="server">
        <ContentTemplate> 
                <div class="row">
                   <asp:Panel id ="Panel1" runat ="server" >
                     <div class="col-xs-12 col-md-8 col-lg-8 col-sm-8">
                         <table width ="100%" border ="0">
                         <tr>
                             <td>
                                 Nombre:
                                 <asp:Label ID="lblNombre" runat="server" Text= "" ></asp:Label> 
                             </td>
                             <td>
                                 Fecha: 
                                 <asp:Label ID="lblfechaconsulta" runat="server" Text= "" ></asp:Label> 
                           
                             </td>
                         
                         </tr> 
                         </table>
                         <hr />
                         
                         <div class="row">
                             <label>Subjetivo: </label>
                             <asp:Label ID="lblsubjetivo" runat="server" Text=""></asp:Label>
                         </div>

                         <hr />
                         <div class="row">
                             <label>Objetivo: </label>
                             <asp:Label ID="lblobjetivo" runat="server" Text=""></asp:Label>
                         </div>
                         <hr />

                         <div class="row">
                             <label>Analisis: </label>
                             <asp:Label ID="lblanalisis" runat="server" Text=""></asp:Label>
                         </div>
                         <hr />


                         <div class="row">  
                             <label>Plan: </label>
                             <asp:Label ID="lblplan" runat="server" Text=""></asp:Label>
                         </div>

                         <hr />
                        <label>Diagnostico</label>
                        <div class="gray-container">
                            <asp:Repeater runat="server" ID="rptDiag">
                                <ItemTemplate>
                                    <div class="row">
                                        <div class="col-xs-12">
                                            <label class="packet-name"><%# Eval("oneDiag.Descripcion_Diagnostico")%></label>
                                            <hr />
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                        <label>Procedimiento</label>
                        <div class="gray-container">
                            <asp:Repeater runat="server" ID="rptProc1">
                                <ItemTemplate>
                                    <div class="row">
                                        <div class="col-xs-12">
                                           <label class="packet-name"><%# Eval("onePro.Descripcion_Procedimiento")%></label>
                                            <hr />
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                     </div>
                   </asp:Panel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
          
    <asp:LinkButton ID="btnPrint" runat="server" Text='<h4><label class="label label-success pull-right label-button">Imprimir<i class="fa fa-margin-left fa-print"></i></label></h4>' OnClientClick = "return PrintPanel();" />  
<script type = "text/javascript">
        function PrintPanel() {

            var panel = document.getElementById("<%=Panel1.ClientID %>");
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
    <style>
        .searchContainer {
            max-height: 300px;
            overflow-x: auto;
            position: absolute;
            width: 100%;
        }

        .modal-body .row {
            margin: 5px 0;
            padding: 5px;
            border-bottom: 1px solid #c8c8c8;
        }

        .ui-accordion-header {
            border-color: #c8c8c8 !important;
        }

        .padding {
            margin: 5px 0;
        }
    </style>
</asp:Content>
