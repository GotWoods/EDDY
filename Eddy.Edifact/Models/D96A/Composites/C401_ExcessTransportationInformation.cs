using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C401")]
public class C401_ExcessTransportationInformation : EdifactComponent
{
	[Position(1)]
	public string ExcessTransportationReasonCoded { get; set; }

	[Position(2)]
	public string ExcessTransportationResponsibilityCoded { get; set; }

	[Position(3)]
	public string CustomerAuthorizationNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C401_ExcessTransportationInformation>(this);
		validator.Required(x=>x.ExcessTransportationReasonCoded);
		validator.Required(x=>x.ExcessTransportationResponsibilityCoded);
		validator.Length(x => x.ExcessTransportationReasonCoded, 1, 3);
		validator.Length(x => x.ExcessTransportationResponsibilityCoded, 1, 3);
		validator.Length(x => x.CustomerAuthorizationNumber, 1, 17);
		return validator.Results;
	}
}
