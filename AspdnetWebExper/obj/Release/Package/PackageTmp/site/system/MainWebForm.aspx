<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainWebForm.aspx.cs" Inherits="AspdnetWebExper.MainWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            width: 50%;
            margin-top: 300px;
            margin-left: 400px;
            font-size: 20px;
            border: solid;
            border-color: gold;
        }
        .custom-style1 {
            text-align: center;
            width: 10%;
            font-style: italic;
            color: greenyellow;
            border: solid;
            border-color: darkorange;
        }
        .custom-style2 {
            text-align: left;
            width: 50%;
            font-size-adjust: initial;
            color: cyan;
            border: solid;
            border-color: darkcyan;
        }
    </style>
</head>
<body style="background-color:wheat;background-image:url(./../../image/aurora__leopard_vs_vista_by_sixwinged.jpg);background-size:cover">
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="custom-style1">
                    <label id="UserId">用户名</label>
                </td>
                <td class="custom-style2">
                    <asp:Label ID="CID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="custom-style1">
                    <label id="UserPCSystem">OS版本</label>
                </td>
                <td class="custom-style2">
                    <asp:Label ID="CSystem" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="custom-style1">
                    <label id="BrowserProperty">浏览器属性</label>
                </td>
                <td class="custom-style2">
                    <asp:Label ID="CBrowserProperty" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
