using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050.Composites;

[Segment("C998")]
public class C998_ContextIdentification : EdiX12Component
{
	[Position(00)]
	public string ContextName { get; set; }

	[Position(01)]
	public string ContextReference { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C998_ContextIdentification>(this);
		validator.Required(x=>x.ContextName);
		validator.Length(x => x.ContextName, 1, 35);
		validator.Length(x => x.ContextReference, 1, 35);
		return validator.Results;
	}
}
