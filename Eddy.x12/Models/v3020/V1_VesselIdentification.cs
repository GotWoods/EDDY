using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("V1")]
public class V1_VesselIdentification : EdiX12Segment
{
	[Position(01)]
	public string VesselCode { get; set; }

	[Position(02)]
	public string VesselName { get; set; }

	[Position(03)]
	public string CountryCode { get; set; }

	[Position(04)]
	public string FlightVoyageNumber { get; set; }

	[Position(05)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(06)]
	public string VesselRequirementCode { get; set; }

	[Position(07)]
	public string VesselTypeCode { get; set; }

	[Position(08)]
	public string VesselCodeQualifier { get; set; }

	[Position(09)]
	public string TransportationMethodTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<V1_VesselIdentification>(this);
		validator.AtLeastOneIsRequired(x=>x.VesselCode, x=>x.VesselName);
		validator.Length(x => x.VesselCode, 4, 7);
		validator.Length(x => x.VesselName, 2, 28);
		validator.Length(x => x.CountryCode, 2);
		validator.Length(x => x.FlightVoyageNumber, 2, 10);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.VesselRequirementCode, 1);
		validator.Length(x => x.VesselTypeCode, 2);
		validator.Length(x => x.VesselCodeQualifier, 1);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		return validator.Results;
	}
}
