<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DontTaiXinZen.aspx.cs" Inherits="RedesignedGoogleForms.test.DontTaiXinZen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnAddSelection" runat="server" Text="增加選項" OnClick="btnAddSelection_Click"/>
            <asp:Button ID="btnWrite" runat="server" Text="寫入" OnClick="btnWrite_Click" />
            <asp:Label ID="Label1" runat="server" Text="Label" ></asp:Label>
            <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </asp:Panel>
            
        </div>
    </form>
</body>
</html>
