using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("N2")]
public class N2_AdditionalNameInformation : EdiX12Segment
{
	[Position(01)]
	public string Name { get; set; }

	[Position(02)]
	public string Name2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<N2_AdditionalNameInformation>(this);
		validator.Required(x=>x.Name);
		validator.Length(x => x.Name, 1, 35);
		validator.Length(x => x.Name2, 1, 35);
		return validator.Results;
	}
}
