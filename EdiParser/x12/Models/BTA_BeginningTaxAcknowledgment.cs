using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("BTA")]
public class BTA_BeginningTaxAcknowledgment : EdiX12Segment
{
	[Position(01)]
	public string AcknowledgmentTypeCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string AmountQualifierCode { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BTA_BeginningTaxAcknowledgment>(this);
		validator.Required(x=>x.AcknowledgmentTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AmountQualifierCode, x=>x.MonetaryAmount);
		validator.Length(x => x.AcknowledgmentTypeCode, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.AmountQualifierCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		return validator.Results;
	}
}
