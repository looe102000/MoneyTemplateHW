using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public IEnumerable<SelectListItem> categorySelectItemList = new List<SelectListItem>
            {
                new SelectListItem{Text="請選擇",Value=null,Selected = true,Disabled=true },
                new SelectListItem{Text="支出",Value="1"},
                new SelectListItem{Text="收入",Value="2"}
            };

        /// <summary>
        /// The MoneyBookData_List
        /// </summary>
        public List<MoneyBookClass> MoneyBookData_List = new List<MoneyBookClass>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MoneyBookViewModel"/> class.
        /// </summary>
        public MoneyBookViewModel()
        {
            var PATH = HostingEnvironment.MapPath("~");
            
            //json 版
            using (StreamReader r = new StreamReader(PATH + "\\App_Data\\TEST_DATA_JSON.JSON"))
            {
                var ReadJason = JsonConvert.DeserializeObject<JObject>(r.ReadToEnd());

                IList<JToken> results = ReadJason["records"]["record"].Children().ToList();

                foreach (JToken result in results)
                {
                    MoneyBookData_List.Add(result.ToObject<MoneyBookClass>());
                }
            }

           // var allTestData = XDocument.Load(PATH + "\\App_Data\\TEST_DATA.xml").Elements("records").Elements("record");

            //foreach (var item in allTestData)
            //{
            //    MoneyBookData_List.Add(new MoneyBookClass
            //    {
            //        category = item.Element("category").Value,
            //        date = item.Element("date").Value,
            //        money = Convert.ToDecimal(item.Element("money").Value)
            //    });
            //}
        }
    }
}