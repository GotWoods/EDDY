using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("MSD")]
public class MSD_MessageActionDetails : EdifactSegment
{
	[Position(1)]
	public E972_MessageProcessingDetails MessageProcessingDetails { get; set; }

	[Position(2)]
	public string ResponseTypeCode { get; set; }

	[Position(3)]
	public E206_ObjectIdentification ObjectIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MSD_MessageActionDetails>(this);
		validator.Length(x => x.ResponseTypeCode, 1, 3);
		return validator.Results;
	}
}
