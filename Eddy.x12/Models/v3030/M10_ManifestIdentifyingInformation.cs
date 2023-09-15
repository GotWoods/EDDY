using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("M10")]
public class M10_ManifestIdentifyingInformation : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(03)]
	public string CountryCode { get; set; }

	[Position(04)]
	public string VesselCode { get; set; }

	[Position(05)]
	public string VesselName { get; set; }

	[Position(06)]
	public string FlightVoyageNumber { get; set; }

	[Position(07)]
	public string ReferenceNumber { get; set; }

	[Position(08)]
	public decimal? Quantity { get; set; }

	[Position(09)]
	public string ManifestTypeCode { get; set; }

	[Position(10)]
	public string VesselCodeQualifier { get; set; }

	[Position(11)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M10_ManifestIdentifyingInformation>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.TransportationMethodTypeCode);
		validator.Required(x=>x.CountryCode);
		validator.Required(x=>x.VesselName);
		validator.Required(x=>x.FlightVoyageNumber);
		validator.Required(x=>x.ManifestTypeCode);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.VesselCode, 1, 7);
		validator.Length(x => x.VesselName, 2, 28);
		validator.Length(x => x.FlightVoyageNumber, 2, 10);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.ManifestTypeCode, 1);
		validator.Length(x => x.VesselCodeQualifier, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
