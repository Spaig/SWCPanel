<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SWCPanel.aspx.cs" Inherits="SWCPanel.SWCPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">   
        Current Earth Time:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblSET" runat="server" Text="earthlings"></asp:Label>
        <br />
        Combine Galactic Time:
        &nbsp;&nbsp;
        <asp:Label ID="lblCGT" runat="server" Text="time_placeholder"></asp:Label>
&nbsp;&nbsp;
        <asp:Button ID="btnUpdateTime" runat="server" OnClick="btnUpdateTime_Click" Text="Time Sync" />
        <br />
        <br />
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
            <asp:ListItem>Test1</asp:ListItem>
            <asp:ListItem>Test2</asp:ListItem>
        </asp:CheckBoxList>
    </form>
</body>
</html>
