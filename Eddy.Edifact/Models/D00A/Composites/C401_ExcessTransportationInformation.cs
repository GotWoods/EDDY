using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C401")]
public class C401_ExcessTransportationInformation : EdifactComponent
{
	[Position(1)]
	public string ExcessTransportationReasonCode { get; set; }

	[Position(2)]
	public string ExcessTransportationResponsibilityCode { get; set; }

	[Position(3)]
	public string CustomerShipmentAuthorisationIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C401_ExcessTransportationInformation>(this);
		validator.Required(x=>x.ExcessTransportationReasonCode);
		validator.Required(x=>x.ExcessTransportationResponsibilityCode);
		validator.Length(x => x.ExcessTransportationReasonCode, 1, 3);
		validator.Length(x => x.ExcessTransportationResponsibilityCode, 1, 3);
		validator.Length(x => x.CustomerShipmentAuthorisationIdentifier, 1, 17);
		return validator.Results;
	}
}
