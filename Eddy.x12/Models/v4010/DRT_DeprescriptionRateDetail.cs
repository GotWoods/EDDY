using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("DRT")]
public class DRT_DeprescriptionRateDetail : EdiX12Segment
{
	[Position(01)]
	public string LoadEmptyStatusCode { get; set; }

	[Position(02)]
	public string BilledRatedAsQualifier { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public decimal? Percent { get; set; }

	[Position(05)]
	public string ChangeTypeCode { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DRT_DeprescriptionRateDetail>(this);
		validator.ARequiresB(x=>x.MonetaryAmount, x=>x.BilledRatedAsQualifier);
		validator.OnlyOneOf(x=>x.MonetaryAmount, x=>x.Percent);
		validator.ARequiresB(x=>x.Percent, x=>x.BilledRatedAsQualifier);
		validator.Length(x => x.LoadEmptyStatusCode, 1);
		validator.Length(x => x.BilledRatedAsQualifier, 2);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.ChangeTypeCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
