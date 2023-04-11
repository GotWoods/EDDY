using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("CRI")]
public class CRI_ClaimReportInformation : EdiX12Segment
{
	[Position(01)]
	public string MaintenanceTypeCode { get; set; }

	[Position(02)]
	public string ClaimStatusCode { get; set; }

	[Position(03)]
	public string MaintenanceReasonCode { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(05)]
	public string FrequencyCode { get; set; }

	[Position(06)]
	public string ClaimFilingIndicatorCode { get; set; }

	[Position(07)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(08)]
	public string DateTimePeriod { get; set; }

	[Position(09)]
	public string AdjustmentReasonCodeCharacteristic { get; set; }

	[Position(10)]
	public string LateReasonCode { get; set; }

	[Position(11)]
	public string ConditionIndicatorCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CRI_ClaimReportInformation>(this);
		validator.Required(x=>x.ClaimFilingIndicatorCode);
		validator.ARequiresB(x=>x.AdjustmentReasonCodeCharacteristic, x=>x.MaintenanceTypeCode);
		validator.ARequiresB(x=>x.LateReasonCode, x=>x.MaintenanceTypeCode);
		validator.Length(x => x.MaintenanceTypeCode, 3);
		validator.Length(x => x.ClaimStatusCode, 1, 2);
		validator.Length(x => x.MaintenanceReasonCode, 2, 3);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.FrequencyCode, 1);
		validator.Length(x => x.ClaimFilingIndicatorCode, 1, 2);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.AdjustmentReasonCodeCharacteristic, 1, 2);
		validator.Length(x => x.LateReasonCode, 2);
		validator.Length(x => x.ConditionIndicatorCode, 2, 3);
		return validator.Results;
	}
}
