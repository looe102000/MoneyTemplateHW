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
        public string Category { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public string Date { get; set; }

        /// <summary>
        /// 金額
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Money { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}