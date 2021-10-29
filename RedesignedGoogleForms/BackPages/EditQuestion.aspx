<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontMaster.Master" AutoEventWireup="true" CodeBehind="EditQuestion.aspx.cs" Inherits="RedesignedGoogleForms.BackPages.EditQuestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
        <asp:Literal ID="Lt_timeSpan" runat="server"></asp:Literal><br />
        <h3>
            <asp:Label ID="lbTitle" runat="server" Text="編輯問題"></asp:Label></h3>
        <br />
        <table cellpadding="5">
            <tr>
                <td>
                    <asp:Label ID="lbCommonQue" runat="server" Text="種類"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlCommonQue" runat="server">
                        <asp:ListItem Value="0">請選擇</asp:ListItem>
                        <asp:ListItem Value="1">新問題</asp:ListItem>
                    </asp:DropDownList>
            </tr>
            <tr>
                <td>
                <td>
                    <asp:CheckBox ID="cbIsMust" runat="server" />
                    <asp:Label ID="lbIsMust" runat="server" Text="是否必填"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbQueTitle" runat="server" Text="問題"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtQueTitle" runat="server" Style="width: 350px"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:DropDownList ID="ddlQueType" runat="server" OnSelectedIndexChanged="ddlQueType_SelectedIndexChanged">
                        <asp:ListItem Value="0">請選擇</asp:ListItem>
                        <asp:ListItem Value="1">單選題</asp:ListItem>
                        <asp:ListItem Value="2">多選題</asp:ListItem>
                        <asp:ListItem Value="3">填空題</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btnQueTypeChecked" runat="server" Text="確定" OnClick="btnQueTypeChecked_Click" />
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAddSelection" runat="server" Text="增加選項" OnClick="btnAddSelection_Click" Visible="false" />
                    <asp:Button ID="btnToZero" runat="server" Text="歸零" Visible="false" OnClick="btnToZero_Click" />
                </td>
                <td>
                    <asp:Panel ID="Panel1" runat="server" Visible="false">
                        <asp:TextBox ID="TextBox1" runat="server" Style="width: 350px" placeholder="選項1" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="TextBox2" runat="server" Style="width: 350px" placeholder="選項2" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="TextBox3" runat="server" Style="width: 350px" placeholder="選項3" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="TextBox4" runat="server" Style="width: 350px" placeholder="選項4" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="TextBox5" runat="server" Style="width: 350px" placeholder="選項5" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="TextBox6" runat="server" Style="width: 350px" placeholder="選項6" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="TextBox7" runat="server" Style="width: 350px" placeholder="選項7" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="TextBox8" runat="server" Style="width: 350px" placeholder="選項8" Visible="false"></asp:TextBox>
                    </asp:Panel>
                    <asp:Label ID="lbMsg" runat="server" Text=""></asp:Label>

                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:CheckBox ID="chkIsFreq" runat="server" />
                    <asp:Label ID="lbIsFreq" runat="server" Text="常用問題"></asp:Label>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnAddQue" runat="server" Text="新增問題" OnClick="btnAddQue_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnDeleteQuestions" runat="server" Text="刪除選中的問題" OnClick="btnDeleteQuestions_Click" />
                </td>
                <td>
                    <asp:GridView ID="QusetionView" runat="server"
                        AutoGenerateColumns="False" class="container" ForeColor="#333333" GridLines="None"
                        CellPadding="10" OnRowDataBound="QusetionView_RowDataBound">
                        <Columns>
                            <%--Gv內容--%>
                            <asp:TemplateField HeaderText="刪除">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="QueNumber" HeaderText="#" />
                            <asp:BoundField DataField="QueText" HeaderText="問題" />
                            <asp:TemplateField HeaderText="種類">
                                <ItemTemplate>
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <asp:Label ID="lbQueType" runat="server" Text="Label"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:CheckBoxField DataField="QueIsMust" HeaderText="必填" />--%>
                            <%--<asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnUpdate" runat="server" Text="編輯" CommandName="Upate" CommandArgument='<%# Eval("ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>--%>

                            <%--Gv內容--%>
                        </Columns>
                    </asp:GridView>
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
