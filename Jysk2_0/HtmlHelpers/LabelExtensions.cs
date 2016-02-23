using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jysk2_0.HtmlHelpers
{
    public static class LabelExtensions
    {
        public static MvcHtmlString Label(this HtmlHelper helper, string target, string text, int count)
        {
            return new MvcHtmlString(string.Format("<label for='{0}' a-cool-attr='theStuff'>{1}- - {1}- -{0} -- Count : {2}</label>", target, text, count));

        }
    }

}