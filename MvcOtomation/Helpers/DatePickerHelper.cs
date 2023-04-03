using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace MvcOtomation.Helpers
{
    public static class DatePickerHelper
    {
        public static MvcHtmlString DatePickerFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var name = ExpressionHelper.GetExpressionText(expression);
            var fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);

            var value = metadata.Model == null ? "" : ((DateTime)metadata.Model).ToString("yyyy-MM-dd");
            var html = string.Format("<input type=\"date\" name=\"{0}\" id=\"{0}\" value=\"{1}\" {2}/>", fullName, value, htmlAttributes);

            return new MvcHtmlString(html);
        }
    }
}
