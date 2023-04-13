using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("ICM")]
public class ICM_IndividualIncome : EdiX12Segment
{
	[Position(01)]
	public string FrequencyCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	[Position(04)]
	public string LocationIdentifier { get; set; }

	[Position(05)]
	public string SalaryGrade { get; set; }

	[Position(06)]
	public string CurrencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ICM_IndividualIncome>(this);
		validator.Required(x=>x.FrequencyCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.Length(x => x.FrequencyCode, 1);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.SalaryGrade, 1, 5);
		validator.Length(x => x.CurrencyCode, 3);
		return validator.Results;
	}
}
