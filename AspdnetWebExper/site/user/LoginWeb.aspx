<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginWeb.aspx.cs" Inherits="AspdnetWebExper.LoginWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            width: 50%;
            margin-top: 430px;
            margin-left: 450px;
            font-size: 30px;
            color: chartreuse;
        }
        .custom-style1 {
            text-align: right;
            width: 34.7%;
        }
        .custom-style2 {
            text-align: left;
            width: 50%;
        }
        .custom-style3 {
            margin-left: 800px;
            color: lawngreen;
        }
    </style>
</head>
<body style="background-color:wheat;background-image:url(./../../image/Final7.jpg);background-size:cover;">
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="custom-style1">
                    <label id="uNameLabel">用户名</label>
                </td>
                <td class="custom-style2">
                    <asp:TextBox ID="uNameText" AutoPostBack="false" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="custom-style1">
                    <label id="uPwdLabel">密码</label>
                </td>
                <td class="custom-style2">
                    <asp:TextBox ID="uPwdText" AutoPostBack="false" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div class="custom-style3">
            <asp:LinkButton ID="userRegistingAccount" Text="注册账户" ForeColor="#ffcc00" BorderColor="#99ff66" BorderStyle="Dashed" runat="server" OnClick="userRegistingAccount_Click"></asp:LinkButton>
            <asp:CheckBox ID="AutoLoginCB" Text="自动登录" runat="server"/>
            <asp:Button ID="uLoginBtn" runat="server" Width="70px" Height="50px" Font-Size="Medium" Text="登录" OnClick="uLoginBtn_Click"/>
        </div>
    </form>
</body>
</html>
