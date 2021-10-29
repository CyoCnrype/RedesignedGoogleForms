using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTools
{
    public class FormSearchManager
    {
        /// <summary>
        /// 取得全部Form
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllForm()
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                $@"SELECT 
                       {SqlStringModel.elementsForSearchForm}
                      FROM [Form]           
                      WHERE [FormIsDeleted] = 0
                    ORDER BY [FormID] ASC
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            //list.Add(new SqlParameter("@allElementInForm", SqlStringModel.allElementInForm));
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

        /// <summary>
        /// 用關鍵字搜尋表單Titel或內文
        /// </summary>
        /// <param name="searchText">關鍵字</param>
        /// <returns></returns>
        public static DataTable SearchFormInDB(string searchText)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                $@"SELECT 
                      {SqlStringModel.elementsForSearchForm}
                    FROM [Form]                     
                    WHERE [FormIsDeleted] = 0 AND
                    [FormTitle] LIKE '%'+@searchText+'%'
                    OR [FormDescription] LIKE '%'+@searchText+'%'
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@searchText", searchText));
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

        /// <summary>
        /// 用關鍵字搜尋表單Titel或內文+時間查詢
        /// </summary>
        /// <param name="searchText">關鍵字</param>
        /// <returns></returns>
        public static DataTable SearchFormInDB(string searchText, DateTime startTime ,DateTime endTime )
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                $@"SELECT 
					{SqlStringModel.elementsForSearchForm}
					   FROM [Form]                     
                    WHERE 				
					[FormTitle] LIKE '%'+@searchText+'%'
                    OR [FormDescription] LIKE '%'+@searchText+'%'	

                      INTERSECT
                      SELECT 
					{SqlStringModel.elementsForSearchForm}
					   FROM [Form]                     
                    WHERE 				
					[FormIsDeleted] = 0    
					AND
					[FormStartTime] > @startTime
					AND 
					[FormEndTime] < @endTime
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            //list.Add(new SqlParameter("@allElementInForm", SqlStringModel.allElementInForm));
            list.Add(new SqlParameter("@searchText", searchText));
            list.Add(new SqlParameter("@startTime", startTime));
            list.Add(new SqlParameter("@endTime", endTime));
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

        /// <summary>
        /// 用GUID找特定Form
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static DataRow SearchFormInDB(Guid guid) // 帶入第幾批次的疫苗，輸出DataRow
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                $@"SELECT 
					{SqlStringModel.elementsForSearchForm}
					   FROM [Form]                     
                    WHERE 				
					[FormID] =@guid             
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@guid", guid));

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
        /// 尋找表單下轄的問題
        /// </summary>
        /// <param name="formID">表單GUID</param>
        /// <returns></returns>
        public static DataTable SearchQuestions(string formID)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                $@"SELECT 
                      {SqlStringModel.elementsForSearchQuestion}
                    FROM [Question]                     
                    WHERE [QueID] = @formID
                    AND
                    [IsAvailable] = 1
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@formID", formID));
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

        /// <summary>
        /// 尋找是否為常用問題
        /// </summary>
        /// <returns></returns>
        public static bool IsFreqQuestion(QuestionModel question)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT 
                          {SqlStringModel.elementsForInsertNewFreqQuestion}
                    FROM [FreqQuestion]
                    WHERE 
                      [QueText]=@QueText
                      AND [QueSelection]=@QueSelection
                      AND [QueSelectionType]=@QueSelectionType
                      AND [QueIsMust]=@QueIsMust
                      AND [IsAvailable] = 1
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@QueText", question.title));
            list.Add(new SqlParameter("@QueSelection", question.selections));
            list.Add(new SqlParameter("@QueSelectionType", question.selectionType));
            list.Add(new SqlParameter("@QueIsMust", question.isMust));

            try
            {
                var dr = DBHelper.ReadDataRow(connStr, dbCommand, list);

                if (dr == null)
                    //if (CheckDataRowIsNull(dr))
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

    }
}
