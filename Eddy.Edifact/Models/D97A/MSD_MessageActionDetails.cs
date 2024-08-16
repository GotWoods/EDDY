using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("MSD")]
public class MSD_MessageActionDetails : EdifactSegment
{
	[Position(1)]
	public E972_MessageProcessingDetails MessageProcessingDetails { get; set; }

	[Position(2)]
	public string ResponseTypeCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MSD_MessageActionDetails>(this);
		validator.Length(x => x.ResponseTypeCoded, 1, 3);
		return validator.Results;
	}
}
