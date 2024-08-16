using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D05B.Composites;

namespace Eddy.Edifact.Models.D05B;

[Segment("CNI")]
public class CNI_ConsignmentInformation : EdifactSegment
{
	[Position(1)]
	public string ConsolidationItemNumber { get; set; }

	[Position(2)]
	public C503_DocumentMessageDetails DocumentMessageDetails { get; set; }

	[Position(3)]
	public string ConsignmentLoadSequenceIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CNI_ConsignmentInformation>(this);
		validator.Length(x => x.ConsolidationItemNumber, 1, 5);
		validator.Length(x => x.ConsignmentLoadSequenceIdentifier, 1, 4);
		return validator.Results;
	}
}
