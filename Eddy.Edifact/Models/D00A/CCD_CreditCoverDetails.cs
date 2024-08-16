using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("CCD")]
public class CCD_CreditCoverDetails : EdifactSegment
{
	[Position(1)]
	public string CreditCoverRequestTypeCode { get; set; }

	[Position(2)]
	public string CreditCoverResponseTypeCode { get; set; }

	[Position(3)]
	public string CreditCoverResponseReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CCD_CreditCoverDetails>(this);
		validator.Length(x => x.CreditCoverRequestTypeCode, 1, 3);
		validator.Length(x => x.CreditCoverResponseTypeCode, 1, 3);
		validator.Length(x => x.CreditCoverResponseReasonCode, 1, 3);
		return validator.Results;
	}
}
