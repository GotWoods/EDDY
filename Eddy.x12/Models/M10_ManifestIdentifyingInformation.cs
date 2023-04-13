using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

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
	public string ReferenceIdentification { get; set; }

	[Position(08)]
	public decimal? Quantity { get; set; }

	[Position(09)]
	public string ManifestTypeCode { get; set; }

	[Position(10)]
	public string VesselCodeQualifier { get; set; }

	[Position(11)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(12)]
	public string ReferenceIdentification2 { get; set; }

	[Position(13)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(14)]
	public string ApplicationTypeCode { get; set; }

	[Position(15)]
	public string AmendmentTypeCode { get; set; }

	[Position(16)]
	public string AmendmentCode { get; set; }

	[Position(17)]
	public string ManifestTypeCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M10_ManifestIdentifyingInformation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.VesselCode, x=>x.VesselCodeQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AmendmentTypeCode, x=>x.AmendmentCode);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.VesselCode, 1, 8);
		validator.Length(x => x.VesselName, 2, 50);
		validator.Length(x => x.FlightVoyageNumber, 2, 30);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.ManifestTypeCode, 1);
		validator.Length(x => x.VesselCodeQualifier, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ApplicationTypeCode, 2);
		validator.Length(x => x.AmendmentTypeCode, 1);
		validator.Length(x => x.AmendmentCode, 2);
		validator.Length(x => x.ManifestTypeCode2, 1);
		return validator.Results;
	}
}
