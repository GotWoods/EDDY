using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E032")]
public class E032_PartyIdentification : EdifactComponent
{
	[Position(1)]
	public string PartyIdentifier { get; set; }

	[Position(2)]
	public string PartyFunctionCodeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E032_PartyIdentification>(this);
		validator.Length(x => x.PartyIdentifier, 1, 35);
		validator.Length(x => x.PartyFunctionCodeQualifier, 1, 3);
		return validator.Results;
	}
}
