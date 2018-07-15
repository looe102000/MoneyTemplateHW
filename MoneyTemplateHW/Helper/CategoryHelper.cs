using System.Web;
using System.Web.Mvc;

namespace MoneyTemplateHW.Helper
{
    public static class CategoryHelper
    {
        /// <summary>
        /// Displays the color of the category.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public static HtmlString DisplayCategoryColor(this HtmlHelper htmlHelper, string item)
        {
            var className = "";
            var itemName = "";

            /*
             * 類型的「支出」字樣顯現為紅色
             * 類型的「收入」字樣顯現為藍色
            */
            switch (item)
            {
                case "1":
                    className = "danger";
                    itemName = "收入";
                    break;

                case "2":
                    className = "primary";
                    itemName = "支出";

                    break;

                case "0":
                    className = "primary";
                    itemName = "支出";

                    break;
            }

            return new MvcHtmlString($"<span class='text-{className}'>{itemName}</span>");
        }
    }
}