using MoneyTemplateHW.Attribute;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "請選擇類別")]
        public string Category { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        [Required(ErrorMessage = "請填入日期")]
        [DataType(DataType.Date, ErrorMessage = "請輸入正確的日期")]
        [判斷日期是否大於今日Attribute]
        public string Date { get; set; }

        /// <summary>
        /// 金額
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        [Required(ErrorMessage = "請填入金額")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "請輸入整數")]
        [Range(0, int.MaxValue, ErrorMessage = "超出範圍")]
        public decimal Money { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [Required(ErrorMessage = "請填入備註")]
        [StringLength(100, ErrorMessage = "最多輸入 100 個中文字")]
        public string Description { get; set; }
    }
}