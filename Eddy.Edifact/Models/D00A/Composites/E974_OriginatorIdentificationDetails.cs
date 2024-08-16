using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E974")]
public class E974_OriginatorIdentificationDetails : EdifactComponent
{
	[Position(1)]
	public string AgentIdentifier { get; set; }

	[Position(2)]
	public string InHouseIdentifier { get; set; }

	[Position(3)]
	public string AgentIdentifier2 { get; set; }

	[Position(4)]
	public string PartyName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E974_OriginatorIdentificationDetails>(this);
		validator.Length(x => x.AgentIdentifier, 1, 9);
		validator.Length(x => x.InHouseIdentifier, 1, 9);
		validator.Length(x => x.AgentIdentifier2, 1, 9);
		validator.Length(x => x.PartyName, 1, 35);
		return validator.Results;
	}
}
