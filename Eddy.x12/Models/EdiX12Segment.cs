using Eddy.Core;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

public abstract class EdiX12Segment : ISourceTracked
{
    public abstract ValidationResult Validate();
    //public ValidationResult ValidationResult { get; set; } = new ValidationResult();

    /// <summary>Where this segment came from in the source text, when the parser tracked it.</summary>
    public SegmentSource Source { get; set; }
}