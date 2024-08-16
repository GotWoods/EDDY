using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C533")]
public class C533_DutyTaxFeeAccountDetail : EdifactComponent
{
	[Position(1)]
	public string DutyTaxFeeAccountIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C533_DutyTaxFeeAccountDetail>(this);
		validator.Required(x=>x.DutyTaxFeeAccountIdentification);
		validator.Length(x => x.DutyTaxFeeAccountIdentification, 1, 6);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		return validator.Results;
	}
}
