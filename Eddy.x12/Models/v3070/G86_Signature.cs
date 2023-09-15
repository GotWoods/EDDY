using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("G86")]
public class G86_Signature : EdiX12Segment
{
	[Position(01)]
	public string Signature { get; set; }

	[Position(02)]
	public string Name { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G86_Signature>(this);
		validator.Length(x => x.Signature, 1, 12);
		validator.Length(x => x.Name, 1, 60);
		return validator.Results;
	}
}
