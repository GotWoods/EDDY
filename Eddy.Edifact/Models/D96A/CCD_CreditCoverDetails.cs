using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("CCD")]
public class CCD_CreditCoverDetails : EdifactSegment
{
	[Position(1)]
	public string CreditCoverRequestCoded { get; set; }

	[Position(2)]
	public string CreditCoverResponseCoded { get; set; }

	[Position(3)]
	public string CreditCoverReasonCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CCD_CreditCoverDetails>(this);
		validator.Length(x => x.CreditCoverRequestCoded, 1, 3);
		validator.Length(x => x.CreditCoverResponseCoded, 1, 3);
		validator.Length(x => x.CreditCoverReasonCoded, 1, 3);
		return validator.Results;
	}
}
