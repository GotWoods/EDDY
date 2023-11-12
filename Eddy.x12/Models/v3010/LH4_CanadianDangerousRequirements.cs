using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

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
	public string SubsidiaryClassification { get; set; }

	[Position(05)]
	public string SubsidiaryClassification2 { get; set; }

	[Position(06)]
	public string SubsidiaryClassification3 { get; set; }

	[Position(07)]
	public string SubsidiaryRiskIndicator { get; set; }

	[Position(08)]
	public int? NetExplosiveQuantity { get; set; }

	[Position(09)]
	public string CanadianHazardousNotation { get; set; }

	[Position(10)]
	public string SpecialCommodityIndicatorCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LH4_CanadianDangerousRequirements>(this);
		validator.Length(x => x.EmergencyResponsePlanNumber, 1, 12);
		validator.Length(x => x.CommunicationNumber, 7, 21);
		validator.Length(x => x.PackingGroupCode, 1, 3);
		validator.Length(x => x.SubsidiaryClassification, 1, 3);
		validator.Length(x => x.SubsidiaryClassification2, 1, 3);
		validator.Length(x => x.SubsidiaryClassification3, 1, 3);
		validator.Length(x => x.SubsidiaryRiskIndicator, 1, 2);
		validator.Length(x => x.NetExplosiveQuantity, 1, 6);
		validator.Length(x => x.CanadianHazardousNotation, 1, 25);
		validator.Length(x => x.SpecialCommodityIndicatorCode, 1);
		return validator.Results;
	}
}
