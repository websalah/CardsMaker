using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.CustomValidations
{
    public class WebsiteAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            string website = value.ToString()!;

            if (!website.StartsWith("http://") && !website.StartsWith("https://"))
            {
                website = "http://" + website;
            }

            bool isValid = Uri.TryCreate(website, UriKind.Absolute, out Uri? uri)
                           && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)
                           && uri.Host.Contains('.');

            return isValid
                ? ValidationResult.Success
                : new ValidationResult("Please enter a valid website URL.");
        }
    }
}
