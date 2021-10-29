using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBTools;

namespace RedesignedGoogleForms.EntryPages
{
    public partial class FormSearchUser : System.Web.UI.Page
    {
        private DataTable currentFormResult;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)//判斷頁面是不是第一次顯示
            {
                //int mgrLevel = (int)Session["MgrLevel"];
                //if (mgrLevel < 1)
                //{
                //    btnLogout_Click();
                //}

                currentFormResult = FormSearchManager.GetAllForm();
                BindDataToGridView();

                Session["Forms"] = currentFormResult;
                //DataRow[] test = currentFormResult.Select($"FormNumber={1}");
                //var a = test[0];


            }
        }

        /// <summary>
        /// 搜尋按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var searchText = this.tbSearch.Text;
            if (searchText == "" && this.txtDatetimeStart.Text == "" && this.txtDatetimeEnd.Text == "")
                return;
            DateTime searchTimeStart = Data.FormTime.minDate;
            DateTime searchTimeEnd = Data.FormTime.maxDate;
            if (this.txtDatetimeStart.Text != "")
                searchTimeStart = Convert.ToDateTime(this.txtDatetimeStart.Text);
            if (this.txtDatetimeEnd.Text != "")
                searchTimeEnd = Convert.ToDateTime(this.txtDatetimeEnd.Text);
            currentFormResult = FormSearchManager.SearchFormInDB(searchText, searchTimeStart, searchTimeEnd);
            BindDataToGridView();

        }

        /// <summary>
        /// 從DB抓資料Bind出來
        /// </summary>
        private void BindDataToGridView()
        {
            if (currentFormResult.Rows.Count == 0)
                this.lbMsg.Text = "查無資料";
            this.GridSearchResult.DataSource = currentFormResult;
            this.GridSearchResult.DataBind();
        }



        /// <summary>
        /// 控制GV裡面特定Label的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridSearchResult_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var row = e.Row;

            if (row.RowType == DataControlRowType.DataRow)
            {
                Label lblFormState = row.FindControl("lblFormState") as Label; //抓到Label
                var drFormState = row.DataItem as DataRowView;  //row的東西丟出來
                bool FormState = drFormState.Row.Field<bool>("IsAvailable");
                //按照邏輯寫出不同的字到抓到Label
                #region 整合到下面
                //switch (FormState)
                //{
                //    case false:
                //        lblFormState.Text = "已關閉";
                //        break;
                //    case true:
                //        lblFormState.Text = "開放中";
                //        break;
                //}
                #endregion

                Label lblFormTitle = row.FindControl("lblFormTitle") as Label;
                var drFormTitle = row.DataItem as DataRowView;
                string FormTitle = drFormTitle.Row.Field<string>("FormTitle");
                string FormID = drFormTitle.Row.Field<Guid>("FormID").ToString();
                switch (FormState)
                {
                    case true:
                        lblFormState.Text = "開放中";
                        //lblFormTitle.Text = $"<a href='EditForm.aspx?FormID={FormTitle}' target='_blank'>{FormTitle}</a>";
                        lblFormTitle.Text = $"<a href='AnserForm.aspx?FormID={FormID}' target='_blank'>{FormTitle}</a>";

                        break;
                    case false:
                        lblFormState.Text = "已關閉";
                        lblFormTitle.Text = FormTitle;
                        break;
                }

            }
        }

        /// <summary>
        /// GridView分頁切換事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridSearchResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridSearchResult.PageIndex = e.NewPageIndex;
            this.GridSearchResult.DataBind();
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("/EntryPages/EntryPage.aspx");
        }

        /// <summary>
        /// 登出
        /// </summary>
        protected void btnLogout_Click()
        {
            Session.RemoveAll();
            Response.Redirect("/EntryPages/EntryPage.aspx");
        }

       

    }
}