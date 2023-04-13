using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("LTE")]
public class LTE_LetterOfRecommendationEvaluation : EdiX12Segment
{
	[Position(01)]
	public string CodeListQualifierCode { get; set; }

	[Position(02)]
	public string IndustryCode { get; set; }

	[Position(03)]
	public string Description { get; set; }

	[Position(04)]
	public string RatingSummaryValueCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LTE_LetterOfRecommendationEvaluation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CodeListQualifierCode, x=>x.IndustryCode);
		validator.AtLeastOneIsRequired(x=>x.IndustryCode, x=>x.Description);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.RatingSummaryValueCode, 1, 2);
		return validator.Results;
	}
}
