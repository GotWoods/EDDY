using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("IFT")]
public class IFT_InteractiveFreeText : EdifactSegment
{
	[Position(1)]
	public E971_FreeTextQualification FreeTextQualification { get; set; }

	[Position(2)]
	public string FreeTextValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IFT_InteractiveFreeText>(this);
		validator.Length(x => x.FreeTextValue, 1, 512);
		return validator.Results;
	}
}
