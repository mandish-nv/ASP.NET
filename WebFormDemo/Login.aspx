<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebFormDemo.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="l1" Text="Username" runat="server"></asp:Label>
        <asp:TextBox ID="uname" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="l2" Text="Password" runat="server"></asp:Label>
        <asp:TextBox ID="pass" TextMode="Password" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="submit" Text="Submit" OnClick="btn_log" runat="server" />
        <br />
        <asp:Label ID="l3" Text="Result" runat="server"></asp:Label>
    </form>
</body>
</html>
