using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("K1")]
public class K1_Remarks : EdiX12Segment
{
	[Position(01)]
	public string FreeFormMessage { get; set; }

	[Position(02)]
	public string FreeFormMessage2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<K1_Remarks>(this);
		validator.Required(x=>x.FreeFormMessage);
		validator.Length(x => x.FreeFormMessage, 1, 30);
		validator.Length(x => x.FreeFormMessage2, 1, 30);
		return validator.Results;
	}
}
