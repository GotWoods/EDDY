using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E974")]
public class E974_OriginatorIdentificationDetails : EdifactComponent
{
	[Position(1)]
	public string AgentIdentification { get; set; }

	[Position(2)]
	public string InHouseIdentification { get; set; }

	[Position(3)]
	public string AgentIdentification2 { get; set; }

	[Position(4)]
	public string PartyName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E974_OriginatorIdentificationDetails>(this);
		validator.Length(x => x.AgentIdentification, 1, 9);
		validator.Length(x => x.InHouseIdentification, 1, 9);
		validator.Length(x => x.AgentIdentification2, 1, 9);
		validator.Length(x => x.PartyName, 1, 35);
		return validator.Results;
	}
}
