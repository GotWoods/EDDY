using System.Collections.Generic;
using System.Linq;
using EdiParser.Validation;

namespace EdiParser.x12.Models.Internals;

public abstract class EdiX12Segment
{
    public abstract ValidationResult Validate();
    public ValidationResult ValidationResult { get; set; } = new ValidationResult();
}