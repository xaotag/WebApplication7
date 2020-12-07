<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InfoList.aspx.cs" Inherits="WebApplication7.Web.Info" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="./css/bootstrap.min.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title id="Title" runat="server"></title>
    <style>
        img {
            width: 100px;
        }
        .My-btn {
            float: right;
        }
        .a1 {
            text-decoration-color: cadetblue;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div id="d1"  runat="server">
            <a href="./Login.aspx" class="a1"  runat="server">登录</a>
            <a href="./Register.aspx" class="a1"  runat="server">注册</a>
        </div>
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand1" ><%--OnItemDataBound="Repeater1_OnItemDataBound"--%>
            <HeaderTemplate>
                <table class="table">
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">标题</th>
                        <th scope="col">作者</th>
                        
                        <th scope="col">发布时间</th>
                        <th scope="col"></th>
                        
                        
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><img class=" img-thumbnail" src="<%#Eval("CoverPictureUrl") %>"/></td>
                    <td>
                        <asp:HiddenField ID="LogID" runat="server" Value='<%#Eval("LogsID") %>' />
                        <asp:LinkButton ID="LinkButton1" CommandName="Title" runat="server"><%#Eval("LogsTitle") %></asp:LinkButton></td>
                    <td><%#Eval("UserName") %></td>
                    <td><%#Eval("CreateTime") %></td>
                    <td>
                        <asp:LinkButton ID="LinkButton3" CommandName="del" runat="server">删除</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton4" CommandName="modify" runat="server">更改</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">添加</asp:LinkButton>
    </form>
</body>
</html>
