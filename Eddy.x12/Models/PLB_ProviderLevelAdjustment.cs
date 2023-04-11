using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("PLB")]
public class PLB_ProviderLevelAdjustment : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentification { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public C042_AdjustmentIdentifier AdjustmentIdentifier { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount { get; set; }

	[Position(05)]
	public C042_AdjustmentIdentifier AdjustmentIdentifier2 { get; set; }

	[Position(06)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(07)]
	public C042_AdjustmentIdentifier AdjustmentIdentifier3 { get; set; }

	[Position(08)]
	public decimal? MonetaryAmount3 { get; set; }

	[Position(09)]
	public C042_AdjustmentIdentifier AdjustmentIdentifier4 { get; set; }

	[Position(10)]
	public decimal? MonetaryAmount4 { get; set; }

	[Position(11)]
	public C042_AdjustmentIdentifier AdjustmentIdentifier5 { get; set; }

	[Position(12)]
	public decimal? MonetaryAmount5 { get; set; }

	[Position(13)]
	public C042_AdjustmentIdentifier AdjustmentIdentifier6 { get; set; }

	[Position(14)]
	public decimal? MonetaryAmount6 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PLB_ProviderLevelAdjustment>(this);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.AdjustmentIdentifier);
		validator.Required(x=>x.MonetaryAmount);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		validator.Length(x => x.MonetaryAmount3, 1, 18);
		validator.Length(x => x.MonetaryAmount4, 1, 18);
		validator.Length(x => x.MonetaryAmount5, 1, 18);
		validator.Length(x => x.MonetaryAmount6, 1, 18);
		return validator.Results;
	}
}
