﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedesignedGoogleForms.UserCtrl
{
    public partial class ucPager : System.Web.UI.UserControl
    {
        /// <summary>鎖定頁面URL</summary>
        public string Url { get; set; }

        /// <summary>總筆數</summary>
        public int TotalSize { get; set; }

        /// <summary>總頁數</summary>
        public int PageSize { get; set; }

        /// <summary>目前頁數</summary>
        public int CurrentPage { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Bind()
        {
            int totalPages = this.GetTotalPages();
            int currentPage = GetCurrentPage();
            int firstPage = currentPage - 1;

            this.aLinkFirstPage.HRef = $"{this.Url}?page=1";
            this.aLinkLastPage.HRef = $"{this.Url}?page={totalPages}";

            this.ltlMsg.Text = $"共 {this.TotalSize} 筆，共 {totalPages} 頁，目前在第 {currentPage} 頁。";
            for (var i = firstPage; i <= currentPage + 1; i++)
            {
                if (i == firstPage + 1) this.ltlPager.Text += $"<li class='page-item disabled'><a class='page-link'>{i}</a></li>";
                else if (i <= 0) currentPage += 1;
                else if (i > totalPages) break;
                else this.ltlPager.Text += $"<li class='page-item'><a href='{this.Url}?page={i}' class='page-link'>{i}</a></li>";
            }
        }

        public int GetCurrentPage()
        {
            string pageText = Request.QueryString["page"];
            if (string.IsNullOrWhiteSpace(pageText)) return 1;
            int page;
            if (!int.TryParse(pageText, out page)) return 1;
            if (page <= 0) return 1;

            return page;
        }

        private int GetTotalPages()
        {
            int pagers = this.TotalSize / this.PageSize;
            if ((this.TotalSize % this.PageSize) > 0) pagers += 1;
            return pagers;
        }

        public void SetPagerInvisible()
        {
            this.aLinkFirstPage.Visible = false;
            this.aLinkLastPage.Visible = false;
        }

    }
}