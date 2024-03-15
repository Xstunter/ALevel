#pragma warning disable CS8603

using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Validations
{
    public class ImageFileNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || !(value is string image))
            {
                return new ValidationResult("Invalid file name");
            }

            if (!image.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
            {
                return new ValidationResult("The file name must end with .png");
            }

            return ValidationResult.Success;
        }
    }
}