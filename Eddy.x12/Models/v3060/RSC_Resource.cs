using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("RSC")]
public class RSC_Resource : EdiX12Segment
{
	[Position(01)]
	public string ResourceCodeOrIdentifier { get; set; }

	[Position(02)]
	public string Description { get; set; }

	[Position(03)]
	public string ResourceType { get; set; }

	[Position(04)]
	public string ActionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RSC_Resource>(this);
		validator.Required(x=>x.ResourceCodeOrIdentifier);
		validator.Length(x => x.ResourceCodeOrIdentifier, 1, 20);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.ResourceType, 2);
		validator.Length(x => x.ActionCode, 1, 2);
		return validator.Results;
	}
}
