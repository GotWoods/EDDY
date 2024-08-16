using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Models.D01C;

[Segment("BCD")]
public class BCD_BenefitAndCoverageDetail : EdifactSegment
{
	[Position(1)]
	public string ServiceTypeCode { get; set; }

	[Position(2)]
	public string BenefitAndCoverageCode { get; set; }

	[Position(3)]
	public string BenefitCoverageConstituentsCode { get; set; }

	[Position(4)]
	public string PeriodTypeCode { get; set; }

	[Position(5)]
	public E017_MonetaryAmount MonetaryAmount { get; set; }

	[Position(6)]
	public string Percentage { get; set; }

	[Position(7)]
	public string QuantityTypeCodeQualifier { get; set; }

	[Position(8)]
	public string Quantity { get; set; }

	[Position(9)]
	public string YesOrNoIndicatorCode { get; set; }

	[Position(10)]
	public string InsuranceCoverTypeCode { get; set; }

	[Position(11)]
	public string FreeText { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BCD_BenefitAndCoverageDetail>(this);
		validator.Required(x=>x.ServiceTypeCode);
		validator.Required(x=>x.BenefitAndCoverageCode);
		validator.Length(x => x.ServiceTypeCode, 1, 3);
		validator.Length(x => x.BenefitAndCoverageCode, 1, 3);
		validator.Length(x => x.BenefitCoverageConstituentsCode, 1, 3);
		validator.Length(x => x.PeriodTypeCode, 1, 3);
		validator.Length(x => x.Percentage, 1, 10);
		validator.Length(x => x.QuantityTypeCodeQualifier, 1, 3);
		validator.Length(x => x.Quantity, 1, 35);
		validator.Length(x => x.YesOrNoIndicatorCode, 1, 3);
		validator.Length(x => x.InsuranceCoverTypeCode, 1, 3);
		validator.Length(x => x.FreeText, 1, 512);
		return validator.Results;
	}
}
