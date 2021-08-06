<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AccountingNote.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:PlaceHolder ID="plcLogin" runat="server" Visible="False"></asp:PlaceHolder>
        Account:<asp:TextBox ID="txtaccount" runat="server"></asp:TextBox>
        <br />
        Password:<asp:TextBox ID="txtPWD" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnlogin" runat="server" Text="login" OnClick="btnlogin_Click"  /><br />
        <asp:Literal ID="ItlMsg" runat="server"></asp:Literal>
    </form>
</body>
</html>
