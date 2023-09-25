using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("BTA")]
public class BTA_BeginningTaxAcknowledgment : EdiX12Segment
{
	[Position(01)]
	public string AcknowledgmentType { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string AmountQualifierCode { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BTA_BeginningTaxAcknowledgment>(this);
		validator.Required(x=>x.AcknowledgmentType);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AmountQualifierCode, x=>x.MonetaryAmount);
		validator.Length(x => x.AcknowledgmentType, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.AmountQualifierCode, 1, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		return validator.Results;
	}
}
