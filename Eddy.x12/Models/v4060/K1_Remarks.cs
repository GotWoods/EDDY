using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4060;

[Segment("K1")]
public class K1_Remarks : EdiX12Segment
{
	[Position(01)]
	public string FreeFormInformation { get; set; }

	[Position(02)]
	public string FreeFormInformation2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<K1_Remarks>(this);
		validator.Required(x=>x.FreeFormInformation);
		validator.Length(x => x.FreeFormInformation, 1, 30);
		validator.Length(x => x.FreeFormInformation2, 1, 30);
		return validator.Results;
	}
}
