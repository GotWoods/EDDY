using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("INT")]
public class INT_Interest : EdiX12Segment
{
	[Position(01)]
	public string InterestTypeCode { get; set; }

	[Position(02)]
	public decimal? InterestRate { get; set; }

	[Position(03)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(04)]
	public string DateTimePeriod { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	[Position(06)]
	public string QuantityQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<INT_Interest>(this);
		validator.Required(x=>x.InterestTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Quantity, x=>x.QuantityQualifier);
		validator.Length(x => x.InterestTypeCode, 1, 2);
		validator.Length(x => x.InterestRate, 1, 6);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.QuantityQualifier, 2);
		return validator.Results;
	}
}
