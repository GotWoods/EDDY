using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("TDT")]
public class TDT_DetailsOfTransport : EdifactSegment
{
	[Position(1)]
	public string TransportStageQualifier { get; set; }

	[Position(2)]
	public string ConveyanceReferenceNumber { get; set; }

	[Position(3)]
	public C220_ModeOfTransport ModeOfTransport { get; set; }

	[Position(4)]
	public C228_TransportMeans TransportMeans { get; set; }

	[Position(5)]
	public C040_Carrier Carrier { get; set; }

	[Position(6)]
	public string TransitDirectionCoded { get; set; }

	[Position(7)]
	public C401_ExcessTransportationInformation ExcessTransportationInformation { get; set; }

	[Position(8)]
	public C222_TransportIdentification TransportIdentification { get; set; }

	[Position(9)]
	public string TransportOwnershipCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TDT_DetailsOfTransport>(this);
		validator.Required(x=>x.TransportStageQualifier);
		validator.Length(x => x.TransportStageQualifier, 1, 3);
		validator.Length(x => x.ConveyanceReferenceNumber, 1, 17);
		validator.Length(x => x.TransitDirectionCoded, 1, 3);
		validator.Length(x => x.TransportOwnershipCoded, 1, 3);
		return validator.Results;
	}
}
