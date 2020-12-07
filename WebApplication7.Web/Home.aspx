<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication7.Web.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="./css/bootstrap.min.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="border: 1px red dashed" class="container">
            <table>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>用户名： <%#Eval("UserName") %></td>

                        </tr>
                        <tr>
                            <td>手机号码： <%#Eval("UserPhone") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <br/>
            <a href="./InfoList.aspx">列表</a>
        </div>
    </form>
</body>
</html>
