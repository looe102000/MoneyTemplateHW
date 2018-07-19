using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyTemplateHW.Models.ViewModels
{
    public static class CategoryModel
    {
        public static List<CategoryItem> CategoryListItem { get; set; }


        static CategoryModel()
        {
            CategoryListItem = new List<CategoryItem>
            {
                new CategoryItem() {Name = "請選擇", Value = null},
                new CategoryItem() {Name = "支出", Value  = 0},
                new CategoryItem() {Name = "收入", Value  = 1},
            };
        }

        public class CategoryItem
        {
            public string Name { get; set; }
            public int? Value { get; set; }
        }
    }
}