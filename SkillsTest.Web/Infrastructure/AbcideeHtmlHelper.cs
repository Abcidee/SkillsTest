using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SkillsTest.Web.Infrastructure
{
    public static class AbcideeHtmlHelper
    {
        public static MvcHtmlString AbcideeValidation(this HtmlHelper htmlHelper, string modelName)
        {
            var str = new StringBuilder();

            if (!htmlHelper.ViewData.ModelState.IsValid)
            {
                str.Append("<small class=\"help-block text-left\" style=\"color:#a94442\">");
                foreach (var item in htmlHelper.ViewData.ModelState.Where(a => a.Key == modelName).FirstOrDefault().Value.Errors)
                {
                    str.Append(item.ErrorMessage);
                    str.Append("&nbsp;");
                }

                str.Append("</small>");
            }

            return new MvcHtmlString(str.ToString());
        }

        public static MvcHtmlString AbcideeValidationSummary(this HtmlHelper htmlHelper)
        {
            var str = new StringBuilder();

            if (!htmlHelper.ViewData.ModelState.IsValid)
            {
                var noModelValidations = htmlHelper.ViewData.ModelState.Where(a => a.Key == "");

                if (noModelValidations.Count() > 0)
                {
                    str.Append("<div class=\"eq-box-lg\">");
                    str.Append("<div class=\"panel text-left\">");
                    str.Append("<div class=\"panel-heading\">");
                    str.Append("<p class=\"panel-title\" style=\"font-size:13px; color:#a94442\">Please verify the following</p>");
                    str.Append("</div>");
                    str.Append("<div class=\"panel-body\">");
                    str.Append("<ul style=\"color:#a94442\">");

                    foreach (var noModelValidation in noModelValidations)
                    {
                        foreach (var item in noModelValidation.Value.Errors)
                        {
                            str.Append("<li>");
                            str.Append(item.ErrorMessage);
                            str.Append("</li>");
                        }
                    }

                    str.Append("</ul>");
                    str.Append("</div>");
                    str.Append("</div>");
                    str.Append("</div>");
                }
            }

            return new MvcHtmlString(str.ToString());
        }
    }
}