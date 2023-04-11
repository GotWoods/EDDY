using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("REL")]
public class REL_Relationship : EdiX12Segment
{
	[Position(01)]
	public string IndividualRelationshipCode { get; set; }

	[Position(02)]
	public int? Number { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<REL_Relationship>(this);
		validator.Required(x=>x.IndividualRelationshipCode);
		validator.Length(x => x.IndividualRelationshipCode, 2);
		validator.Length(x => x.Number, 1, 9);
		return validator.Results;
	}
}
