using Data;
using DBTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedesignedGoogleForms.BackPages
{
    public partial class EditForm : System.Web.UI.Page
    {
        FormModel currentForm = new FormModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            //把全部的Form帶過來
            DataTable currentFormResult = (DataTable)Session["Forms"];
            //找有沒有選中的Form，有的話Bind上去
            string selectedFormID = Request.QueryString["FormID"];
            if (selectedFormID != null)
            {
                DataRow[] dr = currentFormResult.Select($"FormID='{selectedFormID}'");
                var selectedForm = dr[0];
                txtCaption.Text = (string)selectedForm[2];
                txtDescription.Text = (string)selectedForm[7];
                chkStatic.Checked = (bool)selectedForm[3];
                DateTime startTime = (DateTime)selectedForm[4];
                DateTime endDate = (DateTime)selectedForm[5];
                if (startTime.ToString() != "")
                    txtStartDate.Text = startTime.ToString("yyyy-MM-dd");
                if (endDate.ToString() != "")
                    txtEndDate.Text = endDate.ToString("yyyy-MM-dd");
                //GUID寫入到class
                currentForm.id = Guid.Parse(selectedFormID);
            }
            lbTitle.Text = "新增問卷";






        }

        /// <summary>
        /// 放棄編輯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("/EntryPages/EntryPage.aspx");
        }

        /// <summary>
        /// 下一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSend_Click(object sender, EventArgs e)
        {
            


            if (txtCaption.Text == "")
            {
                lbMsg.Text = "表頭為必填";
                return; }

            //抓填入的資料            
            currentForm.title = txtCaption.Text;
            currentForm.description = txtDescription.Text;
            var startTime = txtStartDate.Text;
            var endDate = txtEndDate.Text;
            if (startTime != "")
                currentForm.startTime = Convert.ToDateTime(startTime);
            if (endDate != "")
                currentForm.endTime = Convert.ToDateTime(endDate);
            currentForm.isAvailable = chkStatic.Checked;


            //封裝到session
            Session["FormModel"] = currentForm;


            //下一頁
            Response.Redirect($"EditQuestion.aspx?FormID={currentForm.id}");
        }
    }
}