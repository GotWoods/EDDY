using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("SCA")]
public class SCA_StatisticalCategoryAnalysis : EdiX12Segment
{
	[Position(01)]
	public string CodeListQualifierCode { get; set; }

	[Position(02)]
	public string IndustryCode { get; set; }

	[Position(03)]
	public string StatisticCode { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public decimal? Quantity2 { get; set; }

	[Position(06)]
	public decimal? RangeMinimum { get; set; }

	[Position(07)]
	public decimal? RangeMaximum { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SCA_StatisticalCategoryAnalysis>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CodeListQualifierCode, x=>x.IndustryCode);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.StatisticCode, x=>x.Quantity, x=>x.RangeMaximum);
		validator.ARequiresB(x=>x.Quantity2, x=>x.Quantity);
		validator.IfOneIsFilled_AllAreRequired(x=>x.RangeMinimum, x=>x.RangeMaximum);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.StatisticCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.RangeMinimum, 1, 20);
		validator.Length(x => x.RangeMaximum, 1, 20);
		return validator.Results;
	}
}
