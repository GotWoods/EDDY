using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("K2")]
public class K2_AdministrativeMessage : EdiX12Segment
{
	[Position(01)]
	public string FreeFormMessage { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<K2_AdministrativeMessage>(this);
		validator.Required(x=>x.FreeFormMessage);
		validator.Length(x => x.FreeFormMessage, 1, 60);
		return validator.Results;
	}
}
