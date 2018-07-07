using System;
using System.Collections.Generic;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MoneyTemplateHW.Models.ViewModels
{
    /// <summary>
    /// 記帳本 VIEW MODEL
    /// </summary>
    public class MoneyBookViewModel
    {
        /// <summary>
        /// 類別
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string category { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime date { get; set; }

        /// <summary>
        /// 金額
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal money { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string description { get; set; }

        /// <summary>
        /// The category select item list
        /// </summary>
        public List<SelectListItem> categorySelectItemList = new List<SelectListItem>
            {
                new SelectListItem{Text="請選擇",Value=null,Selected = true},
                new SelectListItem{Text="支出",Value=null},
                new SelectListItem{Text="收入",Value=null}
            };

        /// <summary>
        /// The test
        /// </summary>
        public List<MBOOKVIEWDATA> MBOOKDATA_List = new List<MBOOKVIEWDATA>();

        public MoneyBookViewModel()
        {
            var PATH = HostingEnvironment.MapPath("~");
            var allTestData = XDocument.Load(PATH + "\\App_Data\\TEST_DATA.xml").Elements("records").Elements("record");

            foreach (var item in allTestData)
            {
                MBOOKDATA_List.Add(new MBOOKVIEWDATA
                {
                    category = item.Element("category").Value,
                    date = Convert.ToDateTime(item.Element("date").Value).ToString("yyyy-MM-dd"),
                    money = Convert.ToDecimal(item.Element("money").Value).ToString("N")
                });
            }
        }

        public class MBOOKVIEWDATA
        {
            /// <summary>
            /// 類別
            /// </summary>
            /// <value>
            /// The type.
            /// </value>
            public string category { get; set; }

            /// <summary>
            /// 日期
            /// </summary>
            /// <value>
            /// The date.
            /// </value>
            public string date { get; set; }

            /// <summary>
            /// 金額
            /// </summary>
            /// <value>
            /// The amount.
            /// </value>
            public string money { get; set; }
        }
    }
}