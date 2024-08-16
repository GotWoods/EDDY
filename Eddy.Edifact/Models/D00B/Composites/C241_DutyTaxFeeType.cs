using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C241")]
public class C241_DutyTaxFeeType : EdifactComponent
{
	[Position(1)]
	public string DutyOrTaxOrFeeTypeNameCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string DutyOrTaxOrFeeTypeName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C241_DutyTaxFeeType>(this);
		validator.Length(x => x.DutyOrTaxOrFeeTypeNameCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.DutyOrTaxOrFeeTypeName, 1, 35);
		return validator.Results;
	}
}
