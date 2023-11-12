using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("Q2")]
public class Q2_StatusDetailsOcean : EdiX12Segment
{
	[Position(01)]
	public string VesselCode { get; set; }

	[Position(02)]
	public string CountryCode { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string SailingDate { get; set; }

	[Position(05)]
	public string DischargeDate { get; set; }

	[Position(06)]
	public int? LadingQuantity { get; set; }

	[Position(07)]
	public decimal? Weight { get; set; }

	[Position(08)]
	public string WeightQualifier { get; set; }

	[Position(09)]
	public string FlightVoyageNumber { get; set; }

	[Position(10)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(11)]
	public string ReferenceNumber { get; set; }

	[Position(12)]
	public string VesselCodeQualifier { get; set; }

	[Position(13)]
	public string VesselName { get; set; }

	[Position(14)]
	public decimal? Volume { get; set; }

	[Position(15)]
	public string VolumeUnitQualifier { get; set; }

	[Position(16)]
	public string WeightUnitQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<Q2_StatusDetailsOcean>(this);
		validator.ARequiresB(x=>x.ReferenceNumberQualifier, x=>x.ReferenceNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Volume, x=>x.VolumeUnitQualifier);
		validator.Length(x => x.VesselCode, 4, 7);
		validator.Length(x => x.CountryCode, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.SailingDate, 6);
		validator.Length(x => x.DischargeDate, 6);
		validator.Length(x => x.LadingQuantity, 1, 7);
		validator.Length(x => x.Weight, 1, 8);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.FlightVoyageNumber, 2, 10);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.VesselCodeQualifier, 1);
		validator.Length(x => x.VesselName, 2, 28);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.VolumeUnitQualifier, 1);
		validator.Length(x => x.WeightUnitQualifier, 1);
		return validator.Results;
	}
}
