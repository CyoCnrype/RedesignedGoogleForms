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
    public partial class EditQuestion : System.Web.UI.Page
    {
        FormModel currentForm = new FormModel();
        List<QuestionModel> currentQuestionList = new List<QuestionModel>();
        List<TextBox> txbList = new List<TextBox>();//t
        string selectedFormID = null;
        DataTable dtCurrentQuestions = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            //檢查是否有所屬的Form
            selectedFormID = Request.QueryString["FormID"];
            if (selectedFormID == null)
                Response.Redirect("/EntryPages/EntryPage.aspx");

            if (!IsPostBack)
            {
                ViewState["Ctl_count"] = 1;
                Session["txbList"] = txbList; //t
                Session["dtCurrentQuestions"] = FormSearchManager.SearchQuestions(selectedFormID); ;
            }


            //把Form帶過來
            currentForm = (FormModel)Session["FormModel"];

            //檢查Form底下有無Question，有則Bind
            dtCurrentQuestions = (DataTable)Session["dtCurrentQuestions"];
            if (dtCurrentQuestions != null)
            {
                this.QusetionView.DataSource = dtCurrentQuestions;
                this.QusetionView.DataBind();
            }

        }

        /// <summary>
        /// 新增單/多選選項的項目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddSelection_Click(object sender, EventArgs e)
        {
            //DtxzT();

            DtxzF();
        }
        /// <summary>
        /// 動態新增真方法
        /// </summary>
        private void DtxzT()
        {
            txbList = (List<TextBox>)Session["txbList"];
            int Ctl_count = (int)ViewState["Ctl_count"];
            TextBox txb = new TextBox();
            txb.Text = $"選項{Ctl_count}";
            txb.ID = $"txt{Ctl_count}";
            txbList.Add(txb);
            Ctl_count++;
            Session["txbList"] = txbList;
            ViewState["Ctl_count"] = Ctl_count;

            foreach (TextBox tb in txbList)
            {

                Label label = new Label();
                label.Text = "<br>";
                this.Panel1.Controls.Add(tb);
                this.Panel1.Controls.Add(label);
                //Label1.Text = txbList.Count.ToString();
                //Label1.Text += "Add" + tb.ID + "<br>";
            }
        }
        /// <summary>
        /// 動態新增Fake
        /// </summary>
        private void DtxzF()
        {
            int Ctl_count = (int)ViewState["Ctl_count"];
            if (Ctl_count > 8)
            {
                lbMsg.Text = "選項已達上限";
                return;
            }
            TextBox textBox = new TextBox();
            textBox = (TextBox)Panel1.FindControl($"TextBox{Ctl_count}");
            textBox.Visible = true;
            Ctl_count++;
            ViewState["Ctl_count"] = Ctl_count;
        }


        /// <summary>
        /// 按鈕：新增問題
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddQue_Click(object sender, EventArgs e)
        {
            //過濾必填等條件
            if (txtQueTitle.Text == "")
            {
                lbMsg.Text = "問題為必填";
                return;
            }
            if (ddlCommonQue.SelectedValue == "0" || ddlQueType.SelectedValue == "0")
            {
                lbMsg.Text = "請選擇問題屬性";
                return;
            }
            if (ddlQueType.SelectedValue == "1" || ddlQueType.SelectedValue == "2")
            {
                if (CountSelection(ddlQueType.SelectedValue.ToString()) == 0)
                {
                    lbMsg.Text = "請增加選項";
                    return;
                }
            }

            //檢查是否為常用問題
            string commonQue = ddlCommonQue.SelectedValue;
            if (commonQue == "0")
                return;

            //檢查問題種類，把選項集合成JSON字串
            string questionType = ddlQueType.SelectedValue;
            string selections = CreateSelectionString(questionType);

            //填入問題model
            QuestionModel currentQuestion = new QuestionModel();
            currentQuestion.title = txtQueTitle.Text;
            currentQuestion.isMust = cbIsMust.Checked;
            currentQuestion.selections = selections;
            currentQuestion.selectionType = Convert.ToInt32(questionType);
            currentQuestion.selectionNumber = CountSelection(questionType);
            currentQuestion.id = Guid.Parse(selectedFormID);
            currentQuestion.isAvailable = true;

            //如果是新規常用問題則加入
            if (chkIsFreq.Checked || FormSearchManager.IsFreqQuestion(currentQuestion))
                FormEditManager.InsertNewFreqQuestion(currentQuestion);

            //加入問題list(Dt)
            //currentQuestionList.Add(currentQuestion);
            currentQuestion.CreateDrQueInDt(dtCurrentQuestions);


            //把問題保存到Session
            Session["dtCurrentQuestions"] = dtCurrentQuestions;
            //FormEditManager.InsertNewQuestion(currentQuestion);

            //Bind到下方的GV

            //DataTable dtQuestions = FormSearchManager.SearchQuestions(selectedFormID);
            //currentFormResult = FormSearchManager.SearchFormInDB(searchText, searchTimeStart, searchTimeEnd);
            //this.QusetionView.DataSource = dtQuestions;

            this.QusetionView.DataSource = dtCurrentQuestions;
            this.QusetionView.DataBind();

        }

        /// <summary>
        /// 當問題種類變化時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlQueType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string questionType = ddlQueType.SelectedValue;
            switch (questionType)
            {
                case "1": //單選
                    btnAddSelection.Visible = true;
                    Panel1.Visible = true;
                    lbMsg.Text = "";
                    break;
                case "2"://多選
                    btnAddSelection.Visible = true;
                    Panel1.Visible = true;
                    lbMsg.Text = "";
                    break;
                case "3"://填空
                    btnAddSelection.Visible = false;
                    Panel1.Visible = false;
                    lbMsg.Text = "";
                    break;
                default:
                    btnAddSelection.Visible = true;
                    Panel1.Visible = true;
                    lbMsg.Text = "";
                    return;
            }
        }

        /// <summary>
        /// 確認問題種類變化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQueTypeChecked_Click(object sender, EventArgs e)
        {
            string questionType = ddlQueType.SelectedValue;
            switch (questionType)
            {
                case "1": //單選
                    btnAddSelection.Visible = true;
                    Panel1.Visible = true;
                    btnToZero.Visible = true;
                    lbMsg.Text = "";
                    break;
                case "2"://多選
                    btnAddSelection.Visible = true;
                    Panel1.Visible = true;
                    btnToZero.Visible = true;
                    lbMsg.Text = "";
                    break;
                case "3"://填空
                    btnAddSelection.Visible = false;
                    Panel1.Visible = false;
                    btnToZero.Visible = false;
                    lbMsg.Text = "";
                    break;
                default:
                    btnAddSelection.Visible = false;
                    Panel1.Visible = false;
                    btnToZero.Visible = false;
                    lbMsg.Text = "";
                    return;
            }
        }

        /// <summary>
        /// 選項數量歸0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnToZero_Click(object sender, EventArgs e)
        {
            ViewState["Ctl_count"] = 1;
            Session["txbList"] = new List<TextBox>(); ;
            Panel1.Controls.Clear();
        }

        protected void QusetionView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }



        /// <summary>
        /// 把選項變成JSON字串
        /// </summary>
        /// <param name="questionType"></param>
        /// <returns></returns>
        private string CreateSelectionString(string questionType
            )
        {
            string answer;
            List<string> ansList = new List<string>();

            if (questionType == "1" || questionType == "2")
            {
                for (int i = 1; i <= 8; i++)
                {
                    TextBox textBox = (TextBox)Panel1.FindControl($"TextBox{i}");
                    if (textBox.Text != "")
                        ansList.Add(textBox.Text);
                }
            }
            answer = SerializerHelper.JsonSerializer(ansList);
            return answer;
        }

        /// <summary>
        /// 算出有效選項數
        /// </summary>
        /// <param name="questionType"></param>
        /// <returns></returns>
        private int CountSelection(string questionType)
        {
            int answer = 0;
            //List<string> ansList = new List<string>();

            if (questionType == "1" || questionType == "2")
            {
                for (int i = 1; i <= 8; i++)
                {
                    TextBox textBox = (TextBox)Panel1.FindControl($"TextBox{i}");
                    if (textBox.Text != "")
                        answer++;
                }
            }
            //answer = SerializerHelper.JsonSerializer(ansList);
            return answer;
        }

        /// <summary>
        /// 確認送出所有問題
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSend_Click(object sender, EventArgs e)
        {
            //先把該ID的問題清除(去重)
            FormEditManager.DeleteQuestions(Guid.Parse(selectedFormID));

            //依序把問題輸入DB
            dtCurrentQuestions = (DataTable)Session["dtCurrentQuestions"];
            QuestionModel question = new QuestionModel();
            foreach (DataRow dataRow in dtCurrentQuestions.Rows)
            {
                question = question.CreateModelQue(dataRow);
                FormEditManager.InsertNewQuestion(question);
            }

            //判斷是否是既有Form，無則一併新增
            if ((bool)Session["IsNewForm"])
                FormEditManager.InsertNewForm(currentForm);
            else
            {
                FormEditManager.InsertNewForm(currentForm);
            }

            Response.Write("<Script language='JavaScript'>alert('問卷新增成功!'); location.href='/EntryPages/EntryPage.aspx'; </Script>");
        }

        /// <summary>
        /// 取消、回搜尋
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("FormSearch.aspx");
        }

        protected void btnDeleteQuestions_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < QusetionView.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)QusetionView.Rows[i].FindControl($"CheckBox1");
                if (cb.Checked)
                {
                    //找到FormNumber

                    lbMsg.Text = "???";
                    //string formNumber = QusetionView.Rows[i].Cells[0].Text;


                    //利用FormNumber做刪除
                    //FormEditManager.DeleteForm(formNumber);
                }
            }

            Response.Redirect(Request.Url.ToString());
        }
    }
}