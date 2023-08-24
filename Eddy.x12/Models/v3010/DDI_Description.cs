using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("DDI")]
public class DDI_Description : EdiX12Segment
{
	[Position(01)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DDI_Description>(this);
		validator.Required(x=>x.Description);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
