using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C241")]
public class C241_DutyTaxFeeType : EdifactComponent
{
	[Position(1)]
	public string DutyTaxFeeTypeCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string DutyTaxFeeType { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C241_DutyTaxFeeType>(this);
		validator.Length(x => x.DutyTaxFeeTypeCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.DutyTaxFeeType, 1, 35);
		return validator.Results;
	}
}
