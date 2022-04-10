using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MegaMarketMall.TestData
{
    public class ProductTest 
    {
        public int Id { get; set; }
        [ValidEnumValues] public Types? Type { get; set; } = null;
        public Areas Area { get; set; }
        public string T => Type.ToString();
        
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum Types
        {
            [EnumMember(Value = "Первый")]
            first=1,
            second,
            third
        }

        public enum Areas
        {
            first=1,
            second,
            third
        }
    }
    public class ValidEnumValuesAttribute : ValidationAttribute
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