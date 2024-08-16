using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("UNZ")]
public class UNZ_InterchangeTrailer : EdifactSegment
{
	[Position(1)]
	public string InterchangeControlCount { get; set; }

	[Position(2)]
	public string InterchangeControlReference { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UNZ_InterchangeTrailer>(this);
		validator.Required(x=>x.InterchangeControlCount);
		validator.Required(x=>x.InterchangeControlReference);
		validator.Length(x => x.InterchangeControlCount, 1, 6);
		validator.Length(x => x.InterchangeControlReference, 1, 14);
		return validator.Results;
	}
}
