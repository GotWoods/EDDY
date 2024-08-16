using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("CNI")]
public class CNI_ConsignmentInformation : EdifactSegment
{
	[Position(1)]
	public string ConsolidationItemNumber { get; set; }

	[Position(2)]
	public C503_DocumentMessageDetails DocumentMessageDetails { get; set; }

	[Position(3)]
	public string ConsignmentLoadSequenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CNI_ConsignmentInformation>(this);
		validator.Length(x => x.ConsolidationItemNumber, 1, 4);
		validator.Length(x => x.ConsignmentLoadSequenceNumber, 1, 4);
		return validator.Results;
	}
}
