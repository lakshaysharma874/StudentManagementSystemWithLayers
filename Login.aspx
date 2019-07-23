<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StudentManagementSystemWithLayers.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Student Management</title>
    <link href="Styles/Style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 72%;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1" style="width:400px;margin:214px 0px 0px 457px; line-height: inherit; background-color: #FFFFFF;" border="1">
        <tr>
            <td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="XX-Large" ForeColor="#993300" Text="Login"></asp:Label>
            </td>
        </tr>
       
        <tr>
            <td style="text-align: right; width: 80px">UserName:</td>
            <td style="width: 216px">
                <asp:TextBox ID="txtName" runat="server" Width="248px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right; width: 80px">Password:</td>
            <td style="width: 216px">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="246px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 80px">&nbsp;</td>
            <td style="width: 216px">
                <asp:Button ID="btnLogin" runat="server" Text="Login" Width="92px" OnClick="btnLogin_Click" />
            </td>
            <td>
               
            </td>
        </tr>
        <tr>
            <td style="width: 80px">&nbsp;</td>
            <td style="width: 216px">
                <asp:Label ID="lblError" runat="server" Visible="false"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    </form>
</body>
</html>
