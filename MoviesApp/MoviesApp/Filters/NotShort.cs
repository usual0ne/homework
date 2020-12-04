using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Filters
{
    public class NotShort : ValidationAttribute
    {
        public NotShort(int stringSize)
        {
            StringSize = stringSize;
        }

        public int StringSize { get; }

        public string GetErrorMessage() =>
            $"Too short, at least {StringSize} symbols.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var text = (string)value;
            if(text.Length < StringSize)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
