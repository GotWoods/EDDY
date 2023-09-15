using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("DIS")]
public class DIS_DiscountDetail : EdiX12Segment
{
	[Position(01)]
	public string DiscountTermsTypeCode { get; set; }

	[Position(02)]
	public string DiscountBaseQualifier { get; set; }

	[Position(03)]
	public decimal? DiscountBaseValue { get; set; }

	[Position(04)]
	public string DiscountControlLimitQualifier { get; set; }

	[Position(05)]
	public int? LowerDiscountControlLimit { get; set; }

	[Position(06)]
	public int? UpperDiscountControlLimit { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DIS_DiscountDetail>(this);
		validator.Required(x=>x.DiscountTermsTypeCode);
		validator.Required(x=>x.DiscountBaseQualifier);
		validator.Required(x=>x.DiscountBaseValue);
		validator.Required(x=>x.DiscountControlLimitQualifier);
		validator.Required(x=>x.LowerDiscountControlLimit);
		validator.Length(x => x.DiscountTermsTypeCode, 3);
		validator.Length(x => x.DiscountBaseQualifier, 2);
		validator.Length(x => x.DiscountBaseValue, 1, 10);
		validator.Length(x => x.DiscountControlLimitQualifier, 2, 3);
		validator.Length(x => x.LowerDiscountControlLimit, 1, 10);
		validator.Length(x => x.UpperDiscountControlLimit, 1, 10);
		return validator.Results;
	}
}
