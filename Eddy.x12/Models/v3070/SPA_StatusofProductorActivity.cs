using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("SPA")]
public class SPA_StatusOfProductOrActivity : EdiX12Segment
{
	[Position(01)]
	public string StatusCode { get; set; }

	[Position(02)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(03)]
	public string DateTimePeriod { get; set; }

	[Position(04)]
	public string AmountQualifierCode { get; set; }

	[Position(05)]
	public decimal? MonetaryAmount { get; set; }

	[Position(06)]
	public string StatusReasonCode { get; set; }

	[Position(07)]
	public string StatusReasonCode2 { get; set; }

	[Position(08)]
	public string StatusReasonCode3 { get; set; }

	[Position(09)]
	public string AgencyQualifierCode { get; set; }

	[Position(10)]
	public string ProductDescriptionCode { get; set; }

	[Position(11)]
	public string SourceSubqualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SPA_StatusOfProductOrActivity>(this);
		validator.Required(x=>x.StatusCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AmountQualifierCode, x=>x.MonetaryAmount);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AgencyQualifierCode, x=>x.ProductDescriptionCode);
		validator.Length(x => x.StatusCode, 2);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.AmountQualifierCode, 1, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.StatusReasonCode, 3);
		validator.Length(x => x.StatusReasonCode2, 3);
		validator.Length(x => x.StatusReasonCode3, 3);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.ProductDescriptionCode, 1, 12);
		validator.Length(x => x.SourceSubqualifier, 1, 15);
		return validator.Results;
	}
}
