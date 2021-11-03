using DBTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedesignedGoogleForms.EntryPages
{
    public partial class ForgotPWD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            List<string> msgList = new List<string>();
            if (!this.CheckInput(out msgList))
            {
                this.lblMsg.Text = string.Join("<br/>", msgList);
                return;
            }

            string inp_Name = this.txtName.Text;
            string inp_Phone = this.txtPhone.Text;
            string NewPwd = this.txtNewPWD.Text;

            if (UserInfoManager.UpdatePwd(inp_Name, inp_Phone, NewPwd))
            {
                Session.Clear();
                Response.Write("<Script language='JavaScript'>alert('您的密碼已更改成功!'); location.href='/EntryPages/EntryPage.aspx'; </Script>");

            }

            //Response.Redirect("Login.aspx");
            //this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('您的密碼已更改成功!')</script>");
            
        }

        private bool CheckInput(out List<string> errorMsgList)
        {
            List<string> msgList = new List<string>();

            // 姓名 必填
            if (string.IsNullOrWhiteSpace(this.txtName.Text))
            {
                msgList.Add("請輸入姓名");
                errorMsgList = msgList;
                return false;
            }

            // 電話 必填
            if (string.IsNullOrWhiteSpace(this.txtPhone.Text))
            {
                msgList.Add("請輸入電話號碼 ");
                errorMsgList = msgList;
                return false;
            }

            // 新密碼 必填
            if (string.IsNullOrWhiteSpace(this.txtNewPWD.Text))
            {
                msgList.Add("請輸入新密碼");
                errorMsgList = msgList;
                return false;
            }

            // 確認新密碼 必填
            if (string.IsNullOrWhiteSpace(this.txtPWDconf.Text))
            {
                msgList.Add("請確認新密碼");
                errorMsgList = msgList;
                return false;
            }


            // 新密碼及確認新密碼須為一致
            if (txtNewPWD.Text.Trim() != txtPWDconf.Text.Trim())
            {
                msgList.Add("請確認新密碼是否一致");
                errorMsgList = msgList;
                return false;
            }

            // 密碼長度限制 (8~16)
            if (this.txtNewPWD.Text.Length < 8 || this.txtNewPWD.Text.Length > 16)
            {
                msgList.Add("密碼長度限制 (需要8~16碼)");
                errorMsgList = msgList;
                return false;
            }

            // 檢查姓名及電話是否存在
            string inp_Name = this.txtName.Text;
            string inp_Phone = this.txtPhone.Text;

            if (!UserInfoManager.CheckInfoIsCorrectForForgotPWD(inp_Name, inp_Phone))
            {
                msgList.Add("姓名或電話錯誤");
                errorMsgList = msgList;
                return false;
            }


            errorMsgList = msgList;


            if (msgList.Count == 0)
                return true;
            else
                return false;
        }

        protected void btnBackToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("/EntryPages/EntryPage.aspx");

        }
    }

}
