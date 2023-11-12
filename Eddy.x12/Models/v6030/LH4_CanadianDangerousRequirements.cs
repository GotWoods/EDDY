using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("LH4")]
public class LH4_CanadianDangerousRequirements : EdiX12Segment
{
	[Position(01)]
	public string EmergencyResponsePlanNumber { get; set; }

	[Position(02)]
	public string CommunicationNumber { get; set; }

	[Position(03)]
	public string PackingGroupCode { get; set; }

	[Position(04)]
	public string SubsidiaryClassificationCode { get; set; }

	[Position(05)]
	public string SubsidiaryClassificationCode2 { get; set; }

	[Position(06)]
	public string SubsidiaryClassificationCode3 { get; set; }

	[Position(07)]
	public string SubsidiaryRiskIndicatorCode { get; set; }

	[Position(08)]
	public int? NetExplosiveQuantity { get; set; }

	[Position(09)]
	public string CanadianHazardousNotation { get; set; }

	[Position(10)]
	public string SpecialCommodityIndicatorCode { get; set; }

	[Position(11)]
	public string CommunicationNumber2 { get; set; }

	[Position(12)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LH4_CanadianDangerousRequirements>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.EmergencyResponsePlanNumber, x=>x.CommunicationNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.NetExplosiveQuantity, x=>x.UnitOrBasisForMeasurementCode);
		validator.Length(x => x.EmergencyResponsePlanNumber, 1, 12);
		validator.Length(x => x.CommunicationNumber, 1, 256);
		validator.Length(x => x.PackingGroupCode, 1, 3);
		validator.Length(x => x.SubsidiaryClassificationCode, 1, 3);
		validator.Length(x => x.SubsidiaryClassificationCode2, 1, 3);
		validator.Length(x => x.SubsidiaryClassificationCode3, 1, 3);
		validator.Length(x => x.SubsidiaryRiskIndicatorCode, 1, 2);
		validator.Length(x => x.NetExplosiveQuantity, 1, 10);
		validator.Length(x => x.CanadianHazardousNotation, 1, 25);
		validator.Length(x => x.SpecialCommodityIndicatorCode, 1);
		validator.Length(x => x.CommunicationNumber2, 1, 256);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		return validator.Results;
	}
}
