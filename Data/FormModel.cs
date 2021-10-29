using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// 表單屬性
    /// </summary>
    public class FormModel
    {
        //標題
        public string title { get; set; }
        //是否啟用
        public bool isAvailable { get; set; }
        //起始時間
        public DateTime startTime { get; set; } = DateTime.Now;
        //結束時間
        public DateTime endTime { get; set; } = FormTime.maxDate;
        //內容說明
        public string description { get; set; }
        //問題數量
        public int count { get; set; }
        //表單自身的GUID
        public Guid id { get; set; } = Guid.NewGuid();
        //是否被刪除
        public bool isDeleted { get; set; } = false;
    }

    /// <summary>
    /// 預設表單時間
    /// </summary>
    public class FormTime
    {
        public static DateTime minDate
        {
            get { return new DateTime(1990, 1, 1); }
        }
        public static DateTime maxDate
        {
            get { return new DateTime(2999, 12, 31); }
        }
    }

    /// <summary>
    /// 問題屬性與模組
    /// </summary>
    public class QuestionModel
    {
        //標題
        public string title { get; set; }
        //是否為必填
        public bool isMust { get; set; }
        //選項
        public string selections { get; set; }
        //選項種類
        public int selectionType { get; set; }
        //選項數量
        public int selectionNumber { get; set; }
        //問題GUID(與表單連動)
        public Guid id { get; set; }
        //是否被刪除
        public bool isDeleted { get; set; } = false;
        //是否啟用
        public bool isAvailable { get; set; }


        /// <summary>
        /// 創造問題用Dt
        /// </summary>
        /// <returns></returns>
        public  DataTable CreateQuestionDt()
        {
            DataTable dtQue = new DataTable();
            dtQue.Columns.Add(new DataColumn("QueNumber", typeof(int)));
            dtQue.Columns.Add(new DataColumn("QueTag", typeof(string)));
            dtQue.Columns.Add(new DataColumn("QueText", typeof(string)));
            dtQue.Columns.Add(new DataColumn("QueSelection", typeof(string)));
            dtQue.Columns.Add(new DataColumn("IsAvailable", typeof(bool)));
            dtQue.Columns.Add(new DataColumn("QueSelectionType", typeof(int)));
            dtQue.Columns.Add(new DataColumn("QueIsMust", typeof(bool)));
            dtQue.Columns.Add(new DataColumn("QueID", typeof(Guid)));
            return dtQue;
        }

        /// <summary>
        /// 將本Class的各屬性加入至DT
        /// </summary>
        /// <param name="dtQue"></param>
        /// <returns></returns>
        public DataTable CreateDrQueInDt(DataTable dtQue)
        {
            DataRow drQue = dtQue.NewRow();
            //drQue["QueNumber"] = 0;
            drQue["QueTag"] = null;
            drQue["QueText"] = title;
            drQue["QueSelection"] = selections;
            drQue["IsAvailable"] = isAvailable;
            drQue["QueSelectionType"] = selectionType;
            drQue["QueIsMust"] = isMust;
            drQue["QueID"] = id;
            dtQue.Rows.Add(drQue);
            return dtQue;
        }

        /// <summary>
        /// 將Dr建立為問題模組
        /// </summary>
        /// <param name="drQue"></param>
        /// <returns></returns>
        public QuestionModel CreateModelQue(DataRow drQue)
        {
            QuestionModel qm = new QuestionModel();
            if (            
            drQue["QueText"] == null ||
            drQue["QueSelection"] == null ||
            drQue["IsAvailable"] == null ||
            drQue["QueSelectionType"] == null ||
            drQue["QueIsMust"] == null ||
            drQue["QueID"] == null
            )
                return null;
        
            qm.title = (string)drQue["QueText"] ;
            qm.selections = (string)drQue["QueSelection"]  ;
            qm.isAvailable = (bool)drQue["IsAvailable"] ;
            qm.selectionType = (int)drQue["QueSelectionType"] ;
            qm.isMust = (bool)drQue["QueIsMust"] ;
            qm.id = (Guid)drQue["QueID"] ;

            return qm;
        }


        //
    }
}

