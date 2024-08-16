using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C243")]
public class C243_DutyTaxFeeDetail : EdifactComponent
{
	[Position(1)]
	public string DutyTaxFeeRateIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string DutyTaxFeeRate { get; set; }

	[Position(5)]
	public string DutyTaxFeeRateBasisIdentification { get; set; }

	[Position(6)]
	public string CodeListQualifier2 { get; set; }

	[Position(7)]
	public string CodeListResponsibleAgencyCoded2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C243_DutyTaxFeeDetail>(this);
		validator.Length(x => x.DutyTaxFeeRateIdentification, 1, 7);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.DutyTaxFeeRate, 1, 17);
		validator.Length(x => x.DutyTaxFeeRateBasisIdentification, 1, 12);
		validator.Length(x => x.CodeListQualifier2, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded2, 1, 3);
		return validator.Results;
	}
}
