using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Fisioterapia.Web.Extensions
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public sealed class DateTimeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value is null)
            {
                return ValidationResult.Success;
            }

            return DateTime.TryParseExact(value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataRetorno) ? ValidationResult.Success : new ValidationResult("A data está no formato inválido");


        }
    }
}
