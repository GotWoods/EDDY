using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("GOR")]
public class GOR_GovernmentalRequirements : EdifactSegment
{
	[Position(1)]
	public string TransportMovementCoded { get; set; }

	[Position(2)]
	public C232_GovernmentAction GovernmentAction { get; set; }

	[Position(3)]
	public C232_GovernmentAction GovernmentAction2 { get; set; }

	[Position(4)]
	public C232_GovernmentAction GovernmentAction3 { get; set; }

	[Position(5)]
	public C232_GovernmentAction GovernmentAction4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GOR_GovernmentalRequirements>(this);
		validator.Length(x => x.TransportMovementCoded, 1, 3);
		return validator.Results;
	}
}
