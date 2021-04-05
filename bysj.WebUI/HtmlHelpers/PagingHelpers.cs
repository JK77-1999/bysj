using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using bysj.WebUI.Models;

namespace bysj.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            if (pagingInfo.CurrentPage != 1)
                result.Append("<li><a href='" + pageUrl(pagingInfo.CurrentPage - 1) + "'>&laquo;</a></li>");
            else
                result.Append("<li><a href='#'>&laquo;</a></li>");
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder lis = new TagBuilder("li");
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                lis.InnerHtml = tag.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    lis.AddCssClass("active");
                }

                result.Append(lis.ToString());
            }
            if (pagingInfo.CurrentPage != pagingInfo.TotalPages)
                result.Append("<li><a href='" + pageUrl(pagingInfo.CurrentPage + 1) + "'>&raquo;</a></li>");
            else
                result.Append("<li><a href='#'>&raquo;</a></li>");
            return MvcHtmlString.Create(result.ToString());
        }
    }
}