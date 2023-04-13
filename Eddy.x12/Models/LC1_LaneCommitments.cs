using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("LC1")]
public class LC1_LaneCommitments : EdiX12Segment
{
	[Position(01)]
	public int? NumberOfShipments { get; set; }

	[Position(02)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(03)]
	public int? Number { get; set; }

	[Position(04)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(05)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(06)]
	public int? NumberOfShipments2 { get; set; }

	[Position(07)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(08)]
	public decimal? LaneRanking { get; set; }

	[Position(09)]
	public decimal? FreightRate { get; set; }

	[Position(10)]
	public decimal? FreightRate2 { get; set; }

	[Position(11)]
	public string RateValueQualifier { get; set; }

	[Position(12)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LC1_LaneCommitments>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.NumberOfShipments, x=>x.UnitOrBasisForMeasurementCode);
		validator.ARequiresB(x=>x.FreightRate, x=>x.RateValueQualifier);
		validator.ARequiresB(x=>x.FreightRate2, x=>x.RateValueQualifier);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.RateValueQualifier, x=>x.FreightRate, x=>x.FreightRate2);
		validator.Length(x => x.NumberOfShipments, 1, 5);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.NumberOfShipments2, 1, 5);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.LaneRanking, 1, 4);
		validator.Length(x => x.FreightRate, 1, 15);
		validator.Length(x => x.FreightRate2, 1, 15);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		return validator.Results;
	}
}
