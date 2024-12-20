<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebFormDemo.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="l1" Text="id" runat="server"></asp:Label>
        <asp:TextBox ID="uid" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rv1" ControlToValidate="uid" ErrorMessage="uid cannot be empty" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="l2" Text="username" runat="server"></asp:Label>
        <asp:TextBox ID="uname" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rv2" ControlToValidate="uname" ErrorMessage="uname cannot be empty" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="l3" Text="password" runat="server"></asp:Label>
        <asp:TextBox ID="pass" TextMode="Password" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rv3" ControlToValidate="pass" ErrorMessage="password cannot be empty" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="l4" Text="repassword" runat="server"></asp:Label>
        <asp:TextBox ID="repass" TextMode="Password" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rv4" ControlToValidate="repass" ErrorMessage="repassword cannot be empty" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="rv5" ControlToValidate="repass" ControlToCompare="pass" ErrorMessage="pass and repass should be same" ForeColor="Red" runat="server"></asp:CompareValidator>
        <br />
        <asp:Label ID="l5" Text="Gender" runat="server"></asp:Label>
        <asp:RadioButton ID="rb1" GroupName="gender" Text="male" runat="server" />
        <asp:RadioButton ID="rb2" GroupName="gender" Text="female" runat="server" />
        <br />
        <asp:Label ID="l6" Text="Faculty" runat="server"></asp:Label>
        <asp:DropDownList ID="fac" runat="server">
            <asp:ListItem Value="">Select your faculty:</asp:ListItem>
            <asp:ListItem Value="BIM">BIM</asp:ListItem>
            <asp:ListItem Value="CSIT">CSIT</asp:ListItem>
            <asp:ListItem Value="BBM">BBM</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Button ID="btn1" Text="Submit" OnClick="btn_ans" runat="server" />
        <br />
        <asp:Label ID="l7" Text="Result" runat="server"></asp:Label>
    </form>
</body>
</html>
