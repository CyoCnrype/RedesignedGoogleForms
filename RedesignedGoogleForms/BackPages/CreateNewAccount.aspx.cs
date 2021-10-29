using DBTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedesignedGoogleForms.EntryPages
{
    public partial class CreateNewAccount : System.Web.UI.Page
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
            string inp_Email = this.txtEmail.Text;
            string inp_Account = this.txtAccount.Text;

            if (UserInfoManager.CreateNewAccount(inp_Name, inp_Phone, inp_Email, inp_Account, NewPwd))
            {
                Session.Clear();
                Response.Write("<Script language='JavaScript'>alert('帳號新增成功!'); location.href='/Session.Clear();/EntryPage.aspx'; </Script>");
            }

            Response.Write("帳號新增失敗");


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

            // Email 必填
            if (string.IsNullOrWhiteSpace(this.txtEmail.Text))
            {
                msgList.Add("請輸入Email ");
                errorMsgList = msgList;
                return false;
            }


            // 帳號 必填
            if (string.IsNullOrWhiteSpace(this.txtAccount.Text))
            {
                msgList.Add("請輸入帳號");
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
            var pwd = this.txtNewPWD.Text;
            if (!IsPwdLegal(pwd))
            {
                msgList.Add("密碼長度限制 (需要8~16碼)");
                errorMsgList = msgList;
                return false;
            }

            // 檢查帳號、電話是否存在
            string inp_Account = this.txtAccount.Text;
            string inp_Phone = this.txtPhone.Text;

            if (UserInfoManager.CheckIfAccountOrPhoneExsist(inp_Account, inp_Phone))
            {
                msgList.Add("帳號或電話已經存在");
                errorMsgList = msgList;
                return false;
            }

            // 檢查Email是否存在
            string inp_Email = this.txtEmail.Text;
            if (UserInfoManager.CheckIfEmailExsist(inp_Email))
            {
                msgList.Add("Email已經存在");
                errorMsgList = msgList;
                return false;
            }



            // 電話號碼檢查
            if (!IsPhoneLegal(inp_Phone))
            {
                msgList.Add("電話號碼長度不正確 (台灣為10碼)");
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
            Response.Redirect("EntryPage.aspx");
        }

        private bool IsPhoneLegal(string phnoe)
        {
            if (phnoe.Length != 10)
                return false;
            return true;
        }

        private bool IsPwdLegal(string pwd)
        {
            // 密碼長度限制 (8~16)
            if (pwd.Length < 8 || pwd.Length > 16)
                return false;
            return true;


        }

    }
}