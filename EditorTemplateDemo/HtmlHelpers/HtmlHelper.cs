using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace EditorTemplateDemo.HtmlHelpers
{
    public static class BootstrapHelpers
    {
        public static IHtmlString BootstrapLabelFor<TModel, TProp>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProp>> property, int length = 2)
        {
            return helper.LabelFor(property, new
            {
                @class = string.Format("col-md-{0} control-label", length)
            });
        }

        public static IHtmlString BootstrapLabel(
            this HtmlHelper helper,
            string propertyName, int length = 2)
        {
            return helper.Label(propertyName, new
            {
                @class = string.Format("col-md-{0} control-label", length)
            });
        }
    }
}