using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("UNE")]
public class UNE_FunctionalGroupTrailer : EdifactSegment
{
	[Position(1)]
	public string NumberOfMessages { get; set; }

	[Position(2)]
	public string FunctionalGroupReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UNE_FunctionalGroupTrailer>(this);
		validator.Required(x=>x.NumberOfMessages);
		validator.Required(x=>x.FunctionalGroupReferenceNumber);
		validator.Length(x => x.NumberOfMessages, 1, 6);
		validator.Length(x => x.FunctionalGroupReferenceNumber, 1, 14);
		return validator.Results;
	}
}
