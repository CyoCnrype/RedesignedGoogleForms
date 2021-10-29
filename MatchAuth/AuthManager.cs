using DBTools;
using System;
using System.Data;
using System.Web;

namespace MatchAuth
{
    public class AuthManager
    {
        #region 登入驗證
        /// <summary> 檢查目前是否登入 </summary>
        /// <returns></returns>
        public static bool IsLogined()
        {
            if (HttpContext.Current.Session["UserLoginInfo"] == null)
                return false;
            else
                return true;
        }

        /// <summary> 取得已登入的使用者資訊 (如果沒有登入就回傳 null) </summary>
        /// <returns></returns>
        public static UserInfoModel GetCurrentUser()
        {
            string account = HttpContext.Current.Session["UserLoginInfo"] as string;

            if (account == null)
                return null;

            DataRow dr = UserInfoManager.GetUserInfoByAccount(account);

            if (dr == null)
            {
                HttpContext.Current.Session["UserLoginInfo"] = null;
                return null;
            }

            UserInfoModel model = new UserInfoModel();
            model.MgrID = ((Guid)dr["MgrID"]);
            model.MgrName = dr["MgrName"].ToString();
            model.MgrPhone = dr["MgrPhone"].ToString();
            model.MgrEmail = dr["MgrEmail"].ToString();
            model.MgrStatus = (bool)dr["MgrStatus"];
            model.MgrLevel = (byte)dr["MgrLevel"];
            model.MgrAccount = dr["MgrAccount"].ToString();
            model.MgrPassword = dr["MgrPassword"].ToString();            

            return model;
        }

        #endregion

        #region 登入/登出
        /// <summary> 登入 </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static bool TryLogin(string account, string pwd, out string errorMsg)
        {
            // check empty
            if (string.IsNullOrWhiteSpace(account) || string.IsNullOrWhiteSpace(pwd))
            {
                errorMsg = "請輸入帳號密碼";
                return false;
            }

            // read db and check
            var dr = UserInfoManager.GetUserInfoByAccount(account);

            //check null
            if (dr == null)
            {
                errorMsg = $"此帳號並不存在"; // 查不到的話
                return false;
            }

            // check account / pwd
            if (string.Compare(dr["MgrAccount"].ToString(), account, true) == 0 &&
                string.Compare(dr["MgrPassword"].ToString(), pwd, false) == 0) // 因密碼要強制大小寫因此設定為false
            {
                HttpContext.Current.Session["UserLoginInfo"] = dr["MgrAccount"].ToString(); // 正確並跳頁
                errorMsg = string.Empty;
                return true;
            }
            else
            {
                errorMsg = "請檢查密碼是否正確";
                return false;
            }

        }

        /// <summary> 登出 </summary>
        /// <returns></returns>
        public static void Logout()
        {
            HttpContext.Current.Session["UserLoginInfo"] = null;
        }
        #endregion

    }
}
