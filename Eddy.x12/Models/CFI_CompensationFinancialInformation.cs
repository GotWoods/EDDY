using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("CFI")]
public class CFI_CompensationFinancialInformation : EdiX12Segment
{
	[Position(01)]
	public string CodeCategory { get; set; }

	[Position(02)]
	public string AdjustmentReasonCode { get; set; }

	[Position(03)]
	public string AdjustmentReasonCodeCharacteristic { get; set; }

	[Position(04)]
	public string MaintenanceTypeCode { get; set; }

	[Position(05)]
	public string FrequencyCode { get; set; }

	[Position(06)]
	public string SettlementTypeCode { get; set; }

	[Position(07)]
	public string LateReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CFI_CompensationFinancialInformation>(this);
		validator.Required(x=>x.CodeCategory);
		validator.Length(x => x.CodeCategory, 2);
		validator.Length(x => x.AdjustmentReasonCode, 2);
		validator.Length(x => x.AdjustmentReasonCodeCharacteristic, 1, 2);
		validator.Length(x => x.MaintenanceTypeCode, 3);
		validator.Length(x => x.FrequencyCode, 1);
		validator.Length(x => x.SettlementTypeCode, 1, 2);
		validator.Length(x => x.LateReasonCode, 2);
		return validator.Results;
	}
}
