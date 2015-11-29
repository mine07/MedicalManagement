<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImprimirReceta.aspx.cs" Inherits="MedicalManagement.ImprimirReceta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <a href="#" onClick="history.back();" __designer:mapid="696"><label class="pull-right label label-primary label-button" __designer:mapid="697">Volver<i class="fa fa-arrow-left fa-margin-left" __designer:mapid="698"></i></label></a>
    <h2>Imprimir Receta</h2>
  </div>

<asp:ScriptManager runat="server" />  


    <asp:UpdatePanel runat="server" >
   
        <ContentTemplate>    
            <hr />
                <div class="row">
                   <asp:Panel id ="pnlImprimir" runat ="server">
                     <div class="col-xs-12 col-md-8 col-lg-8 col-sm-8">
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
                         <div class="container-fluid padding" id="Medicine-Container">

                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                <div class="gray-container" style="max-height: 450px;">
                                <table width="100%" border="0">
                                            <tr>
                                                <th><label class="h5">Medicamento</label></th>
                                                <th><label class="h5">Dosis</label></th> 
                                                <th><label class="h5">Notas</label></th> 
                                             </tr>
                                

                                <asp:Repeater runat="server" ID="rptTemporal">
                                    <ItemTemplate>
                                        
                                            <tr>
                                                <th>
                                                    <label><%# Eval("Tem_Medicamento") %></label>
                                                </th>
                                                <th>
                                                    <label><%# Eval("Tem_Dosis") %></label>
                                                </th>
                                                <th>
                                                    <label><%# Eval("Tem_Notas") %></label>
                                                </th>
                                            </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                </table>
                                </div>
                             <hr />
                         </div>
                     </div>
                   </asp:Panel>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:LinkButton ID="btnPrint" runat="server"  Text='<h4><label class="label label-success pull-right label-button">Imprimir<i class="fa fa-margin-left fa-print"></i></label></h4>' OnClientClick = "return PrintPanel();" />  

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

    
    <style>
        .searchContainer {
            max-height: 300px;
            overflow-x: auto;
            position: absolute;
            width: 90%;
        }

        
    </style>
</asp:Content>

