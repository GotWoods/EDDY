using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("CON")]
public class CON_ContactInformation : EdifactSegment
{
	[Position(1)]
	public E966_ContactInformation ContactInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CON_ContactInformation>(this);
		return validator.Results;
	}
}
