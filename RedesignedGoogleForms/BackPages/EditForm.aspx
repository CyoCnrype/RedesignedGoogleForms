<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontMaster.Master" AutoEventWireup="true" CodeBehind="EditForm.aspx.cs" Inherits="RedesignedGoogleForms.BackPages.EditForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
        <asp:Literal ID="Lt_timeSpan" runat="server"></asp:Literal><br />
        <h3>
        <asp:Label ID="lbTitle" runat="server" Text="編輯問卷"></asp:Label></h3>
        <br />
        <table cellpadding="5">
            <tr>
                <td>
                    <asp:Label ID="lblCaption" runat="server" Text="問卷名稱"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtCaption" runat="server" Style="width: 350px"></asp:TextBox></td>
                <asp:Label ID="lbMsg" runat="server" Text=""></asp:Label>
            </tr>
            <tr valign="top">
                <td>
                    <asp:Label ID="lblDescription" runat="server" Text="描述內容"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" Style="width: 400px" TextMode="MultiLine" placeholder="描述內容為非必填"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblStartDate" runat="server" Text="開始時間"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtStartDate" TextMode="Date" runat="server" Style="width: 350px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEndDate" runat="server" Text="結束時間"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtEndDate" TextMode="Date" runat="server" Style="width: 350px"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:CheckBox ID="chkStatic" runat="server" />
                    <asp:Label ID="lblStatic" runat="server" Text="啟用"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <asp:Button ID="btnSend" runat="server" Text="下一步" OnClick="btnSend_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="放棄" OnClick="btnCancel_Click" />

                </td>
            </tr>
        </table>


    </div>
</asp:Content>
