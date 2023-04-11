using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("BBC")]
public class BBC_LegalClaims : EdiX12Segment 
{
	[Position(01)]
	public string ClaimTypeCode { get; set; }

	[Position(02)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BBC_LegalClaims>(this);
		validator.Required(x=>x.ClaimTypeCode);
		validator.Length(x => x.ClaimTypeCode, 1, 2);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
