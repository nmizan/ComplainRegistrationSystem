<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="ComplainRegistrationSystem.Manager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="userName" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#6600CC"></asp:Label>
        <br />
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="viewComplainButton" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#6600CC" OnClick="viewComplainButton_Click" Text="View Complain" Width="144px" />
        &nbsp;&nbsp;
        <asp:Button ID="chngPassButton" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#6600CC" OnClick="chngPassButton_Click" Text="Change Password" Width="195px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="userInfoButton" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#6600CC" OnClick="userInfoButton_Click" Text="User Information" Width="176px" />
        &nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="assistantInfoButton0" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#6600CC" Text="Assistant Information" Width="191px" OnClick="assistantInfoButton0_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="logoutButton" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#6600FF" OnClick="logoutButton_Click" Text="Logout" Width="80px" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
