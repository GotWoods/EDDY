using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("TSR")]
public class TSR_TransportServiceRequirements : EdifactSegment
{
	[Position(1)]
	public C536_ContractAndCarriageCondition ContractAndCarriageCondition { get; set; }

	[Position(2)]
	public C233_Service Service { get; set; }

	[Position(3)]
	public C537_TransportPriority TransportPriority { get; set; }

	[Position(4)]
	public C703_NatureOfCargo NatureOfCargo { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TSR_TransportServiceRequirements>(this);
		return validator.Results;
	}
}
