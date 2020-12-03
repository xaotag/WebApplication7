<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication7.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        #table1 {
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="table1">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="账号"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="密码"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="登录" OnClick="Button1_Click" /></td>
                </tr>
            </table>



        </div>
    </form>
</body>
</html>
