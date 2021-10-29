using DBTools;
using MatchAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedesignedGoogleForms.BackPages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)//判斷頁面是不是第一次顯示
            {
                //this.lblCode.Text = RandomCode(5);

                Session.RemoveAll();
                txtAccount.Text = "";
                txtPWD.Text = "";
            }
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string inp_Account = this.txtAccount.Text; // inp 為 input
            string inp_PWD = this.txtPWD.Text;
            string msg;

            //驗證是否為登入失敗，如果失敗回傳false
            if (!AuthManager.TryLogin(inp_Account, inp_PWD, out msg))
            {
                this.lblMsg.Text = msg;
                return;
            }

            //如果閒置10分鐘則強制登出
            Session.Timeout = 10;

            //登入成功、轉頁，根據使用者等級開啟功能
            var dr = UserInfoManager.GetAccountUserLevel(inp_Account);
            HttpContext.Current.Session["MgrLevel"] = dr;
            Response.Redirect("FormSearch.aspx");

        }

        /// <summary>
        /// 忘記密碼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnForgetPWD_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPWD.aspx");
        }

        /// <summary>
        /// 註冊帳號
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateNewAccount.aspx");
        }


    }
}