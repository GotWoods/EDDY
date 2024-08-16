using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C203")]
public class C203_RateTariffClass : EdifactComponent
{
	[Position(1)]
	public string RateOrTariffClassDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string RateOrTariffClassDescription { get; set; }

	[Position(5)]
	public string SupplementaryRateOrTariffCode { get; set; }

	[Position(6)]
	public string CodeListIdentificationCode2 { get; set; }

	[Position(7)]
	public string CodeListResponsibleAgencyCode2 { get; set; }

	[Position(8)]
	public string SupplementaryRateOrTariffCode2 { get; set; }

	[Position(9)]
	public string CodeListIdentificationCode3 { get; set; }

	[Position(10)]
	public string CodeListResponsibleAgencyCode3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C203_RateTariffClass>(this);
		validator.Required(x=>x.RateOrTariffClassDescriptionCode);
		validator.Length(x => x.RateOrTariffClassDescriptionCode, 1, 9);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.RateOrTariffClassDescription, 1, 35);
		validator.Length(x => x.SupplementaryRateOrTariffCode, 1, 6);
		validator.Length(x => x.CodeListIdentificationCode2, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode2, 1, 3);
		validator.Length(x => x.SupplementaryRateOrTariffCode2, 1, 6);
		validator.Length(x => x.CodeListIdentificationCode3, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode3, 1, 3);
		return validator.Results;
	}
}
