﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SWCPanel.aspx.cs" Inherits="SWCPanel.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">   
        Combine Galactic Time:
        <asp:Label ID="lblCGT" runat="server" Text="Time!"></asp:Label>
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
