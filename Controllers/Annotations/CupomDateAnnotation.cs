using System.ComponentModel.DataAnnotations;

namespace BookStore.Controllers.Annotations;
public class CuponDateAttribute : ValidationAttribute
{
  protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
  {
    var dateValue = value as DateOnly?;

    if (dateValue is null)
    {
      return new ValidationResult("Expiration date to cupon is required");
    }

    var today = DateOnly.FromDateTime(DateTime.Now);

    if (today > dateValue)
    {
      return new ValidationResult("Expiration date must be in future date");
    }


    return ValidationResult.Success;
  }
}
