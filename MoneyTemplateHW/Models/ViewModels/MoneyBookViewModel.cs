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
    /// <seealso cref="MoneyTemplateHW.Models.ViewModels.MoneyBookClass" />
    public class MoneyBookViewModel : MoneyBookClass
    {
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
        public List<MoneyBookClass> MoneyBookData_List = new List<MoneyBookClass>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MoneyBookViewModel"/> class.
        /// </summary>
        public MoneyBookViewModel()
        {
            var PATH = HostingEnvironment.MapPath("~");
            var allTestData = XDocument.Load(PATH + "\\App_Data\\TEST_DATA.xml").Elements("records").Elements("record");

            foreach (var item in allTestData)
            {
                MoneyBookData_List.Add(new MoneyBookClass
                {
                    category = item.Element("category").Value,
                    date = Convert.ToDateTime(item.Element("date").Value),
                    money = Convert.ToDecimal(item.Element("money").Value)
                });
            }
        }
    }
}