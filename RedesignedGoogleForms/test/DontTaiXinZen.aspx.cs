using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedesignedGoogleForms.test
{
    public partial class DontTaiXinZen : System.Web.UI.Page
    {
        List<TextBox> txbList = new List<TextBox>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["Ctl_count"] = 0;
                Session["txbList"] = txbList;
            }
        }

        protected void btnAddSelection_Click(object sender, EventArgs e)
        {

            txbList = (List<TextBox>)Session["txbList"];
            int Ctl_count = (int)ViewState["Ctl_count"];
            TextBox txb = new TextBox();
            txb.ID = $"txt{Ctl_count}";
            txbList.Add(txb);
            Ctl_count++;
            Session["txbList"] = txbList;
            ViewState["Ctl_count"] = Ctl_count;

            foreach (TextBox tb in txbList)
            {
                this.Panel1.Controls.Add(tb);
                //Label1.Text = txbList.Count.ToString();
                //Label1.Text += "Add" + tb.ID + "<br>";
            }

        }

        protected void btnWrite_Click(object sender, EventArgs e)
        {
            List<string> ansList = new List<string>();
            string ans;
            for (int i = 1; i <= 3; i++)
            {
                TextBox txb = (TextBox)Panel1.FindControl($"TextBox{i}");
                ansList.Add(txb.Text);
                //Label1.Text += txb.Text + "<br>";                
            }
            ans = SerializerHelper.JsonSerializer(ansList);
            Label1.Text += ans + "<br>";
            //Label1.Text += "Add" + tb.ID + "<br>";

            //動態取值(失敗)
            //TextBox txb = (TextBox)Panel1.FindControl("txt0");
            //Label1.Text = txb.Text;
        }

        //private void Add5()
        //{
        //    int Ctl_count = (int)ViewState["Ctl_count"];

        //    for (int i = 0; i < 5; i++)
        //    {
        //        TextBox txb = new TextBox();
        //        txb.ID = $"txt{Ctl_count}";
        //        txbList.Add(txb);
        //        Ctl_count++;
        //    }

        //    //txb.ID = $"txt{Ctl_count}";
        //    //txbList.Add(txb);
        //    //Session["txbList"] = txbList;
        //    //Ctl_count++;
        //    ViewState["Ctl_count"] = Ctl_count;

        //    foreach (TextBox tb in txbList)
        //    {
        //        this.Panel1.Controls.Add(tb);
        //        //Label1.Text = txbList.Count.ToString();
        //        Label1.Text += "Add" + tb.ID + "<br>";
        //    }

        //    //this.Panel1.Controls.Add(txb);
        //}

    }
}