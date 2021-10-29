using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTools
{
    public class UserInfoManager
    {
        /// <summary>
        /// 利用帳號名查出帳號資訊
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static DataRow GetUserInfoByAccount(string account)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                $@"SELECT [MgrID]
                        , [MgrName]
                        , [MgrPhone]
                        , [MgrEmail]
                        , [MgrStatus]
                        , [MgrLevel]
                        , [MgrPassword]
                        , [MgrAccount]

                    FROM [ManagerAcc]
                    WHERE [MgrAccount] = @account
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@account", account));

            try
            {
                return DBHelper.ReadDataRow(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 利用GUID查出帳號資訊
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        public static DataRow GetUserInfoByGuid(Guid userGuid)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                $@"SELECT [MgrID]
                        , [MgrName]
                        , [MgrPhone]
                        , [MgrEmail]
                        , [MgrStatus]
                        , [MgrLevel]
                        , [MgrPassword]
                        , [MgrAccount]

                     FROM [ManagerAcc]
                    WHERE [MgrID] = @userGuid
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@userGuid", userGuid));

            try
            {
                return DBHelper.ReadDataRow(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 利用帳號查出權限等級
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static int GetAccountUserLevel(string account)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                $@"SELECT 
                        [MgrLevel]
                    FROM [ManagerAcc]
                    WHERE [MgrAccount] = @account
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@account", account));

            try
            {
                var dr = DBHelper.ReadDataRow(connectionString, dbCommandString, list);
                string UserLevelText = dr[0].ToString();
                int UserLevel = Convert.ToInt32(UserLevelText);
                return UserLevel;
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return 0;
            }
        }

        /// <summary>
        /// 變更密碼
        /// </summary>
        /// <param name="account"></param>
        /// <param name="uid"></param>
        /// <param name="Newpwd"></param>
        /// <returns></returns>
        public static bool UpdatePwd(string account, Guid uid, string Newpwd)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" UPDATE [ManagerAcc]
                    SET [MgrPassword] = @Newpwd                    
                    WHERE [MgrAccount] = @account AND [MgrID] = @uid ";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@account", account));
            paramList.Add(new SqlParameter("@uid", uid));
            paramList.Add(new SqlParameter("@Newpwd", Newpwd));

            try
            {
                int effectRows = DBHelper.ModifyData(connStr, dbCommand, paramList);

                if (effectRows == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return false;
            }
        }

        /// <summary>
        /// 以姓名與電話變更密碼
        /// </summary>
        /// <param name="account"></param>
        /// <param name="MgrPhone"></param>
        /// <param name="NewPwd"></param>
        /// <returns></returns>
        public static bool UpdatePwd(string name, string MgrPhone, string NewPwd)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" UPDATE [ManagerAcc]
                    SET [MgrPassword] = @Newpwd                    
                    WHERE [MgrName] = @name AND [MgrPhone] = @MgrPhone ";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@name", name));
            paramList.Add(new SqlParameter("@MgrPhone", MgrPhone));
            paramList.Add(new SqlParameter("@Newpwd", NewPwd));

            try
            {
                int effectRows = DBHelper.ModifyData(connStr, dbCommand, paramList);

                if (effectRows == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return false;
            }
        }


        public static DataTable GetUserInfoFor(Guid UserID)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                $@"SELECT [Name]
                        , [Gender]
                        , [Age]
                        , [Occupation]
                        , [Area]
                        , [ID]
                        , [Account]
                        , [Status]
                        , [DoseCount]
                    FROM [UserInfo]
                    WHERE [UserID] = @userID
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@userID", UserID));
            try
            {
                return DBHelper.ReadDataTable(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return null;
            }
        }

        public static DataTable GetGeneralUserInfo()
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                $@"SELECT [UserID]
                        , [Name]
                        , [Gender]
                        , [Age]
                        , [Occupation]
                        , [Area]
                        , [UserLevel]
                        , [ID]
                        , [Account]
                        , [Password]
                        , [Status]
                        , [DoseCount]
                    FROM [UserInfo]
                    WHERE [UserLevel] = 1
                ";

            List<SqlParameter> list = new List<SqlParameter>();

            try
            {
                return DBHelper.ReadDataTable(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return null;
            }
        }
        public static DataRow GetUserInfoInDataRow()
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                $@"SELECT [UserID]
                        , [Name]
                        , [Gender]
                        , [Age]
                        , [Occupation]
                        , [Area]
                        , [UserLevel]
                        , [ID]
                        , [Account]
                        , [Password]
                        , [Status]
                        , [DoseCount]
                    FROM [UserInfo]
                    WHERE [UserLevel] = 1
                ";

            List<SqlParameter> list = new List<SqlParameter>();

            try
            {
                return DBHelper.ReadDataRow(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return null;
            }
        }



        public static bool CheckInfoIsCorrectForChangPWD(string Account, string PWD)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT 
                        [Account]
                        ,[Password]
                    FROM [UserInfo]
                    WHERE Account = @account AND Password = @pwd";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@account", Account));
            paramList.Add(new SqlParameter("@pwd", PWD));

            try
            {
                var dr = DBHelper.ReadDataRow(connStr, dbCommand, paramList);

                //if (!CheckDataRowIsNull(dr))
                if (dr != null)
                {
                    var OrigAccount = dr[0].ToString();
                    var OrigPWD = dr[1].ToString();
                    if (Account.Trim() == OrigAccount.Trim() && PWD.Trim() == OrigPWD.Trim())
                    {
                        return true;
                    }
                    else
                        return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return false;
            }
        }

        /// <summary>
        /// 檢查DB是否有姓名與電話
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="phone">電話</param>
        /// <returns></returns>
        public static bool CheckInfoIsCorrectForForgotPWD(string name, string phone)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT 
                        [MgrName]
                        ,[MgrPhone]
                    FROM [ManagerAcc]
                    WHERE  [MgrName] = @name AND [MgrPhone] = @phone";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@name", name));
            paramList.Add(new SqlParameter("@phone", phone));

            try
            {
                var dr = DBHelper.ReadDataRow(connStr, dbCommand, paramList);

                //if (!CheckDataRowIsNull(dr))
                if (dr != null)
                {
                    var OrigName = dr[0].ToString();
                    var OrigID = dr[1].ToString();
                    if (name.Trim() == OrigName.Trim() && phone.Trim() == OrigID.Trim())
                    {
                        return true;
                    }
                    else
                        return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return false;
            }
        }


        /// <summary>
        /// 檢查帳號、電話號碼是否重複
        /// </summary>
        /// <param name="account">帳號</param>
        /// <param name="phone">電話</param>
        /// <returns></returns>
        public static bool CheckIfAccountOrPhoneExsist(string account, string phone)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT 
                        [MgrAccount]
                        ,[MgrPhone]
                    FROM [ManagerAcc]
                    WHERE  [MgrAccount] = @account OR [MgrPhone] = @phone";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@account", account));
            paramList.Add(new SqlParameter("@phone", phone));

            try
            {
                var dr = DBHelper.ReadDataRow(connStr, dbCommand, paramList);

                //if (!CheckDataRowIsNull(dr))
                if (dr != null)
                {
                    var OrigAccount = dr[0].ToString();
                    var OrigPhone = dr[1].ToString();
                    if (OrigAccount.Trim() == account.Trim() || phone.Trim() == OrigPhone.Trim())
                    {
                        return true;
                    }
                    else
                        return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return false;
            }
        }

        /// <summary>
        /// 檢查帳號、電話號碼是否重複
        /// </summary>
        /// <param name="email">帳號</param>
        /// <returns></returns>
        public static bool CheckIfEmailExsist(string email)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT 
                        [MgrEmail]
                    FROM [ManagerAcc]
                    WHERE  [MgrEmail] = @email ";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@email", email));

            try
            {
                var dr = DBHelper.ReadDataRow(connStr, dbCommand, paramList);

                //if (!CheckDataRowIsNull(dr))
                if (dr != null)
                {
                    var OrigEmail = dr[0].ToString();
                    if (OrigEmail.Trim() == email.Trim())
                    {
                        return true;
                    }
                    else
                        return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return false;
            }
        }


        public static bool CreateNewAccount(string MgrName, string MgrPhone, string MgrEmail, string MgrAccount, string MgrPassword)
        {
            //隨機生成GUID
            Guid MgrID = Guid.NewGuid();

            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" 
                    INSERT INTO [ManagerAcc]
                    (
                        [MgrID]
                      ,[MgrName]
                      ,[MgrPhone]
                      ,[MgrEmail]
                      ,[MgrStatus]
                      ,[MgrLevel]
                      ,[MgrPassword]
                      ,[MgrAccount]
                    )
                    VALUES 
                    (  
                        @MgrID
                      ,@MgrName
                      ,@MgrPhone
                      ,@MgrEmail
                      ,@MgrStatus
                      ,@MgrLevel
                      ,@MgrPassword
                      ,@MgrAccount
                    )
                ";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@MgrID", MgrID));
            list.Add(new SqlParameter("@MgrName", MgrName));
            list.Add(new SqlParameter("@MgrPhone", MgrPhone));
            list.Add(new SqlParameter("@MgrEmail", MgrEmail));
            list.Add(new SqlParameter("@MgrStatus", 1));
            list.Add(new SqlParameter("@MgrLevel", 1));
            list.Add(new SqlParameter("@MgrPassword", MgrPassword));
            list.Add(new SqlParameter("@MgrAccount", MgrAccount));

            try
            {
                DBHelper.CreatData(connStr, dbCommand, list);
                return true;
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
            }

            return false;
        }

    }
}
