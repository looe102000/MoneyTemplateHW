using MoneyTemplateHW.Attribute;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoneyTemplateHW.Models
{
    public class DailyRecord
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "請選擇類別")]
        public string Category { get; set; }

        [Required(ErrorMessage = "請填入金額")]
        [Range(0, int.MaxValue, ErrorMessage = "請輸入整數")]
        public string Money { get; set; }

        [Required(ErrorMessage = "請填入日期")]
        [DataType(DataType.Date, ErrorMessage = "請輸入正確的日期")]
        [判斷日期是否大於今日Attribute]
        public string Date { get; set; }

        [Required(ErrorMessage = "請填入備註")]
        [StringLength(100, ErrorMessage = "最多輸入 100 個中文字")]
        public string Description { get; set; }
    }
}