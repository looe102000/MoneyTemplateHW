using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MoneyTemplateHW.Models.ViewModels
{
    /// <summary>
    /// 記帳本 VIEW MODEL
    /// </summary>
    public class MoneyBook
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

        public string description { get; set; }

        public List<SelectListItem> categorySelectItemList = new List<SelectListItem>();
    }
}