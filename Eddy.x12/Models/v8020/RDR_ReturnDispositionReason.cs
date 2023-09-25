using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v8020;

[Segment("RDR")]
public class RDR_ReturnDispositionReason : EdiX12Segment
{
	[Position(01)]
	public string ReturnsDispositionCode { get; set; }

	[Position(02)]
	public string ReturnRequestReasonCode { get; set; }

	[Position(03)]
	public string ReturnResponseReasonCode { get; set; }

	[Position(04)]
	public string Description { get; set; }

	[Position(05)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RDR_ReturnDispositionReason>(this);
		validator.OnlyOneOf(x=>x.ReturnRequestReasonCode, x=>x.ReturnResponseReasonCode);
		validator.Length(x => x.ReturnsDispositionCode, 2);
		validator.Length(x => x.ReturnRequestReasonCode, 2);
		validator.Length(x => x.ReturnResponseReasonCode, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
