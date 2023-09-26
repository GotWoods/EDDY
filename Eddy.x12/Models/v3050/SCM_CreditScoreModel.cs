using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("SCM")]
public class SCM_CreditScoreModel : EdiX12Segment
{
	[Position(01)]
	public string ProductServiceID { get; set; }

	[Position(02)]
	public int? Number { get; set; }

	[Position(03)]
	public string EvaluationRatingCode { get; set; }

	[Position(04)]
	public string FreeFormMessage { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SCM_CreditScoreModel>(this);
		validator.Length(x => x.ProductServiceID, 1, 40);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.EvaluationRatingCode, 1);
		validator.Length(x => x.FreeFormMessage, 1, 60);
		return validator.Results;
	}
}
