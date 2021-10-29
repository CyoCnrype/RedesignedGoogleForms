<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontMaster.Master" AutoEventWireup="true" CodeBehind="AnserForm.aspx.cs" Inherits="RedesignedGoogleForms.FrontPages.AnserForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="border: 3px #000000 solid;">
        <div>
            問卷名稱：&nbsp&nbsp<asp:Literal ID="ltTitle" runat="server"></asp:Literal><br />
            問卷敘述：&nbsp&nbsp<asp:Literal ID="ltDiscription" runat="server"></asp:Literal><br />
            <br />
            <br />
            姓名：&nbsp&nbsp<asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
            <br />
            手機：&nbsp&nbsp<asp:TextBox ID="txtPhone" runat="server"></asp:TextBox><br />
            <br />
            Email：&nbsp<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
            <br />
            年齡：&nbsp&nbsp<asp:TextBox ID="txtAge" runat="server"></asp:TextBox><br />
            <br />
        </div>
        <div id="main">
        </div>
        <asp:Button ID="btnSubmit" runat="server" Text="送出" />
        <asp:Button ID="btnCancel" runat="server" Text="取消" /><br />        
        <asp:Literal ID="ltMsg" runat="server"></asp:Literal>
        <asp:HiddenField ID="hfFormPaper" runat="server" />
    </div>
</asp:Content>
