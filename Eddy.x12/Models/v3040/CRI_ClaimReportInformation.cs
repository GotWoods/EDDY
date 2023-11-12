using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

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

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CRI_ClaimReportInformation>(this);
		validator.Length(x => x.MaintenanceTypeCode, 3);
		validator.Length(x => x.ClaimStatusCode, 1, 2);
		validator.Length(x => x.MaintenanceReasonCode, 2, 3);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.FrequencyCode, 1);
		return validator.Results;
	}
}
