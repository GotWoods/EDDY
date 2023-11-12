using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("S1E")]
public class S1E_SecurityTrailerLevel1 : EdiX12Segment
{
	[Position(01)]
	public string MessageAuthenticationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S1E_SecurityTrailerLevel1>(this);
		validator.Required(x=>x.MessageAuthenticationCode);
		validator.Length(x => x.MessageAuthenticationCode, 9);
		return validator.Results;
	}
}
