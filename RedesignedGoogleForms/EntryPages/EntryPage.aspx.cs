using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedesignedGoogleForms.EntryPages
{
    public partial class EntryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)//判斷頁面是不是第一次顯示
            {
                //this.lblCode.Text = RandomCode(5);
                Session.RemoveAll();
            }

            Session["UserIdentity"] = null;
        }

        /// <summary>
        /// 問卷填寫者按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUser_Click(object sender, EventArgs e)
        {
            Session["MgrLevel"] = 0;
            Response.Redirect("/FrontPages/FormSearchUser.aspx");            
        }


        /// <summary>
        /// 問卷製作者登入按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnManager_Click(object sender, EventArgs e)
        {
            Response.Redirect("/BackPages/Login.aspx");
        }
    }
}