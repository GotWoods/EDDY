using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("VRC")]
public class VRC_VehicleRecovery : EdiX12Segment
{
	[Position(01)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(02)]
	public string DateTimePeriod { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	[Position(04)]
	public string RecoveryConditionCode { get; set; }

	[Position(05)]
	public string RecoveryClassificationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<VRC_VehicleRecovery>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.RecoveryConditionCode, 1, 2);
		validator.Length(x => x.RecoveryClassificationCode, 1, 2);
		return validator.Results;
	}
}
