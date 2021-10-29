<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontMaster.Master" AutoEventWireup="true" CodeBehind="FormSearch.aspx.cs" Inherits="RedesignedGoogleForms.EntryPages.FormSearch" %>

<%--ucPager test--%>
<%--<%@ Register Src="~/UserCtrl/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container" >
    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
    <asp:Button ID="btnLogout" runat="server" Text="登出" OnClick="btnLogout_Click" />
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        document.body.oncopy = function () { event.returnValue = false }
    </script>
    <br />
    <br />
    
    <div class="container" style="border: 3px #000000 solid;">
        <img src="../MasterPages/Pics/magnifier.png" width="50" height="50" />
        <table>
            <tr>
                <asp:TextBox runat="server" ID="tbSearch" class="form-control" placeholder="請輸入搜尋"></asp:TextBox>
            </tr>
            <tr>
                <td>
                    <img src="../MasterPages/Pics/calendar.png" width="50" height="50" /></td>
                <td>
                    <table></table>
                    <label>選擇起始日期：</label>
                    <div class='input-group date' id='datetimepickerStart'>
                        <asp:TextBox type="text" TextMode="Date" CssClass="form-control" ID="txtDatetimeStart" runat="server"></asp:TextBox>
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                    <label>選擇結束日期：</label>
                    <div class='input-group date' id='datetimepickerEnd'>
                        <asp:TextBox type='text' TextMode="Date" CssClass="form-control" ID="txtDatetimeEnd" runat="server"></asp:TextBox>
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-outline-success" Text="搜尋" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <asp:Button ID="btnNewForm" runat="server" Text="建立新表單" OnClick="btnNewForm_Click" />
    <asp:Button ID="btnDeleteForm" runat="server" Text="刪除選中的表單" OnClick="btnDeleteForm_Click" />
    <%--BindArea--%>
    <asp:Label ID="lbMsg" runat="server" Text=""></asp:Label>
    <%--Gv--%>
    <asp:GridView ID="GridSearchResult" runat="server" class="container"
        OnRowDataBound="GridSearchResult_RowDataBound" AutoGenerateColumns="False"
        AllowPaging="True"
        CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="GridSearchResult_PageIndexChanging">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <%--Gv內容--%>

             <asp:BoundField DataField="FormNumber" HeaderText="#" />
            <%--<asp:HyperLinkField HeaderText="問卷" DataNavigateUrlFields="FormNumber"
                DataNavigateUrlFormatString="\Form.aspx?ID={0}" DataTextField="FormTitle" />--%>
            <asp:TemplateField HeaderText="問卷">
                    <ItemTemplate>
                        <asp:Label ID="lblFormTitle" runat="server" ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            <%--<asp:BoundField DataField="FormState" HeaderText="狀態" />--%>
            <asp:TemplateField HeaderText="狀態">
                    <ItemTemplate>
                        <asp:Label ID="lblFormState" runat="server" ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

            <asp:BoundField DataField="FormStartTime" HeaderText="開始時間" />
            <asp:BoundField DataField="FormEndTime" HeaderText="結束時間" />

            <asp:TemplateField HeaderText="觀看統計" ShowHeader="False" >
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="" Text="觀看統計"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="刪除">
                <EditItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

             <%--Gv內容End--%>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>


    <%--ucPager test--%>
    <%--    <uc1:ucPager runat="server" ID="ucPager" PageSize="5" CurrentPage="1" TotalSize="10" Url="/BackEndPages/SystemAdminPages/LoginDefaultS.aspx" />--%>



    <%--日曆樣式--%>
    <%--<link href="https://cdn.bootcss.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://cdn.bootcss.com/bootstrap-datetimepicker/4.17.47/css/bootstrap-datetimepicker.min.css" rel="stylesheet">
    <script src="https://cdn.bootcss.com/jquery/3.3.1/jquery.js"></script>
    <script src="https://cdn.bootcss.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://cdn.bootcss.com/moment.js/2.24.0/moment-with-locales.js"></script>
    <script src="https://cdn.bootcss.com/bootstrap-datetimepicker/4.17.47/js/bootstrap-datetimepicker.min.js"></script>
    <link href="../ExternalTools/css/bootstrap.css" rel="stylesheet" />--%>
    <%--日曆邏輯--%>
    <%-- <script>
        $(function () {
            $('#datetimepickerStart').datetimepicker({
                format: 'YYYY-MM-DD',
                locale: moment.locale('zh-cn')
            });
            $('#datetimepickerEnd').datetimepicker({
                format: 'YYYY-MM-DD',
                locale: moment.locale('zh-cn')
            });
        });
    </script>--%>
</asp:Content>
