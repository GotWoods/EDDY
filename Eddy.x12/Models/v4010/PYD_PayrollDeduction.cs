using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("PYD")]
public class PYD_PayrollDeduction : EdiX12Segment
{
	[Position(01)]
	public decimal? MonetaryAmount { get; set; }

	[Position(02)]
	public string FrequencyCode { get; set; }

	[Position(03)]
	public string TaxTreatmentCode { get; set; }

	[Position(04)]
	public string DeductionTypeCode { get; set; }

	[Position(05)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PYD_PayrollDeduction>(this);
		validator.Required(x=>x.MonetaryAmount);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.FrequencyCode, 1);
		validator.Length(x => x.TaxTreatmentCode, 1);
		validator.Length(x => x.DeductionTypeCode, 1, 4);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
