using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

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
	public string TimePeriodQualifier { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ES_EquipmentStatus>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TimePeriodQualifier, x=>x.Quantity);
		validator.Length(x => x.BadOrderReasonCode, 1);
		validator.Length(x => x.HoldReasonCode, 2);
		validator.Length(x => x.AssociationOfAmericanRailroadsCarGradeCode, 1);
		validator.Length(x => x.TimePeriodQualifier, 1);
		validator.Length(x => x.Quantity, 1, 15);
		return validator.Results;
	}
}
