using System;
using System.ComponentModel.DataAnnotations;

namespace MoneyTemplateHW.Attribute
{
    public class 判斷日期是否大於今日AttributeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime inputDate = Convert.ToDateTime(value);

                if ((new TimeSpan(Convert.ToDateTime(inputDate).Ticks - DateTime.Today.Ticks).Days) > 0)
                {
                    return new ValidationResult("日期不得大於今日");
                }
                else
                {
                    // valid
                    return ValidationResult.Success;
                };
            }
            else
            {
                return new ValidationResult("請輸入日期");
            }
        }
    }
}