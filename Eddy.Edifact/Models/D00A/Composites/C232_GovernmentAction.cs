using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C232")]
public class C232_GovernmentAction : EdifactComponent
{
	[Position(1)]
	public string GovernmentAgencyIdentificationCode { get; set; }

	[Position(2)]
	public string GovernmentInvolvementCode { get; set; }

	[Position(3)]
	public string GovernmentActionCode { get; set; }

	[Position(4)]
	public string GovernmentProcedureCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C232_GovernmentAction>(this);
		validator.Length(x => x.GovernmentAgencyIdentificationCode, 1, 3);
		validator.Length(x => x.GovernmentInvolvementCode, 1, 3);
		validator.Length(x => x.GovernmentActionCode, 1, 3);
		validator.Length(x => x.GovernmentProcedureCode, 1, 3);
		return validator.Results;
	}
}
