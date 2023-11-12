using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("PLB")]
public class PLB_ProviderLevelAdjustment : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumber { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string ReferenceNumber2 { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount { get; set; }

	[Position(05)]
	public string ReferenceNumber3 { get; set; }

	[Position(06)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(07)]
	public string ReferenceNumber4 { get; set; }

	[Position(08)]
	public decimal? MonetaryAmount3 { get; set; }

	[Position(09)]
	public string ReferenceNumber5 { get; set; }

	[Position(10)]
	public decimal? MonetaryAmount4 { get; set; }

	[Position(11)]
	public string ReferenceNumber6 { get; set; }

	[Position(12)]
	public decimal? MonetaryAmount5 { get; set; }

	[Position(13)]
	public string ReferenceNumber7 { get; set; }

	[Position(14)]
	public decimal? MonetaryAmount6 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PLB_ProviderLevelAdjustment>(this);
		validator.Required(x=>x.ReferenceNumber);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.ReferenceNumber2);
		validator.Required(x=>x.MonetaryAmount);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumber3, x=>x.MonetaryAmount2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumber4, x=>x.MonetaryAmount3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumber5, x=>x.MonetaryAmount4);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumber6, x=>x.MonetaryAmount5);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumber7, x=>x.MonetaryAmount6);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.ReferenceNumber3, 1, 30);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.ReferenceNumber4, 1, 30);
		validator.Length(x => x.MonetaryAmount3, 1, 15);
		validator.Length(x => x.ReferenceNumber5, 1, 30);
		validator.Length(x => x.MonetaryAmount4, 1, 15);
		validator.Length(x => x.ReferenceNumber6, 1, 30);
		validator.Length(x => x.MonetaryAmount5, 1, 15);
		validator.Length(x => x.ReferenceNumber7, 1, 30);
		validator.Length(x => x.MonetaryAmount6, 1, 15);
		return validator.Results;
	}
}
