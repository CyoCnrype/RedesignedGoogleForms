<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontMaster.Master" AutoEventWireup="true" CodeBehind="EntryPage.aspx.cs" Inherits="RedesignedGoogleForms.EntryPages.EntryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h4>系統介紹</h4>

        <table class="table table-striped table-light">
            <thead>
                <tr>
                    <th>操作方法</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>請按下進入填寫或登入以新增/修改表單</td>
                </tr>
            </tbody>
        </table>
        <br />
        <h4>歡迎光臨買Form！</h4>
        <div class="text-center">
            <asp:Button  CssClass="btn btn-outline-success btn-lg"  ID="btnUser" runat="server" Text="   填寫表單   " OnClick="btnUser_Click" />
            &nbsp&nbsp&nbsp
            <asp:Button  CssClass="btn btn-outline-danger btn-lg"  ID="btnManager" runat="server" Text="   新增/建立表單   "  OnClick="btnManager_Click"/>
            <br />
        </div><br />
        <br />
        <h4>系統開發者</h4>
        <p class="text-center font-weight-bold">YellowDuckGroup  </p>
    </div>
</asp:Content>
