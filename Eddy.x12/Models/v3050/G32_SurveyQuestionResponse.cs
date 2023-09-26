using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("G32")]
public class G32_SurveyQuestionResponse : EdiX12Segment
{
	[Position(01)]
	public int? Number { get; set; }

	[Position(02)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public string Date { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G32_SurveyQuestionResponse>(this);
		validator.Required(x=>x.Number);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.Date, 6);
		return validator.Results;
	}
}
