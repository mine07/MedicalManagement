<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login2.aspx.cs" Inherits="MedicalManagement.login2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

    <p align="center">


    <br>
    <br>
    <br>
    <br>
    <br>
    <br>
    <br>


    <table border="0">
        <tr>
            <td align="center"><img src="IMG/Logotipo_i.jpg"></td>     
        </tr>
    </table>

    <br><br>

    <table border="1" spacing="0">
    <tr><td>


    <table border="0">
        <tr>
            <td colspan="4">&nbsp;</td>     
        </tr>
        <tr>
            <td>&nbsp;</td>     
            <td><font face="Arial, Helvetica, sans-serif" size="2">Usuario&nbsp;:&nbsp;</font></td>               
            <td><asp:textbox runat="server" ID="txtusuario"></asp:textbox></td>  
                         
            <td>&nbsp;</td>     
        </tr>
        <tr>
            <td>&nbsp;</td>     
            <td><font face="Arial, Helvetica, sans-serif" size="2">Contraseña&nbsp;:&nbsp;</font></td>     
            <td><asp:textbox runat="server" ID="txtcontrasena" TextMode="Password"></asp:textbox> </td>     
            <td>&nbsp;</td>     
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>     
        </tr>
        <tr>
            <td colspan="4" align="center">
            <asp:Button ID="BtnRecuperar" runat="server" Text="Recuperar Contraseña"
         style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:Button>                
                &nbsp;
                    <asp:Button ID="BtnEntrar" runat="server" Text="Entrar"
        onclick="btnEntrar_Click" style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:Button>
                    </td>     
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>     
        </tr>
    </table>
    </td></tr></table>
    </p>

    <br><br>
		  <div align="center"><img src="IMG/Line.png"><font face="Arial, Helvetica, sans-serif" size="1">&nbsp;</font></div>

    
    </div>
    </form>
</body>
</html>
