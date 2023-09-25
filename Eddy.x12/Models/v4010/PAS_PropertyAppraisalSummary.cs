using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("PAS")]
public class PAS_PropertyAppraisalSummary : EdiX12Segment
{
	[Position(01)]
	public string PropertyValueEstimateTypeCode { get; set; }

	[Position(02)]
	public string AmountQualifierCode { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(05)]
	public decimal? MonetaryAmount3 { get; set; }

	[Position(06)]
	public string ImprovementStatusCode { get; set; }

	[Position(07)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PAS_PropertyAppraisalSummary>(this);
		validator.Required(x=>x.PropertyValueEstimateTypeCode);
		validator.Required(x=>x.AmountQualifierCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.IfOneIsFilled_AllAreRequired(x=>x.MonetaryAmount2, x=>x.MonetaryAmount3);
		validator.Length(x => x.PropertyValueEstimateTypeCode, 1);
		validator.Length(x => x.AmountQualifierCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		validator.Length(x => x.MonetaryAmount3, 1, 18);
		validator.Length(x => x.ImprovementStatusCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
