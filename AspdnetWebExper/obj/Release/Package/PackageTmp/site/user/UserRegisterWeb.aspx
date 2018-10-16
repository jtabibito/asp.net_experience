<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegisterWeb.aspx.cs" Inherits="AspdnetWebExper.site.user.UserRegisterWeb" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-top: 300px;
            text-align: center;
            width: 100%;
        }
        .custom-style1 {
            text-align: right;
            width: 30%;
        }
        .custom-style2 {
            text-align: left;
        }
        .auto-style2 {
            text-align: right;
            width: 20%;
            height: 72px;
        }
        .auto-style3 {
            text-align: left;
            height: 72px;
        }
        .custom-style3 {
            text-align: center;
            margin-left: -400px;
        }
        .custom-style4 {
            text-align: center;
            font-size: larger;
            margin-left: -200px;
        }
        .form-style {
            margin-left: 300px;
            font-size: x-large;
        }
        .auto-style4 {
            text-align: right;
            width: 30%;
            height: 72px;
        }
        .auto-style5 {
            text-align: left;
            height: 72px;
        }
    </style>
</head>
<body style="background-image:url(./../../image/beta6.jpg);background-size:cover;">
    <form id="form1" runat="server" class="form-style">
        <table class="auto-style1">
            <tr>
                <td class="custom-style1">
                    <label id="uid">用户名</label>
                </td>
                <td class="custom-style2">
                    <asp:TextBox ID="uNameText" Width="300px" runat="server"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="uNameText_TextBoxWatermarkExtender" runat="server" WatermarkText="请输入用户名" TargetControlID="uNameText">
                    </asp:TextBoxWatermarkExtender>
                    <asp:RequiredFieldValidator ID="uNmValidater" runat="server" ControlToValidate="uNameText" ErrorMessage="用户名为空" ViewStateMode="Enabled" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="uNmValidater_ValidatorCalloutExtender" runat="server" TargetControlID="uNmValidater" Width="400px">
                    </asp:ValidatorCalloutExtender>
            <asp:Image ID="PreviewImage" runat="server" BorderStyle="Dashed" Height="60px" ImageAlign="AbsMiddle" ImageUrl="~/gravatar/chinaz1.ico" Width="60px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <label id="upwd">密码</label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="uPwdText" Width="300px" runat="server"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="uPwdText_TextBoxWatermarkExtender" WatermarkText="包含一个英文字母和特殊字符" runat="server" TargetControlID="uPwdText">
                    </asp:TextBoxWatermarkExtender>
                    <asp:PasswordStrength ID="uPwdText_PasswordStrength" runat="server" MinimumNumericCharacters="6" MinimumSymbolCharacters="1" MinimumUpperCaseCharacters="1" PreferredPasswordLength="10" PrefixText="强度: " RequiresUpperAndLowerCaseCharacters="True" TargetControlID="uPwdText" TextStrengthDescriptions="很弱;弱;中等;强;很强">
                    </asp:PasswordStrength>
                    <asp:FileUpload ID="ImageFileUpload" runat="server" BackColor="#FF99FF" />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <label id="upwd_alfirm">确认密码</label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="uPwdAlfirmText" Width="300px" runat="server"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="uPwdAlfirmText_TextBoxWatermarkExtender" WatermarkText="请确认密码" runat="server" TargetControlID="uPwdAlfirmText">
                    </asp:TextBoxWatermarkExtender>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="uPwdText" ControlToValidate="uPwdAlfirmText" ErrorMessage="密码前后不一致" ForeColor="Red"></asp:CompareValidator>
                    <asp:ValidatorCalloutExtender ID="CompareValidator1_ValidatorCalloutExtender" runat="server" TargetControlID="CompareValidator1" Width="400px">
                    </asp:ValidatorCalloutExtender>
                </td>
            </tr>
        </table>
        <div class="custom-style4">
            <asp:Button ID="GravatarUploadBtn" runat="server"  Font-Size="large" Width="90px" Height="40px" Text="上传头像" OnClick="GravatarUploadBtn_Click" />
            <asp:Button ID="SubmitBtn" runat="server" Text="确认" Font-Size="large" Width="90px" Height="40px" OnClick="SubmitBtn_Click"/>
        </div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager" runat="server">
            </asp:ToolkitScriptManager>
    </form>
</body>
</html>
