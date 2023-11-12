using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("ES")]
public class ES_EquipmentStatus : EdiX12Segment
{
	[Position(01)]
	public string BadOrderReasonCode { get; set; }

	[Position(02)]
	public string HoldReasonCode { get; set; }

	[Position(03)]
	public string AssociationOfAmericanRailroadsCarGradeCode { get; set; }

	[Position(04)]
	public string TimePeriodUnitQualifier { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	[Position(06)]
	public string SwitchTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ES_EquipmentStatus>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TimePeriodUnitQualifier, x=>x.Quantity);
		validator.Length(x => x.BadOrderReasonCode, 1);
		validator.Length(x => x.HoldReasonCode, 2);
		validator.Length(x => x.AssociationOfAmericanRailroadsCarGradeCode, 1);
		validator.Length(x => x.TimePeriodUnitQualifier, 1);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.SwitchTypeCode, 2);
		return validator.Results;
	}
}
