using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("X01")]
public class X01_AutomatedManifestArchiveStatusDetails : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string LocationQualifier { get; set; }

	[Position(03)]
	public string LocationIdentifier { get; set; }

	[Position(04)]
	public string VesselCodeQualifier { get; set; }

	[Position(05)]
	public string VesselCode { get; set; }

	[Position(06)]
	public string VesselName { get; set; }

	[Position(07)]
	public string FlightVoyageNumber { get; set; }

	[Position(08)]
	public string DateTimeQualifier { get; set; }

	[Position(09)]
	public string Date { get; set; }

	[Position(10)]
	public decimal? Quantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<X01_AutomatedManifestArchiveStatusDetails>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.LocationQualifier);
		validator.Required(x=>x.LocationIdentifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.VesselCodeQualifier, x=>x.VesselCode);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.LocationIdentifier, 1, 25);
		validator.Length(x => x.VesselCodeQualifier, 1);
		validator.Length(x => x.VesselCode, 1, 7);
		validator.Length(x => x.VesselName, 2, 28);
		validator.Length(x => x.FlightVoyageNumber, 2, 10);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Quantity, 1, 15);
		return validator.Results;
	}
}
