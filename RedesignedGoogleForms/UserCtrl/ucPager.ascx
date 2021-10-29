<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPager.ascx.cs" Inherits="RedesignedGoogleForms.UserCtrl.ucPager" %>

<div class="row">
    <div class="col-4"></div>
    <div class="col-4">
        <nav aria-label="Page navigation example">
            <ul class="pagination justify-content-center">
                <li class="page-item">
                    <a href="#" runat="server" id="aLinkFirstPage" class="page-link">第一頁</a>
                </li>
                <asp:Literal Text="" ID="ltlPager" runat="server" />
                <li class="page-item">
                    <a href="#" runat="server" id="aLinkLastPage" class="page-link">最後頁</a>
                </li>
            </ul>
        </nav>
    </div>
    <div class="col-4"></div>


</div>
<div class="row">
    <div class="col-3"></div>
    <div class="col-6 text-center" style="background-color: whitesmoke;">
        <asp:Literal runat="server" ID="ltlMsg"></asp:Literal>
    </div>
    <div class="col-3"></div>
</div>
