using EdiParser.Validation;

namespace EdiParser.x12.Models;

public abstract class EdiX12Segment
{
    public abstract ValidationResult Validate();
    //public ValidationResult ValidationResult { get; set; } = new ValidationResult();
}