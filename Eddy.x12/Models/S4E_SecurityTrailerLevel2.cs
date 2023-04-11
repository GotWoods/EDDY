using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("S4E")]
public class S4E_SecurityTrailerLevel2 : EdiX12Segment
{
	[Position(01)]
	public string HashOrAuthenticationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S4E_SecurityTrailerLevel2>(this);
		validator.Required(x=>x.HashOrAuthenticationCode);
		validator.Length(x => x.HashOrAuthenticationCode, 1, 64);
		return validator.Results;
	}
}
