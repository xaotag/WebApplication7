<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogDetail.aspx.cs" Inherits="WebApplication7.Web.LogDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="./css/bootstrap.min.css" rel="stylesheet" />
    <title></title>
    <style>
        .p-text {
            margin: 0 auto;
            font: bold;
        }

        .card {
            margin-top: 20px;
        }

        .user {
            color: aqua
        }

        .content {
            font-size: 125%;
        }

        .time {
            color: aqua;
            font-size: 75%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-md">
            <div class="card ">
                <h2 id="Title" runat="server" class="p-text"><%#Eval("LogsTitle") %></h2>
                <div class="card-body">
                    <div id="TextDiv1" class="d-flex p-2 bd-highlight" runat="server">
                    </div>
                </div>
            </div>
            <asp:TextBox ID="TextBox1" runat="server" placeholder="评论"></asp:TextBox><asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="发布" OnClick="Button1_Click" />
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>

                        <td class="user"><%# Eval("UserName") %></td>
                        <td></td>
                    </tr>
                    <tr>

                        <td class="content"><%# Eval("ComContent") %></td>
                        <td class="time"><%# Eval("CommentTime") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
