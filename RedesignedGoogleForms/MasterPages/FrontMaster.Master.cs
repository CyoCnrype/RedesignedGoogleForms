﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VaccineMatchingSystem.MasterPages
{
    public partial class FrontMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReturnEntryPoint_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("/EntryPages/EntryPage.aspx");
            
        }
    }
}