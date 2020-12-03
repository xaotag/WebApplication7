<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddInfoLog.aspx.cs" Inherits="WebApplication7.Web.AddInfoLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="./css/bootstrap.min.css" rel="stylesheet" />
    <style>
        #TxtAr {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-md">
            
            <asp:TextBox ID="TextBox1" runat="server" placeholder="标题"></asp:TextBox><br/>
            <p></p>
           <textarea id="TxtAr" runat="server"   placeholder="内容"></textarea>
            <asp:Button Text="发布" ID="Button1" CssClass="btn btn-primary" runat="server" OnClick="Unnamed1_Click" />
        </div>
    </form>
        
</body>
</html>
