using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C533")]
public class C533_DutyTaxFeeAccountDetail : EdifactComponent
{
	[Position(1)]
	public string DutyOrTaxOrFeeAccountCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C533_DutyTaxFeeAccountDetail>(this);
		validator.Required(x=>x.DutyOrTaxOrFeeAccountCode);
		validator.Length(x => x.DutyOrTaxOrFeeAccountCode, 1, 6);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		return validator.Results;
	}
}