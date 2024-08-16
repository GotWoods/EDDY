using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("UNE")]
public class UNE_GroupTrailer : EdifactSegment
{
	[Position(1)]
	public string GroupControlCount { get; set; }

	[Position(2)]
	public string GroupReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UNE_GroupTrailer>(this);
		validator.Required(x=>x.GroupControlCount);
		validator.Required(x=>x.GroupReferenceNumber);
		validator.Length(x => x.GroupControlCount, 1, 6);
		validator.Length(x => x.GroupReferenceNumber, 1, 14);
		return validator.Results;
	}
}
