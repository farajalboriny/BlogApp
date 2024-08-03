using System.ComponentModel.DataAnnotations;

namespace BlogApp.Application.Contracts.CustomValidators.ArticleValidators;

public class TagsRequiredIfPublishedAttribute(string statusPropertyName) : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var dto = validationContext.ObjectInstance;
        var statusProperty = dto.GetType().GetProperty(statusPropertyName);
        var statusValue = statusProperty?.GetValue(dto) as string;

        if (statusValue == "Published" && (value == null || !(value as List<Guid>).Any()))
        {
            return new ValidationResult("Tags are required when the status is 'Published'.");
        }

        return ValidationResult.Success;
    }
}