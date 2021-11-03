using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTools
{
    public class FormEditManager
    {
        /// <summary>
        /// 新增表單
        /// </summary>
        /// <param name="form">表單模組</param>
        public static void InsertNewForm(FormModel form)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" 
                    INSERT INTO [Form]
                    (
                           {SqlStringModel.elementsForInsertNewForm}
                    )
                    VALUES 
                    (                          
                         @FormTag
                         ,@FormTitle
                         ,@FormState
                         ,@FormStartTime
                         ,@FormEndTime                         
                         ,@FormDescription
                         ,@FormCount
                         ,@FormID
                         ,@FormIsDeleted
                       
                    )
                ";
            List<SqlParameter> list = new List<SqlParameter>();
            //list.Add(new SqlParameter("@FormNumber", ));
            list.Add(new SqlParameter("@FormTag", ""));
            list.Add(new SqlParameter("@FormTitle", form.title));
            list.Add(new SqlParameter("@FormState", form.isAvailable));
            list.Add(new SqlParameter("@FormStartTime", form.startTime));
            list.Add(new SqlParameter("@FormEndTime", form.endTime));
            //list.Add(new SqlParameter("@FormEstablishedTime", form));
            list.Add(new SqlParameter("@FormDescription", form.description));
            list.Add(new SqlParameter("@FormCount", form.count));
            list.Add(new SqlParameter("@FormID", form.id));
            list.Add(new SqlParameter("@FormIsDeleted", form.isDeleted));
            

            try
            {
                DBHelper.CreatData(connStr, dbCommand, list);
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
            }
        }
        /// <summary>
        /// 修改表單
        /// </summary>
        /// <param name="form"></param>
        public static void UpdateForm(FormModel form)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" 
                   UPDATE [Form]
                    SET 
                             [FormTitle]                          =@FormTitle
                             ,[IsAvailable]                       =@IsAvailable
                             ,[FormStartTime]               =@FormStartTime
                             ,[FormEndTime]                =@FormEndTime
                             ,[FormDescription]           =@FormDescription
                             ,[FormCount]                     =@FormCount
                             ,[FormIsDeleted]               =@FormIsDeleted


                    WHERE [FormID] = @FormID 
                ";
            List<SqlParameter> list = new List<SqlParameter>();
            //list.Add(new SqlParameter("@FormTag", ""));
            list.Add(new SqlParameter("@FormTitle", form.title));
            list.Add(new SqlParameter("@IsAvailable", form.isAvailable));
            list.Add(new SqlParameter("@FormStartTime", form.startTime));
            list.Add(new SqlParameter("@FormEndTime", form.endTime));
            //list.Add(new SqlParameter("@FormEstablishedTime", form));
            list.Add(new SqlParameter("@FormDescription", form.description));
            list.Add(new SqlParameter("@FormCount", form.count));
            list.Add(new SqlParameter("@FormID", form.id));
            list.Add(new SqlParameter("@FormIsDeleted", form.isDeleted));


            try
            {
                DBHelper.CreatData(connStr, dbCommand, list);
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// 刪除表單
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public static bool DeleteForm(string FormNumber)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" UPDATE [Form]
                    SET [FormIsDeleted] = 1

                    WHERE [FormNumber] = @FormNumber 
                ";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@FormNumber", FormNumber));
            //paramList.Add(new SqlParameter("@userID", UserID));

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
        /// 新增問題
        /// </summary>
        /// <param name="question"></param>
        public static void InsertNewQuestion(QuestionModel question)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" 
                    INSERT INTO [Question]
                    (
                           {SqlStringModel.elementsForInsertNewQuestion}
                    )
                    VALUES 
                    (                          
                          @QueTag
                         ,@QueText
                         ,@QueSelection
                         ,@QueStatus
                         ,@QueSelectionType
                         ,@QueIsMust
                         ,@QueID
                       
                    )
                ";
            List<SqlParameter> list = new List<SqlParameter>();
            //list.Add(new SqlParameter("@FormNumber", ));
            list.Add(new SqlParameter("@QueTag", ""));
            list.Add(new SqlParameter("@QueText", question.title));
            list.Add(new SqlParameter("@QueSelection", question.selections));
            list.Add(new SqlParameter("@QueStatus", question.isAvailable));
            list.Add(new SqlParameter("@QueSelectionType", question.selectionType));
            list.Add(new SqlParameter("@QueIsMust", question.isMust));
            list.Add(new SqlParameter("@QueID", question.id));
          

            try
            {
                DBHelper.CreatData(connStr, dbCommand, list);
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// 新增常用問題
        /// </summary>
        /// <param name="question"></param>
        public static void InsertNewFreqQuestion(QuestionModel question)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" 
                    INSERT INTO [FreqQuestion]
                    (
                           {SqlStringModel.elementsForInsertNewFreqQuestion}
                    )
                    VALUES 
                    (                          
                           @QueText
                          ,@QueSelection
                          ,@IsAvailable
                          ,@QueSelectionType
                          ,@QueIsMust
                       
                    )
                ";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@QueText", question.title));
            list.Add(new SqlParameter("@QueSelection", question.selections));
            list.Add(new SqlParameter("@IsAvailable", question.isAvailable));
            list.Add(new SqlParameter("@QueSelectionType", question.selectionType));
            list.Add(new SqlParameter("@QueIsMust", question.isMust));

            try
            {
                DBHelper.CreatData(connStr, dbCommand, list);
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// 刪除問題
        /// </summary>
        /// <param name="FormGuid"></param>
        /// <returns></returns>
        public static bool DeleteQuestions(Guid formGuid)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" DELETE FROM  [Question]
                    WHERE [QueID] = @formGuid 
                ";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@formGuid", formGuid));
            //paramList.Add(new SqlParameter("@userID", UserID));

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

    }
}
