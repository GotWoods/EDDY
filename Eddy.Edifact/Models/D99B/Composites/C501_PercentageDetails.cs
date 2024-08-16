using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C501")]
public class C501_PercentageDetails : EdifactComponent
{
	[Position(1)]
	public string PercentageTypeCodeQualifier { get; set; }

	[Position(2)]
	public string Percentage { get; set; }

	[Position(3)]
	public string PercentageBasisIdentificationCode { get; set; }

	[Position(4)]
	public string CodeListIdentificationCode { get; set; }

	[Position(5)]
	public string CodeListResponsibleAgencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C501_PercentageDetails>(this);
		validator.Required(x=>x.PercentageTypeCodeQualifier);
		validator.Length(x => x.PercentageTypeCodeQualifier, 1, 3);
		validator.Length(x => x.Percentage, 1, 10);
		validator.Length(x => x.PercentageBasisIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		return validator.Results;
	}
}
