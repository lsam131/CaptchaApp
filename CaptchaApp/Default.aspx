<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CaptchaApp.Default" %>
<%@ Register Assembly="BotDetect" Namespace="BotDetect.Web.UI" 
  TagPrefix="BotDetect" %> 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <BotDetect:WebFormsCaptcha ID="Captcha1" runat="server" UserInputID="CaptchaControl1" 
            CodeLength="5"
            ImageSize="200,60"
            ImageFormat="Jpeg"
            SoundEnabled="false"
            />
        <asp:TextBox ID="CaptchaControl1" runat="server" MaxLength="5"/> 
        <asp:Image ID="Image1" runat="server" />

        <asp:Label ID="Label_ErrorMsg" runat="server" Text=""></asp:Label>
        <asp:Label ID="CaptchaCode" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
