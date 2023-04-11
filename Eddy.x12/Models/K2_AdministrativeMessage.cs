using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("K2")]
public class K2_AdministrativeMessage : EdiX12Segment
{
	[Position(01)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<K2_AdministrativeMessage>(this);
		validator.Required(x=>x.Description);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
