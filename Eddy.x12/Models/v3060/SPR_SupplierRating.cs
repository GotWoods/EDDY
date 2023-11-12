using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("SPR")]
public class SPR_SupplierRating : EdiX12Segment
{
	[Position(01)]
	public string RatingCategoryCode { get; set; }

	[Position(02)]
	public decimal? MeasurementValue { get; set; }

	[Position(03)]
	public decimal? RangeMinimum { get; set; }

	[Position(04)]
	public decimal? RangeMaximum { get; set; }

	[Position(05)]
	public string RatingSummaryValueCode { get; set; }

	[Position(06)]
	public string Description { get; set; }

	[Position(07)]
	public decimal? MeasurementValue2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SPR_SupplierRating>(this);
		validator.ARequiresB(x=>x.MeasurementValue2, x=>x.RatingCategoryCode);
		validator.Length(x => x.RatingCategoryCode, 2);
		validator.Length(x => x.MeasurementValue, 1, 20);
		validator.Length(x => x.RangeMinimum, 1, 20);
		validator.Length(x => x.RangeMaximum, 1, 20);
		validator.Length(x => x.RatingSummaryValueCode, 1);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.MeasurementValue2, 1, 20);
		return validator.Results;
	}
}
