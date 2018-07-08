using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MoneyTemplateHW.Models.ViewModels
{
    /// <summary>
    /// 記帳本 View Components
    /// </summary>
    public static class MoneyBookViewComponents
    {
        /// <summary>
        /// The category select item list
        /// </summary>
        public static IEnumerable<SelectListItem> categorySelectItemList = new List<SelectListItem>
        {
            new SelectListItem {Text = "請選擇", Value = ""},
            new SelectListItem {Text = "支出", Value  = "1"},
            new SelectListItem {Text = "收入", Value  = "2"}
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="MoneyBookViewComponents"/> class.
        /// </summary>
        public static IEnumerable<MoneyBookViewModel> GetFakeData()
        {
            var path = HostingEnvironment.MapPath("~");

            //json 版
            using (StreamReader r = new StreamReader(path + "\\App_Data\\TEST_DATA_JSON.JSON"))
            {
                var readJason = JsonConvert.DeserializeObject<JObject>(r.ReadToEnd());

                IList<JToken> results = readJason["records"]["record"].Children().ToList();

                foreach (JToken result in results)
                {
                    yield return result.ToObject<MoneyBookViewModel>();
                }
            }
        }
    }
}