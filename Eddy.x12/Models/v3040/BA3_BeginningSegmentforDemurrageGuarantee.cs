using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("BA3")]
public class BA3_BeginningSegmentForDemurrageGuarantee : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string VesselCode { get; set; }

	[Position(03)]
	public string FlightVoyageNumber { get; set; }

	[Position(04)]
	public string ReferenceNumber { get; set; }

	[Position(05)]
	public string ReferenceNumber2 { get; set; }

	[Position(06)]
	public string PierNumber { get; set; }

	[Position(07)]
	public string PierName { get; set; }

	[Position(08)]
	public string PortFunctionCode { get; set; }

	[Position(09)]
	public string PortName { get; set; }

	[Position(10)]
	public string LocationIdentifier { get; set; }

	[Position(11)]
	public string ArrivalDate { get; set; }

	[Position(12)]
	public string VesselCodeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BA3_BeginningSegmentForDemurrageGuarantee>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.VesselCode);
		validator.Required(x=>x.FlightVoyageNumber);
		validator.Required(x=>x.ReferenceNumber);
		validator.Required(x=>x.ReferenceNumber2);
		validator.Required(x=>x.PierNumber);
		validator.Required(x=>x.PierName);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.VesselCode, 1, 7);
		validator.Length(x => x.FlightVoyageNumber, 2, 10);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.PierNumber, 1, 4);
		validator.Length(x => x.PierName, 2, 14);
		validator.Length(x => x.PortFunctionCode, 1);
		validator.Length(x => x.PortName, 2, 24);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.ArrivalDate, 6);
		validator.Length(x => x.VesselCodeQualifier, 1);
		return validator.Results;
	}
}
