using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

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

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CRI_ClaimReportInformation>(this);
		validator.Required(x=>x.ClaimFilingIndicatorCode);
		validator.Length(x => x.MaintenanceTypeCode, 3);
		validator.Length(x => x.ClaimStatusCode, 1, 2);
		validator.Length(x => x.MaintenanceReasonCode, 2, 3);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.FrequencyCode, 1);
		validator.Length(x => x.ClaimFilingIndicatorCode, 1, 2);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		return validator.Results;
	}
}
