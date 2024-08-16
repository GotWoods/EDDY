using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D11A.Composites;

namespace Eddy.Edifact.Models.D11A;

[Segment("TDT")]
public class TDT_TransportInformation : EdifactSegment
{
	[Position(1)]
	public string TransportStageCodeQualifier { get; set; }

	[Position(2)]
	public string MeansOfTransportJourneyIdentifier { get; set; }

	[Position(3)]
	public C220_ModeOfTransport ModeOfTransport { get; set; }

	[Position(4)]
	public C001_TransportMeans TransportMeans { get; set; }

	[Position(5)]
	public C040_Carrier Carrier { get; set; }

	[Position(6)]
	public string TransitDirectionIndicatorCode { get; set; }

	[Position(7)]
	public C401_ExcessTransportationInformation ExcessTransportationInformation { get; set; }

	[Position(8)]
	public C222_TransportIdentification TransportIdentification { get; set; }

	[Position(9)]
	public string TransportMeansOwnershipIndicatorCode { get; set; }

	[Position(10)]
	public C003_PowerType PowerType { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TDT_TransportInformation>(this);
		validator.Required(x=>x.TransportStageCodeQualifier);
		validator.Length(x => x.TransportStageCodeQualifier, 1, 3);
		validator.Length(x => x.MeansOfTransportJourneyIdentifier, 1, 17);
		validator.Length(x => x.TransitDirectionIndicatorCode, 1, 3);
		validator.Length(x => x.TransportMeansOwnershipIndicatorCode, 1, 3);
		return validator.Results;
	}
}
