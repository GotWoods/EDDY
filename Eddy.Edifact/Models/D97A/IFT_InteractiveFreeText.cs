using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("IFT")]
public class IFT_InteractiveFreeText : EdifactSegment
{
	[Position(1)]
	public E971_FreeTextQualification FreeTextQualification { get; set; }

	[Position(2)]
	public string FreeText { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IFT_InteractiveFreeText>(this);
		validator.Length(x => x.FreeText, 1, 70);
		return validator.Results;
	}
}
