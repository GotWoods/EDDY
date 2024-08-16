using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D98A.Composites;

[Segment("E012")]
public class E012_NameInformation : EdifactComponent
{
	[Position(1)]
	public string PartyQualifier { get; set; }

	[Position(2)]
	public string PartyName { get; set; }

	[Position(3)]
	public string PartyIdentification { get; set; }

	[Position(4)]
	public string NameStatusCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E012_NameInformation>(this);
		validator.Required(x=>x.PartyQualifier);
		validator.Length(x => x.PartyQualifier, 1, 3);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.PartyIdentification, 1, 35);
		validator.Length(x => x.NameStatusCoded, 1, 3);
		return validator.Results;
	}
}
