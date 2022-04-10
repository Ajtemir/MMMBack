using System;
using System.ComponentModel.DataAnnotations;

namespace MegaMarketMall.Data.Attributes
{
    public class ValidEnumValueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null)
                return ValidationResult.Success;
            Type enumType = value.GetType();
            bool valid = Enum.IsDefined(enumType, value);
            if (!valid)
            {
                this.ErrorMessage = "Error options of field";
                return new ValidationResult(String.Format("{0} is not a valid value for type {1}", value, enumType.Name));
            }
            return ValidationResult.Success;
        }
    }
}