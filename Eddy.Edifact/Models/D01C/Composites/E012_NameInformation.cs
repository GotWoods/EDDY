using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D01C.Composites;

[Segment("E012")]
public class E012_NameInformation : EdifactComponent
{
	[Position(1)]
	public string PartyFunctionCodeQualifier { get; set; }

	[Position(2)]
	public string PartyName { get; set; }

	[Position(3)]
	public string PartyIdentifier { get; set; }

	[Position(4)]
	public string NameStatusCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E012_NameInformation>(this);
		validator.Required(x=>x.PartyFunctionCodeQualifier);
		validator.Length(x => x.PartyFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.PartyIdentifier, 1, 35);
		validator.Length(x => x.NameStatusCode, 1, 3);
		return validator.Results;
	}
}
