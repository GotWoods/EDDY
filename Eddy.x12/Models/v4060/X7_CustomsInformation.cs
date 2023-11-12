using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4060;

[Segment("X7")]
public class X7_CustomsInformation : EdiX12Segment
{
	[Position(01)]
	public string FreeFormInformation { get; set; }

	[Position(02)]
	public string FreeFormInformation2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<X7_CustomsInformation>(this);
		validator.Required(x=>x.FreeFormInformation);
		validator.Length(x => x.FreeFormInformation, 1, 30);
		validator.Length(x => x.FreeFormInformation2, 1, 30);
		return validator.Results;
	}
}
