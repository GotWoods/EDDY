using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("AD1")]
public class AD1_AdjustmentAmount : EdiX12Segment
{
	[Position(01)]
	public string AdjustmentReasonCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public string AdjustmentReasonCodeCharacteristic { get; set; }

	[Position(04)]
	public string FrequencyCode { get; set; }

	[Position(05)]
	public string LateReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AD1_AdjustmentAmount>(this);
		validator.Required(x=>x.AdjustmentReasonCode);
		validator.Length(x => x.AdjustmentReasonCode, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.AdjustmentReasonCodeCharacteristic, 1, 2);
		validator.Length(x => x.FrequencyCode, 1);
		validator.Length(x => x.LateReasonCode, 2);
		return validator.Results;
	}
}
