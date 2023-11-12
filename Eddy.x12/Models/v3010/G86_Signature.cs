using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G86")]
public class G86_Signature : EdiX12Segment
{
	[Position(01)]
	public string Signature { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G86_Signature>(this);
		validator.Required(x=>x.Signature);
		validator.Length(x => x.Signature, 1, 12);
		return validator.Results;
	}
}
