using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("APD")]
public class APD_AdditionalTransportDetails : EdifactSegment
{
	[Position(1)]
	public E961_TransportDetails TransportDetails { get; set; }

	[Position(2)]
	public E962_TerminalInformation TerminalInformation { get; set; }

	[Position(3)]
	public E963_DistanceOrTimeDetails DistanceOrTimeDetails { get; set; }

	[Position(4)]
	public E964_TravellerTimeDetails TravellerTimeDetails { get; set; }

	[Position(5)]
	public E965_SpecialTravelFacilities SpecialTravelFacilities { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<APD_AdditionalTransportDetails>(this);
		return validator.Results;
	}
}
