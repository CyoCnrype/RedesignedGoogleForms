﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RedesignedGoogleForms.BackPages.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        document.body.oncopy = function () { event.returnValue = false }
    </script>
    <br />
    <br /> <div>
    <asp:Label CssClass="col-form-label-lg" ID="lblAccount" runat="server" Text="帳號："></asp:Label><br />
    <asp:TextBox CssClass="form-control" ID="txtAccount" runat="server" placeholder="在此輸入您的帳號"></asp:TextBox><br />
    <asp:Label CssClass="col-form-label-lg" ID="lblPWD" runat="server" Text="密碼："></asp:Label><br />
    <asp:TextBox CssClass="form-control" ID="txtPWD" runat="server" TextMode="Password" placeholder="在此輸入您的密碼"></asp:TextBox><br />
    </div>

        <div>
        <asp:Button CssClass="btn btn-outline-success btn-lg" ID="btnLogin" runat="server" Text="   登入   " OnClick="btnLogin_Click"/> &nbsp &nbsp &nbsp
        <asp:Button CssClass="btn btn-outline-danger" ID="btnForgetPWD" runat="server" Text=" 忘記密碼 " OnClick="btnForgetPWD_Click"/> &nbsp &nbsp
        <asp:Button CssClass="btn btn btn-primary" ID="btnCreateAccount" runat="server" Text=" 註冊帳號 " OnClick="btnCreateAccount_Click" />
            <asp:Label CssClass="col-form-label-lg" ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
    <br /><br /><br /><br /><br />
</asp:Content>
