using DBTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedesignedGoogleForms.FrontPages
{
    public partial class AnserForm : System.Web.UI.Page
    {
        string selectedFormID = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //檢查是否有所屬的Form
            selectedFormID = Request.QueryString["FormID"];
            if (selectedFormID == null)
                Response.Redirect("/EntryPages/EntryPage.aspx");

            DataRow dataRow = FormSearchManager.SearchFormInDB(Guid.Parse(selectedFormID));
            ltTitle.Text = (string)dataRow[2];
            ltDiscription.Text = (string)dataRow[7];
        }
    }
}