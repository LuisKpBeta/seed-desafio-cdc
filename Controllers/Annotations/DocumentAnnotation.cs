using System.ComponentModel.DataAnnotations;

namespace BookStore.Controllers.Annotations;
public class DocumentAttribute : ValidationAttribute
{
  protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
  {
    var document = value as string;

    if (string.IsNullOrEmpty(document))
    {
      return new ValidationResult("Document value is required");
    }

    if (document.Length != 11 && document.Length != 14)
    {
      return new ValidationResult("Document must be a only number of CPF or CPNJ");
    }

    return ValidationResult.Success;
  }
}
