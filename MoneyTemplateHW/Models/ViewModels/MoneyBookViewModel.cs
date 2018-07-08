using System;

namespace MoneyTemplateHW.Models.ViewModels
{
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
        public string date { get; set; }

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
    }
}