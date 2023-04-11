using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("LT")]
public class LT_LetterOfRecommendation : EdiX12Segment
{
	[Position(01)]
	public string IndividualRelationshipCode { get; set; }

	[Position(02)]
	public string Description { get; set; }

	[Position(03)]
	public string Name { get; set; }

	[Position(04)]
	public string Description2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LT_LetterOfRecommendation>(this);
		validator.Required(x=>x.IndividualRelationshipCode);
		validator.Length(x => x.IndividualRelationshipCode, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.Description2, 1, 80);
		return validator.Results;
	}
}
