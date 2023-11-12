using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("X7")]
public class X7_CustomsInformation : EdiX12Segment
{
	[Position(01)]
	public string FreeFormMessage { get; set; }

	[Position(02)]
	public string FreeFormMessage2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<X7_CustomsInformation>(this);
		validator.Required(x=>x.FreeFormMessage);
		validator.Length(x => x.FreeFormMessage, 1, 30);
		validator.Length(x => x.FreeFormMessage2, 1, 30);
		return validator.Results;
	}
}
