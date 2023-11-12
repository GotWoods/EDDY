using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030.Composites;

[Segment("C042")]
public class C042_AdjustmentIdentifier : EdiX12Component
{
	[Position(00)]
	public string AdjustmentReasonCode { get; set; }

	[Position(01)]
	public string ReferenceIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C042_AdjustmentIdentifier>(this);
		validator.Required(x=>x.AdjustmentReasonCode);
		validator.Length(x => x.AdjustmentReasonCode, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		return validator.Results;
	}
}
